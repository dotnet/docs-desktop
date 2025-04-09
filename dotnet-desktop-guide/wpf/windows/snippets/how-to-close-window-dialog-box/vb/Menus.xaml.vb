Public Class Menus
    '<CloseDialog>
    Private Sub okButton_Click(sender As Object, e As RoutedEventArgs)
        DialogResult = True
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)
        DialogResult = False
    End Sub
    '</CloseDialog>

    '<CloseNormal>
    Private Sub closeButton_Click(sender As Object, e As RoutedEventArgs)
        Close()
    End Sub
    '</CloseNormal>

    '<Hide>
    Private Sub saveButton_Click(sender As Object, e As RoutedEventArgs)
        Hide()
    End Sub
    '</Hide>
End Class
