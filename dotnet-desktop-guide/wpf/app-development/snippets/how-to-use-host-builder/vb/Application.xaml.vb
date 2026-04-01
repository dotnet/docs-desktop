Imports System.Windows
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Class Application

    Private _host As IHost

    ' <CreateHost>
    Private Async Sub Application_Startup(sender As Object, e As StartupEventArgs)
        _host = Host.CreateDefaultBuilder() _
            .ConfigureServices(Sub(context, services)
                                   services.AddHostedService(Of SampleLifecycleService)()
                                   services.AddSingleton(Of IGreetingService, GreetingService)()
                                   services.AddSingleton(Of MainWindow)()
                               End Sub) _
            .Build()

        Await _host.StartAsync()

        Dim mainWindow As MainWindow = _host.Services.GetRequiredService(Of MainWindow)()
        mainWindow.Show()
    End Sub
    ' </CreateHost>

    ' <StopHost>
    Private Async Sub Application_Exit(sender As Object, e As ExitEventArgs)
        Using _host
            Await _host.StopAsync()
        End Using
    End Sub
    ' </StopHost>

End Class
