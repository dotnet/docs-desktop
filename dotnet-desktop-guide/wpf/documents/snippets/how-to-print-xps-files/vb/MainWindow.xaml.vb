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

            ' Determine whether XPS validation is needed.
            Dim fastCopy As Boolean = cbxValidateXps.IsChecked = False

            ' Batch add a collection of XPS files to the print queue.
            ' Run asynchronously to avoid blocking the UI thread.
            Dim isAllPrinted As Boolean = Await BatchAddToPrintQueueAsync(xpsFilePaths, fastCopy)

            ' Show result message.
            MessageBox.Show($"{If(isAllPrinted, "Added", "Failed to add")} all documents to the print queue.")

        End Sub

        ' <SampleCode1>
        ''' <summary>
        ''' Asyncronously, add a batch of XPS documents to the print queue using a PrintQueue.AddJob method.
        ''' Handle the thread apartment state required by the PrintQueue.AddJob method.
        ''' </summary>
        ''' <param name="xpsFilePaths">A collection of XPS documents.</param>
        ''' <param name="fastCopy">Whether to validate the XPS documents.</param>
        ''' <returns>Whether all documents were added to the print queue.</returns>
        Public Shared Async Function BatchAddToPrintQueueAsync(xpsFilePaths As IEnumerable(Of String), Optional fastCopy As Boolean = False) As Task(Of Boolean)

            Dim isAllPrinted As Boolean = True

            ' Queue some work to run on the ThreadPool.
            ' Wait for completion without blocking the calling thread.
            Await Task.Run(
                Sub()
                    If fastCopy Then
                        isAllPrinted = BatchAddToPrintQueue(xpsFilePaths, fastCopy)
                    Else
                        ' Create a thread to call the PrintQueue.AddJob method.
                        Dim newThread As New Thread(
                            Sub()
                                isAllPrinted = BatchAddToPrintQueue(xpsFilePaths, fastCopy)
                            End Sub
                        )

                        ' Set the thread to single-threaded apartment state.
                        newThread.SetApartmentState(ApartmentState.STA)

                        ' Start the thread.
                        newThread.Start()

                        ' Wait for thread completion. Blocks the calling thread,
                        ' which is a ThreadPool thread.
                        newThread.Join()
                    End If
                End Sub
            )

            Return isAllPrinted

        End Function

        ''' <summary>
        ''' Add a batch of XPS documents to the print queue using a PrintQueue.AddJob method.
        ''' </summary>
        ''' <param name="xpsFilePaths">A collection of XPS documents.</param>
        ''' <param name="fastCopy">Whether to validate the XPS documents.</param>
        ''' <returns>Whether all documents were added to the print queue.</returns>
        Public Shared Function BatchAddToPrintQueue(xpsFilePaths As IEnumerable(Of String), fastCopy As Boolean) As Boolean

            Dim isAllPrinted As Boolean = True

            ' To print without getting the "Save Output File As" dialog, ensure
            ' that your default printer is not the Microsoft XPS Document Writer,
            ' Microsoft Print to PDF, or other print-to-file option.

            ' Get a reference to the default print queue.
            Dim defaultPrintQueue As PrintQueue = LocalPrintServer.GetDefaultPrintQueue()

            ' Iterate through the document collection.
            For Each xpsFilePath As String In xpsFilePaths

                ' Get document name.
                Dim xpsFileName As String = Path.GetFileName(xpsFilePath)

                Try
                    ' The AddJob method adds a new print job for an XPS
                    ' document into the print queue, and assigns a job name.
                    ' Use fastCopy to skip XPS validation and progress notifications.
                    ' If fastCopy is false, the thread that calls PrintQueue.AddJob
                    ' must have a single-threaded apartment state.
                    Dim xpsPrintJob As PrintSystemJobInfo = defaultPrintQueue.AddJob(jobName:=xpsFileName, documentPath:=xpsFilePath, fastCopy)

                    ' If the queue is not paused and the printer is working, then jobs will automatically begin printing.
                    Debug.WriteLine($"Added {xpsFileName} to the print queue.")
                Catch e As PrintJobException
                    isAllPrinted = False
                    Debug.WriteLine($"Failed to add {xpsFileName} to the print queue: {e.Message}\r\n{e.InnerException}")
                End Try
            Next

            Return isAllPrinted

        End Function
        ' </SampleCode1>
    End Class

End Namespace
