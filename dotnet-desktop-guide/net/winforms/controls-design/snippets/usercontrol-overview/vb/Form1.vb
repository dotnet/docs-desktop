Public Class Form1
    '<event_handlers>
    Private Sub ctlFirstName_TextChanged(sender As Object, e As EventArgs) Handles ctlFirstName.TextChanged
        UpdateNameLabel()
    End Sub

    Private Sub ctlLastName_TextChanged(sender As Object, e As EventArgs) Handles ctlLastName.TextChanged
        UpdateNameLabel()
    End Sub
    '</event_handlers>

    '<load>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateNameLabel()
    End Sub
    '</load>

    '<update_label>
    Private Sub UpdateNameLabel()
        If String.IsNullOrWhiteSpace(ctlFirstName.Text) Or String.IsNullOrWhiteSpace(ctlLastName.Text) Then
            lblFullName.Text = "Please fill out both the first name and the last name."
        Else
            lblFullName.Text = $"Hello {ctlFirstName.Text} {ctlLastName.Text}, I hope you're having a good day."
        End If
    End Sub
    '</update_label>
End Class
