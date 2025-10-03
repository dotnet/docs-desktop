Imports System
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class TypeSafeRetrieval
        ' <BasicTypeSafeRetrieval>
        Public Shared Sub BasicTypeSafeRetrievalExamples()
            ' Retrieve text data using a standard format
            Dim textData As String = Nothing
            If Clipboard.TryGetData(DataFormats.Text, textData) Then
                ProcessTextData(textData)
            End If

            ' Retrieve an integer using a custom format
            Dim numberData As Integer
            If Clipboard.TryGetData("NumberData", numberData) Then
                ProcessNumber(numberData)
            End If

            ' Retrieve Unicode text using a standard format
            Dim unicodeText As String = Nothing
            If Clipboard.TryGetData(DataFormats.UnicodeText, unicodeText) Then
                ProcessUnicodeText(unicodeText)
            End If

            ' Retrieve raw text data with OLE conversion control
            Dim rawText As String = Nothing
            If Clipboard.TryGetData(DataFormats.Text, rawText) Then
                ProcessRawText(rawText)
            End If

            ' Retrieve file drops using a standard format
            Dim files As String() = Nothing
            If Clipboard.TryGetData(DataFormats.FileDrop, files) Then
                ProcessFiles(files)
            End If
        End Sub
        ' </BasicTypeSafeRetrieval>

        ' <CustomJsonTypes>
        Public Shared Sub CustomJsonTypesExamples()
            ' Retrieve a custom type stored with SetDataAsJson(Of T)()
            Dim person As Person = Nothing
            If Clipboard.TryGetData("Person", person) Then
                ProcessPerson(person)
            End If

            ' Retrieve application-specific data formats
            Dim settings As AppSettings = Nothing
            If Clipboard.TryGetData("MyApp.Settings", settings) Then
                ApplySettings(settings)
            End If

            ' Retrieve complex custom objects
            Dim doc As DocumentInfo = Nothing
            If Clipboard.TryGetData("DocumentData", doc) Then
                LoadDocument(doc)
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

        Private Shared Sub ProcessTextData(text As String)
            Console.WriteLine($"Text: {text}")
        End Sub

        Private Shared Sub ProcessNumber(number As Integer)
            Console.WriteLine($"Number: {number}")
        End Sub

        Private Shared Sub ProcessUnicodeText(text As String)
            Console.WriteLine($"Unicode: {text}")
        End Sub

        Private Shared Sub ProcessRawText(text As String)
            Console.WriteLine($"Raw: {text}")
        End Sub

        Private Shared Sub ProcessFiles(files As String())
            Console.WriteLine($"Files: {String.Join(", ", files)}")
        End Sub

        Private Shared Sub ProcessPerson(person As Person)
            Console.WriteLine($"Person: {person.Name}")
        End Sub

        Private Shared Sub ApplySettings(settings As AppSettings)
            Console.WriteLine($"Settings: {settings.Theme}")
        End Sub

        Private Shared Sub LoadDocument(doc As DocumentInfo)
            Console.WriteLine($"Document: {doc.Title}")
        End Sub
    End Class
End Namespace