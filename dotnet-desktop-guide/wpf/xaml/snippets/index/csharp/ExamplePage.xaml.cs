using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExampleNamespace;

public partial class ExamplePage : Page
{
    public ExamplePage() =>
        InitializeComponent();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var buttonControl = (Button)e.Source;
        buttonControl.Foreground = Brushes.Red;
    }
}
