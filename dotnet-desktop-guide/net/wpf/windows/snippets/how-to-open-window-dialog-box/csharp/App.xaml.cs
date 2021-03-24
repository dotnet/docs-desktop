using System.Windows;

namespace DisplayWindows
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the window
            Window1 window = new Window1();

            // Open the window
            window.Show();
        }
    }
}
