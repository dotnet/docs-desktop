Imports System
Imports System.Windows.Forms

Namespace ClipboardExamples
    ' Examples of obsolete patterns that no longer work in .NET 10
    Public Class ObsoletePatterns
        ' <ObsoleteCustomType>
        <Serializable>
        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        Public Shared Sub BrokenCustomTypeExample()
            ' This worked in .NET 8 and earlier but silently fails starting with .NET 9
            Dim person As New Person With {.Name = "John", .Age = 30}
            Clipboard.SetData("MyApp.Person", person)  ' No data is stored

            ' Later attempts to retrieve the data return a NotSupportedException instance
            Dim data As Object = Clipboard.GetData("MyApp.Person")
        End Sub
        ' </ObsoleteCustomType>

        ' <ObsoleteGetData>
        Public Shared Sub ObsoleteGetDataExample()
            ' Don't use - GetData() is obsolete in .NET 10
            Dim data As Object = Clipboard.GetData("MyApp.Person")  ' Obsolete method

            ' Returns a NotSupportedException instance for a custom object type
            If data IsNot Nothing Then
                Dim person As Person = CType(data, Person)
                Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}")
            End If
        End Sub
        ' </ObsoleteGetData>
    End Class
End Namespace
