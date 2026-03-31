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

        If message Is Nothing Then
            Return "Hello, World!"
        End If

        Return message
    End Function

End Class
' </GreetingService>
