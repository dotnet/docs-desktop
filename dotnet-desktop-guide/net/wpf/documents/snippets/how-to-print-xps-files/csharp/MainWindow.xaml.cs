using System;
using System.Collections.Generic;
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

            // Events.
            btnPrint.Click += BtnPrint_Click;
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
            var xpsFilePaths = Directory.GetFiles(path: txtFolderPath.Text, searchPattern: "*.xps");
            if (xpsFilePaths.Length == 0)
            {
                MessageBox.Show("No XPS files found.");
                return;
            }

            // Batch add a collection of XPS files to the print queue.
            // Run asynchronously to avoid blocking the UI thread.
            bool isAllPrinted = await BatchAddToPrintQueueAsync(xpsFilePaths);

            // Show result message.
            MessageBox.Show($"{(isAllPrinted ? "Added" : "Failed to add")} all documents to the print queue.");
        }

        // <SampleCode1>
        /// <summary>
        /// Batch add a collection of XPS documents to the print queue using the PrintQueue.AddJob method.
        /// The thread that calls PrintQueue.AddJob must have a single-threaded apartment state.
        /// </summary>
        /// <param name="xpsFilePaths">A collection of XPS documents.</param>
        /// <returns>Whether all documents were added to the print queue.</returns>
        public static async Task<bool> BatchAddToPrintQueueAsync(IEnumerable<string> xpsFilePaths)
        {
            bool isAllPrinted = true;

            // Queue some work to run on the ThreadPool.
            // Wait for completion without blocking the calling thread.
            await Task.Run(() =>
            {
                // Create a thread (single-threaded apartment) to call the PrintQueue.AddJob method.
                Thread newThread = new(() =>
                {
                    // To batch print without getting the "Save Output File As" dialog,
                    // ensure that your default printer is not Microsoft XPS Document Writer,
                    // Microsoft Print to PDF, or other print-to-file option.

                    // Get the default print queue.
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
                            // The thread that calls PrintQueue.AddJob must have a single-threaded apartment state.
                            PrintSystemJobInfo xpsPrintJob =
                                    defaultPrintQueue.AddJob(jobName: xpsFileName, documentPath: xpsFilePath, fastCopy: false);

                            // If the queue is not paused and the printer is working, then jobs will automatically begin printing.
                            Console.WriteLine($"Added {xpsFileName} to the print queue.");
                        }
                        catch (PrintJobException e)
                        {
                            isAllPrinted = false;
                            Console.WriteLine($"Failed to add {xpsFileName} to the print queue: {e.Message}");
                        }
                    }
                });

                // Set the thread to single-threaded apartment state.
                newThread.SetApartmentState(ApartmentState.STA);

                // Start the thread.
                newThread.Start();

                // Wait for thread completion. Blocks the calling thread,
                // which is we're running this on a ThreadPool thread.
                newThread.Join();
            });

            return isAllPrinted;
        }
        // </SampleCode1>
    }
}
