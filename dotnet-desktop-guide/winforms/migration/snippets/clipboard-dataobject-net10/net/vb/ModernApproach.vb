Imports System
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class ModernApproach
        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        ' <ModernTryGetData>
        Public Shared Sub ModernTryGetDataExample()
            Dim data As New Person With {.Name = "Alice", .Age = 30}
            Clipboard.SetDataAsJson("MyAppData", data)

            ' Use this - type-safe approach with TryGetData(Of T)()
            Dim person As Person = Nothing
            If Clipboard.TryGetData("MyApp.Person", person) Then
                ' person is guaranteed to be the correct type
                Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}")
            Else
                ' Handle the case where data isn't available or is the wrong type
                MessageBox.Show("Unable to retrieve person data from clipboard")
            End If
        End Sub
        ' </ModernTryGetData>
    End Class
End Namespace
