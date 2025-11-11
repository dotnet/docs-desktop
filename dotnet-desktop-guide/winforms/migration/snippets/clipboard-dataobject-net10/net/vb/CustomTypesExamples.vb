Imports System
Imports System.Text.Json.Serialization
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class CustomTypesExamples
        ' <SimpleCustomTypes>
        ' Simple classes serialize all public properties automatically.
        Public Class DocumentMetadata
            Public Property Title As String
            Public Property Created As DateTime
            Public Property Author As String
        End Class

        ' Structs with public properties work seamlessly.
        Public Structure Point3D
            Public Property X As Double
            Public Property Y As Double
            Public Property Z As Double
        End Structure
        ' </SimpleCustomTypes>

        ' <JsonAttributesExample>
        Public Class ClipboardFriendlyType
            ' Include a field that normally isn't serialized
            <JsonInclude>
            Private _privateData As Integer

            ' Public properties are always serialized
            Public Property Name As String

            ' Exclude sensitive or non-essential data
            <JsonIgnore>
            Public Property InternalId As String

            ' Handle property name differences for compatibility
            <JsonPropertyName("display_text")>
            Public Property DisplayText As String

            ' Control null value handling
            <JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingNull)>
            Public Property OptionalField As String
        End Class
        ' </JsonAttributesExample>

        ' <CustomTypesClipboardOperations>
        Public Shared Sub CustomTypesClipboardOperationsExample()
            Dim data As New ClipboardFriendlyType With {
                .Name = "Sample",
                .DisplayText = "Sample Display Text",
                .InternalId = "internal-123" ' This property isn't serialized due to <JsonIgnore>
            }

            Clipboard.SetDataAsJson("MyAppData", data)

            Dim retrieved As ClipboardFriendlyType = Nothing
            If Clipboard.TryGetData("MyAppData", retrieved) Then
                Console.WriteLine($"Retrieved: {retrieved.Name}")
                ' retrieved.InternalId is null because of <JsonIgnore>
            End If
        End Sub
        ' </CustomTypesClipboardOperations>
    End Class
End Namespace
