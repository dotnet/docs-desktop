Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        '<CreateControl>
        Dim label1 As New Label With {.Text = "&First Name",
                                      .Location = New Point(10, 10),
                                      .TabIndex = 10}

        Dim field1 As New TextBox With {.Location = New Point(label1.Location.X,
                                                              label1.Bounds.Bottom + Padding.Top),
                                        .TabIndex = 11}

        Controls.Add(label1)
        Controls.Add(field1)
        '</CreateControl>
    End Sub

    '<HandlerViaCode>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Create and add the button
        Dim myNewButton As New Button() With {.Location = New Point(10, 10),
                                              .Size = New Size(120, 25),
                                              .Text = "Do work"}

        'Handle the Click event for the new button
        AddHandler myNewButton.Click, AddressOf MyNewButton_Click
        Me.Controls.Add(myNewButton)

        'Remove this button handler so the user cannot do this twice
        '<RemoveHandler>
        RemoveHandler Button1.Click, AddressOf Button1_Click
        '</RemoveHandler>
    End Sub

    Private Sub MyNewButton_Click(sender As Object, e As EventArgs)

    End Sub
    '</HandlerViaCode>
End Class
