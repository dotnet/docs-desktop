using System;
using System.Windows;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        public void ValidateSnippet(object sender, RoutedEventArgs e)
        {
            TropicalAquarium tropicalAquarium = new();
            Aquarium aquarium = new();

            FrameworkPropertyMetadata aquariumPropertyMetadata = (FrameworkPropertyMetadata)Aquarium.AquariumGraphicProperty.GetMetadata(aquarium);
            FrameworkPropertyMetadata tropicalAquariumPropertyMetadata = (FrameworkPropertyMetadata)Aquarium.AquariumGraphicProperty.GetMetadata(tropicalAquarium);

            lblMessage.Content = $"Tropical aquarium graphic URL: " + $"{tropicalAquarium.AquariumGraphic.OriginalString}" + Environment.NewLine;
            lblMessage.Content += $"Aquarium graphic URL: " + $"{aquarium.AquariumGraphic.OriginalString}" + Environment.NewLine;

            lblMessage.Content += $"Queried owner-type AquariumGraphic default value: " + $"{aquariumPropertyMetadata.DefaultValue}" + Environment.NewLine;
            lblMessage.Content += $"Queried owner-type AquariumGraphic affects render: " + $"{aquariumPropertyMetadata.AffectsRender}" + Environment.NewLine;

            lblMessage.Content += $"Queried derived-type TropicalAquarium default value: " + $"{tropicalAquariumPropertyMetadata.DefaultValue}" + Environment.NewLine;
            lblMessage.Content += $"Queried derived-type TropicalAquarium affects render: " + $"{tropicalAquariumPropertyMetadata.AffectsRender}" + Environment.NewLine;
        }
    }

    //<BaseDependencyProperty>
    public class Aquarium : DependencyObject
    {
        // Register a dependency property with the specified property name,
        // property type, owner type, and property metadata.
        public static readonly DependencyProperty AquariumGraphicProperty =
            DependencyProperty.Register(
              name: "AquariumGraphic",
              propertyType: typeof(Uri),
              ownerType: typeof(Aquarium),
              typeMetadata: new FrameworkPropertyMetadata(
                  defaultValue: new Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                  flags: FrameworkPropertyMetadataOptions.AffectsRender)
            );

        // Declare a read-write CLR wrapper with get/set accessors.
        public Uri AquariumGraphic
        {
            get => (Uri)GetValue(AquariumGraphicProperty);
            set => SetValue(AquariumGraphicProperty, value);
        }
    }
    //</BaseDependencyProperty>

    //<InheritedDependencyProperty>
    public class TropicalAquarium : Aquarium
    {
        // Static constructor.
        static TropicalAquarium()
        {
            // Create a new metadata instance with a modified default value.
            FrameworkPropertyMetadata newPropertyMetadata = new(
                defaultValue: new Uri("http://www.contoso.com/tropical-aquarium-graphic.jpg"));

            // Call OverrideMetadata on the dependency property identifier.
            // Pass in the type for which the new metadata will be applied
            // and the new metadata instance.
            AquariumGraphicProperty.OverrideMetadata(
                forType: typeof(TropicalAquarium),
                typeMetadata: newPropertyMetadata);
        }
    }
    //</InheritedDependencyProperty>
}
