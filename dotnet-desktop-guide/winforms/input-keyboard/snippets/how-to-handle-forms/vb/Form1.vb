Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()
        AddHandler Me.KeyPress, AddressOf Form1_KeyPress
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    '<HandleKey>
    ' Detect all numeric characters at the form level and consume 1, 4, and 7.
    ' Form.KeyPreview must be set to true for this event handler to be called.
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' pressed.")

            Select Case e.KeyChar
                Case "1"c, "4"c, "7"c
                    MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' consumed.")
                    e.Handled = True
            End Select
        End If

    End Sub
    '</HandleKey>

    ' <ProcessCmdKey>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Intercept Ctrl+A for custom handling
        If keyData = (Keys.Control Or Keys.A) Then
            MessageBox.Show("Ctrl+A intercepted at form level")
            Return True ' Mark as handled
        End If

        ' Pass other keys to the base handler
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    ' </ProcessCmdKey>

End Class