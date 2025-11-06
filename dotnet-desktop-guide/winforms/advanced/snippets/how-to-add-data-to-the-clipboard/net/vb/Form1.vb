Imports System.Collections.Specialized
Imports System.IO

Public Class Form1

    Public Sub New()
        InitializeComponent()
        '<ClipboardClear>
        Clipboard.Clear()
        '</ClipboardClear>
    End Sub

    '<CustomerClass>
    'Customer class used in custom clipboard format examples.
    Public Class Customer

        Public Property Name As String

        Public Sub New(ByVal name As String)
            Me.Name = name
        End Sub

    End Class
    '</CustomerClass>

    '<SetTextExample>
    ' Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    Public Function SwapClipboardAudio(
        ByVal replacementAudioStream As Stream) As Stream

        Dim returnAudioStream As Stream = Nothing

        If Clipboard.ContainsAudio() Then
            returnAudioStream = Clipboard.GetAudioStream()
            Clipboard.SetAudio(replacementAudioStream)
        End If

        Return returnAudioStream

    End Function

    ' Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    Public Function SwapClipboardFileDropList(ByVal replacementList As StringCollection) As StringCollection

        Dim returnList As StringCollection = Nothing

        If Clipboard.ContainsFileDropList() Then
            returnList = Clipboard.GetFileDropList()
            Clipboard.SetFileDropList(replacementList)
        End If

        Return returnList

    End Function

    ' Demonstrates SetImage, ContainsImage, and GetImage.
    Public Function SwapClipboardImage(
        ByVal replacementImage As Image) As Image

        Dim returnImage As Image = Nothing

        If Clipboard.ContainsImage() Then
            returnImage = Clipboard.GetImage()
            Clipboard.SetImage(replacementImage)
        End If

        Return returnImage
    End Function

    ' Demonstrates SetText, ContainsText, and GetText.
    Public Function SwapClipboardHtmlText(
        ByVal replacementHtmlText As String) As String

        Dim returnHtmlText As String = Nothing

        If Clipboard.ContainsText(TextDataFormat.Html) Then
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html)
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html)
        End If

        Return returnHtmlText

    End Function
    '</SetTextExample>

    '<CustomFormatExample>
    ' Demonstrates SetData, ContainsData, and GetData
    ' using a custom format name and a business object.
    Public ReadOnly Property TestCustomFormat() As Customer
        Get
            Clipboard.SetDataAsJson("CustomerFormat", New Customer("Customer Name"))

            If Clipboard.ContainsData("CustomerFormat") Then
                Dim customerData As Customer = Nothing

                If Clipboard.TryGetData("CustomerFormat", customerData) Then
                    Return customerData
                End If

            End If

            Return Nothing
        End Get
    End Property
    '</CustomFormatExample>

    '<MultipleFormatsExample>
    ' Demonstrates how to use a DataObject to add
    ' data to the Clipboard in multiple formats.
    Public Sub TestClipboardMultipleFormats()

        Dim data As New DataObject()

        Dim customer As New Customer("Customer #2112")
        Dim listViewItem As New ListViewItem($"Customer as ListViewItem {customer.Name}")

        ' Add a Customer object using the type as the format.
        data.SetDataAsJson(customer)

        ' Add a ListViewItem object using a custom format name.
        data.SetDataAsJson("ListViewItemFormat", listViewItem.Text)

        Clipboard.SetDataObject(data)

        ' Retrieve the data from the Clipboard.
        Dim retrievedData As DataObject = CType(Clipboard.GetDataObject(), DataObject)

        If retrievedData.GetDataPresent("ListViewItemFormat") Then
            Dim item As String = Nothing

            If retrievedData.TryGetData("ListViewItemFormat", item) Then
                Dim recreatedListViewItem As New ListViewItem(item)
                MessageBox.Show($"Data contains ListViewItem with text of {recreatedListViewItem.Text}")
            End If

        End If

        If retrievedData.GetDataPresent(GetType(Customer)) Then
            Dim newCustomer As Customer = Nothing

            If retrievedData.TryGetData(newCustomer) Then
                MessageBox.Show($"Data contains Customer with name of {newCustomer.Name}")
            End If

        End If

    End Sub
    '</MultipleFormatsExample>

    '<GenericSetDataExample>
    ' Demonstrates SetData, ContainsData, and GetData.
    Public Function SwapClipboardFormattedData(
        ByVal format As String, ByVal data As Object) As Object

        Dim returnObject As Object = Nothing

        If Clipboard.ContainsData(format) Then
            returnObject = Clipboard.GetData(format)
            Clipboard.SetData(format, data)
        End If

        Return returnObject

    End Function
    '</GenericSetDataExample>

End Class
