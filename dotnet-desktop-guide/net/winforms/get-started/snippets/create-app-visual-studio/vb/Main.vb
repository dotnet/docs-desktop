Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrWhiteSpace(txtName.Text) And Not lstNames.Items.Contains(txtName.Text) Then
            lstNames.Items.Add(txtName.Text)
        End If
    End Sub
End Class
