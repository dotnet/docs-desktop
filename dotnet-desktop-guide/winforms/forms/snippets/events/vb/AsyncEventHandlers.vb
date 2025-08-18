Imports System
Imports System.Net.Http
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace AsyncEventHandlersExample
    Public Partial Class ExampleForm
        Inherits Form

        Private WithEvents downloadButton As Button
        Private WithEvents processButton As Button
        Private WithEvents complexButton As Button
        Private WithEvents badButton As Button
        Private WithEvents legacyButton As Button
        Private resultTextBox As TextBox
        Private statusLabel As Label
        Private progressBar As ProgressBar

        ' <snippet_BasicAsyncEventHandler>
        Private Async Sub downloadButton_Click(sender As Object, e As EventArgs) Handles downloadButton.Click
            downloadButton.Enabled = False
            statusLabel.Text = "Downloading..."
            
            Try
                Using httpClient As New HttpClient()
                    Dim content As String = Await httpClient.GetStringAsync("https://api.example.com/data")
                    
                    ' Update UI with the result
                    resultTextBox.Text = content
                    statusLabel.Text = "Download complete"
                End Using
            Catch ex As Exception
                statusLabel.Text = $"Error: {ex.Message}"
            Finally
                downloadButton.Enabled = True
            End Try
        End Sub
        ' </snippet_BasicAsyncEventHandler>

        ' <snippet_DeadlockAntiPattern>
        ' DON'T DO THIS - causes deadlocks
        Private Sub badButton_Click(sender As Object, e As EventArgs) Handles badButton.Click
            Try
                Using httpClient As New HttpClient()
                    ' This blocks the UI thread and causes a deadlock
                    Dim content As String = httpClient.GetStringAsync("https://api.example.com/data").GetAwaiter().GetResult()
                    resultTextBox.Text = content
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}")
            End Try
        End Sub
        ' </snippet_DeadlockAntiPattern>

        ' <snippet_InvokeAsyncNet9>
        Private Async Sub processButton_Click(sender As Object, e As EventArgs) Handles processButton.Click
            processButton.Enabled = False
            
            ' Start background work
            Await Task.Run(Async Function()
                For i As Integer = 0 To 100 Step 10
                    ' Simulate work
                    Await Task.Delay(200)
                    
                    ' Create local variable to avoid closure issues
                    Dim currentProgress As Integer = i
                    
                    ' Update UI safely from background thread
                    Await progressBar.InvokeAsync(Sub()
                        progressBar.Value = currentProgress
                        statusLabel.Text = $"Progress: {currentProgress}%"
                    End Sub)
                Next
            End Function)
            
            processButton.Enabled = True
        End Sub
        ' </snippet_InvokeAsyncNet9>

        ' <snippet_InvokeAsyncUIThread>
        Private Async Sub complexButton_Click(sender As Object, e As EventArgs) Handles complexButton.Click
            ' For VB.NET, we use a simpler approach since async lambdas with CancellationToken are more complex
            Await Me.InvokeAsync(Sub()
                ' This runs on UI thread
                statusLabel.Text = "Starting complex operation..."
            End Sub)
            
            ' Perform the async operation
            Dim result As String = Await SomeAsyncApiCall()
            
            ' Update UI after completion
            Await Me.InvokeAsync(Sub()
                resultTextBox.Text = result
                statusLabel.Text = "Operation completed"
            End Sub)
        End Sub

        Private Async Function SomeAsyncApiCall() As Task(Of String)
            Using httpClient As New HttpClient()
                Return Await httpClient.GetStringAsync("https://api.example.com/data")
            End Using
        End Function
        ' </snippet_InvokeAsyncUIThread>

        ' <snippet_LegacyNetFramework>
        Private Async Sub legacyButton_Click(sender As Object, e As EventArgs) Handles legacyButton.Click
            Dim legacyButton As Button = TryCast(sender, Button)
            legacyButton.Enabled = False
            
            Try
                ' Move to background thread to avoid blocking UI
                Await Task.Run(Async Function()
                    Dim result As String = Await SomeAsyncOperation()
                    
                    ' Marshal back to UI thread
                    Me.Invoke(New Action(Sub()
                        resultTextBox.Text = result
                        statusLabel.Text = "Complete"
                    End Sub))
                End Function)
            Finally
                ' This runs on the UI thread since the await completed
                legacyButton.Enabled = True
            End Try
        End Sub

        Private Async Function SomeAsyncOperation() As Task(Of String)
            Using httpClient As New HttpClient()
                Return Await httpClient.GetStringAsync("https://api.example.com/data")
            End Using
        End Function
        ' </snippet_LegacyNetFramework>
    End Class
End Namespace
