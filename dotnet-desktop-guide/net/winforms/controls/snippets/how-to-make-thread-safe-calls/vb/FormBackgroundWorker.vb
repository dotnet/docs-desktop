Public Class FormBackgroundWorker
    '<Background>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (Not BackgroundWorker1.IsBusy) Then
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim counter = 0
        Dim max = 10

        While counter <= max

            BackgroundWorker1.ReportProgress(0, counter.ToString())
            System.Threading.Thread.Sleep(1000)

            counter += 1

        End While

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        TextBox1.Text = e.UserState
    End Sub
    '</Background>
End Class
