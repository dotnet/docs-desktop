'<full>
Imports System.Threading

Public Class MainWindow
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
    End Sub

    '<handler>
    Private Sub textBox1_KeyDown(sender As Object, e As System.Windows.Input.KeyEventArgs)

        If e.Key = Key.Return Then
            textBlock1.Text = "You Entered: " + textBox1.Text
        End If

    End Sub
    '</handler>
End Class
'</full>
