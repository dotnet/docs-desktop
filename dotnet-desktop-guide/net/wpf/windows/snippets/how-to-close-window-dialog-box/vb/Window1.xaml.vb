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

    Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
        '<SaveFile>
        ' Configure save file dialog box
        Dim dialog As New Microsoft.Win32.SaveFileDialog()
        dialog.FileName = "Document" ' Default file name
        dialog.DefaultExt = ".txt" ' Default file extension
        dialog.Filter = "Text documents (.txt)|*.txt" ' Filter files by extension

        ' Show save file dialog box
        Dim result As Boolean? = dialog.ShowDialog()

        ' Process save file dialog box results
        If result = True Then
            ' Save document
            Dim filename As String = dialog.FileName
        End If
        '</SaveFile>
    End Sub

    Private Sub Open_Click(sender As Object, e As RoutedEventArgs)
        '<OpenFile>
        ' Configure open file dialog box
        Dim dialog As New Microsoft.Win32.OpenFileDialog()
        dialog.FileName = "Document" ' Default file name
        dialog.DefaultExt = ".txt" ' Default file extension
        dialog.Filter = "Text documents (.txt)|*.txt" ' Filter files by extension

        ' Show open file dialog box
        Dim result As Boolean? = dialog.ShowDialog()

        ' Process open file dialog box results
        If result = True Then
            ' Open document
            Dim filename As String = dialog.FileName
        End If
        '</OpenFile>
    End Sub

    Private Sub Print_Click(sender As Object, e As RoutedEventArgs)
        '<Print>
        ' Configure printer dialog box
        Dim dialog As New System.Windows.Controls.PrintDialog()
        dialog.PageRangeSelection = System.Windows.Controls.PageRangeSelection.AllPages
        dialog.UserPageRangeEnabled = True

        ' Show save file dialog box
        Dim result As Boolean? = dialog.ShowDialog()

        ' Process save file dialog box results
        If result = True Then
            ' Print document
        End If
        '</Print>
    End Sub
End Class
