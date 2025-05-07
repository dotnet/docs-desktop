using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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

        //<EmojiViewBox>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Grid gridContainer = new Grid()
            {
                Width = 175,
                Height = 150
            };

            // Template to generate the content
            ControlTemplate viewBoxTemplate = (ControlTemplate)System.Windows.Markup.XamlReader.Parse(@"
                <ControlTemplate TargetType=""ContentControl"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                    <Viewbox>
                        <Border Background=""LightGray"" BorderBrush=""Black"" BorderThickness=""0.5"">
                            <TextBlock Foreground=""Red"">💕</TextBlock>
                        </Border>
                    </Viewbox>
                </ControlTemplate>
                ");

            gridContainer.RowDefinitions.Add(new RowDefinition());
            gridContainer.RowDefinitions.Add(new RowDefinition());

            // Dock panel
            DockPanel panel1 = new DockPanel();
            Grid.SetRow(panel1, 0);

            // Create the three controls for the panel
            panel1.Children.Add(new ContentControl() { Template = viewBoxTemplate });
            panel1.Children.Add(new ContentControl() { Template = viewBoxTemplate });
            panel1.Children.Add(new ContentControl() { Template = viewBoxTemplate });

            // Add the dock panel to the grid
            gridContainer.Children.Add(panel1);

            // Stack panel
            StackPanel panel2 = new StackPanel();
            panel2.Orientation = Orientation.Horizontal;
            Grid.SetRow(panel2, 1);

            // Create the three controls for the panel
            panel2.Children.Add(new ContentControl() { Template = viewBoxTemplate });
            panel2.Children.Add(new ContentControl() { Template = viewBoxTemplate });
            panel2.Children.Add(new ContentControl() { Template = viewBoxTemplate });

            // Add the dock panel to the grid
            gridContainer.Children.Add(panel2);
            
            // Set the grid as the content of this window or page
            Content = gridContainer;
        }
        //</EmojiViewBox>
    }
}
