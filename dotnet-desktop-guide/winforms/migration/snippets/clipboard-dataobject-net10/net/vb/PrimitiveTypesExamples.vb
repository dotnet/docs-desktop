Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class PrimitiveTypesExamples
        ' <PrimitiveTypesExample>
        Public Shared Sub PrimitiveTypesExample()
            ' Numeric types
            Clipboard.SetData("MyInt", 42)
            Clipboard.SetData("MyDouble", 3.14159)
            Clipboard.SetData("MyDecimal", 123.45D)

            ' Text and character types
            Clipboard.SetData("MyString", "Hello World")
            Clipboard.SetData("MyChar", "A"c)

            ' Boolean and date/time types
            Clipboard.SetData("MyBool", True)
            Clipboard.SetData("MyDateTime", DateTime.Now)
            Clipboard.SetData("MyTimeSpan", TimeSpan.FromMinutes(30))

            ' Later retrieval with type safety
            Dim value As TimeSpan

            If Clipboard.TryGetData("MyTimeSpan", value) Then
                Console.WriteLine($"Clipboard value is: {value}")
            End If
        End Sub
        ' </PrimitiveTypesExample>

        ' <CollectionsExample>
        Public Shared Sub CollectionsExample()
            ' Arrays of primitive types
            Dim numbers As Integer() = {1, 2, 3, 4, 5}
            Clipboard.SetData("NumberArray", numbers)

            Dim coordinates As Double() = {1.0, 2.5, 3.7}
            Clipboard.SetData("Coordinates", coordinates)

            ' Generic lists
            Dim intList As New List(Of Integer) From {10, 20, 30}
            Clipboard.SetData("IntList", intList)

            ' Retrieval maintains type safety
            Dim retrievedNumbers As Integer() = Nothing

            If Clipboard.TryGetData("NumberArray", retrievedNumbers) Then
                Console.WriteLine($"Numbers: {String.Join(", ", retrievedNumbers)}")
            End If
        End Sub
        ' </CollectionsExample>
    End Class
End Namespace
