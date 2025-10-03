Imports System
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class SetDataAsJsonExamples
        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        Public Class AppSettings
            Public Property Theme As String
            Public Property AutoSave As Boolean
        End Class

        ' <AutomaticFormatInference>
        Public Shared Sub AutomaticFormatInferenceExample()
            Dim person As New Person With {.Name = "Alice", .Age = 25}

            ' The format is automatically inferred from the type name
            Clipboard.SetDataAsJson("Person", person)  ' Uses "Person" as the format

            ' Retrieve the data later
            Dim retrievedPerson As Person = Nothing
            If Clipboard.TryGetData("Person", retrievedPerson) Then
                Console.WriteLine($"Retrieved: {retrievedPerson.Name}")
            End If
        End Sub
        ' </AutomaticFormatInference>

        ' <CustomFormat>
        Public Shared Sub CustomFormatExample()
            Dim settings As New AppSettings With {.Theme = "Dark", .AutoSave = True}

            ' Use a custom format for better organization
            Clipboard.SetDataAsJson("MyApp.Settings", settings)

            ' Store the same data in multiple formats
            Clipboard.SetDataAsJson("Config.V1", settings)
            Clipboard.SetDataAsJson("AppConfig", settings)
        End Sub
        ' </CustomFormat>
    End Class
End Namespace