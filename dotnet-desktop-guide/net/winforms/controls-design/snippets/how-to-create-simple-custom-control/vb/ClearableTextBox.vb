'<default_event>
Imports System.ComponentModel

<DefaultEvent("TextChanged")>
Public Class ClearableTextBox
    '</default_event>
    '<text_changed>
    <Browsable(True)>
    Public Shadows Custom Event TextChanged As EventHandler
        AddHandler(value As EventHandler)
            AddHandler txtValue.TextChanged, value
        End AddHandler
        RemoveHandler(value As EventHandler)
            RemoveHandler txtValue.TextChanged, value
        End RemoveHandler
        RaiseEvent(sender As Object, e As EventArgs)

        End RaiseEvent
    End Event
    '</text_changed>

    '<text>
    <Browsable(True)>
    Public Shadows Property Text() As String
        Get
            Return txtValue.Text
        End Get
        Set(value As String)
            txtValue.Text = value
        End Set
    End Property
    '</text>

    '<title>
    <Browsable(True)>
    Public Property Title() As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property
    '</title>

    '<click_event>
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        txtValue.Text = ""
    End Sub
    '</click_event>
End Class
