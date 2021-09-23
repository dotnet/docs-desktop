Imports System.IO
Imports System.Printing
Imports System.Windows.Xps
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

        End Sub

        Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)

            For Each printQueue As PrintQueue In GetPrintQueues()
                ' Add printers that have at least one relevant print options.
                Dim printCapabilites As PrintCapabilities = printQueue.GetPrintCapabilities()

                If printCapabilites.CollationCapability.Contains(Collation.Collated) _
                OrElse printCapabilites.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge) _
                OrElse printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft) Then
                    cmbPrinters.Items.Add(printQueue.Name)
                End If
            Next

            ' Select the first printer.
            If cmbPrinters.Items.Count > 0 Then cmbPrinters.SelectedIndex = 0

        End Sub

        Private Sub BtnBrowse_Click(sender As Object, e As RoutedEventArgs)

            ' Configure an open file dialog box.
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog() With {
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

            ' Check the XPS file exists.
            If Not File.Exists(txtXpsFilePath.Text) Then
                MessageBox.Show("First select an XPS file.")
                Return
            End If

            ' Get the print queue for the selected printer.
            Dim selectedPrintQueue As PrintQueue = GetPrintQueues().SingleOrDefault(Function(x) Equals(x.Name, cmbPrinters.SelectedItem.ToString()))

            ' Get a print ticket with modified print options for the selected printer.
            Dim printTicket As PrintTicket = GetPrintTicket(selectedPrintQueue)

            ' Send the XPS document to the selected printer.
            PrintXpsDocumentAsync(txtXpsFilePath.Text, selectedPrintQueue, printTicket)

            ' Show modified print options.
            Dim optionList As List(Of String) = New List(Of String)()
            If printTicket.Collation = Collation.Collated Then optionList.Add("Collated")
            If printTicket.Duplexing = Duplexing.TwoSidedLongEdge Then optionList.Add("TwoSidedLongEdge")
            If printTicket.Stapling = Stapling.StapleDualLeft Then optionList.Add("StapleDualLeft")
            Dim options = If(optionList.Count > 0, String.Join(", ", optionList), "None")

            ' Show result message.
            MessageBox.Show($"Sent {Path.GetFileName(txtXpsFilePath.Text)} to the printer.{vbCrLf}Print options: {options}")
        End Sub

        ' <GetPrintQueues>
        ''' <summary>
        ''' Return a collection of print queues, which individually hold the features or states
        ''' of a printer as well as common properties for all print queues.
        ''' </summary>
        ''' <returns>A collection of print queues.</returns>
        Public Shared Function GetPrintQueues() As PrintQueueCollection

            ' Create a LocalPrintServer instance, which represents 
            ' the print server for the local computer.
            Dim localPrintServer As LocalPrintServer = New LocalPrintServer()

            ' Get the default print queue on the local computer.
            'Dim  printQueue As PrintQueue = localPrintServer.DefaultPrintQueue

            ' Get all print queues on the local computer.
            Dim printQueueCollection As PrintQueueCollection = localPrintServer.GetPrintQueues()

            ' Return a collection of print queues, which individually hold the features or states
            ' of a printer as well as common properties for all print queues.
            Return printQueueCollection

        End Function
        ' </GetPrintQueues>

        ' <GetPrintTicket>
        ''' <summary>
        ''' Returns a print ticket, which is a set of instructions telling a printer how
        ''' to set its various features, such as duplexing, collating, and stapling.
        ''' </summary>
        ''' <param name="printQueue">The print queue to print to.</param>
        ''' <returns>A print ticket.</returns>
        Public Shared Function GetPrintTicket(printQueue As PrintQueue) As PrintTicket

            Dim printCapabilites As PrintCapabilities = printQueue.GetPrintCapabilities()

            ' Get a default print ticket from printer.
            Dim printTicket As PrintTicket = printQueue.DefaultPrintTicket

            ' Modify the print ticket.
            If printCapabilites.CollationCapability.Contains(Collation.Collated) Then
                printTicket.Collation = Collation.Collated
            End If
            If printCapabilites.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge) Then
                printTicket.Duplexing = Duplexing.TwoSidedLongEdge
            End If
            If printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft) Then
                printTicket.Stapling = Stapling.StapleDualLeft
            End If

            ' Returns a print ticket, which is a set of instructions telling a printer how
            ' to set its various features, such as duplexing, collating, and stapling.
            Return printTicket

        End Function
        ' </GetPrintTicket>

        ' <PrintXpsDocument>
        ''' <summary>
        ''' Asynchronously, add the XPS document together with a print ticket to the print queue.
        ''' </summary>
        ''' <param name="xpsFilePath">Path to source XPS file.</param>
        ''' <param name="printQueue">The print queue to print to.</param>
        ''' <param name="printTicket">The print ticket for the selected print queue.</param>
        Public Shared Sub PrintXpsDocumentAsync(xpsFilePath As String, printQueue As PrintQueue, printTicket As PrintTicket)

            ' Create an XpsDocumentWriter object for the print queue.
            Dim xpsDocumentWriter As XpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue)

            ' Open the selected document.
            Dim xpsDocument As XpsDocument = New XpsDocument(xpsFilePath, FileAccess.Read)

            ' Get a fixed document sequence for the selected document.
            Dim fixedDocSeq As FixedDocumentSequence = xpsDocument.GetFixedDocumentSequence()

            ' Asynchronously, add the XPS document together with a print ticket to the print queue.
            xpsDocumentWriter.WriteAsync(fixedDocSeq, printTicket)

        End Sub

        ''' <summary>
        ''' Synchronously, add the XPS document together with a print ticket to the print queue.
        ''' </summary>
        ''' <param name="xpsFilePath">Path to source XPS file.</param>
        ''' <param name="printQueue">The print queue to print to.</param>
        ''' <param name="printTicket">The print ticket for the selected print queue.</param>
        Public Shared Sub PrintXpsDocument(xpsFilePath As String, printQueue As PrintQueue, printTicket As PrintTicket)

            ' Create an XpsDocumentWriter object for the print queue.
            Dim xpsDocumentWriter As XpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue)

            ' Open the selected document.
            Dim xpsDocument As XpsDocument = New XpsDocument(xpsFilePath, FileAccess.Read)

            ' Get a fixed document sequence for the selected document.
            Dim fixedDocSeq As FixedDocumentSequence = xpsDocument.GetFixedDocumentSequence()

            ' Synchronously, add the XPS document together with a print ticket to the print queue.
            xpsDocumentWriter.Write(fixedDocSeq, printTicket)

        End Sub
        ' </PrintXpsDocument>

    End Class

End Namespace
