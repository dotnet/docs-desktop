Imports System.IO
Imports System.Printing
Imports System.Threading

Namespace CodeSampleVb
    Partial Public Class MainWindow
        Inherits Window

        ''' <summary>
        ''' Interaction logic for MainWindow.xaml
        ''' </summary>
        Public Sub New()

            InitializeComponent()

            ' Events.
            AddHandler btnPrint.Click, AddressOf BtnPrint_Click

        End Sub

        Private Async Sub BtnPrint_Click(sender As Object, e As RoutedEventArgs)

            '  Check that the folder exists.
            If Not Directory.Exists(txtFolderPath.Text) Then
                MessageBox.Show("First select a valid folder path.")
                Return
            End If

            ' Check whether any XPS files exist in the folder.
            Dim xpsFilePaths = Directory.GetFiles(path:=txtFolderPath.Text, searchPattern:="*.xps")
            If xpsFilePaths.Length = 0 Then
                MessageBox.Show("No XPS files found.")
                Return
            End If

            ' Batch add a collection of XPS files to the print queue.
            ' Run asynchronously to avoid blocking the UI thread.
            Dim isAllPrinted As Boolean = Await BatchAddToPrintQueueAsync(xpsFilePaths)

            ' Show result message.
            MessageBox.Show($"{If(isAllPrinted, "Added", "Failed to add")} all documents to the print queue.")

        End Sub


        ' <SampleCode1>
        ''' <summary>
        ''' Batch print a collection of XPS documents using the PrintQueue.AddJob method.
        ''' The thread that calls PrintQueue.AddJob must have a single-threaded apartment state.
        ''' </summary>
        ''' <param name="xpsFilePaths">A collection of XPS documents.</param>
        ''' <returns>Whether all documents were added to the print queue.</returns>
        Public Shared Async Function BatchAddToPrintQueueAsync(xpsFilePaths As IEnumerable(Of String)) As Task(Of Boolean)

            Dim isAllPrinted As Boolean = True

            ' Queue some work to run on the ThreadPool.
            ' Wait for completion without blocking the calling thread.
            Await Task.Run(
                Sub()
                    ' Create a thread (single-threaded apartment) to call the PrintQueue.AddJob method.
                    Dim newThread As New Thread(
                        Sub()
                            ' To batch print without getting the "Save Output File As" dialog,
                            ' ensure that your default printer Is Not Microsoft XPS Document Writer,
                            ' Microsoft Print to PDF, Or other print-to-file option.

                            ' Get the default print queue.
                            Dim defaultPrintQueue As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()

                            ' Iterate through the document collection.
                            For Each xpsFilePath As String In xpsFilePaths

                                ' Get document name.
                                Dim xpsFileName As String = Path.GetFileName(xpsFilePath)

                                Try
                                    ' The AddJob method adds a New print job for an XPS
                                    ' document into the print queue, And assigns a job name.
                                    ' Use fastCopy to skip XPS validation And progress notifications.
                                    ' The thread that calls PrintQueue.AddJob must have a single-threaded apartment state.
                                    Dim xpsPrintJob As PrintSystemJobInfo = defaultPrintQueue.AddJob(jobName:=xpsFileName, documentPath:=xpsFilePath, fastCopy:=False)
                                    Console.WriteLine($"Added {xpsFileName} to the print queue.")
                                Catch e As PrintJobException
                                    isAllPrinted = False
                                    ' If the queue is not paused and the printer is working, then jobs will automatically begin printing.
                                    Console.WriteLine($"Failed to add {xpsFileName} to the print queue: {e.Message}")
                                End Try
                            Next
                        End Sub
                    )

                    ' Set the thread to single-threaded apartment state.
                    newThread.SetApartmentState(ApartmentState.STA)

                    ' Start the thread.
                    newThread.Start()

                    ' Wait for thread completion. Blocks the calling thread,
                    ' which is we're running this on a ThreadPool thread.
                    newThread.Join()
                End Sub
            )

            Return isAllPrinted

        End Function

    End Class

End Namespace
