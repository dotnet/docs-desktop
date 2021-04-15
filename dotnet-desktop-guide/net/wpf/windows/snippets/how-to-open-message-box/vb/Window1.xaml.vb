Public Class Window1
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        '<YesNoCancel>
        Dim messageBoxText As String = "Do you want to save changes?"
        Dim caption As String = "Word Processor"
        Dim Button As MessageBoxButton = MessageBoxButton.YesNoCancel
        Dim Icon As MessageBoxImage = MessageBoxImage.Warning
        Dim result As MessageBoxResult

        '<MessageBoxShow>
        result = MessageBox.Show(messageBoxText, caption, Button, Icon, MessageBoxResult.Yes)
        '</YesNoCancel>

        Select Case result
            Case MessageBoxResult.Cancel
                ' User pressed Cancel
            Case MessageBoxResult.Yes
                ' User pressed Yes
            Case MessageBoxResult.No
                ' User pressed No
        End Select
        '</MessageBoxShow>
    End Sub

    Private Sub Button2_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Message to display to the user", "Window caption", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.RightAlign)
    End Sub

    Private Sub Alert_Click(sender As Object, e As RoutedEventArgs)
        '<AlertSimple>
        MessageBox.Show("Unable to save file, try again.")
        '</AlertSimple>
        '<Alert>
        MessageBox.Show("Unable to save file, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error)
        '</Alert>
    End Sub

    Private Sub Warning_Click(sender As Object, e As RoutedEventArgs)
        '<Warning>
        MessageBox.Show("If you close the next window without saving, your changes will be lost.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning)
        '</Warning>
    End Sub

    Private Sub Prompt_Click(sender As Object, e As RoutedEventArgs)
        '<Prompt>
        If MessageBox.Show("If the file save fails, do you want to automatically try again?",
                           "Save file",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Question) = MessageBoxResult.Yes Then

            ' Do something here

        End If
        '</Prompt>
    End Sub
End Class
