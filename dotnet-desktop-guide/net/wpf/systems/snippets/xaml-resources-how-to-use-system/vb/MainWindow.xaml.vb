Class MainWindow
    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        ' <SystemFont>
        Dim myButton = New Button() With
        {
            .Content = "SystemFonts",
            .Background = SystemColors.ControlDarkDarkBrush,
            .FontSize = SystemFonts.IconFontSize,
            .FontWeight = SystemFonts.MessageFontWeight,
            .FontFamily = SystemFonts.CaptionFontFamily
        }

        mainStackPanel.Children.Add(myButton)
        ' </SystemFont>
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        ' <SystemParams>
        Dim myButton = New Button() With
        {
            .Content = "SystemParameters",
            .FontSize = 8,
            .Background = SystemColors.ControlDarkDarkBrush,
            .Height = SystemParameters.CaptionHeight,
            .Width = SystemParameters.CaptionWidth
        }

        mainStackPanel.Children.Add(myButton)
        ' </SystemParams>
    End Sub
End Class
