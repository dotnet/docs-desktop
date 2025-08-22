Imports System
Imports System.Net.Http
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class FormInvokeAsync
    Inherits Form

    Private WithEvents button1 As Button
    Private WithEvents button2 As Button
    Private loggingTextBox As TextBox

    Public Sub New()
        button1 = New Button With {.Text = "Invoke Async Basic", .Location = New System.Drawing.Point(10, 10), .Width = 200}
        button2 = New Button With {.Text = "Invoke Async Advanced", .Location = New System.Drawing.Point(10, 50), .Width = 200}
        loggingTextBox = New TextBox With {.Location = New System.Drawing.Point(10, 90), .Width = 200, .Multiline = True, .Height = 500}
        Controls.Add(button1)
        Controls.Add(button2)
        Controls.Add(loggingTextBox)
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
                                   Await loggingTextBox.InvokeAsync(Sub()
                                                                        loggingTextBox.Text = $"Progress: {currentProgress}%"
                                                                    End Sub)
                               Next
                           End Function)

            ' Update UI after completion
            Await loggingTextBox.InvokeAsync(Sub()
                                                 loggingTextBox.Text = "Operation completed!"
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
            loggingTextBox.Text = "Starting operation..."

            ' Dispatch and run on a new thread, but wait for tasks to finish
            ' Exceptions are rethrown here, because await is used
            Await Task.WhenAll(Task.Run(AddressOf SomeApiCallAsync),
                               Task.Run(AddressOf SomeApiCallAsync),
                               Task.Run(AddressOf SomeApiCallAsync))

            ' Dispatch and run on a new thread, but don't wait for task to finish
            ' Exceptions are not rethrown here, because await is not used
            Call Task.Run(AddressOf SomeApiCallAsync)

        Catch ex As OperationCanceledException
            loggingTextBox.Text += "Operation canceled."
        Catch ex As Exception
            loggingTextBox.Text += $"Error: {ex.Message}"
        Finally
            button2.Enabled = True
        End Try
    End Sub

    Private Async Function SomeApiCallAsync() As Task
        Using client As New HttpClient()

            ' Simulate random network delay
            Await Task.Delay(Random.Shared.Next(500, 2500))

            ' Do I/O asynchronously
            Dim result As String = Await client.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md")

            ' Marshal back to UI thread
            ' Extra work here in VB to handle ValueTask conversion
            Await Me.InvokeAsync(DirectCast(
                    Async Function(cancelToken As CancellationToken) As Task
                        loggingTextBox.Text &= $"{Environment.NewLine}Operation finished at: {DateTime.Now:HH:mm:ss.fff}"
                    End Function,
                Func(Of CancellationToken, Task)).AsValueTask() 'Extension method to convert Task
            )

            ' Do more Async I/O ...
        End Using
    End Function
    ' </snippet_InvokeAsyncAdvanced>
End Class
