Imports System.ComponentModel

<DefaultEvent("TextChanged")>
Public Class ClearableTextBox

    Private _mother As Person

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

    <Browsable(True)>
    Public Shadows Property Text() As String
        Get
            Return txtValue.Text
        End Get
        Set(value As String)
            txtValue.Text = value
        End Set
    End Property

    <Browsable(True)>
    Public Property Title() As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    '<property>
    <Browsable(False)>
    Public Property Mother As Person
        Get
            Return _mother
        End Get
        Set(value As Person)
            _mother = value
        End Set
    End Property
    '</property>

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        txtValue.Text = ""
    End Sub

    Public Class Person
        Public Property FirstName As String
        Public Property LastName As String
    End Class
End Class
