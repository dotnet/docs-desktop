using System.Windows;

namespace Dialogs
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void formatMarginsButton_Click(object sender, RoutedEventArgs e)
        {
            Method2();

        }

        // <DialogResultButtons>
        private void okButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = true;

        private void cancelButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;
        // </DialogResultButtons>

        private void Method()
        {
            // <HandleClosing>
            var marginsWindow = new Margins();

            marginsWindow.Closed += (sender, eventArgs) =>
            {
                MessageBox.Show($"You closed the margins window! It had the title of {marginsWindow.Title}");
            };

            marginsWindow.Show();
            // </HandleClosing>
        }

        private void Method2()
        {
            // <HandleDialogResponse>
            var dialog = new Margins();

            // Display the dialog box and read the response
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                // User accepted the dialog box
                MessageBox.Show("Your request will be processed.");
            }
            else
            {
                // User cancelled the dialog box
                MessageBox.Show("Sorry it didn't work out, we'll try again later.");
            }
            // </HandleDialogResponse>
        }
    }
}
