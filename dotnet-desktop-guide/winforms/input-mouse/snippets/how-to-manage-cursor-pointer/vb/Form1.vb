Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '<SetControlCursor>
        Button2.Cursor = System.Windows.Forms.Cursors.Hand
        '</SetControlCursor>
    End Sub

    '<MoveCursor>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PointToScreen(Button2.Location)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PointToScreen(Button1.Location)
    End Sub
    '</MoveCursor>

    '<ShowHideCursor>
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Cursor.Hide()
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Cursor.Show()
    End Sub
    '</ShowHideCursor>

End Class
