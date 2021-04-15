using System.Windows;

namespace CloseWindows
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
            var menu = new Menus();
            var result = menu.ShowDialog();
            menu.Show();
        }

        // <DialogResultButtons>
        private void okButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = true;

        private void cancelButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;
        // </DialogResultButtons>
    }
}
