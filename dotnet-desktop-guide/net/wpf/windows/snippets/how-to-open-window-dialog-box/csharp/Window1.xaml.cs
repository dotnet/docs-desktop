using System.Windows;

namespace DisplayWindows
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void formatMarginsButton_Click(object sender, RoutedEventArgs e)
        {
            // <ShowDialog>
            var window = new Margins();
            window.Owner = this;
            window.ShowDialog();
            // </ShowDialog>
        }

        private void showMenus_Click(object sender, RoutedEventArgs e)
        {
            new Menus().ShowDialog();
        }

        // <DialogResultButtons>
        private void okButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = true;

        private void cancelButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;
        // </DialogResultButtons>
    }
}
