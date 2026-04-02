Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace My

    Partial Friend Class MyApplication

        Private Shared _host As IHost

        ' Build and start the host when the application starts.
        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim builder = Host.CreateApplicationBuilder()

            builder.Services.AddHostedService(Of SampleLifecycleService)()
            builder.Services.AddTransient(Of Form1)()
            builder.Services.AddSingleton(Of IGreetingService, GreetingService)()

            _host = builder.Build()

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

End Namespace
