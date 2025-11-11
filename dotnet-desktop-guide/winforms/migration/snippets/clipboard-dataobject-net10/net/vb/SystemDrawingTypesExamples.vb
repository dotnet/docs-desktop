Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class SystemDrawingTypesExamples
        ' <SystemDrawingTypes>
        Public Shared Sub SystemDrawingTypesExample()
            ' Geometric types
            Dim location As New Point(100, 200)
            Dim bounds As New Rectangle(0, 0, 500, 300)
            Dim dimensions As New Size(800, 600)

            Clipboard.SetData("Location", location)
            Clipboard.SetData("Bounds", bounds)
            Clipboard.SetData("Size", dimensions)

            ' Color information
            Dim backgroundColor As Color = Color.FromArgb(255, 128, 64, 192)
            Clipboard.SetData("BackColor", backgroundColor)

            ' Bitmap data (use with caution for large images)
            Dim smallIcon As New Bitmap(16, 16)
            Clipboard.SetData("Icon", smallIcon)
        End Sub
        ' </SystemDrawingTypes>
    End Class
End Namespace