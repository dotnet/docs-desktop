Imports System
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class ClipboardUsageExample

        Public Class MyCustomType
            Public Property Data As String
        End Class

        ' <ClipboardUsage>
        ' Use the resolver with clipboard operations
        Private Shared Function SecureTypeResolver(typeName As TypeName) As Type
            ' Implementation from SecureTypeResolver example
            ' ... (allow-list implementation here)
            Throw New InvalidOperationException($"Type '{typeName.FullName}' is not permitted")
        End Function

        Public Shared Sub UseSecureTypeResolver()
            ' Retrieve legacy data using the secure type resolver
            Dim data As MyCustomType = Nothing
            If Clipboard.TryGetData("LegacyData", AddressOf SecureTypeResolver, data) Then
                ProcessLegacyData(data)
            Else
                Console.WriteLine("No compatible data found on clipboard")
            End If
        End Sub
        ' </ClipboardUsage>

        Private Shared Sub ProcessLegacyData(data As MyCustomType)
            Console.WriteLine($"Processing legacy data: {data.Data}")
        End Sub

    End Class
End Namespace