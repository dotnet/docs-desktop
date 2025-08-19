using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncEventHandlers;

public partial class ExampleForm : Form
{
    private Button downloadButton;
    private Button processButton;
    private Button complexButton;
    private Button badButton;
    private TextBox resultTextBox;
    private Label statusLabel;
    private ProgressBar progressBar;

    public ExampleForm()
    {
        Size = new System.Drawing.Size(400, 600);
        downloadButton = new Button { Text = "Download Data" };
        processButton = new Button { Text = "Process Data" };
        complexButton = new Button { Text = "Complex Operation" };
        badButton = new Button { Text = "Bad Example (Deadlock)" };
        resultTextBox = new TextBox { Multiline = true, Width = 300, Height = 200 };
        statusLabel = new Label { Text = "Status: Ready" };
        progressBar = new ProgressBar { Width = 300 };
        downloadButton.Click += downloadButton_Click;
        processButton.Click += processButton_Click;
        complexButton.Click += complexButton_Click;
        badButton.Click += badButton_Click;

        // Arrange controls
        int margin = 20;
        int spacing = 10;

        // Buttons stacked vertically.
        downloadButton.Location = new System.Drawing.Point(margin, margin);
        downloadButton.Width = 300;

        processButton.Location = new System.Drawing.Point(margin, downloadButton.Bottom + spacing);
        processButton.Width = downloadButton.Width;

        complexButton.Location = new System.Drawing.Point(margin, processButton.Bottom + spacing);
        complexButton.Width = downloadButton.Width;

        badButton.Location = new System.Drawing.Point(margin, complexButton.Bottom + spacing);
        badButton.Width = downloadButton.Width;

        // Status and progress below buttons.
        statusLabel.AutoSize = true;
        statusLabel.Location = new System.Drawing.Point(margin, badButton.Bottom + spacing);

        progressBar.Location = new System.Drawing.Point(margin, statusLabel.Bottom + spacing);
        progressBar.Width = downloadButton.Width;

        // Result text box below progress bar.
        resultTextBox.Location = new System.Drawing.Point(margin, progressBar.Bottom + spacing);


        Controls.Add(downloadButton);
        Controls.Add(processButton);
        Controls.Add(complexButton);
        Controls.Add(badButton);
        Controls.Add(resultTextBox);
        Controls.Add(statusLabel);
        Controls.Add(progressBar);
    }

    // <snippet_BasicAsyncEventHandler>
    private async void downloadButton_Click(object sender, EventArgs e)
    {
        downloadButton.Enabled = false;
        statusLabel.Text = "Downloading...";
        
        try
        {
            using var httpClient = new HttpClient();
            string content = await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md");
            
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
            // This blocks the UI thread and causes a deadlock
            string content = DownloadPageContentAsync().GetAwaiter().GetResult();
            resultTextBox.Text = content;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private async Task<string> DownloadPageContentAsync()
    {
        using var httpClient = new HttpClient();
        await Task.Delay(2000); // Simulate delay
        return await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md");
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
        return await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md");
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
        await Task.Delay(2000); // Simulate delay
        return await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md");
    }
    // </snippet_LegacyNetFramework>
}
