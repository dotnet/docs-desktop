Imports System.Drawing.Printing
Imports System.IO
Public Class Form1
    '<string_declaration>
    ' Declare a string to hold the entire document contents.
    Private DocumentContents As String
    ' Declare a variable to hold the portion of the document that
    ' is not printed.
    Private StringToPrint As String
    '</string_declaration>

    '<print_file_using_event_handler>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(StringToPrint, Me.Font, e.MarginBounds.Size,
            StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page.
        e.Graphics.DrawString(StringToPrint, Me.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        StringToPrint = StringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = StringToPrint.Length > 0

        ' If there are no more pages, reset the string to be printed.
        If Not e.HasMorePages Then
            StringToPrint = DocumentContents
        End If

    End Sub
    '</print_file_using_event_handler>

    '<read_document_and_show_print_preview_dialog>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    
        '<open_and_read_document_contents_the_string>
        Dim docName As String = "testPage.txt"
        Dim docPath As String = "C:\"
        PrintDocument1.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                DocumentContents = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        StringToPrint = DocumentContents
        '</open_and_read_document_contents_the_string>

        '<set_the_document_property>
        PrintPreviewDialog1.Document = PrintDocument1
        '</set_the_document_property>

        '<set_property_of_dialog>
        PrintPreviewDialog1.ShowDialog()
        '</set_property_of_dialog>

    End Sub
    '</read_document_and_show_print_preview_dialog>

End Class
