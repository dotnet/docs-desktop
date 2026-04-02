Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Logging

' <Form1>
Public Class Form1

    Private _logger As ILogger(Of Form1)
    Private _greetingService As IGreetingService

    Sub New(ILogger As ILogger(Of Form1), greetingService As IGreetingService)
        InitializeComponent()
        _logger = ILogger
        _greetingService = greetingService
    End Sub

    Private Sub ButtonGreet_Click(sender As Object, e As EventArgs) Handles btnGreet.Click
        Dim greeting As String = _greetingService.GetGreeting()
        lblGreeting.Text = greeting
        _logger.LogInformation("Greeting displayed: {Greeting}", greeting)
    End Sub

End Class
' </Form1>
