using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpfProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowDark_Click(object sender, RoutedEventArgs e)
    {
        DarkWindow window = new();
        window.Show();
    }
    private void ShowLight_Click(object sender, RoutedEventArgs e)
    {
        LightWindow window = new();
        window.Show();
    }
    private void ShowTheme_Click(object sender, RoutedEventArgs e)
    {
        ThemeWindow window = new();
        window.Show();
    }
    private void SetLightThemeApp_Click(object sender, RoutedEventArgs e)
    {
        //<ThemeMode>
        // Set light mode at the application-level
        Application.Current.ThemeMode = ThemeMode.Light;

        // Set dark mode on the current window
        this.ThemeMode = ThemeMode.Dark;
        //</ThemeMode>
    }
}