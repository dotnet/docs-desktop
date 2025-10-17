Imports System
Imports System.Collections.Generic
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class BinaryFormatterSupport
        <Serializable>
        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        <Serializable>
        Public Class AppSettings
            Public Property Theme As String
            Public Property AutoSave As Boolean
        End Class

        <Serializable>
        Public Class MyCustomType
            Public Property Data As String
        End Class

        ' <SecureTypeResolver>
        ' Create a security-focused type resolver
        Private Shared Function SecureTypeResolver(typeName As TypeName) As Type
            ' Explicit allow-list of permitted types—add only what you need
            Dim allowedTypes As New Dictionary(Of String, Type) From {
                {GetType(Person).FullName, GetType(Person)},
                {GetType(AppSettings).FullName, GetType(AppSettings)},
                {GetType(String).FullName, GetType(String)},
                {GetType(Integer).FullName, GetType(Integer)}
            }
            ' Add only the specific types your application requires

            ' Only allow explicitly listed types - exact string match required
            Dim allowedType As Type = Nothing
            If allowedTypes.TryGetValue(typeName.FullName, allowedType) Then
                Return allowedType
            End If

            ' Reject any type not in the allow-list with clear error message
            Throw New InvalidOperationException(
                $"Type '{typeName.FullName}' is not permitted for clipboard deserialization")
        End Function

        ' Use the resolver with clipboard operations
        Public Shared Sub UseSecureTypeResolver()
            Dim data As MyCustomType = Nothing
            If Clipboard.TryGetData("LegacyData", AddressOf SecureTypeResolver, data) Then
                Console.WriteLine($"Processing legacy data: {data.Data}")
            End If
        End Sub
        ' </SecureTypeResolver>
    End Class
End Namespace
