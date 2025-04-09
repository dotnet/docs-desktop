Public Class Form2
    '<MultipleHandlers>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click
        'Do some work to handle the events
    End Sub
    '</MultipleHandlers>
End Class
