Class MainWindow
    '<EmojiViewBox>
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim gridContainer As New Grid() With {.Width = 175, .Height = 150}

        ' Template to generate the content
        Dim viewBoxTemplate As ControlTemplate = DirectCast(Markup.XamlReader.Parse("
                <ControlTemplate TargetType=""ContentControl"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                    <Viewbox>
                        <Border Background=""LightGray"" BorderBrush=""Black"" BorderThickness=""0.5"">
                            <TextBlock Foreground=""Red"">💕</TextBlock>
                        </Border>
                    </Viewbox>
                </ControlTemplate>"), ControlTemplate)


        gridContainer.RowDefinitions.Add(New RowDefinition())
        gridContainer.RowDefinitions.Add(New RowDefinition())

        ' Dock panel
        Dim panel1 As New DockPanel()
        Grid.SetRow(panel1, 0)

        ' Create the three controls for the panel
        panel1.Children.Add(New ContentControl() With {.Template = viewBoxTemplate})
        panel1.Children.Add(New ContentControl() With {.Template = viewBoxTemplate})
        panel1.Children.Add(New ContentControl() With {.Template = viewBoxTemplate})

        ' Add the dock panel to the grid
        gridContainer.Children.Add(panel1)

        ' Stack panel
        Dim panel2 As New StackPanel() With {.Orientation = Orientation.Horizontal}
        Grid.SetRow(panel2, 1)

        ' Create the three controls for the panel
        panel2.Children.Add(New ContentControl() With {.Template = viewBoxTemplate})
        panel2.Children.Add(New ContentControl() With {.Template = viewBoxTemplate})
        panel2.Children.Add(New ContentControl() With {.Template = viewBoxTemplate})

        ' Add the dock panel to the grid
        gridContainer.Children.Add(panel2)

        'Set the grid as the content of this window or page
        Content = gridContainer
    End Sub
    '</EmojiViewBox>
End Class
