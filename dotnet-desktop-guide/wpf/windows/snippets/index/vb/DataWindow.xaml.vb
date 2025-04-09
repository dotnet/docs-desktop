Public Class DataWindow

    Private _isDataDirty As Boolean

    Private Sub documentTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        _isDataDirty = True
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)

        ' If data is dirty, prompt user and ask for a response
        If _isDataDirty Then
            Dim result = MessageBox.Show("Document has changed. Close without saving?",
                                         "Question",
                                         MessageBoxButton.YesNo)

            ' User doesn't want to close, cancel closure
            If result = MessageBoxResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub
End Class
