Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDialog1.Document = PrintDocument1
        '<show-dialog>
        'display show dialog and if user selects "Ok" document is printed
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
        '</show-dialog>
    End Sub

    '<specify-the-material-to-be-printed>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.FillRectangle(Brushes.Red, New Rectangle(100, 100, 100, 100))
    End Sub
    '</specify-the-material-to-be-printed>

    '<message-box-indicating-document-has-finished-printing>
    Private Sub PrintDocument1_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.EndPrint
        MessageBox.Show(PrintDocument1.DocumentName + " has finished printing.")
    End Sub
    '</message-box-indicating-document-has-finished-printing>

End Class
