Class MainWindow
    '<CreateStyleCode>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        'Create colors
        Dim purple = DirectCast(ColorConverter.ConvertFromString("#4E1A3D"), Color)
        Dim white = Colors.White
        Dim salmon = Colors.Salmon

        'Create a new style for a button
        Dim buttonStyle As New Style()

        'Set the properties of the style
        buttonStyle.Setters.Add(New Setter(Control.BackgroundProperty, New SolidColorBrush(purple)))
        buttonStyle.Setters.Add(New Setter(Control.ForegroundProperty, New SolidColorBrush(white)))
        buttonStyle.Setters.Add(New Setter(Control.BorderBrushProperty, New LinearGradientBrush(purple, salmon, 45D)))
        buttonStyle.Setters.Add(New Setter(Control.BorderThicknessProperty, New Thickness(5)))

        '<SetResource>
        'Set this style as a resource. Any DynamicResource looking for this key will be updated.
        Me.Resources("buttonStyle1") = buttonStyle
        '</SetResource>

        '<SetButtonStyle>
        'Set this style directly to a button
        DirectCast(sender, Button).Style = buttonStyle
        '</SetButtonStyle>

    End Sub
    '</CreateStyleCode>

    Private Sub ButtonFind_Click(sender As Object, e As RoutedEventArgs)
        Dim myButton As Button = DirectCast(sender, Button)

        '<FindResource>
        myButton.Style = myButton.TryFindResource("buttonStyle1")
        '</FindResource>
    End Sub

End Class
