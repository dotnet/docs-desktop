Imports System.ComponentModel
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media

Class MainWindow




    '
    ' The examples that use a code-based UI
    '

    Sub CreateBaseWindow()

        '<ExampleAppCode>
        ' Grid container which is the content of the Window
        Dim container As New Grid() With {.Margin = New Thickness(5)}
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())

        ' Create the two labels, assign the second label to the second row
        Dim labelName As New Label() With {.Content = "Enter your name:"}
        container.Children.Add(labelName)

        Dim labelAddress As New Label() With {.Content = "Enter your address:"}
        Grid.SetRow(labelAddress, 1)
        container.Children.Add(labelAddress)

        ' Create the two textboxes, assign both to the second column and
        ' assign the second textbox to the second row.
        Dim textboxName As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetColumn(textboxName, 1)
        container.Children.Add(textboxName)

        Dim textboxAddress As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetRow(textboxAddress, 1)
        Grid.SetColumn(textboxAddress, 1)
        container.Children.Add(textboxAddress)

        ' Create the two buttons, assign both to the third row and
        ' assign the second button to the second column.
        Dim buttonReset As New Button() With {.Margin = New Thickness(2), .Content = "Reset"}
        Grid.SetRow(buttonReset, 2)
        container.Children.Add(buttonReset)

        Dim buttonSubmit As New Button() With {.Margin = New Thickness(2), .Content = "Submit"}
        Grid.SetColumn(buttonSubmit, 1)
        Grid.SetRow(buttonSubmit, 2)
        container.Children.Add(buttonSubmit)

        ' Create the window and assign the container (Grid) as its content
        Dim inputWindow As New Window() With
        {
            .Title = "Input Record",
            .Height = Double.NaN,
            .Width = 300,
            .SizeToContent = SizeToContent.Height,
            .Content = container
        }

        inputWindow.Show()
        '</ExampleAppCode>

    End Sub

    Sub CreateWindowButtonProperty()

        Dim container As New Grid() With {.Margin = New Thickness(5)}
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())

        Dim labelName As New Label() With {.Content = "Enter your name:"}
        container.Children.Add(labelName)

        Dim labelAddress As New Label() With {.Content = "Enter your address:"}
        Grid.SetRow(labelAddress, 1)
        container.Children.Add(labelAddress)

        Dim textboxName As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetColumn(textboxName, 1)
        container.Children.Add(textboxName)

        Dim textboxAddress As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetRow(textboxAddress, 1)
        Grid.SetColumn(textboxAddress, 1)
        container.Children.Add(textboxAddress)

        Dim buttonReset As New Button() With {.Margin = New Thickness(2), .Content = "Reset"}
        Grid.SetRow(buttonReset, 2)
        container.Children.Add(buttonReset)

        '<Properties>
        Dim buttonSubmit As New Button() With {.Margin = New Thickness(2), .Content = "Submit"}
        buttonSubmit.FontSize = 18.0F
        buttonSubmit.FontWeight = FontWeights.Bold
        buttonSubmit.Background =
                New LinearGradientBrush(
                    ColorConverter.ConvertFromString("#0073E6"),
                    ColorConverter.ConvertFromString("#81D4FA"),
                    New Point(0D, 0D),
                    New Point(0.9D, 0D))
        '</Properties>
        Grid.SetColumn(buttonSubmit, 1)
        Grid.SetRow(buttonSubmit, 2)
        container.Children.Add(buttonSubmit)

        Dim inputWindow As New Window() With
        {
            .Title = "Input Record",
            .Height = Double.NaN,
            .Width = 300,
            .SizeToContent = SizeToContent.Height,
            .Content = container
        }

        inputWindow.Show()

    End Sub

    Sub CreateWindowButtonStyle()

        '<Style>
        Dim container As New Grid() With {.Margin = New Thickness(5)}
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())

        Dim buttonStyle As New Style(GetType(Button))
        buttonStyle.Setters.Add(New Setter(Button.FontSizeProperty, 18.0R))
        buttonStyle.Setters.Add(New Setter(Button.FontWeightProperty, FontWeights.Bold))
        buttonStyle.Setters.Add(New Setter(Button.BackgroundProperty,
                New LinearGradientBrush(
                    ColorConverter.ConvertFromString("#0073E6"),
                    ColorConverter.ConvertFromString("#81D4FA"),
                    New Point(0D, 0D),
                    New Point(0.9D, 0D))))

        container.Resources.Add(GetType(Button), buttonStyle)
        '</Style>

        Dim labelName As New Label() With {.Content = "Enter your name:"}
        container.Children.Add(labelName)

        Dim labelAddress As New Label() With {.Content = "Enter your address:"}
        Grid.SetRow(labelAddress, 1)
        container.Children.Add(labelAddress)

        Dim textboxName As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetColumn(textboxName, 1)
        container.Children.Add(textboxName)

        Dim textboxAddress As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetRow(textboxAddress, 1)
        Grid.SetColumn(textboxAddress, 1)
        container.Children.Add(textboxAddress)

        Dim buttonReset As New Button() With {.Margin = New Thickness(2), .Content = "Reset"}
        Grid.SetRow(buttonReset, 2)
        container.Children.Add(buttonReset)

        Dim buttonSubmit As New Button() With {.Margin = New Thickness(2), .Content = "Submit"}
        Grid.SetColumn(buttonSubmit, 1)
        Grid.SetRow(buttonSubmit, 2)
        container.Children.Add(buttonSubmit)

        Dim inputWindow As New Window() With
        {
            .Title = "Input Record",
            .Height = Double.NaN,
            .Width = 300,
            .SizeToContent = SizeToContent.Height,
            .Content = container
        }

        inputWindow.Show()

    End Sub

    Sub CreateWindowButtonTemplate()

        Dim container As New Grid() With {.Margin = New Thickness(5)}
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())

        Dim labelName As New Label() With {.Content = "Enter your name:"}
        container.Children.Add(labelName)

        Dim labelAddress As New Label() With {.Content = "Enter your address:"}
        Grid.SetRow(labelAddress, 1)
        container.Children.Add(labelAddress)

        Dim textboxName As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetColumn(textboxName, 1)
        container.Children.Add(textboxName)

        Dim textboxAddress As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetRow(textboxAddress, 1)
        Grid.SetColumn(textboxAddress, 1)
        container.Children.Add(textboxAddress)

        Dim buttonReset As New Button() With {.Margin = New Thickness(2), .Content = "Reset"}
        Grid.SetRow(buttonReset, 2)
        container.Children.Add(buttonReset)

        '<Template>
        Dim buttonSubmit As New Button() With {.Margin = New Thickness(2), .Content = "Submit"}

        ' Create the XAML used to define the button template
        Const xaml As String = "
            <ControlTemplate TargetType=""Button"">
                <Border Name=""Border"" CornerRadius=""10"" BorderThickness=""1"" BorderBrush=""Black"">
                    <Border.Background>
                        <LinearGradientBrush StartPoint=""0,0.5"" 
                             EndPoint=""1,0.5"">
                            <GradientStop Color=""{Binding Background.Color, RelativeSource={RelativeSource TemplatedParent}}"" Offset=""0.0"" />
                            <GradientStop Color=""PeachPuff"" Offset=""0.9"" />
                        </LinearGradientBrush>
                    </Border.Background>
                    <ContentPresenter Margin=""2"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"" RecognizesAccessKey=""True""/>
                </Border>
                <ControlTemplate.Triggers>
                    <!--Change the appearance of the button when the user clicks it.-->
                    <Trigger Property=""IsPressed"" Value=""true"">
                        <Setter TargetName=""Border"" Property=""Background"">
                            <Setter.Value>
                                <LinearGradientBrush StartPoint=""0,0.5"" EndPoint=""1,0.5"">
                                    <GradientStop Color=""{Binding Background.Color, RelativeSource={RelativeSource TemplatedParent}}"" Offset=""0.0"" />
                                    <GradientStop Color=""LightBlue"" Offset=""0.9"" />
                                </LinearGradientBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>"

        ' Load the XAML into a stream that can be parsed
        Using stream As New MemoryStream(System.Text.Encoding.UTF8.GetBytes(xaml))

            ' Create a parser context and add the default namespace and 
            ' the x namespace, which is common to WPF XAML
            Dim context = New System.Windows.Markup.ParserContext()
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation")
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml")

            ' Parse the XAML and assign it to the button's template
            buttonSubmit.Template = System.Windows.Markup.XamlReader.Load(stream, context)
        End Using

        ' Set the other properties of the button
        Grid.SetColumn(buttonSubmit, 1)
        Grid.SetRow(buttonSubmit, 2)

        ' Assign the button to the grid container
        container.Children.Add(buttonSubmit)
        '</Template>

        Dim inputWindow As New Window() With
            {
            .Title = "Input Record",
            .Height = Double.NaN,
            .Width = 300,
            .SizeToContent = SizeToContent.Height,
            .Content = container
            }

        inputWindow.Show()

    End Sub


    Sub CreateEventWindow()

        Dim container As New Grid() With {.Margin = New Thickness(5)}
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.RowDefinitions.Add(New RowDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())
        container.ColumnDefinitions.Add(New ColumnDefinition())

        Dim labelName As New Label() With {.Content = "Enter your name:"}
        container.Children.Add(labelName)

        Dim labelAddress As New Label() With {.Content = "Enter your address:"}
        Grid.SetRow(labelAddress, 1)
        container.Children.Add(labelAddress)

        Dim textboxName As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetColumn(textboxName, 1)
        container.Children.Add(textboxName)

        Dim textboxAddress As New TextBox() With {.Margin = New Thickness(2)}
        Grid.SetRow(textboxAddress, 1)
        Grid.SetColumn(textboxAddress, 1)
        container.Children.Add(textboxAddress)

        Dim buttonReset As New Button() With {.Margin = New Thickness(2), .Content = "Reset"}
        Grid.SetRow(buttonReset, 2)
        container.Children.Add(buttonReset)

        '<Event>
        Dim buttonSubmit As New Button() With {.Margin = New Thickness(2), .Content = "Submit"}
        AddHandler buttonSubmit.Click, AddressOf Submit_Click
        '</Event>
        Grid.SetColumn(buttonSubmit, 1)
        Grid.SetRow(buttonSubmit, 2)
        container.Children.Add(buttonSubmit)

        Dim inputWindow As New Window() With
        {
            .Title = "Input Record",
            .Height = Double.NaN,
            .Width = 300,
            .SizeToContent = SizeToContent.Height,
            .Content = container
        }

        inputWindow.Show()

    End Sub

    Sub Submit_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Submit button clicked")
    End Sub

    Private Sub ButtonClickEventExample_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New ButtonClickEventExample
        window.ShowDialog()
    End Sub

    Private Sub ButtonClickEventExampleByCode_Click(sender As Object, e As RoutedEventArgs)
        CreateEventWindow()
    End Sub

    Private Sub ShowExampleAppByXaml_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New ExampleApp
        window.ShowDialog()
    End Sub

    Private Sub ShowExampleAppByCode_Click(sender As Object, e As RoutedEventArgs)
        CreateBaseWindow()
    End Sub

    Private Sub ShowButtonPropertyByXaml_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New ButtonPropertyWindow
        window.ShowDialog()
    End Sub

    Private Sub ShowButtonPropertyByCode_Click(sender As Object, e As RoutedEventArgs)
        CreateWindowButtonProperty()
    End Sub

    Private Sub ShowButtonStyleXaml_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New ButtonStyleWindow
        window.ShowDialog()
    End Sub

    Private Sub ShowButtonStyleCode_Click(sender As Object, e As RoutedEventArgs)
        CreateWindowButtonStyle()
    End Sub

    Private Sub ShowButtonTemplateXaml_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New ButtonTemplateWindow
        window.ShowDialog()
    End Sub

    Private Sub ShowButtonTemplateCode_Click(sender As Object, e As RoutedEventArgs)
        CreateWindowButtonTemplate()
    End Sub
End Class
