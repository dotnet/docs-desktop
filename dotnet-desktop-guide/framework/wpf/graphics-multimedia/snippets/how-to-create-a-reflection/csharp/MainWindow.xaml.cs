using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //<Reflection>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var container = new StackPanel();
            container.Height = 400;
            container.Margin = new Thickness(25);

            // Visual Element that will be reflected
            var visualElement = new Border
            {
                Width = 400,
                Background = new LinearGradientBrush(
                                            (Color)ColorConverter.ConvertFromString("#CCCCFF"),
                                            Colors.White,
                                            new Point(0.0, 0.5),
                                            new Point(1.0, 0.5))
            };

            // Stack panel inside parent border
            {
                var visualElementChild1 = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(10)
                };

                // Stack panel content
                {
                    var paragraphContent = new TextBlock
                    {
                        Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.\nSuspendisse vel ante. Donec luctus tortor sit amet est.\nNullam pulvinar odio et wisi.\nPellentesque quis magna. Sed pellentesque.",
                        Width = 200,
                        Margin = new Thickness(10),
                        TextWrapping = TextWrapping.Wrap
                    };

                    var ellipsePanel = new StackPanel();
                    ellipsePanel.Children.Add(new Ellipse() { Margin = new Thickness(10), Height = 50, Width = 50, Fill = Brushes.Black });
                    ellipsePanel.Children.Add(new Ellipse() { Margin = new Thickness(10), Height = 50, Width = 50, Fill = Brushes.Purple });

                    // Add to parent
                    visualElementChild1.Children.Add(paragraphContent);
                    visualElementChild1.Children.Add(ellipsePanel);
                }

                // Add to parent
                visualElement.Child = visualElementChild1;
            }

            // Add visual to reflect to container
            container.Children.Add(visualElement);

            // Line separator
            container.Children.Add(new Rectangle() { Height = 1, Fill = Brushes.Gray, HorizontalAlignment = HorizontalAlignment.Stretch });

            // Reflection
            Rectangle reflection = new Rectangle();

            reflection.DataContext = visualElement;
            reflection.SetBinding(Rectangle.WidthProperty, "ActualWidth");
            reflection.SetBinding(Rectangle.HeightProperty, "ActualHeight");

            // Create the reflection effect
            var transform = new TransformGroup();
            transform.Children.Add(new ScaleTransform(1, -1));
            transform.Children.Add(new TranslateTransform(0, 1));

            var reflectedBrush = new VisualBrush();
            reflectedBrush.RelativeTransform = transform;
            reflectedBrush.Opacity = 0.75;
            reflectedBrush.Stretch = Stretch.None;
            reflectedBrush.Visual = visualElement;

            // Add the reflection effect
            reflection.Fill = reflectedBrush;

            reflection.OpacityMask = new LinearGradientBrush(
                                        new GradientStopCollection(new[]
                                            {
                                                new GradientStop((Color)ColorConverter.ConvertFromString("#FF000000"), 0.0),
                                                new GradientStop((Color)ColorConverter.ConvertFromString("#33000000"), 0.5),
                                                new GradientStop((Color)ColorConverter.ConvertFromString("#00000000"), 0.75)
                                            }),
                                        new Point(0.5, 0),
                                        new Point(0.5, 1));

            reflection.Effect = new BlurEffect() { Radius = 1.5 };

            // Add the reflection to the container
            container.Children.Add(reflection);

            // Set the container as the content of this window
            Content = container;
        }
        //</Reflection>
    }
}
