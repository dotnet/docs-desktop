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
            ' Use this - type-safe approach with TryGetData(Of T)()
            Dim person As Person = Nothing
            If Clipboard.TryGetData("MyApp.Person", person) Then
                ProcessPerson(person)  ' person is guaranteed to be the correct type
            Else
                ' Handle the case where data isn't available or is the wrong type
                ShowError("Unable to retrieve person data from clipboard")
            End If
        End Sub
        ' </ModernTryGetData>

        Private Shared Sub ProcessPerson(person As Person)
            Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}")
        End Sub

        Private Shared Sub ShowError(message As String)
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
    End Class
End Namespace