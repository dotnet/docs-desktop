Imports System.Windows.Forms
Imports System.Drawing

'<RollbackForm>
Partial Public Class Form1

    Private _initialStyle As FormBorderStyle
    Private _isDoubleClicking As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim button1 As New DoubleClickButton

        _initialStyle = FormBorderStyle

        button1.Location = New Point(50, 50)
        button1.Size = New Size(200, 23)
        button1.Text = "Click or Double Click"

        AddHandler button1.Click, AddressOf Button1_Click
        AddHandler button1.DoubleClick, AddressOf Button1_DoubleClick

        Controls.Add(button1)

    End Sub

    Private Sub Button1_DoubleClick(sender As Object, e As EventArgs)
        ' This flag prevents the click handler logic from running
        ' A double click raises the click event twice.
        _isDoubleClicking = True
        FormBorderStyle = _initialStyle
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If _isDoubleClicking Then
            _isDoubleClicking = False
        Else
            FormBorderStyle = FormBorderStyle.FixedToolWindow
        End If
    End Sub
End Class
'</RollbackForm>
