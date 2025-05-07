Public Class Window1
    '<GetMainWindow>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show($"The main window's title is: {Application.Current.MainWindow.Title}")
    End Sub
    '</GetMainWindow>
End Class
