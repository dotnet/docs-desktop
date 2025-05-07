Public Class Final
    '<FinalCode>
    Private Sub ButtonAddName_Click(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrWhiteSpace(txtName.Text) And Not lstNames.Items.Contains(txtName.Text) Then
            lstNames.Items.Add(txtName.Text)
        End If
    End Sub
    '</FinalCode>
End Class
