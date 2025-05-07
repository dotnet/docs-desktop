Public Class Window1
    '<DialogResultButtons>
    Private Sub okButton_Click(sender As Object, e As RoutedEventArgs)
        DialogResult = True
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)
        DialogResult = False
    End Sub
    '</DialogResultButtons>

    Private Sub Method1()
        '<HandleClosing>
        Dim marginsWindow As New Margins

        AddHandler marginsWindow.Closed, Sub(sender As Object, e As EventArgs)
                                             MessageBox.Show($"You closed the margins window! It had the title of {marginsWindow.Title}")
                                         End Sub

        marginsWindow.Show()
        '</HandleClosing>
    End Sub

    Private Sub formatMarginsButton_Click(sender As Object, e As RoutedEventArgs)
        Method1()
    End Sub

    Private Sub Method2()
        '<HandleDialogResponse>
        Dim marginsWindow As New Margins

        Dim result As Boolean? = marginsWindow.ShowDialog()

        If result = True Then
            ' User accepted the dialog box
            MessageBox.Show("Your request will be processed.")
        Else
            ' User cancelled the dialog box
            MessageBox.Show("Sorry it didn't work out, we'll try again later.")
        End If

        marginsWindow.Show()
        '</HandleDialogResponse>
    End Sub
End Class
