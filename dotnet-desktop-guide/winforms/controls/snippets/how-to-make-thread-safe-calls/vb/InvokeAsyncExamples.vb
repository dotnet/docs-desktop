Imports System
Imports System.Net.Http
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class InvokeAsyncForm
    Inherits Form

    Private WithEvents button1 As Button
    Private WithEvents button2 As Button
    Private textBox1 As TextBox

    Public Sub New()
        button1 = New Button With {.Text = "Invoke Async Basic", .Location = New System.Drawing.Point(10, 10), .Width = 200}
        button2 = New Button With {.Text = "Invoke Async Advanced", .Location = New System.Drawing.Point(10, 50), .Width = 200}
        textBox1 = New TextBox With {.Location = New System.Drawing.Point(10, 90), .Width = 200, .Multiline = True, .Height = 500}
        Controls.Add(button1)
        Controls.Add(button2)
        Controls.Add(textBox1)
    End Sub

    ' <snippet_InvokeAsyncBasic>
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        button1.Enabled = False

        Try
            ' Perform background work
            Await Task.Run(Async Function()
                               For i As Integer = 0 To 100 Step 10
                                   ' Simulate work
                                   Await Task.Delay(100)

                                   ' Create local variable to avoid closure issues
                                   Dim currentProgress As Integer = i

                                   ' Update UI safely from background thread
                                   Await textBox1.InvokeAsync(Sub()
                                                                  textBox1.Text = $"Progress: {currentProgress}%"
                                                              End Sub)
                               Next
                           End Function)

            ' Update UI after completion
            Await textBox1.InvokeAsync(Sub()
                                           textBox1.Text = "Operation completed!"
                                       End Sub)
        Finally
            button1.Enabled = True
        End Try
    End Sub
    ' </snippet_InvokeAsyncBasic>

    ' <snippet_InvokeAsyncAdvanced>
    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        button2.Enabled = False
        Try
            ' Create a cancellation token source for this operation
            Using cts As New CancellationTokenSource()
                ' For VB.NET, use a separate method to handle the async operation with cancellation
                Await AsyncOperationWithCancellation(cts.Token)
            End Using
        Finally
            button2.Enabled = True
        End Try
    End Sub

    Private Async Function AsyncOperationWithCancellation(cancellationToken As CancellationToken) As Task
        ' Update UI to show starting state
        Await Me.InvokeAsync(Sub()
                                 textBox1.Text = "Starting operation..."
                             End Sub, cancellationToken)

        Dim resultMessage As String = ""

        Try
            ' Perform async work with cancellation support
            Dim result As String = Await SomeAsyncApiCall(cancellationToken)
            resultMessage = $"Result: {result}"

        Catch ex As OperationCanceledException
            resultMessage = "Operation canceled."

        Catch ex As Exception
            resultMessage = $"Error: {ex.Message}"

        End Try

        ' Update UI with final result
        Await Me.InvokeAsync(Sub()
                                 textBox1.Text = resultMessage
                             End Sub, cancellationToken)
    End Function

    Private Async Function SomeAsyncApiCall(cancellationToken As CancellationToken) As Task(Of String)

        Using client As New HttpClient()
            Await Task.Delay(2000, cancellationToken) ' Simulate network delay
            Return Await client.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md", cancellationToken)
        End Using

    End Function
    ' </snippet_InvokeAsyncAdvanced>
End Class
