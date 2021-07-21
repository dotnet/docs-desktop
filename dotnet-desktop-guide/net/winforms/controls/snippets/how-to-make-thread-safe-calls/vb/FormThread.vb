Public Class FormThread
    '<Good>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim threadParameters As New System.Threading.ThreadStart(Sub()
                                                                     WriteTextSafe("This text was set safely.")
                                                                 End Sub)

        Dim thread2 As New System.Threading.Thread(threadParameters)
        thread2.Start()

    End Sub

    Private Sub WriteTextSafe(text As String)

        If (TextBox1.InvokeRequired) Then

            TextBox1.Invoke(Sub()
                                WriteTextSafe($"{text} (THREAD2)")
                            End Sub)

        Else
            TextBox1.Text = text
        End If

    End Sub
    '</Good>
End Class
