Imports System
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples

    Public Class DragDropExamples
        Public Class MyItem
            Public Property Name As String
            Public Property Value As String
        End Class

        ' <DragDropUsage>
        Private Sub OnDragDrop(sender As Object, e As DragEventArgs)
            If TypeOf e.Data Is ITypedDataObject Then
                Dim typedData As ITypedDataObject = CType(e.Data, ITypedDataObject)

                ' Retrieve files from drag data using a standard format
                Dim files As String() = Nothing
                If typedData.TryGetData(DataFormats.FileDrop, files) Then
                    ProcessDroppedFiles(files)
                End If

                ' Retrieve text using a standard format
                Dim text As String = Nothing
                If typedData.TryGetData(DataFormats.Text, text) Then
                    ProcessDroppedText(text)
                End If

                ' Retrieve custom items using an application-specific format
                Dim item As MyItem = Nothing
                If typedData.TryGetData("CustomItem", item) Then
                    ProcessCustomItem(item)
                End If
            End If
        End Sub
        ' </DragDropUsage>

        Private Sub ProcessDroppedFiles(files As String())
            Console.WriteLine($"Dropped files: {String.Join(", ", files)}")
        End Sub

        Private Sub ProcessDroppedText(text As String)
            Console.WriteLine($"Dropped text: {text}")
        End Sub

        Private Sub ProcessCustomItem(item As MyItem)
            Console.WriteLine($"Dropped custom item: {item.Name} = {item.Value}")
        End Sub
    End Class
End Namespace
