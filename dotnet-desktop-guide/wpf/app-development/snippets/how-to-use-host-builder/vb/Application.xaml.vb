Imports System.Windows
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Class Application

    Private _host As IHost

    ' <CreateHost>
    Private Async Sub Application_Startup(sender As Object, e As StartupEventArgs)
        Dim builder = Host.CreateApplicationBuilder()

        builder.Services.AddHostedService(Of SampleLifecycleService)()
        builder.Services.AddSingleton(Of IGreetingService, GreetingService)()
        builder.Services.AddSingleton(Of MainWindow)()

        _host = builder.Build()

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
