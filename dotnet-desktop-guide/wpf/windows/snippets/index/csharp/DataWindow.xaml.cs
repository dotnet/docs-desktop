using System.Windows;
using System.Windows.Controls;

namespace WindowsOverview
{
    public partial class DataWindow : Window
    {
        private bool _isDataDirty;

        public DataWindow() =>
            InitializeComponent();

        private void documentTextBox_TextChanged(object sender, TextChangedEventArgs e) =>
            _isDataDirty = true;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If data is dirty, prompt user and ask for a response
            if (_isDataDirty)
            {
                var result = MessageBox.Show("Document has changed. Close without saving?",
                                             "Question",
                                             MessageBoxButton.YesNo);

                // User doesn't want to close, cancel closure
                if (result == MessageBoxResult.No)
                    e.Cancel = true;
            }
        }
    }
}
