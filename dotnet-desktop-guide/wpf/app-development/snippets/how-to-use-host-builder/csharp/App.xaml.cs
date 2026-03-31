using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostBuilderApp;

public partial class App : Application
{
    private IHost _host = default!;

    // <CreateHost>
    private async void Application_Startup(object sender, StartupEventArgs e)
    {
        _host = Host.CreateDefaultBuilder()
            // <RegisterServices>
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<SampleLifecycleService>();
                services.AddSingleton<IGreetingService, GreetingService>();
                services.AddSingleton<MainWindow>();
            })
            // </RegisterServices>
            .Build();

        await _host.StartAsync();

        MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
    // </CreateHost>

    // <StopHost>
    private async void Application_Exit(object sender, ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }
    }
    // </StopHost>
}
