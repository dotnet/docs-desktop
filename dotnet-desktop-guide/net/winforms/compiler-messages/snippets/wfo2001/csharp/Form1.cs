namespace ExampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <Async>
        CancellationTokenSource _stopWatchTokenSource = new();
        CancellationToken _stopWatchToken;

        private async void btnStopWatch_Click(object sender, EventArgs e)
        {
            if (_stopWatchToken.CanBeCanceled)
            {
                btnStopWatch.Text = "Start";
                _stopWatchTokenSource.Cancel();
                _stopWatchTokenSource.Dispose();
                _stopWatchTokenSource = new CancellationTokenSource();
                _stopWatchToken = CancellationToken.None;

                return;
            }

            _stopWatchToken = _stopWatchTokenSource.Token;
            btnStopWatch.Text = "Stop";

            await Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        await this.InvokeAsync(UpdateUiAsync, _stopWatchToken);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            });

            // ****
            // The actual UI update method
            // ****
            async ValueTask UpdateUiAsync(CancellationToken cancellation)
            {
                lblStopWatch.Text = $"{DateTime.Now:HH:mm:ss - fff}";
                await Task.Delay(20, cancellation);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _stopWatchTokenSource.Cancel();
        }
        // </Async>
    }
}
