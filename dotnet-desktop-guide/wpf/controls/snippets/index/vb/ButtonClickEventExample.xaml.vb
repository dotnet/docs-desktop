Imports System.Windows

Public Class ButtonClickEventExample
    ' <ClickHandler>
    Private Sub Submit_Click(sender As Object, e As Windows.RoutedEventArgs)
        MessageBox.Show("Someone clicked the submit button.")
    End Sub
    ' </ClickHandler>
End Class
