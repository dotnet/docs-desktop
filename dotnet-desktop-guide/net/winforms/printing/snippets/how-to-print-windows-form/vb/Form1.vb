Public Class Form1
    
    Dim memoryImage As Bitmap

    Private Sub printDocument1_PrintPage(ByVal sender As System.Object, 
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.Graphics.DrawImage(memoryImage, 0, 0)
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
         
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = Me.Size
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, s)
        
        PrintDocument1.Print()
        
    End Sub
End Class
