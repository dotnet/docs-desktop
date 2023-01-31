Class ExamplePage
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim buttonControl = DirectCast(e.Source, Button)
        buttonControl.Foreground = Brushes.Red
    End Sub
End Class
