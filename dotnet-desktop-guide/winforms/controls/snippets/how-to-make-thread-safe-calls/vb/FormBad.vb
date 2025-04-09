Public Class FormBad
    '<Bad>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim thread2 As New System.Threading.Thread(AddressOf WriteTextUnsafe)
        thread2.Start()
    End Sub

    Private Sub WriteTextUnsafe()
        TextBox1.Text = "This text was set unsafely."
    End Sub
    '</Bad>
End Class
