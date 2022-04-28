Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1

    '<add_string_to_your_form>
    'Private PrintDocument1 As New PrintDocument()
    Private stringToPrint As String
    '</add_string_to_your_form>

    '<print_contents_of_the_file_using_event_handler>
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object,
    ByVal e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size,
        StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black,
        e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

    End Sub
    '</print_contents_of_the_file_using_event_handler>

    Private Sub ReadFile()

        '<set_DocumentName_then_open_and_read_document_to_the_string">
        Dim docName As String = "testPage.txt"
        Dim docPath As String = "C:\"
        PrintDocument1.DocumentName = docName

        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        '</set_DocumentName_then_open_and_read_document_to_the_string">

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ReadFile()

        '<call_print_method_to_print_file>
        PrintDocument1.Print()
        '</call_print_method_to_print_file>

    End Sub

End Class
