using System.Windows;

namespace MainApp
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // <MainWindowDirect>
            Application.Current.MainWindow = new Window2();

            Application.Current.MainWindow.Show();
            // </MainWindowDirect>

            // <MainWindowIndirect>
            var appWindow = new Window2();

            appWindow.Show();
            // </MainWindowIndirect>
        }
    }
}
