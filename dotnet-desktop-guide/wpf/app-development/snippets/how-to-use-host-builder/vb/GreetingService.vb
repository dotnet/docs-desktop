Imports Microsoft.Extensions.Configuration

' <GreetingService>
Public Class GreetingService
    Implements IGreetingService

    Private ReadOnly _configuration As IConfiguration

    Public Sub New(configuration As IConfiguration)
        _configuration = configuration
    End Sub

    Public Function GetGreeting() As String Implements IGreetingService.GetGreeting
        Dim message As String = _configuration.GetValue(Of String)("GreetingMessage")

        If String.IsNullOrEmpty(message) Then
            Return "Hello from the Generic Host!"
        End If

        Return message
    End Function

End Class
' </GreetingService>
