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

namespace SampleApplication
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

        // <CreateStyleCode>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create colors
            Color purple = (Color)ColorConverter.ConvertFromString("#4E1A3D");
            Color white = Colors.White;
            Color salmon = Colors.Salmon;

            // Create a new style for a button
            var buttonStyle = new Style(typeof(Button));

            // Set the properties of the style
            buttonStyle.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(purple)));
            buttonStyle.Setters.Add(new Setter(Control.ForegroundProperty, new SolidColorBrush(white)));
            buttonStyle.Setters.Add(new Setter(Control.BorderBrushProperty, new LinearGradientBrush(purple, salmon, 45d)));
            buttonStyle.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(5)));

            // <SetResource>
            // Set this style as a resource. Any DynamicResource tied to this key will be updated.
            this.Resources["buttonStyle1"] = buttonStyle;
            // </SetResource>

            // <SetButtonStyle>
            // Set this style directly to a button
            ((Button)sender).Style = buttonStyle;
            // </SetButtonStyle>
        }
        // </CreateStyleCode>

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            Button myButton = (Button)sender;

            // <FindResource>
            myButton.Style = myButton.TryFindResource("buttonStyle1") as Style;
            // </FindResource>
        }
    }
}
