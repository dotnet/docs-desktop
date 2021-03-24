Public Class Window1
    Private Sub formatMarginsButton_Click(sender As Object, e As RoutedEventArgs)
        '<ShowDialog>
        Dim myWindow As New Margins()

        myWindow.Owner = Me
        myWindow.ShowDialog()
        '</ShowDialog>
    End Sub

    Private Sub showMenus_Click(sender As Object, e As RoutedEventArgs)
        '<ShowNormal>
        Dim myWindow As New Margins()

        myWindow.Owner = Me
        myWindow.Show()
        '</ShowNormal>
    End Sub

    Private Sub okButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
