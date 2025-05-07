Imports System.Drawing.Printing
Imports System.IO
Public Class Form1
    '<string_declaration>
    ' Declare a string to hold the entire document contents.
    Private documentContents As String
    ' Declare a variable to hold the portion of the document that
    ' is not printed.
    Private stringToPrint As String
    '</string_declaration>

    '<print_file_using_event_handler>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size,
            StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page.
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        stringToPrint = StringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

        ' If there are no more pages, reset the string to be printed.
        If Not e.HasMorePages Then
            stringToPrint = documentContents
        End If

    End Sub
    '</print_file_using_event_handler>

    '<read_document_and_show_print_preview_dialog>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    
        '<open_and_read_document_contents_to_the_string>
        Dim docName As String = "testPage.txt"
        Dim docPath As String = "C:\Users\v-rsatao\Desktop\"
        Dim fullPath As String = System.IO.Path.Combine(docPath, docName)

        PrintDocument1.DocumentName = docName
        stringToPrint = System.IO.File.ReadAllText(fullPath)
        '</open_and_read_document_contents_to_the_string>

        '<set_the_document_property>
        PrintPreviewDialog1.Document = PrintDocument1
        '</set_the_document_property>

        '<set_property_of_dialog>
        PrintPreviewDialog1.ShowDialog()
        '</set_property_of_dialog>

    End Sub
    '</read_document_and_show_print_preview_dialog>

End Class
