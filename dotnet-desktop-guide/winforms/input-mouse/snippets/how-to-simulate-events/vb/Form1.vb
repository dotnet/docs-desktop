Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()

    End Sub

    '<ClickCheckbox>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InvokeOnClick(CheckBox1, EventArgs.Empty)
    End Sub
    '</ClickCheckbox>

    Private Sub SimulateButtonClick()
        '<PerformClick>
        Button1.PerformClick()
        '</PerformClick>
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

End Class
