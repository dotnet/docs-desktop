Public Class Margins
    Private Sub okButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    '<CancelAndHide>
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        ' Cancel the closure
        e.Cancel = True

        ' Hide the window
        Hide()
    End Sub
    '</CancelAndHide>
End Class
