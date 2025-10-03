Imports System
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples
    ' <ITypedDataObjectImplementation>
    Public Class TypedDataObject
        Inherits DataObject
        Implements ITypedDataObject

        Public Overloads Function TryGetData(Of T)(format As String, ByRef data As T) As Boolean Implements ITypedDataObject.TryGetData
            ' Use new type-safe logic
            Return MyBase.TryGetData(format, data)
        End Function

        ' This overload requires BinaryFormatter support (not recommended)
        Public Overloads Function TryGetData(Of T)(format As String, resolver As Func(Of TypeName, Type), ByRef data As T) As Boolean
            data = Nothing
            Return False ' Simplified implementation for example
        End Function
    End Class
    ' </ITypedDataObjectImplementation>

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