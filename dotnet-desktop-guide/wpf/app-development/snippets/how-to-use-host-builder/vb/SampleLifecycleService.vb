Imports System.Threading
Imports Microsoft.Extensions.Hosting

' <SampleLifecycleService>
Public Class SampleLifecycleService
    Implements IHostedService

    Public Function StartAsync(cancellationToken As CancellationToken) As Task Implements IHostedService.StartAsync
        System.Diagnostics.Debug.WriteLine("SampleLifecycleService: Started.")
        Return Task.CompletedTask
    End Function

    Public Function StopAsync(cancellationToken As CancellationToken) As Task Implements IHostedService.StopAsync
        System.Diagnostics.Debug.WriteLine("SampleLifecycleService: Stopped.")
        Return Task.CompletedTask
    End Function

End Class
' </SampleLifecycleService>
