Public Class Form1
    
    Dim memoryImage As Bitmap

    Private Sub printDocument1_PrintPage(ByVal sender As System.Object,
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles _
       PrintDocument1.PrintPage
        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '<capture_screen>
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = Me.Size
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, s)
        '</capture_screen>

        '<call_print_method_to_print_form>
        PrintDocument1.Print()
        '</call_print_method_to_print_form>

    End Sub
End Class
