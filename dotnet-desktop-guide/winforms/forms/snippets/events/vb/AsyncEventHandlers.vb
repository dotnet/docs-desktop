Imports System
Imports System.Net.Http
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class ExampleForm
    Inherits Form

    Private WithEvents downloadButton As Button
    Private WithEvents processButton As Button
    Private WithEvents complexButton As Button
    Private WithEvents badButton As Button
    Private WithEvents legacyButton As Button
    Private resultTextBox As TextBox
    Private statusLabel As Label
    Private progressBar As ProgressBar

    Public Sub New()
        Size = New System.Drawing.Size(400, 600)
        downloadButton = New Button With {.Text = "Download Data"}
        processButton = New Button With {.Text = "Process Data"}
        complexButton = New Button With {.Text = "Complex Operation"}
        badButton = New Button With {.Text = "Bad Example (Deadlock)"}
        resultTextBox = New TextBox With {.Multiline = True, .Width = 300, .Height = 200}
        statusLabel = New Label With {.Text = "Status: Ready"}
        progressBar = New ProgressBar With {.Width = 300}

        'Arrange controls
        Dim Margin = 20
        Dim spacing = 10

        'Buttons stacked vertically.
        downloadButton.Location = New System.Drawing.Point(Margin, Margin)
        downloadButton.Width = 300

        processButton.Location = New System.Drawing.Point(Margin, downloadButton.Bottom + spacing)
        processButton.Width = downloadButton.Width

        complexButton.Location = New System.Drawing.Point(Margin, processButton.Bottom + spacing)
        complexButton.Width = downloadButton.Width

        badButton.Location = New System.Drawing.Point(Margin, complexButton.Bottom + spacing)
        badButton.Width = downloadButton.Width

        'Status And progress below buttons.
        statusLabel.AutoSize = True
        statusLabel.Location = New System.Drawing.Point(Margin, badButton.Bottom + spacing)

        progressBar.Location = New System.Drawing.Point(Margin, statusLabel.Bottom + spacing)
        progressBar.Width = downloadButton.Width

        'Result text box below progress bar.
        resultTextBox.Location = New System.Drawing.Point(Margin, progressBar.Bottom + spacing)

        Controls.Add(downloadButton)
        Controls.Add(processButton)
        Controls.Add(complexButton)
        Controls.Add(badButton)
        Controls.Add(resultTextBox)
        Controls.Add(statusLabel)
        Controls.Add(progressBar)
    End Sub

    ' <snippet_BasicAsyncEventHandler>
    Private Async Sub downloadButton_Click(sender As Object, e As EventArgs) Handles downloadButton.Click
        downloadButton.Enabled = False
        statusLabel.Text = "Downloading..."

        Try
            Using httpClient As New HttpClient()
                Dim content As String = Await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md")

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
            ' This blocks the UI thread and causes a deadlock
            Dim content As String = DownloadPageContentAsync().GetAwaiter().GetResult()
            resultTextBox.Text = content
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub

    Private Async Function DownloadPageContentAsync() As Task(Of String)
        Using httpClient As New HttpClient()
            Return Await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md")
        End Using
    End Function
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
            Return Await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md")
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
            Return Await httpClient.GetStringAsync("https://github.com/dotnet/docs/raw/refs/heads/main/README.md")
        End Using
    End Function
    ' </snippet_LegacyNetFramework>
End Class
