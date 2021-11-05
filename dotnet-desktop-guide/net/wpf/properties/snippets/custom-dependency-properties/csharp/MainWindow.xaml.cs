using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
    }

    public class Aquarium : DependencyObject
    {
        //<RegisterDependencyPropertyWithWrapper>
        //<RegisterDependencyProperty>
        // Register a dependency property with the specified property name,
        // property type, owner type, and property metadata. Store the dependency
        // property identifier as a public static readonly member of the class.
        public static readonly DependencyProperty AquariumGraphicProperty =
            DependencyProperty.Register(
              name: "AquariumGraphic",
              propertyType: typeof(Uri),
              ownerType: typeof(Aquarium),
              typeMetadata: new FrameworkPropertyMetadata(
                  defaultValue: new Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                  flags: FrameworkPropertyMetadataOptions.AffectsRender,
                  propertyChangedCallback: new PropertyChangedCallback(OnUriChanged))
            );
        //</RegisterDependencyProperty>

        // Declare a read-write property.
        public Uri AquariumGraphic
        {
            get => (Uri)GetValue(AquariumGraphicProperty);
            set => SetValue(AquariumGraphicProperty, value);
        }
        //</RegisterDependencyPropertyWithWrapper>

        private static void OnUriChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            Shape shape = (Shape)dependencyObject;
            shape.Fill = new ImageBrush(new BitmapImage((Uri)e.NewValue));
        }
    }
}
