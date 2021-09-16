using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Printing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
        }

        private async void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            // Check that the folder exists.
            if (!Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show("First select a valid folder path.");
                return;
            }

            // Check whether any XPS files exist in the folder.
            string[] xpsFilePaths = Directory.GetFiles(path: txtFolderPath.Text, searchPattern: "*.xps");
            if (xpsFilePaths.Length == 0)
            {
                MessageBox.Show("No XPS files found.");
                return;
            }

            // Determine whether XPS validation is needed.
            bool fastCopy = cbxValidateXps.IsChecked == false;

            // Batch add a collection of XPS files to the print queue.
            // Run asynchronously to avoid blocking the UI thread.
            bool isAllPrinted = await BatchAddToPrintQueueAsync(xpsFilePaths, fastCopy);

            // Show result message.
            MessageBox.Show($"{(isAllPrinted ? "Added" : "Failed to add")} all documents to the print queue.");
        }

        // <SampleCode1>
        /// <summary>
        /// Asyncronously, add a batch of XPS documents to the print queue using a PrintQueue.AddJob method.
        /// Handle the thread apartment state required by the PrintQueue.AddJob method.
        /// </summary>
        /// <param name="xpsFilePaths">A collection of XPS documents.</param>
        /// <param name="fastCopy">Whether to validate the XPS documents.</param>
        /// <returns>Whether all documents were added to the print queue.</returns>
        public static async Task<bool> BatchAddToPrintQueueAsync(IEnumerable<string> xpsFilePaths, bool fastCopy = false)
        {
            bool allAdded = true;

            // Queue some work to run on the ThreadPool.
            // Wait for completion without blocking the calling thread.
            await Task.Run(() =>
            {
                if (fastCopy)
                    allAdded = BatchAddToPrintQueue(xpsFilePaths, fastCopy);
                else
                {
                    // Create a thread to call the PrintQueue.AddJob method.
                    Thread newThread = new(() =>
                    {
                        allAdded = BatchAddToPrintQueue(xpsFilePaths, fastCopy);
                    });

                    // Set the thread to single-threaded apartment state.
                    newThread.SetApartmentState(ApartmentState.STA);

                    // Start the thread.
                    newThread.Start();

                    // Wait for thread completion. Blocks the calling thread,
                    // which is a ThreadPool thread.
                    newThread.Join();
                }
            });

            return allAdded;
        }

        /// <summary>
        /// Add a batch of XPS documents to the print queue using a PrintQueue.AddJob method.
        /// </summary>
        /// <param name="xpsFilePaths">A collection of XPS documents.</param>
        /// <param name="fastCopy">Whether to validate the XPS documents.</param>
        /// <returns>Whether all documents were added to the print queue.</returns>
        public static bool BatchAddToPrintQueue(IEnumerable<string> xpsFilePaths, bool fastCopy)
        {
            bool allAdded = true;

            // To print without getting the "Save Output File As" dialog, ensure
            // that your default printer is not the Microsoft XPS Document Writer,
            // Microsoft Print to PDF, or other print-to-file option.

            // Get a reference to the default print queue.
            PrintQueue defaultPrintQueue = LocalPrintServer.GetDefaultPrintQueue();

            // Iterate through the document collection.
            foreach (string xpsFilePath in xpsFilePaths)
            {
                // Get document name.
                string xpsFileName = Path.GetFileName(xpsFilePath);

                try
                {
                    // The AddJob method adds a new print job for an XPS
                    // document into the print queue, and assigns a job name.
                    // Use fastCopy to skip XPS validation and progress notifications.
                    // If fastCopy is false, the thread that calls PrintQueue.AddJob
                    // must have a single-threaded apartment state.
                    PrintSystemJobInfo xpsPrintJob =
                            defaultPrintQueue.AddJob(jobName: xpsFileName, documentPath: xpsFilePath, fastCopy);

                    // If the queue is not paused and the printer is working, then jobs will automatically begin printing.
                    Debug.WriteLine($"Added {xpsFileName} to the print queue.");
                }
                catch (PrintJobException e)
                {
                    allAdded = false;
                    Debug.WriteLine($"Failed to add {xpsFileName} to the print queue: {e.Message}\r\n{e.InnerException}");
                }
            }

            return allAdded;
        }
        // </SampleCode1>
    }
}
