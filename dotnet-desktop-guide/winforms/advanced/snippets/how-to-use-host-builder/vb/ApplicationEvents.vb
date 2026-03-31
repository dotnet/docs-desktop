Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace My

    ' <CreateHost>
    Partial Friend Class MyApplication

        Private Shared _host As IHost

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            _host = Host.CreateDefaultBuilder() _
                .ConfigureServices(Sub(context, services)
                                       services.AddHostedService(Of SampleLifecycleService)()
                                       services.AddTransient(Of Form1)()
                                       services.AddSingleton(Of IGreetingService, GreetingService)()
                                   End Sub) _
                .Build()

            _host.Start()
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            _host.StopAsync().GetAwaiter().GetResult()
            _host.Dispose()
        End Sub

        Friend Shared ReadOnly Property HostInstance As IHost
            Get
                Return _host
            End Get
        End Property

    End Class
    ' </CreateHost>

End Namespace
