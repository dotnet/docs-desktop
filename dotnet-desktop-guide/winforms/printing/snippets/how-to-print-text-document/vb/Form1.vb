Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1

    '<add_string_to_your_form>
    'Private PrintDocument1 As New PrintDocument()
    Private stringToPrint As String
    '</add_string_to_your_form>

    '<print_contents_using_event_handler>
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
    '</print_contents_using_event_handler>

    '<set_DocumentName_and_string>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim docName As String = "testPage.txt"
        Dim docPath As String = "C:\"
        Dim fullPath As String = System.IO.Path.Combine(docPath, docName)

        PrintDocument1.DocumentName = docName

        stringToPrint = System.IO.File.ReadAllText(fullPath)
        
        '<call_print_method_to_print_file>
        PrintDocument1.Print()
        '</call_print_method_to_print_file>

    End Sub
    '</set_DocumentName_and_string>

End Class
