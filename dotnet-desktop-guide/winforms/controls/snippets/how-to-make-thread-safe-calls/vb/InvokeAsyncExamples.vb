Imports System
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ThreadSafeCallsExample
    Public Partial Class InvokeAsyncForm
        Inherits Form

        Private button1 As Button
        Private button2 As Button
        Private textBox1 As TextBox

        ' <snippet_InvokeAsyncBasic>
        Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Button1.Enabled = False
            
            Try
                ' Perform background work
                Await Task.Run(Async Function()
                    For i As Integer = 0 To 100 Step 10
                        ' Simulate work
                        Await Task.Delay(100)
                        
                        ' Update UI safely from background thread
                        Await TextBox1.InvokeAsync(Sub()
                            TextBox1.Text = $"Progress: {i}%"
                        End Sub)
                    Next
                End Function)
                
                ' Update UI after completion
                Await TextBox1.InvokeAsync(Sub()
                    TextBox1.Text = "Operation completed!"
                End Sub)
            Finally
                Button1.Enabled = True
            End Try
        End Sub
        ' </snippet_InvokeAsyncBasic>

        ' <snippet_InvokeAsyncAdvanced>
        Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            Await Me.InvokeAsync(Async Function(cancellationToken)
                ' This runs on UI thread but doesn't block it
                TextBox1.Text = "Starting operation..."
                
                ' Perform async work on UI thread
                Dim result As String = Await SomeAsyncApiCall()
                
                ' Update UI directly since we're on UI thread
                TextBox1.Text = $"Result: {result}"
                
                Return Nothing
            End Function)
        End Sub

        Private Async Function SomeAsyncApiCall() As Task(Of String)
            Using client As New HttpClient()
                Return Await client.GetStringAsync("https://api.example.com/data")
            End Using
        End Function
        ' </snippet_InvokeAsyncAdvanced>
    End Class
End Namespace
