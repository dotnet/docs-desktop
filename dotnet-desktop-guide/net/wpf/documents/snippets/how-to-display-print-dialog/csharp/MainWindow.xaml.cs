using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Configure an open file dialog box
            OpenFileDialog openFileDialog = new()
            {
                FileName = "Document", // Default file name
                DefaultExt = ".xps", // Default file extension
                Filter = "Text documents (.xps)|*.xps" // Filter files by extension
            };

            // Show open file dialog box.
            bool? result = openFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Show selected XPS file path
                txtXpsFilePath.Text = openFileDialog.FileName;
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            // Check the file exists
            if (!File.Exists(txtXpsFilePath.Text))
            {
                _ = MessageBox.Show("First select an XPS file.");
                return;
            }

            // Create the print dialog object and set options
            PrintDialog printDialog = new()
            {
                PageRangeSelection = PageRangeSelection.AllPages,
                UserPageRangeEnabled = true
            };

            // Display the dialog. This returns true if the user presses the Print button
            bool? isPrinted = printDialog.ShowDialog();
            if (isPrinted != true)
            {
                return;
            }

            // Print the document to an XPS or OXPS file
            try
            {
                // Open the selected file
                XpsDocument xpsDocument = new(txtXpsFilePath.Text, FileAccess.Read);

                // Support creation of multiple-page elements
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                // Launch a 'Save Print Output As' dialog, and then print to the specified output file
                printDialog.PrintDocument(fixedDocSeq.DocumentPaginator, $"Printing {Path.GetFileName(txtXpsFilePath.Text)}");
            }
            catch (Exception e2)
            {
                _ = MessageBox.Show(e2.Message);
            }
        }
    }
}
