using System.Windows;

namespace WindowsOverview
{
    public partial class ChildWindow1 : Window
    {
        public ChildWindow1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a window and make the current window its owner
            var ownedWindow = new ChildWindow1();
            ownedWindow.Owner = this;
            ownedWindow.Show();
        }
    }
}
