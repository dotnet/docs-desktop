using Microsoft.Extensions.Hosting;

namespace HostBuilderApp;

// <SampleLifecycleService>
public class SampleLifecycleService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        System.Diagnostics.Debug.WriteLine("SampleLifecycleService: Started.");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        System.Diagnostics.Debug.WriteLine("SampleLifecycleService: Stopped.");
        return Task.CompletedTask;
    }
}
// </SampleLifecycleService>
