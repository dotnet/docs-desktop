Public Class Window1
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        '<YesNoCancel>
        Dim messageBoxText As String = "Do you want to save changes?"
        Dim caption As String = "Word Processor"
        Dim Button As MessageBoxButton = MessageBoxButton.YesNoCancel
        Dim Icon As MessageBoxImage = MessageBoxImage.Warning
        Dim result As MessageBoxResult

        '<MessageBoxShow>
        result = MessageBox.Show(messageBoxText, caption, Button, Icon)
        '</YesNoCancel>

        '</MessageBoxShow>
    End Sub
End Class
