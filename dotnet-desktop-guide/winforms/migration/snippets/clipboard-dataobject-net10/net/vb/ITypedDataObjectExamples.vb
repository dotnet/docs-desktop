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
                    Console.WriteLine($"Dropped files: {String.Join(", ", files)}")
                End If

                ' Retrieve text using a standard format
                Dim text As String = Nothing
                If typedData.TryGetData(DataFormats.Text, text) Then
                    Console.WriteLine($"Dropped text: {text}")
                End If

                ' Retrieve custom items using an application-specific format
                Dim item As MyItem = Nothing
                If typedData.TryGetData("CustomItem", item) Then
                    Console.WriteLine($"Dropped custom item: {item.Name} = {item.Value}")
                End If
            End If
        End Sub
        ' </DragDropUsage>
    End Class
End Namespace
