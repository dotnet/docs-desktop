using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostBuilderApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddHostedService<SampleLifecycleService>();
        builder.Services.AddTransient<Form1>();
        builder.Services.AddSingleton<IGreetingService, GreetingService>();

        IHost host = builder.Build();

        host.Start();

        Form1 mainForm = host.Services.GetRequiredService<Form1>();
        Application.Run(mainForm);

        host.StopAsync().GetAwaiter().GetResult();
        host.Dispose();
    }
}
