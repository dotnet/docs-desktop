Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace My

    ' <CreateHost>
    Partial Friend Class MyApplication

        Private Shared _host As IHost

        ' Build and start the host when the application starts.
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

        ' Stop and dispose of the host when the application shuts down.
        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            _host.StopAsync().GetAwaiter().GetResult()
            _host.Dispose()
        End Sub

        ' Resolve the main form from DI instead of using the default form instance.
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = _host.Services.GetRequiredService(Of Form1)()
        End Sub

        ' Expose the host so forms can resolve services via HostInstance.Services.
        Friend Shared ReadOnly Property HostInstance As IHost
            Get
                Return _host
            End Get
        End Property

    End Class
    ' </CreateHost>

End Namespace
