Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form2

    Public Sub New()
        InitializeComponent()
    End Sub

    '<MoveCursor>
    <Runtime.InteropServices.DllImport("USER32.DLL", EntryPoint:="SetCursorPos")>
    Public Shared Function SetCursorPos(x As Integer, y As Integer) As Boolean : End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim position As Point = PointToScreen(CheckBox1.Location) + New Size(CheckBox1.Width / 2, CheckBox1.Height / 2)
        SetCursorPos(position.X, position.Y)
    End Sub
    '</MoveCursor>
End Class
