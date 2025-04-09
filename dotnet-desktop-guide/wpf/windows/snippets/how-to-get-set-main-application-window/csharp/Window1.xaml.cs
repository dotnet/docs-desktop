using System.Windows;

namespace MainApp
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // <GetMainWindow>
        private void Button_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show($"The main window's title is: {Application.Current.MainWindow.Title}");
        // </GetMainWindow>
    }
}
