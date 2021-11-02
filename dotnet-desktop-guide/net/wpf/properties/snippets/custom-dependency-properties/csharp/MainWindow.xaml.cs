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
        // property type, owner type, and property metadata.
        private static readonly DependencyProperty s_aquariumGraphicProperty =
            DependencyProperty.Register(
              name: "AquariumGraphic",
              propertyType: typeof(Uri),
              ownerType: typeof(Aquarium),
              typeMetadata: new FrameworkPropertyMetadata(
                  defaultValue: new Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                  flags: FrameworkPropertyMetadataOptions.AffectsRender,
                  propertyChangedCallback: new PropertyChangedCallback(OnUriChanged))
            );

        // Store the dependency property identifier as a static member of the class.
        public static readonly DependencyProperty AquariumGraphicProperty =
            s_aquariumGraphicProperty;
        //</RegisterDependencyProperty>

        // Declare a read-write property.
        public Uri AquariumContents
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
