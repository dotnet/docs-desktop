using System;
using System.Net.Http;
using System.Threading; // Added for CancellationToken
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project;

public partial class InvokeAsyncForm : Form
{
    private Button button1;
    private Button button2;
    private TextBox textBox1;

    public InvokeAsyncForm()
    {
        button1 = new Button { Text = "Invoke Async Basic", Location = new System.Drawing.Point(10, 10), Width = 200 };
        button2 = new Button { Text = "Invoke Async Advanced", Location = new System.Drawing.Point(10, 50), Width = 200 };
        textBox1 = new TextBox { Location = new System.Drawing.Point(10, 90), Width = 200, Multiline = true, Height =500 };
        button1.Click += button1_Click;
        button2.Click += button2_Click;
        Controls.Add(button1);
        Controls.Add(button2);
        Controls.Add(textBox1);
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
                    await textBox1.InvokeAsync(() =>
                    {
                        textBox1.Text = $"Progress: {currentProgress}%";
                    });
                }
            });
            
            // Update UI after completion
            await textBox1.InvokeAsync(() =>
            {
                textBox1.Text = "Operation completed!";
            });
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
            await this.InvokeAsync(async (cancellationToken) =>
            {
                // This runs on UI thread but doesn't block it
                textBox1.Text = "Starting operation...";
                
                try
                {
                    // Perform async work on UI thread
                    var result = await SomeAsyncApiCall(cancellationToken);
                    
                    // Update UI directly since we're on UI thread
                    textBox1.Text = $"Result: {result}";
                }
                catch (OperationCanceledException)
                {
                    textBox1.Text = "Operation canceled.";
                }
                catch (Exception ex)
                {
                    textBox1.Text = $"Error: {ex.Message}";
                }
            });
        }
        finally
        {
            button2.Enabled = true;
        }
    }

    private async Task<string> SomeAsyncApiCall(CancellationToken cancellationToken)
    {
        using var client = new HttpClient();
        await Task.Delay(2000, cancellationToken); // Simulate network delay
        return await client.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md", cancellationToken);
    }
    // </snippet_InvokeAsyncAdvanced>
}
