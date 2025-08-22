using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project;

public partial class FormInvokeAsync : Form
{
    private Button button1;
    private Button button2;
    private TextBox loggingTextBox;

    public FormInvokeAsync()
    {
        button1 = new Button { Text = "Invoke Async Basic", Location = new System.Drawing.Point(10, 10), Width = 200 };
        button2 = new Button { Text = "Invoke Async Advanced", Location = new System.Drawing.Point(10, 50), Width = 200 };
        loggingTextBox = new TextBox { Location = new System.Drawing.Point(10, 90), Width = 300, Multiline = true, Height =500 };
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        Controls.Add(button1);
        Controls.Add(button2);
        Controls.Add(loggingTextBox);
    }

    // <snippet_InvokeAsyncBasic>
    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        
        try
        {
            // Perform background work
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    // Simulate work
                    await Task.Delay(100);
                    
                    // Create local variable to avoid closure issues
                    int currentProgress = i;
                    
                    // Update UI safely from background thread
                    await loggingTextBox.InvokeAsync(() =>
                    {
                        loggingTextBox.Text = $"Progress: {currentProgress}%";
                    });
                }
            });

            loggingTextBox.Text = "Operation completed!";
        }
        finally
        {
            button1.Enabled = true;
        }
    }
    // </snippet_InvokeAsyncBasic>

    // <snippet_InvokeAsyncAdvanced>
    private async void button2_Click(object sender, EventArgs e)
    {
        button2.Enabled = false;
        try
        {
            loggingTextBox.Text = "Starting operation...";

            // Dispatch and run on a new thread, but wait for tasks to finish
            // Exceptions are rethrown here, because await is used
            await Task.WhenAll(Task.Run(SomeApiCallAsync),
                               Task.Run(SomeApiCallAsync),
                               Task.Run(SomeApiCallAsync));

            // Dispatch and run on a new thread, but don't wait for task to finish
            // Exceptions are not rethrown here, because await is not used
            _ = Task.Run(SomeApiCallAsync);
        }
        catch (OperationCanceledException)
        {
            loggingTextBox.Text += "Operation canceled.";
        }
        catch (Exception ex)
        {
            loggingTextBox.Text += $"Error: {ex.Message}";
        }
        finally
        {
            button2.Enabled = true;
        }
    }

    private async Task SomeApiCallAsync()
    {
        using var client = new HttpClient();
        
        // Simulate random network delay
        await Task.Delay(Random.Shared.Next(500, 2500));

        // Do I/O asynchronously
        string result = await client.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md");

        // Marshal back to UI thread
        await this.InvokeAsync(async (cancelToken) =>
        {
            loggingTextBox.Text += $"{Environment.NewLine}Operation finished at: {DateTime.Now:HH:mm:ss.fff}";
        });

        // Do more async I/O ...
    }
    // </snippet_InvokeAsyncAdvanced>
}
