Option Explicit On
Imports System.Windows.Media.Effects

Class MainWindow
    '<Reflection>
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim container As New StackPanel With {.Height = 400, .Margin = New Thickness(25)}

        ' Visual Element that will be reflected
        Dim visualElement As New Border With {
            .Width = 400,
            .Background = New LinearGradientBrush(
                                            ColorConverter.ConvertFromString("#CCCCFF"),
                                            Colors.White,
                                            New Point(0.0, 0.5),
                                            New Point(1.0, 0.5))
        }

        ' Stack panel inside parent border
        Dim visualElementChild1 As New StackPanel With {
            .Orientation = Orientation.Horizontal,
            .Margin = New Thickness(10)
        }

        ' Stack panel content
        Dim paragraphContent As New TextBlock With {
            .Text = $"Lorem ipsum dolor sit amet, consectetuer adipiscing elit.{vbNewLine}Suspendisse vel ante. Donec luctus tortor sit amet est.{vbNewLine}Nullam pulvinar odio et wisi.{vbNewLine}Pellentesque quis magna. Sed pellentesque.",
            .Width = 200,
            .Margin = New Thickness(10),
            .TextWrapping = TextWrapping.Wrap
        }

        Dim ellipsePanel = New StackPanel
        ellipsePanel.Children.Add(New Ellipse() With {.Margin = New Thickness(10), .Height = 50, .Width = 50, .Fill = Brushes.Black})
        ellipsePanel.Children.Add(New Ellipse() With {.Margin = New Thickness(10), .Height = 50, .Width = 50, .Fill = Brushes.Purple})

        ' Add stack panel content
        visualElementChild1.Children.Add(paragraphContent)
        visualElementChild1.Children.Add(ellipsePanel)

        ' Add stack panel to border
        visualElement.Child = visualElementChild1

        ' Add visual to reflect to container
        container.Children.Add(visualElement)

        ' Line separator
        container.Children.Add(New Rectangle() With {.Height = 1, .Fill = Brushes.Gray, .HorizontalAlignment = HorizontalAlignment.Stretch})

        ' Reflection
        Dim reflection As New Rectangle

        reflection.DataContext = visualElement
        reflection.SetBinding(Rectangle.WidthProperty, "ActualWidth")
        reflection.SetBinding(Rectangle.HeightProperty, "ActualHeight")

        ' Create the reflection effect
        Dim Transform = New TransformGroup
        Transform.Children.Add(New ScaleTransform(1, -1))
        Transform.Children.Add(New TranslateTransform(0, 1))

        Dim reflectedBrush As New VisualBrush With {
            .RelativeTransform = Transform,
            .Opacity = 0.75,
            .Stretch = Stretch.None,
            .Visual = visualElement
        }

        ' Add the reflection effect
        reflection.Fill = reflectedBrush

        reflection.OpacityMask = New LinearGradientBrush(
                                        New GradientStopCollection(
                                            {
                                                New GradientStop(ColorConverter.ConvertFromString("#FF000000"), 0.0),
                                                New GradientStop(ColorConverter.ConvertFromString("#33000000"), 0.5),
                                                New GradientStop(ColorConverter.ConvertFromString("#00000000"), 0.75)
                                            }),
                                        New Point(0.5, 0),
                                        New Point(0.5, 1))

        reflection.Effect = New BlurEffect() With {.Radius = 1.5}

        ' Add the reflection to the container
        container.Children.Add(reflection)

        ' Set the container as the content of this window
        Content = container
    End Sub
    '</Reflection>
End Class
