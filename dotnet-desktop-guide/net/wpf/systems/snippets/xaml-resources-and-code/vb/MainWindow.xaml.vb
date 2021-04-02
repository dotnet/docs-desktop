Class MainWindow
    '<ButtonBrush>
    Private Sub myButton_Click(sender As Object, e As RoutedEventArgs)
        Dim buttonControl = DirectCast(sender, Button)
        buttonControl.Background = DirectCast(Me.FindResource("RainbowBrush"), Brush)
    End Sub
    '</ButtonBrush>
End Class
