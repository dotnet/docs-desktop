Imports System
Imports System.IO
Imports System.Windows.Xps.Packaging
Imports Microsoft.Win32

Namespace CodeSampleVb
    Partial Public Class MainWindow
        Inherits Window

        ''' <summary>
        ''' Interaction logic for MainWindow.xaml
        ''' </summary>
        Public Sub New()
            InitializeComponent()

            AddHandler btnBrowse.Click, AddressOf BtnBrowse_Click
            AddHandler btnPrint.Click, AddressOf BtnPrint_Click
        End Sub

        ''' <summary>
        ''' Browse button click event handler
        ''' Gets the path to a source XPS file
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub BtnBrowse_Click(sender As Object, e As RoutedEventArgs)
            ' Configure an open file dialog box
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.FileName = "Document"    ' Default file name
            openFileDialog.DefaultExt = ".xps"    ' Default file extension
            openFileDialog.Filter = "Text documents (.xps)|*.xps"     ' Filter files by extension

            ' Show open file dialog box
            Dim result As Boolean? = openFileDialog.ShowDialog()

            ' Process open file dialog box results
            If result = True Then
                txtXpsFilePath.Text = openFileDialog.FileName
            End If
        End Sub

        ''' <summary>
        ''' Print button click event handler
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub BtnPrint_Click(sender As Object, e As RoutedEventArgs)
            ' Check the file exists
            If Not File.Exists(txtXpsFilePath.Text) Then
                MessageBox.Show("First select an XPS file.")
                Return
            End If

            PrintFile(txtXpsFilePath.Text, hidePrintDialog:=cbxHidePrintDialog.IsChecked = True)
        End Sub

        ''' <summary>
        ''' Print an XPS document to OXPS format.
        ''' Optionally, print all pages without showing a print dialog window.
        ''' </summary>
        ''' <param name="xpsFilePath">Path to source XPS file</param>
        ''' <param name="hidePrintDialog">Whether to hide the print dialog window (shown by default)</param>
        ' <SampleCode>
        Private Shared Sub PrintFile(xpsFilePath As String, Optional hidePrintDialog As Boolean = False)
            ' Create the print dialog object and set options
            Dim printDialog As New PrintDialog

            If Not hidePrintDialog Then
                Dim isPrinted As Boolean? = printDialog.ShowDialog()
                If isPrinted <> True Then Return
            End If

            Try
                ' Open the selected file
                Dim xpsDocument As New XpsDocument(xpsFilePath, FileAccess.Read)

                ' Get a fixed document sequence for the selected file
                Dim fixedDocSeq As FixedDocumentSequence = xpsDocument.GetFixedDocumentSequence()

                ' Create a paginator for all pages in the selected file
                Dim docPaginator As DocumentPaginator = fixedDocSeq.DocumentPaginator

                ' Print to a new file
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}")
            Catch e As Exception
                MessageBox.Show(e.Message)
            End Try
        End Sub
        ' </SampleCode>
    End Class
End Namespace
