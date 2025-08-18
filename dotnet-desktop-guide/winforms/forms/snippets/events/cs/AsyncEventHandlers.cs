using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncEventHandlersExample
{
    public partial class ExampleForm : Form
    {
        private Button downloadButton;
        private Button processButton;
        private Button complexButton;
        private Button badButton;
        private TextBox resultTextBox;
        private Label statusLabel;
        private ProgressBar progressBar;

        // <snippet_BasicAsyncEventHandler>
        private async void downloadButton_Click(object sender, EventArgs e)
        {
            downloadButton.Enabled = false;
            statusLabel.Text = "Downloading...";
            
            try
            {
                using var httpClient = new HttpClient();
                string content = await httpClient.GetStringAsync("https://api.example.com/data");
                
                // Update UI with the result
                resultTextBox.Text = content;
                statusLabel.Text = "Download complete";
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error: {ex.Message}";
            }
            finally
            {
                downloadButton.Enabled = true;
            }
        }
        // </snippet_BasicAsyncEventHandler>

        // <snippet_DeadlockAntiPattern>
        // DON'T DO THIS - causes deadlocks
        private void badButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var httpClient = new HttpClient();
                // This blocks the UI thread and causes a deadlock
                string content = httpClient.GetStringAsync("https://api.example.com/data").GetAwaiter().GetResult();
                resultTextBox.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // </snippet_DeadlockAntiPattern>

        // <snippet_InvokeAsyncNet9>
        private async void processButton_Click(object sender, EventArgs e)
        {
            processButton.Enabled = false;
            
            // Start background work
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    // Simulate work
                    await Task.Delay(200);
                    
                    // Create local variable to avoid closure issues
                    int currentProgress = i;
                    
                    // Update UI safely from background thread
                    await progressBar.InvokeAsync(() =>
                    {
                        progressBar.Value = currentProgress;
                        statusLabel.Text = $"Progress: {currentProgress}%";
                    });
                }
            });
            
            processButton.Enabled = true;
        }
        // </snippet_InvokeAsyncNet9>

        // <snippet_InvokeAsyncUIThread>
        private async void complexButton_Click(object sender, EventArgs e)
        {
            await this.InvokeAsync(async (cancellationToken) =>
            {
                // This runs on UI thread but doesn't block it
                statusLabel.Text = "Starting complex operation...";
                
                var result = await SomeAsyncApiCall();
                
                // Update UI directly since we're already on UI thread
                resultTextBox.Text = result;
                statusLabel.Text = "Operation completed";
            });
        }

        private async Task<string> SomeAsyncApiCall()
        {
            using var httpClient = new HttpClient();
            return await httpClient.GetStringAsync("https://api.example.com/data");
        }
        // </snippet_InvokeAsyncUIThread>

        // <snippet_LegacyNetFramework>
        private async void legacyButton_Click(object sender, EventArgs e)
        {
            var legacyButton = sender as Button;
            legacyButton.Enabled = false;
            
            try
            {
                // Move to background thread to avoid blocking UI
                await Task.Run(async () =>
                {
                    var result = await SomeAsyncOperation();
                    
                    // Marshal back to UI thread
                    this.Invoke(new Action(() =>
                    {
                        resultTextBox.Text = result;
                        statusLabel.Text = "Complete";
                    }));
                });
            }
            finally
            {
                // This runs on the UI thread since the await completed
                legacyButton.Enabled = true;
            }
        }

        private async Task<string> SomeAsyncOperation()
        {
            using var httpClient = new HttpClient();
            return await httpClient.GetStringAsync("https://api.example.com/data");
        }
        // </snippet_LegacyNetFramework>
    }
}
