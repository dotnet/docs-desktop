Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace OtherNamespace

    Class OneClass

        ' <ProgramVersion>
        Private _host As IHost

        <STAThread()>
        Friend Sub Main(args As String())
            ' Configure the host with services
            Dim builder = Host.CreateApplicationBuilder(args)

            builder.Services.AddHostedService(Of SampleLifecycleService)()
            builder.Services.AddTransient(Of Form1)()
            builder.Services.AddSingleton(Of IGreetingService, GreetingService)()

            _host = builder.Build()
            _host.Start()

            ' Run the application with the main form resolved from the host
            Application.SetHighDpiMode(HighDpiMode.SystemAware)
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(_host.Services.GetRequiredService(Of Form1)())

            ' Stop the host when the application exits
            _host.StopAsync().GetAwaiter().GetResult()
            _host.Dispose()
        End Sub

        Friend ReadOnly Property HostInstance As IHost
            Get
                Return _host
            End Get
        End Property
        ' </ProgramVersion>

    End Class

End Namespace
