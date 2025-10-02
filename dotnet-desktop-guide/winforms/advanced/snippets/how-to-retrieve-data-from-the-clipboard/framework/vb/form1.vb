Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    '<helper-methods>
    <Serializable()> Public Class Customer

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
    ' Demonstrates SetData, ContainsData, and GetData
    ' using a custom format name and a business object.
    Public ReadOnly Property TestCustomFormat() As Customer
        Get
            Clipboard.SetData("CustomerFormat", New Customer("Customer Name"))

            If Clipboard.ContainsData("CustomerFormat") Then
                Return CType(Clipboard.GetData("CustomerFormat"), Customer)
            End If

            Return Nothing
        End Get
    End Property
    '</retrieve-custom-format>

    '<retrieve-multiple-formats>
    ' Demonstrates how to use a DataObject to add
    ' data to the Clipboard in multiple formats.
    Public Sub TestClipboardMultipleFormats()

        Dim data As New DataObject()

        ' Add a Customer object using the type as the format.
        data.SetData(New Customer("Customer as Customer object"))

        ' Add a ListViewItem object using a custom format name.
        data.SetData("CustomFormat", _
            New ListViewItem("Customer as ListViewItem"))

        Clipboard.SetDataObject(data)
        Dim retrievedData As DataObject = _
            CType(Clipboard.GetDataObject(), DataObject)

        If (retrievedData.GetDataPresent("CustomFormat")) Then

            Dim item As ListViewItem = _
                TryCast(retrievedData.GetData("CustomFormat"), ListViewItem)

            If item IsNot Nothing Then
                MessageBox.Show(item.Text)
            End If

        End If

        If retrievedData.GetDataPresent(GetType(Customer)) Then

            Dim customer As Customer = _
                CType(retrievedData.GetData(GetType(Customer)), Customer)

            If customer IsNot Nothing Then

                MessageBox.Show(customer.Name)
            End If

        End If

    End Sub
    '</retrieve-multiple-formats>

    ' Demonstrates SetData, ContainsData, and GetData.
    Public Function SwapClipboardFormattedData( _
        ByVal format As String, ByVal data As Object) As Object

        Dim returnObject As Object = Nothing

        If (Clipboard.ContainsData(format)) Then
            returnObject = Clipboard.GetData(format)
            Clipboard.SetData(format, data)
        End If

        Return returnObject

    End Function

    '<retrieve-common-format>
    ' Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    Public Function SwapClipboardAudio( _
        ByVal replacementAudioStream As System.IO.Stream) _
        As System.IO.Stream

        Dim returnAudioStream As System.IO.Stream = Nothing

        If (Clipboard.ContainsAudio()) Then
            returnAudioStream = Clipboard.GetAudioStream()
            Clipboard.SetAudio(replacementAudioStream)
        End If

        Return returnAudioStream

    End Function

    ' Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    Public Function SwapClipboardFileDropList(ByVal replacementList _
        As System.Collections.Specialized.StringCollection) _
        As System.Collections.Specialized.StringCollection

        Dim returnList As System.Collections.Specialized.StringCollection _
            = Nothing

        If Clipboard.ContainsFileDropList() Then

            returnList = Clipboard.GetFileDropList()
            Clipboard.SetFileDropList(replacementList)
        End If

        Return returnList

    End Function

    ' Demonstrates SetImage, ContainsImage, and GetImage.
    Public Function SwapClipboardImage( _
        ByVal replacementImage As System.Drawing.Image) _
        As System.Drawing.Image

        Dim returnImage As System.Drawing.Image = Nothing

        If Clipboard.ContainsImage() Then
            returnImage = Clipboard.GetImage()
            Clipboard.SetImage(replacementImage)
        End If

        Return returnImage

    End Function

    ' Demonstrates SetText, ContainsText, and GetText.
    Public Function SwapClipboardHtmlText( _
        ByVal replacementHtmlText As String) As String

        Dim returnHtmlText As String = Nothing

        If (Clipboard.ContainsText(TextDataFormat.Html)) Then
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html)
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html)
        End If

        Return returnHtmlText

    End Function
    '</retrieve-common-format>

End Class