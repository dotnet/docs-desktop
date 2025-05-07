Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDialog1.Document = PrintDocument1
        '<show_dialog>
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
        '</show_dialog>
    End Sub
    '<specify_the_material_to_be_printed>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.FillRectangle(Brushes.Red, New Rectangle(100, 100, 100, 100))
    End Sub
    '</specify_the_material_to_be_printed>

    '<message_box_indicating_document_has_finished_printing>
    Private Sub PrintDocument1_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.EndPrint
        MessageBox.Show(PrintDocument1.DocumentName + " has finished printing.")
    End Sub
    '</message_box_indicating_document_has_finished_printing>

End Class
