Public Class Window3
    '<RemoveControl>
    Private Sub RemoveThis_Click(sender As Object, e As RoutedEventArgs)
        Dim element = DirectCast(e.Source, FrameworkElement)

        If buttonContainer.Children.Contains(element) Then
            buttonContainer.Children.Remove(element)
        End If
    End Sub
    '</RemoveControl>
End Class
