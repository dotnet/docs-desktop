Imports System.Drawing.Text

Public Class Form1

    '<DrawFont>
    ' Helper function to print text in a font and style
    Private Function DrawFont(graphicsObj As Graphics,
                              family As FontFamily,
                              style As FontStyle,
                              colorBrush As SolidBrush,
                              location As PointF,
                              styleName As String) As Single

        ' The string to print, which contains the family name and style
        Dim familyNameAndStyle As String = $"{family.Name} {styleName}"

        ' Create the font object
        Using fontObject As New Font(family.Name, 16, style, GraphicsUnit.Pixel)

            ' Draw the string
            graphicsObj.DrawString(familyNameAndStyle, fontObject, colorBrush, location)

            ' Return the height of the font
            Return fontObject.Height

        End Using

    End Function

    ' The OnPaint method of a form, which provides the graphics object
    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        Dim location As New PointF(10, 0)
        Dim solidBrush As New SolidBrush(Color.Black)

        Dim fontFamilies() As FontFamily
        Dim privateFontCollection As New PrivateFontCollection() ' Dispose later

        ' Add three font files to the private collection.
        privateFontCollection.AddFontFile(System.Environment.ExpandEnvironmentVariables("%systemroot%\Fonts\Arial.ttf"))
        privateFontCollection.AddFontFile(System.Environment.ExpandEnvironmentVariables("%systemroot%\Fonts\CourBI.ttf"))
        privateFontCollection.AddFontFile(System.Environment.ExpandEnvironmentVariables("%systemroot%\Fonts\TimesBD.ttf"))

        ' Get the array of FontFamily objects.
        fontFamilies = privateFontCollection.Families

        ' Process each font in the collection
        For i = 0 To fontFamilies.Length - 1

            ' Draw the font in every style

            ' Regular
            If fontFamilies(i).IsStyleAvailable(FontStyle.Regular) Then
                location.Y += DrawFont(e.Graphics, fontFamilies(i), FontStyle.Regular, solidBrush, location, "Regular")
            End If

            ' Bold
            If fontFamilies(i).IsStyleAvailable(FontStyle.Bold) Then
                location.Y += DrawFont(e.Graphics, fontFamilies(i), FontStyle.Bold, solidBrush, location, "Bold")
            End If

            ' Italic
            If fontFamilies(i).IsStyleAvailable(FontStyle.Italic) Then
                location.Y += DrawFont(e.Graphics, fontFamilies(i), FontStyle.Italic, solidBrush, location, "Italic")
            End If

            ' Bold and Italic
            If fontFamilies(i).IsStyleAvailable(FontStyle.Italic) And
               fontFamilies(i).IsStyleAvailable(FontStyle.Italic) Then
                location.Y += DrawFont(e.Graphics, fontFamilies(i), FontStyle.Bold Or FontStyle.Italic, solidBrush, location, "BoldItalic")
            End If

            ' Underline
            If fontFamilies(i).IsStyleAvailable(FontStyle.Underline) Then
                location.Y += DrawFont(e.Graphics, fontFamilies(i), FontStyle.Underline, solidBrush, location, "Underline")
            End If

            ' Strikeout
            If fontFamilies(i).IsStyleAvailable(FontStyle.Strikeout) Then
                location.Y += DrawFont(e.Graphics, fontFamilies(i), FontStyle.Strikeout, solidBrush, location, "Strikeout")
            End If

            ' Extra space between font families
            location.Y += 10

        Next

        privateFontCollection.Dispose()

    End Sub
    '</DrawFont>

End Class
