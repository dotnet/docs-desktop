Imports System
Imports System.IO
Imports System.Reflection
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

            ' Events.
            AddHandler btnBrowse.Click, AddressOf BtnBrowse_Click
            AddHandler btnPrint.Click, AddressOf BtnPrint_Click

        End Sub


        Private Sub BtnBrowse_Click(sender As Object, e As RoutedEventArgs)

            ' Configure an open file dialog box.
            Dim openFileDialog As New OpenFileDialog With {
                .FileName = "Document",
                .DefaultExt = ".xps",
                .Filter = "Text documents (.xps)|*.xps"
                }

            ' Show open file dialog box.
            Dim result As Boolean? = openFileDialog.ShowDialog()

            ' Process open file dialog box results.
            If result = True Then
                ' Show selected XPS file path.
                txtXpsFilePath.Text = openFileDialog.FileName
            End If

        End Sub

        Private Sub BtnPrint_Click(sender As Object, e As RoutedEventArgs)

            ' Check the file exists.
            If Not File.Exists(txtXpsFilePath.Text) Then
                MessageBox.Show("First select an XPS file.")
                Return
            End If

            ' Get the print dialog visibility.
            Dim hidePrintDialog = cbxHidePrintDialog.IsChecked = True
            Dim isPrinted As Boolean

            ' Print whole document.
            isPrinted = PrintWholeDocument(txtXpsFilePath.Text, hidePrintDialog)
            MessageBox.Show($"PrintWholeDocument {If(isPrinted, "printed", "failed to print")}.")

            ' Print a specific range of document pages as specified in the print dialog.
            If Not hidePrintDialog Then

                isPrinted = PrintDocumentPageRange(txtXpsFilePath.Text)
                MessageBox.Show($"PrintDocumentPageRange {If(isPrinted, "printed", "failed to print")}.")

            End If

        End Sub

        ' <SampleCode1>
        ''' <summary>
        ''' Print all pages of an XPS document.
        ''' Optionally, print all pages without showing a print dialog window.
        ''' </summary>
        ''' <param name="xpsFilePath">Path to source XPS file</param>
        ''' <param name="hidePrintDialog">Whether to hide the print dialog window (shown by default)</param>
        ''' <returns>Whether the document printed</returns>
        Public Shared Function PrintWholeDocument(xpsFilePath As String, Optional hidePrintDialog As Boolean = False) As Boolean

            ' Create the print dialog object and set options.
            Dim printDialog As New PrintDialog

            If Not hidePrintDialog Then

                ' Display the dialog. This returns true if the user presses the Print button.
                Dim isPrinted As Boolean? = printDialog.ShowDialog()
                If isPrinted <> True Then Return False

            End If

            ' Print the whole document.
            Try

                ' Open the selected document.
                Dim xpsDocument As New XpsDocument(xpsFilePath, FileAccess.Read)

                ' Get a fixed document sequence for the selected document.
                Dim fixedDocSeq As FixedDocumentSequence = xpsDocument.GetFixedDocumentSequence()

                ' Create a paginator for all pages in the selected document.
                Dim docPaginator As DocumentPaginator = fixedDocSeq.DocumentPaginator

                ' Print to a new file.
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}")

                Return True

            Catch e As Exception

                MessageBox.Show(e.Message)

                Return False

            End Try

        End Function
        ' </SampleCode1>

        ' <SampleCode2>
        ''' <summary>
        ''' Print a specific range of pages within an XPS document.
        ''' </summary>
        ''' <param name="xpsFilePath">Path to source XPS file</param>
        ''' <returns>Whether the document printed</returns>
        Public Shared Function PrintDocumentPageRange(xpsFilePath As String) As Boolean

            ' Create the print dialog object and set options.
            Dim printDialog As New PrintDialog With {
                .UserPageRangeEnabled = True
            }

            ' Display the dialog. This returns true if the user presses the Print button.
            Dim isPrinted As Boolean? = printDialog.ShowDialog()
            If isPrinted <> True Then Return False

            ' Print a specific page range within the document.
            Try

                ' Open the selected document.
                Dim xpsDocument As New XpsDocument(xpsFilePath, FileAccess.Read)

                ' Get a fixed document sequence for the selected document.
                Dim fixedDocSeq As FixedDocumentSequence = xpsDocument.GetFixedDocumentSequence()

                ' Create a paginator for all pages in the selected document.
                Dim docPaginator As DocumentPaginator = fixedDocSeq.DocumentPaginator

                ' Check whether a page range was specified in the print dialog.
                If printDialog.PageRangeSelection = PageRangeSelection.UserPages Then

                    ' Create a document paginator for the specified range of pages.
                    docPaginator = New DocPaginator(fixedDocSeq.DocumentPaginator, printDialog.PageRange)

                End If

                ' Print to a new file.
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}")

                Return True

            Catch e As Exception

                MessageBox.Show(e.Message)

                Return False

            End Try

        End Function

        ' <summary>
        ' Extend the abstract DocumentPaginator class to support page range printing.
        ' This class is based on the following online resources:
        ' https://www.thomasclaudiushuber.com/2009/11/24/wpf-printing-how-to-print-a-pagerange-with-wpfs-printdialog-
        ' that-means-the-user-can-select-specific-pages-and-only-these-pages-are-printed/
        ' https://social.msdn.microsoft.com/Forums/vstudio/en-US/9180e260-0791-4f2d-962d-abcb22ba8d09/how-to-print-
        ' multiple-page-ranges-with-wpf-printdialog
        ' https://social.msdn.microsoft.com/Forums/en-US/841e804b-9130-4476-8709-0d2854c11582/exception-quotfixedpage-
        ' cannot-contain-another-fixedpagequot-when-printing-to-the-xps-document?forum=wpf
        ' </summary>
        Public Class DocPaginator
            Inherits DocumentPaginator

            Private ReadOnly _documentPaginator As DocumentPaginator
            Private ReadOnly _startPageIndex As Integer
            Private ReadOnly _endPageIndex As Integer
            Private ReadOnly _pageCount As Integer

            Public Sub New(documentPaginator As DocumentPaginator, pageRange As PageRange)

                ' Set document paginator.
                _documentPaginator = documentPaginator

                ' Set page indices.
                _startPageIndex = pageRange.PageFrom - 1
                _endPageIndex = pageRange.PageTo - 1

                ' Validate And set page count.
                If _startPageIndex >= 0 AndAlso
                    _endPageIndex >= 0 AndAlso
                    _startPageIndex <= _documentPaginator.PageCount - 1 AndAlso
                    _endPageIndex <= _documentPaginator.PageCount - 1 AndAlso
                    _startPageIndex <= _endPageIndex Then
                    _pageCount = _endPageIndex - _startPageIndex + 1
                End If

            End Sub

            Public Overrides ReadOnly Property IsPageCountValid As Boolean
                Get
                    Return True
                End Get
            End Property

            Public Overrides ReadOnly Property PageCount As Integer
                Get
                    Return _pageCount
                End Get
            End Property

            Public Overrides ReadOnly Property Source As IDocumentPaginatorSource
                Get
                    Return _documentPaginator.Source
                End Get
            End Property

            Public Overrides Property PageSize As Size
                Get
                    Return _documentPaginator.PageSize
                End Get
                Set(value As Size)
                    _documentPaginator.PageSize = value
                End Set
            End Property

            Public Overrides Function GetPage(pageNumber As Integer) As DocumentPage

                Dim documentPage As DocumentPage = _documentPaginator.GetPage(_startPageIndex + pageNumber)

                ' Workaround for "FixedPageInPage" exception.
                If documentPage.Visual.GetType() Is GetType(FixedPage) Then

                    Dim fixedPage As FixedPage = documentPage.Visual
                    Dim containerVisual = New ContainerVisual()

                    For Each child As Object In fixedPage.Children
                        Dim childClone = CType(child.[GetType]().GetMethod("MemberwiseClone", BindingFlags.Instance Or BindingFlags.NonPublic).Invoke(child, Nothing), UIElement)
                        Dim parentField As FieldInfo = childClone.[GetType]().GetField("_parent", BindingFlags.Instance Or BindingFlags.NonPublic)

                        If parentField IsNot Nothing Then
                            parentField.SetValue(childClone, Nothing)
                            containerVisual.Children.Add(childClone)
                        End If
                    Next

                    Return New DocumentPage(containerVisual, documentPage.Size, documentPage.BleedBox, documentPage.ContentBox)

                End If

                Return documentPage

            End Function

        End Class
        ' </SampleCode2>

    End Class

End Namespace
