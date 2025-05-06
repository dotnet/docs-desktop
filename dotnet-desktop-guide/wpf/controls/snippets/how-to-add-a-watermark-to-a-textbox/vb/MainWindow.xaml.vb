Class MainWindow
    ' <code>
    Private Sub OnTextBoxTextChanged(sender As Object, e As TextChangedEventArgs)
        If TypeOf sender Is TextBox Then
            Dim box As TextBox = DirectCast(sender, TextBox)

            If String.IsNullOrEmpty(box.Text) Then
                box.Background = DirectCast(FindResource("watermark"), ImageBrush)
            Else
                box.Background = Nothing
            End If
        End If
    End Sub
    ' </code>
End Class
