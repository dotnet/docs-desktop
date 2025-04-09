using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PrintQueue printQueue in GetPrintQueues())
            {
                // Add printers that have at least one relevant print options.
                PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();
                if (printCapabilites.CollationCapability.Contains(Collation.Collated) ||
                    printCapabilites.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge) ||
                    printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft))
                    cmbPrinters.Items.Add(printQueue.Name);
            }

            // Select the first printer.
            if (cmbPrinters.Items.Count > 0) 
                cmbPrinters.SelectedIndex = 0;
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
            // Check the XPS file exists.
            if (!File.Exists(txtXpsFilePath.Text))
            {
                MessageBox.Show("First select an XPS file.");
                return;
            }

            // Get the print queue for the selected printer.
            PrintQueue selectedPrintQueue = GetPrintQueues().SingleOrDefault(x => Equals(x.Name, cmbPrinters.SelectedItem.ToString()));

            // Get a print ticket with modified print options for the selected printer.
            PrintTicket printTicket = GetPrintTicket(selectedPrintQueue);

            // Send the XPS document to the selected printer.
            PrintXpsDocumentAsync(txtXpsFilePath.Text, selectedPrintQueue, printTicket);

            // Show modified print options.
            List<string> optionList = new();
            if (printTicket.Collation == Collation.Collated)
                optionList.Add("Collated");
            if (printTicket.Duplexing == Duplexing.TwoSidedLongEdge)
                optionList.Add("TwoSidedLongEdge");
            if (printTicket.Stapling == Stapling.StapleDualLeft)
                optionList.Add("StapleDualLeft");
            var options = optionList.Count > 0 ? string.Join(", ", optionList) : "None";

            // Show result message.
            MessageBox.Show($"Sent {Path.GetFileName(txtXpsFilePath.Text)} to the printer.\r\nPrint options: {options}");
        }

        // <GetPrintQueues>
        /// <summary>
        /// Return a collection of print queues, which individually hold the features or states
        /// of a printer as well as common properties for all print queues.
        /// </summary>
        /// <returns>A collection of print queues.</returns>
        public static PrintQueueCollection GetPrintQueues()
        {
            // Create a LocalPrintServer instance, which represents 
            // the print server for the local computer.
            LocalPrintServer localPrintServer = new();

            // Get the default print queue on the local computer.
            //PrintQueue printQueue = localPrintServer.DefaultPrintQueue;

            // Get all print queues on the local computer.
            PrintQueueCollection printQueueCollection = localPrintServer.GetPrintQueues();

            // Return a collection of print queues, which individually hold the features or states
            // of a printer as well as common properties for all print queues.
            return printQueueCollection;
        }
        // </GetPrintQueues>

        // <GetPrintTicket>
        /// <summary>
        /// Returns a print ticket, which is a set of instructions telling a printer how
        /// to set its various features, such as duplexing, collating, and stapling.
        /// </summary>
        /// <param name="printQueue">The print queue to print to.</param>
        /// <returns>A print ticket.</returns>
        public static PrintTicket GetPrintTicket(PrintQueue printQueue)
        {
            PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();

            // Get a default print ticket from printer.
            PrintTicket printTicket = printQueue.DefaultPrintTicket;

            // Modify the print ticket.
            if (printCapabilites.CollationCapability.Contains(Collation.Collated))
                printTicket.Collation = Collation.Collated;
            if (printCapabilites.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge))
                printTicket.Duplexing = Duplexing.TwoSidedLongEdge;
            if (printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft))
                printTicket.Stapling = Stapling.StapleDualLeft;

            // Returns a print ticket, which is a set of instructions telling a printer how
            // to set its various features, such as duplexing, collating, and stapling.
            return printTicket;
        }
        // </GetPrintTicket>

        // <PrintXpsDocument>
        /// <summary>
        /// Asynchronously, add the XPS document together with a print ticket to the print queue.
        /// </summary>
        /// <param name="xpsFilePath">Path to source XPS file.</param>
        /// <param name="printQueue">The print queue to print to.</param>
        /// <param name="printTicket">The print ticket for the selected print queue.</param>
        public static void PrintXpsDocumentAsync(string xpsFilePath, PrintQueue printQueue, PrintTicket printTicket)
        {
            // Create an XpsDocumentWriter object for the print queue.
            XpsDocumentWriter xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);

            // Open the selected document.
            XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

            // Get a fixed document sequence for the selected document.
            FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

            // Asynchronously, add the XPS document together with a print ticket to the print queue.
            xpsDocumentWriter.WriteAsync(fixedDocSeq, printTicket);
        }

        /// <summary>
        /// Synchronously, add the XPS document together with a print ticket to the print queue.
        /// </summary>
        /// <param name="xpsFilePath">Path to source XPS file.</param>
        /// <param name="printQueue">The print queue to print to.</param>
        /// <param name="printTicket">The print ticket for the selected print queue.</param>
        public static void PrintXpsDocument(string xpsFilePath, PrintQueue printQueue, PrintTicket printTicket)
        {
            // Create an XpsDocumentWriter object for the print queue.
            XpsDocumentWriter xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);

            // Open the selected document.
            XpsDocument xpsDocument = new(xpsFilePath, FileAccess.Read);

            // Get a fixed document sequence for the selected document.
            FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

            // Synchronously, add the XPS document together with a print ticket to the print queue.
            xpsDocumentWriter.Write(fixedDocSeq, printTicket);
        }
        // </PrintXpsDocument>
    }
}
