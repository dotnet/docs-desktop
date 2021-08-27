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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Events
            btnBrowse.Click += BtnBrowse_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        /// <summary>
        /// Browse button click event handler
        /// Gets the path to a source XPS file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Configure an open file dialog box
            OpenFileDialog openFileDialog = new()
            {
                FileName = "Document", // Default file name
                DefaultExt = ".xps", // Default file extension
                Filter = "Text documents (.xps)|*.xps" // Filter files by extension
            };

            // Show open file dialog box
            bool? result = openFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Show selected XPS file path
                txtXpsFilePath.Text = openFileDialog.FileName;
            }
        }


        /// <summary>
        /// Print button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            // Check the file exists
            if (!File.Exists(txtXpsFilePath.Text))
            {
                MessageBox.Show("First select an XPS file.");
                return;
            }

            PrintFile(txtXpsFilePath.Text, hidePrintDialog: cbxHidePrintDialog.IsChecked == true);
        }

        /// <summary>
        /// Print an XPS document to OXPS format.
        /// Optionally, print all pages without showing a print dialog window.
        /// </summary>
        /// <param name="xpsFilePath">Path to source XPS file</param>
        /// <param name="hidePrintDialog">Whether to hide the print dialog window (shown by default)</param>
        // <SampleCode>
        private static void PrintFile(string xpsFilePath, bool hidePrintDialog = false)
        {
            // Create the print dialog object and set options
            PrintDialog printDialog = new();

            if (!hidePrintDialog)
            {
                // Display the dialog. This returns true if the user presses the Print button
                bool? isPrinted = printDialog.ShowDialog();
                if (isPrinted != true)
                    return;
            }

            // Print the document to an XPS or OXPS file
            try
            {
                // Open the selected file
                XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

                // Get a fixed document sequence for the selected file
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                // Create a paginator for all pages in the selected file
                DocumentPaginator docPaginator = fixedDocSeq.DocumentPaginator;

                // Print to a new file
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        // </SampleCode>

        /// <summary>
        /// Print an XPS document to OXPS format. Optionally, print a specific range
        /// of pages using a print dialog window, or all pages without the dialog.
        /// </summary>
        /// <param name="xpsFilePath">Path to source XPS file</param>
        /// <param name="useDialog">Whether to launch a Print Dialog</param>
        private static void PrintFileWithSpecificPages(string xpsFilePath, bool useDialog)
        {
            // Create the print dialog object and set options
            PrintDialog printDialog = new()
            {
                UserPageRangeEnabled = useDialog
            };

            // Display the dialog. This returns true if the user presses the Print button
            if (useDialog)
            {
                bool? isPrinted = printDialog.ShowDialog();
                if (isPrinted != true)
                    return;
            }

            // Print the document to an XPS or OXPS file
            try
            {
                // Open the selected file
                XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

                // Get a fixed document sequence for the selected file
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                // Create a paginator for all pages in the selected file
                DocumentPaginator docPaginator = fixedDocSeq.DocumentPaginator;

                // Check whether a page range was specified in the print dialog
                if (printDialog.PageRangeSelection == PageRangeSelection.UserPages)
                {
                    // Create a document paginator for the specified range of pages
                    docPaginator = new DocPaginator(fixedDocSeq.DocumentPaginator, printDialog.PageRange);
                }

                // Print to a new file
                printDialog.PrintDocument(docPaginator, $"Printing {Path.GetFileName(xpsFilePath)}");
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        /// <summary>
        /// Extend the abstract DocumentPaginator to support printing specific page ranges
        /// </summary>
        public class DocPaginator : DocumentPaginator
        {
            private readonly DocumentPaginator _documentPaginator;
            private readonly int _startPageIndex;
            private readonly int _endPageIndex;
            private readonly int _pageCount;

            public DocPaginator(DocumentPaginator documentPaginator, PageRange pageRange)
            {
                // Set document paginator
                _documentPaginator = documentPaginator;

                // Set page indices
                _startPageIndex = pageRange.PageFrom - 1;
                _endPageIndex = pageRange.PageTo - 1;

                // Validate and set page count
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

                // Workaround for "FixedPageInPage" exception
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
    }
}
