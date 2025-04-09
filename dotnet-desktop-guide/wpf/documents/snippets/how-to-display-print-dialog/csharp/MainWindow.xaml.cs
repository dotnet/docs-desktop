using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Events.
            btnBrowse.Click += BtnBrowse_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Configure an open file dialog box.
            OpenFileDialog openFileDialog = new()
            {
                FileName = "Document",
                DefaultExt = ".xps",
                Filter = "Text documents (.xps)|*.xps"
            };

            // Show open file dialog box.
            bool? result = openFileDialog.ShowDialog();

            // Process open file dialog box results.
            if (result == true)
            {
                // Show selected XPS file path.
                txtXpsFilePath.Text = openFileDialog.FileName;
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            // Check the file exists.
            if (!File.Exists(txtXpsFilePath.Text))
            {
                MessageBox.Show("First select an XPS file.");
                return;
            }

            // Get the print dialog visibility.
            bool hidePrintDialog = cbxHidePrintDialog.IsChecked == true;

            // Print whole document.
            bool isPrinted = PrintWholeDocument(txtXpsFilePath.Text, hidePrintDialog);
            MessageBox.Show($"PrintWholeDocument {(isPrinted ? "printed" : "failed to print")}.");

            // Print a specific range of document pages as specified in the print dialog.
            if (!hidePrintDialog)
            {
                isPrinted = PrintDocumentPageRange(txtXpsFilePath.Text);
                MessageBox.Show($"PrintDocumentPageRange {(isPrinted ? "printed" : "failed to print")}.");
            }
        }

        // <SampleCode1>
        /// <summary>
        /// Print all pages of an XPS document.
        /// Optionally, hide the print dialog window.
        /// </summary>
        /// <param name="xpsFilePath">Path to source XPS file</param>
        /// <param name="hidePrintDialog">Whether to hide the print dialog window (shown by default)</param>
        /// <returns>Whether the document printed</returns>
        public static bool PrintWholeDocument(string xpsFilePath, bool hidePrintDialog = false)
        {
            // Create the print dialog object and set options.
            PrintDialog printDialog = new();

            if (!hidePrintDialog)
            {
                // Display the dialog. This returns true if the user presses the Print button.
                bool? isPrinted = printDialog.ShowDialog();
                if (isPrinted != true)
                    return false;
            }

            // Print the whole document.
            try
            {
                // Open the selected document.
                XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

                // Get a fixed document sequence for the selected document.
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                // Create a paginator for all pages in the selected document.
                DocumentPaginator docPaginator = fixedDocSeq.DocumentPaginator;

                // Print to a new file.
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}");

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }
        // </SampleCode1>

        // <SampleCode2>
        /// <summary>
        /// Print a specific range of pages within an XPS document.
        /// </summary>
        /// <param name="xpsFilePath">Path to source XPS file</param>
        /// <returns>Whether the document printed</returns>
        public static bool PrintDocumentPageRange(string xpsFilePath)
        {
            // Create the print dialog object and set options.
            PrintDialog printDialog = new()
            {
                UserPageRangeEnabled = true
            };

            // Display the dialog. This returns true if the user presses the Print button.
            bool? isPrinted = printDialog.ShowDialog();
            if (isPrinted != true)
                return false;

            // Print a specific page range within the document.
            try
            {
                // Open the selected document.
                XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

                // Get a fixed document sequence for the selected document.
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                // Create a paginator for all pages in the selected document.
                DocumentPaginator docPaginator = fixedDocSeq.DocumentPaginator;

                // Check whether a page range was specified in the print dialog.
                if (printDialog.PageRangeSelection == PageRangeSelection.UserPages)
                {
                    // Create a document paginator for the specified range of pages.
                    docPaginator = new DocPaginator(fixedDocSeq.DocumentPaginator, printDialog.PageRange);
                }

                // Print to a new file.
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}");

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        /// <summary>
        /// Extend the abstract DocumentPaginator class to support page range printing. This class is based on the following online resources:
        ///
        /// https://www.thomasclaudiushuber.com/2009/11/24/wpf-printing-how-to-print-a-pagerange-with-wpfs-printdialog-that-means-the-user-can-select-specific-pages-and-only-these-pages-are-printed/
        ///
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/9180e260-0791-4f2d-962d-abcb22ba8d09/how-to-print-multiple-page-ranges-with-wpf-printdialog
        ///
        /// https://social.msdn.microsoft.com/Forums/en-US/841e804b-9130-4476-8709-0d2854c11582/exception-quotfixedpage-cannot-contain-another-fixedpagequot-when-printing-to-the-xps-document?forum=wpf
        /// </summary>
        public class DocPaginator : DocumentPaginator
        {
            private readonly DocumentPaginator _documentPaginator;
            private readonly int _startPageIndex;
            private readonly int _endPageIndex;
            private readonly int _pageCount;

            public DocPaginator(DocumentPaginator documentPaginator, PageRange pageRange)
            {
                // Set document paginator.
                _documentPaginator = documentPaginator;

                // Set page indices.
                _startPageIndex = pageRange.PageFrom - 1;
                _endPageIndex = pageRange.PageTo - 1;

                // Validate and set page count.
                if (_startPageIndex >= 0 &&
                    _endPageIndex >= 0 &&
                    _startPageIndex <= _documentPaginator.PageCount - 1 &&
                    _endPageIndex <= _documentPaginator.PageCount - 1 &&
                    _startPageIndex <= _endPageIndex)
                    _pageCount = _endPageIndex - _startPageIndex + 1;
            }

            public override bool IsPageCountValid => true;

            public override int PageCount => _pageCount;

            public override IDocumentPaginatorSource Source => _documentPaginator.Source;

            public override Size PageSize { get => _documentPaginator.PageSize; set => _documentPaginator.PageSize = value; }

            public override DocumentPage GetPage(int pageNumber)
            {
                DocumentPage documentPage = _documentPaginator.GetPage(_startPageIndex + pageNumber);

                // Workaround for "FixedPageInPage" exception.
                if (documentPage.Visual is FixedPage fixedPage)
                {
                    var containerVisual = new ContainerVisual();
                    foreach (object child in fixedPage.Children)
                    {
                        var childClone = (UIElement)child.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(child, null);

                        FieldInfo parentField = childClone.GetType().GetField("_parent", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (parentField != null)
                        {
                            parentField.SetValue(childClone, null);
                            containerVisual.Children.Add(childClone);
                        }
                    }

                    return new DocumentPage(containerVisual, documentPage.Size, documentPage.BleedBox, documentPage.ContentBox);
                }

                return documentPage;
            }
        }
        // </SampleCode2>
    }
}
