Public Class ChildWindow1
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' Create a window and make the current window its owner
        Dim ownedWindow As New ChildWindow1
        ownedWindow.Owner = Me
        ownedWindow.Show()
    End Sub
End Class
