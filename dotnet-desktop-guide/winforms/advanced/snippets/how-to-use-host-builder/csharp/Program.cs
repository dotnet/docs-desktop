using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostBuilderApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // <CreateHost>
        IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<SampleLifecycleService>();
                services.AddTransient<Form1>();
                services.AddSingleton<IGreetingService, GreetingService>();
            })
            .Build();

        host.Start();
        // </CreateHost>

        // <ResolveAndRun>
        Form1 mainForm = host.Services.GetRequiredService<Form1>();
        Application.Run(mainForm);
        // </ResolveAndRun>

        host.StopAsync().GetAwaiter().GetResult();
        host.Dispose();
    }
}
