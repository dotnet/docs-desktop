using System.Windows;

namespace WindowsOverview
{
    public partial class ClosingWindow : Window
    {
        public ClosingWindow() =>
            InitializeComponent();

        private void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window
            this.Close();
        }
    }
}
