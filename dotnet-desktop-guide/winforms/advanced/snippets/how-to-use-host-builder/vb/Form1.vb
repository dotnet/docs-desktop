Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Logging

' <Form1>
Public Class Form1

    Private _logger As ILogger(Of Form1)
    Private _greetingService As IGreetingService

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim services = My.MyApplication.HostInstance.Services
        _logger = services.GetRequiredService(Of ILogger(Of Form1))()
        _greetingService = services.GetRequiredService(Of IGreetingService)()
    End Sub

    Private Sub ButtonGreet_Click(sender As Object, e As EventArgs) Handles btnGreet.Click
        Dim greeting As String = _greetingService.GetGreeting()
        lblGreeting.Text = greeting
        _logger.LogInformation("Greeting displayed: {Greeting}", greeting)
    End Sub

End Class
' </Form1>
