using System.Windows;
using Microsoft.Extensions.Logging;

namespace HostBuilderApp;

// <MainWindowCodeBehind>
public partial class MainWindow : Window
{
    private readonly ILogger<MainWindow> _logger;
    private readonly IGreetingService _greetingService;

    public MainWindow(ILogger<MainWindow> logger, IGreetingService greetingService)
    {
        InitializeComponent();

        _logger = logger;
        _greetingService = greetingService;
    }

    private void OnGetGreetingClick(object sender, RoutedEventArgs e)
    {
        _logger.LogInformation("Get Greeting button clicked.");
        GreetingText.Text = _greetingService.GetGreeting();
    }
}
// </MainWindowCodeBehind>
