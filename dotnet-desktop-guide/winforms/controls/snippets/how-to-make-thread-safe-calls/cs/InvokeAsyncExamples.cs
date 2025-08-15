using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafeCallsExample
{
    public partial class InvokeAsyncForm : Form
    {
        private Button button1;
        private Button button2;
        private TextBox textBox1;

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
                        
                        // Update UI safely from background thread
                        await textBox1.InvokeAsync(() =>
                        {
                            textBox1.Text = $"Progress: {i}%";
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
            await this.InvokeAsync(async (cancellationToken) =>
            {
                // This runs on UI thread but doesn't block it
                textBox1.Text = "Starting operation...";
                
                // Perform async work on UI thread
                var result = await SomeAsyncApiCall();
                
                // Update UI directly since we're on UI thread
                textBox1.Text = $"Result: {result}";
            });
        }

        private async Task<string> SomeAsyncApiCall()
        {
            using var client = new HttpClient();
            return await client.GetStringAsync("https://api.example.com/data");
        }
        // </snippet_InvokeAsyncAdvanced>
    }
}
