Imports System
Imports System.Collections.Generic
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class SecureTypeResolverExample

        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        Public Class AppSettings
            Public Property Theme As String
            Public Property AutoSave As Boolean
        End Class

        ' <SecureTypeResolver>
        ' Create a security-focused type resolver
        Private Shared Function SecureTypeResolver(typeName As TypeName) As Type
            ' Explicit allow-list of permitted types—add only what you need
            Dim allowedTypes As New Dictionary(Of String, Type) From {
                {"MyApp.Person", GetType(Person)},
                {"MyApp.AppSettings", GetType(AppSettings)},
                {"System.String", GetType(String)},
                {"System.Int32", GetType(Integer)}
            } ' Add only the specific types your application requires

            ' Only allow explicitly listed types - exact string match required
            Dim allowedType As Type = Nothing
            If allowedTypes.TryGetValue(typeName.FullName, allowedType) Then
                Return allowedType
            End If

            ' Reject any type not in the allow-list with clear error message
            Throw New InvalidOperationException(
                $"Type '{typeName.FullName}' is not permitted for clipboard deserialization")
        End Function
        ' </SecureTypeResolver>

    End Class
End Namespace