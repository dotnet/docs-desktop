Imports System
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class TypeResolver
        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        Public Class AppSettings
            Public Property Theme As String
            Public Property AutoSave As Boolean
        End Class

        Public Class MyType
            Public Property Data As String
        End Class

        ' <TypeResolverExample>
        Public Shared Sub TypeResolverExample()
            ' Create a type resolver that maps old type names to current types
            Dim resolver As Func(Of TypeName, Type) =
                Function(typeName)
                    ' Only allow specific, known, safe types
                    Select Case typeName.FullName
                        Case "MyApp.Person"
                            Return GetType(Person)
                        Case "MyApp.Settings"
                            Return GetType(AppSettings)
                        Case "System.String"
                            Return GetType(String)
                        Case "System.Int32"
                            Return GetType(Integer)
                        Case Else
                            Throw New InvalidOperationException($"Type not allowed: {typeName.FullName}")
                    End Select
                End Function

            ' Use the resolver with legacy binary data
            Dim person As Person = Nothing
            If Clipboard.TryGetData("LegacyFormat", resolver, person) Then
                Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}")
            End If

            ' Use a resolver with conversion control
            Dim data As MyType = Nothing
            If Clipboard.TryGetData("OldCustomData", resolver, data) Then
                Console.WriteLine($"Processing custom data: {data.Data}")
            End If
        End Sub
        ' </TypeResolverExample>
    End Class
End Namespace
