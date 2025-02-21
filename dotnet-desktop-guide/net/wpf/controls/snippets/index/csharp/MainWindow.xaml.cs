using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Examples
{
    public partial class MainWindow : Window
    {
        public MainWindow() =>
            InitializeComponent();

        private void ButtonClickEventExample_Click(object sender, RoutedEventArgs e) =>
            new ButtonClickEventExample().ShowDialog();

        private void ShowExampleAppByXaml_Click(object sender, RoutedEventArgs e) =>
            new ExampleApp().ShowDialog();

        private void ShowExampleAppByCode_Click(object sender, RoutedEventArgs e) =>
            CreateBaseWindow();

        private void ShowButtonPropertyByXaml_Click(object sender, RoutedEventArgs e) =>
            new ButtonPropertyWindow().ShowDialog();

        private void ShowButtonPropertyByCode_Click(object sender, RoutedEventArgs e) =>
            CreateWindowButtonProperty();

        private void ShowButtonStyleXaml_Click(object sender, RoutedEventArgs e) =>
            new ButtonStyleWindow().ShowDialog();

        private void ShowButtonStyleCode_Click(object sender, RoutedEventArgs e) =>
            CreateWindowButtonStyle();

        private void ShowButtonTemplateXaml_Click(object sender, RoutedEventArgs e) =>
            new ButtonTemplateWindow().ShowDialog();

        private void ShowButtonTemplateCode_Click(object sender, RoutedEventArgs e) =>
            CreateWindowButtonTemplate();


        /*
        ** The examples that use a code-based UI
        */

        private void CreateBaseWindow()
        {
            // <ExampleAppCode>
            // Grid container which is the content of the Window
            Grid container = new() { Margin = new Thickness(5) };
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());

            // Create the two labels, assign the second label to the second row
            Label labelName = new() { Content = "Enter your name:" };
            container.Children.Add(labelName);

            Label labelAddress = new() { Content = "Enter your address:" };
            Grid.SetRow(labelAddress, 1);
            container.Children.Add(labelAddress);

            // Create the two textboxes, assign both to the second column and
            // assign the second textbox to the second row.
            TextBox textboxName = new() { Margin = new Thickness(2) };
            Grid.SetColumn(textboxName, 1);
            container.Children.Add(textboxName);

            TextBox textboxAddress = new() { Margin = new Thickness(2) };
            Grid.SetRow(textboxAddress, 1);
            Grid.SetColumn(textboxAddress, 1);
            container.Children.Add(textboxAddress);

            // Create the two buttons, assign both to the third row and
            // assign the second button to the second column.
            Button buttonReset = new() { Margin = new Thickness(2), Content = "Reset" };
            Grid.SetRow(buttonReset, 2);
            container.Children.Add(buttonReset);

            Button buttonSubmit = new() { Margin = new Thickness(2), Content = "Submit" };
            Grid.SetColumn(buttonSubmit, 1);
            Grid.SetRow(buttonSubmit, 2);
            container.Children.Add(buttonSubmit);

            // Create the popup window and assign the container (Grid) as its content
            Window inputWindow = new()
            {
                Title = "Input Record",
                Height = double.NaN,
                Width = 300,
                SizeToContent = SizeToContent.Height,
                Content = container
            };

            inputWindow.Show();
            // </ExampleAppCode>
        }

        private void CreateWindowButtonProperty()
        {
            Grid container = new() { Margin = new Thickness(5) };
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());

            Label labelName = new() { Content = "Enter your name:" };
            container.Children.Add(labelName);

            Label labelAddress = new() { Content = "Enter your address:" };
            Grid.SetRow(labelAddress, 1);
            container.Children.Add(labelAddress);

            TextBox textboxName = new() { Margin = new Thickness(2) };
            Grid.SetColumn(textboxName, 1);
            container.Children.Add(textboxName);

            TextBox textboxAddress = new() { Margin = new Thickness(2) };
            Grid.SetRow(textboxAddress, 1);
            Grid.SetColumn(textboxAddress, 1);
            container.Children.Add(textboxAddress);

            Button buttonReset = new() { Margin = new Thickness(2), Content = "Reset" };
            Grid.SetRow(buttonReset, 2);
            container.Children.Add(buttonReset);

            // <Properties>
            Button buttonSubmit = new() { Margin = new Thickness(2), Content = "Submit" };
            buttonSubmit.FontSize = 18f;
            buttonSubmit.FontWeight = FontWeights.Bold;
            buttonSubmit.Background =
                new LinearGradientBrush(
                    (Color)ColorConverter.ConvertFromString("#0073E6"),
                    (Color)ColorConverter.ConvertFromString("#81D4FA"),
                    new Point(0d, 0d),
                    new Point(0.9d, 0d));
            // </Properties>
            Grid.SetColumn(buttonSubmit, 1);
            Grid.SetRow(buttonSubmit, 2);
            container.Children.Add(buttonSubmit);

            Window inputWindow = new()
            {
                Title = "Input Record",
                Height = double.NaN,
                Width = 300,
                SizeToContent = SizeToContent.Height,
                Content = container
            };

            inputWindow.Show();
        }

        private void CreateWindowButtonStyle()
        {
            // <Style>
            Grid container = new() { Margin = new Thickness(5) };
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());

            Style buttonStyle = new(typeof(Button));
            buttonStyle.Setters.Add(new Setter(Button.FontSizeProperty, 18d));
            buttonStyle.Setters.Add(new Setter(Button.FontWeightProperty, FontWeights.Bold));
            buttonStyle.Setters.Add(new Setter(Button.BackgroundProperty,
                new LinearGradientBrush(
                    (Color)ColorConverter.ConvertFromString("#0073E6"),
                    (Color)ColorConverter.ConvertFromString("#81D4FA"),
                    new Point(0d, 0d),
                    new Point(0.9d, 0d))));

            container.Resources.Add(typeof(Button), buttonStyle);
            // </Style>

            Label labelName = new() { Content = "Enter your name:" };
            container.Children.Add(labelName);

            Label labelAddress = new() { Content = "Enter your address:" };
            Grid.SetRow(labelAddress, 1);
            container.Children.Add(labelAddress);

            TextBox textboxName = new() { Margin = new Thickness(2) };
            Grid.SetColumn(textboxName, 1);
            container.Children.Add(textboxName);

            TextBox textboxAddress = new() { Margin = new Thickness(2) };
            Grid.SetRow(textboxAddress, 1);
            Grid.SetColumn(textboxAddress, 1);
            container.Children.Add(textboxAddress);

            Button buttonReset = new() { Margin = new Thickness(2), Content = "Reset" };
            Grid.SetRow(buttonReset, 2);
            container.Children.Add(buttonReset);

            Button buttonSubmit = new() { Margin = new Thickness(2), Content = "Submit" };
            Grid.SetColumn(buttonSubmit, 1);
            Grid.SetRow(buttonSubmit, 2);
            container.Children.Add(buttonSubmit);
            
            Window inputWindow = new()
            {
                Title = "Input Record",
                Height = double.NaN,
                Width = 300,
                SizeToContent = SizeToContent.Height,
                Content = container
            };
            
            inputWindow.Show();
        }

        private void CreateWindowButtonTemplate()
        {
            Grid container = new() { Margin = new Thickness(5) };
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.RowDefinitions.Add(new RowDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());
            container.ColumnDefinitions.Add(new ColumnDefinition());

            Label labelName = new() { Content = "Enter your name:" };
            container.Children.Add(labelName);

            Label labelAddress = new() { Content = "Enter your address:" };
            Grid.SetRow(labelAddress, 1);
            container.Children.Add(labelAddress);

            TextBox textboxName = new() { Margin = new Thickness(2) };
            Grid.SetColumn(textboxName, 1);
            container.Children.Add(textboxName);

            TextBox textboxAddress = new() { Margin = new Thickness(2) };
            Grid.SetRow(textboxAddress, 1);
            Grid.SetColumn(textboxAddress, 1);
            container.Children.Add(textboxAddress);

            Button buttonReset = new() { Margin = new Thickness(2), Content = "Reset" };
            Grid.SetRow(buttonReset, 2);
            container.Children.Add(buttonReset);

            // <Template>
            Button buttonSubmit = new() { Margin = new Thickness(2), Content = "Submit" };

            // Create the XAML used to define the button template
            const string xaml = """
                <ControlTemplate TargetType="Button">
                    <Border Name="Border" CornerRadius="10" BorderThickness="1" BorderBrush="Black">
                        <Border.Background>
                            <LinearGradientBrush StartPoint="0,0.5" 
                                 EndPoint="1,0.5">
                                <GradientStop Color="{Binding Background.Color, RelativeSource={RelativeSource TemplatedParent}}" Offset="0.0" />
                                <GradientStop Color="PeachPuff" Offset="0.9" />
                            </LinearGradientBrush>
                        </Border.Background>
                        <ContentPresenter Margin="2" HorizontalAlignment="Center" VerticalAlignment="Center" RecognizesAccessKey="True"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <!--Change the appearance of the button when the user clicks it.-->
                        <Trigger Property="IsPressed" Value="true">
                            <Setter TargetName="Border" Property="Background">
                                <Setter.Value>
                                    <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                                        <GradientStop Color="{Binding Background.Color, RelativeSource={RelativeSource TemplatedParent}}" Offset="0.0" />
                                        <GradientStop Color="LightBlue" Offset="0.9" />
                                    </LinearGradientBrush>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
                """;

            // Load the XAML into a stream that can be parsed
            using MemoryStream stream = new(System.Text.Encoding.UTF8.GetBytes(xaml));

            // Create a parser context and add the default namespace and the x namespace common to WPF XAML
            System.Windows.Markup.ParserContext context = new();
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

            // Parse the XAML and assign it to the button's template
            buttonSubmit.Template = (ControlTemplate)System.Windows.Markup.XamlReader.Load(stream, context);

            // Set the other properties of the button
            Grid.SetColumn(buttonSubmit, 1);
            Grid.SetRow(buttonSubmit, 2);

            // Assign the button to the grid container
            container.Children.Add(buttonSubmit);
            // <Template>

            Window inputWindow = new()
            {
                Title = "Input Record",
                Height = double.NaN,
                Width = 300,
                SizeToContent = SizeToContent.Height,
                Content = container
            };

            inputWindow.Show();
        }
    }
}
