Imports System.Collections.Specialized
Imports System.Drawing
Imports System.Windows.Forms

Namespace RetrieveClipboardData

    Public Class MainForm
        Inherits Form

        '<helper-methods>
        <Serializable()>
        Public Class Customer

            Private nameValue As String = String.Empty

            Public Sub New(ByVal name As String)
                nameValue = name
            End Sub

            Public Property Name() As String
                Get
                    Return nameValue
                End Get
                Set(ByVal value As String)
                    nameValue = value
                End Set
            End Property

        End Class
        '</helper-methods>

        Public Sub New()
            Clipboard.Clear()
        End Sub

        '<retrieve-custom-format>
        ' Demonstrates TryGetData using a custom format name and a business object.
        ' Note: In .NET 10, SetData for objects is no longer supported,
        ' so this example shows how to retrieve data that might have been
        ' set by other applications or earlier .NET versions.
        Public ReadOnly Property TestCustomFormat() As Customer
            Get
                Dim data As Object = Nothing
                ' For demonstration, we'll use string data instead of objects
                ' since SetData for objects is no longer supported in .NET 10
                If Clipboard.TryGetData("CustomerFormat", data) Then
                    Return TryCast(data, Customer)
                End If
                Return Nothing
            End Get
        End Property
        '</retrieve-custom-format>

        '<retrieve-multiple-formats>
        ' Demonstrates how to retrieve data from the Clipboard in multiple formats
        ' using TryGetData instead of the obsoleted GetData method.
        Public Sub TestClipboardMultipleFormats()

            Dim dataObject As IDataObject = Clipboard.GetDataObject()

            If dataObject IsNot Nothing Then

                ' Check for custom format
                If dataObject.GetDataPresent("CustomFormat") Then

                    Dim customData As Object = Nothing
                    If Clipboard.TryGetData("CustomFormat", customData) Then

                        Dim item As ListViewItem = TryCast(customData, ListViewItem)
                        If item IsNot Nothing Then
                            MessageBox.Show(item.Text)
                        ElseIf TypeOf customData Is String Then
                            MessageBox.Show(CStr(customData))
                        End If

                    End If

                End If

                ' Check for Customer type - note that object serialization
                ' through SetData is no longer supported in .NET 10
                If dataObject.GetDataPresent(GetType(Customer)) Then

                    Dim customerData As Object = Nothing
                    If Clipboard.TryGetData(GetType(Customer).FullName, customerData) Then

                        Dim customer As Customer = TryCast(customerData, Customer)
                        If customer IsNot Nothing Then
                            MessageBox.Show(customer.Name)
                        End If

                    End If

                End If

                ' For modern .NET 10 applications, prefer using standard formats
                If Clipboard.ContainsText() Then
                    Dim text As String = Clipboard.GetText()
                    MessageBox.Show($"Text data: {text}")
                End If

            End If

        End Sub
        '</retrieve-multiple-formats>

        '<retrieve-common-format>
        ' Demonstrates TryGetData methods for common formats.
        ' These methods are preferred over the older Get* methods.
        Public Function SwapClipboardAudio(ByVal replacementAudioStream As System.IO.Stream) As System.IO.Stream

            Dim returnAudioStream As System.IO.Stream = Nothing

            If Clipboard.ContainsAudio() Then
                returnAudioStream = Clipboard.GetAudioStream()
                Clipboard.SetAudio(replacementAudioStream)
            End If

            Return returnAudioStream

        End Function

        ' Demonstrates TryGetData for file drop lists
        Public Function SwapClipboardFileDropList(ByVal replacementList As StringCollection) As StringCollection

            Dim returnList As StringCollection = Nothing

            If Clipboard.ContainsFileDropList() Then
                returnList = Clipboard.GetFileDropList()
                Clipboard.SetFileDropList(replacementList)
            End If

            Return returnList

        End Function

        ' Demonstrates TryGetData for images
        Public Function SwapClipboardImage(ByVal replacementImage As Image) As Image

            Dim returnImage As Image = Nothing

            If Clipboard.ContainsImage() Then
                returnImage = Clipboard.GetImage()
                Clipboard.SetImage(replacementImage)
            End If

            Return returnImage

        End Function

        ' Demonstrates TryGetData for text in HTML format
        Public Function SwapClipboardHtmlText(ByVal replacementHtmlText As String) As String

            Dim returnHtmlText As String = Nothing

            If Clipboard.ContainsText(TextDataFormat.Html) Then
                returnHtmlText = Clipboard.GetText(TextDataFormat.Html)
                Clipboard.SetText(replacementHtmlText, TextDataFormat.Html)
            End If

            Return returnHtmlText

        End Function

        ' Example of using TryGetData for custom string-based data
        Public Function GetCustomStringData(ByVal format As String) As String

            Dim data As Object = Nothing
            If Clipboard.TryGetData(format, data) Then
                Return TryCast(data, String)
            End If

            Return Nothing

        End Function
        '</retrieve-common-format>

    End Class

End Namespace