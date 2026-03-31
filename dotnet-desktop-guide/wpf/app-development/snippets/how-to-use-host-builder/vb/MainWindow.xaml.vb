Imports System.Windows
Imports Microsoft.Extensions.Logging

' <MainWindowCodeBehind>
Class MainWindow

    Private ReadOnly _logger As ILogger(Of MainWindow)
    Private ReadOnly _greetingService As IGreetingService

    Public Sub New(logger As ILogger(Of MainWindow), greetingService As IGreetingService)
        InitializeComponent()

        _logger = logger
        _greetingService = greetingService
    End Sub

    Private Sub OnGetGreetingClick(sender As Object, e As RoutedEventArgs)
        _logger.LogInformation("Get Greeting button clicked.")
        GreetingText.Text = _greetingService.GetGreeting()
    End Sub

End Class
' </MainWindowCodeBehind>
