Imports System
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class TypeSafeRetrieval
        ' <BasicTypeSafeRetrieval>
        Public Shared Sub BasicTypeSafeRetrievalExamples()
            ' Retrieve text data using a standard format
            Dim textData As String = Nothing
            If Clipboard.TryGetData(DataFormats.Text, textData) Then
                Console.WriteLine($"Text: {textData}")
            End If

            ' Retrieve an integer using a custom format
            Dim numberData As Integer
            If Clipboard.TryGetData("NumberData", numberData) Then
                Console.WriteLine($"Number: {numberData}")
            End If

            ' Retrieve Unicode text using a standard format
            Dim unicodeText As String = Nothing
            If Clipboard.TryGetData(DataFormats.UnicodeText, unicodeText) Then
                Console.WriteLine($"Unicode: {unicodeText}")
            End If

            ' Retrieve raw text data with OLE conversion control
            Dim rawText As String = Nothing
            If Clipboard.TryGetData(DataFormats.Text, rawText) Then
                Console.WriteLine($"Raw: {rawText}")
            End If

            ' Retrieve file drops using a standard format
            Dim files As String() = Nothing
            If Clipboard.TryGetData(DataFormats.FileDrop, files) Then
                Console.WriteLine($"Files: {String.Join(", ", files)}")
            End If
        End Sub
        ' </BasicTypeSafeRetrieval>

        ' <CustomJsonTypes>
        Public Shared Sub CustomJsonTypesExamples()
            ' Retrieve a custom type stored with SetDataAsJson(Of T)()
            Dim person As Person = Nothing
            If Clipboard.TryGetData("Person", person) Then
                Console.WriteLine($"Person: {person.Name}")
            End If

            ' Retrieve application-specific data formats
            Dim settings As AppSettings = Nothing
            If Clipboard.TryGetData("MyApp.Settings", settings) Then
                Console.WriteLine($"Settings: {settings.Theme}")
            End If

            ' Retrieve complex custom objects
            Dim doc As DocumentInfo = Nothing
            If Clipboard.TryGetData("DocumentData", doc) Then
                Console.WriteLine($"Document: {doc.Title}")
            End If
        End Sub
        ' </CustomJsonTypes>

        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        Public Class AppSettings
            Public Property Theme As String
            Public Property AutoSave As Boolean
        End Class

        Public Class DocumentInfo
            Public Property Title As String
            Public Property Author As String
            Public Property Created As DateTime
        End Class
    End Class
End Namespace
