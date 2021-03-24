Public Class Margins
    Private Sub okButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    '<CancelAndHide>
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        'First, cancel the window closure
        e.Cancel = True

        'Next, hide the window
        Hide()
    End Sub
    '</CancelAndHide>
End Class
