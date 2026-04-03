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
        var builder = Host.CreateApplicationBuilder();

        // <RegisterServices>
        builder.Services.AddHostedService<SampleLifecycleService>();
        builder.Services.AddSingleton<IGreetingService, GreetingService>();
        builder.Services.AddSingleton<MainWindow>();
        // </RegisterServices>

        _host = builder.Build();

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
