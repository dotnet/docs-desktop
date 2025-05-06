Public Class MainWindow
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        lblTimes.Content = Application.Current.Properties("NumberOfAppSessions")
    End Sub
End Class
