Public Class FormInvokeSync
    '<Good>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        WriteTextSafe("Writing message #1")
        Task.Run(Sub() WriteTextSafe("Writing message #2"))

    End Sub

    Private Sub WriteTextSafe(text As String)

        If (TextBox1.InvokeRequired) Then

            TextBox1.Invoke(Sub()
                                WriteTextSafe($"{text} (NON-UI THREAD)")
                            End Sub)

        Else
            TextBox1.Text += $"{Environment.NewLine}{text}"
        End If

    End Sub
    '</Good>

    '<Bad>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WriteTextUnsafe("Writing message #1 (UI THREAD)")
        Task.Run(Sub() WriteTextUnsafe("Writing message #2 (OTHER THREAD)"))
    End Sub

    Private Sub WriteTextUnsafe(text As String)
        TextBox1.Text += $"{Environment.NewLine}{text}"
    End Sub
    '</Bad>
End Class
