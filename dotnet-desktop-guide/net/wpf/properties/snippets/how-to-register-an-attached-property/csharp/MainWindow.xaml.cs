using System.Diagnostics;
using System.Windows;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Test get/set accessors.
            Aquarium aquarium = new();
            Aquarium.SetHasFish(aquarium, true);
            bool hasFish = Aquarium.GetHasFish(aquarium);
            Debug.WriteLine($"Has fish: {hasFish}");
        }
    }

    //<RegisterAttachedProperty>
    public class Aquarium : UIElement
    {
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty HasFishProperty =
            DependencyProperty.RegisterAttached(
              "HasFish",
              typeof(bool),
              typeof(Aquarium),
              new FrameworkPropertyMetadata(defaultValue: false,
                  flags: FrameworkPropertyMetadataOptions.AffectsRender)
            );

        // Declare a get accessor method.
        public static bool GetHasFish(UIElement target) =>
            (bool)target.GetValue(HasFishProperty);

        // Declare a set accessor method.
        public static void SetHasFish(UIElement target, bool value) =>
            target.SetValue(HasFishProperty, value);
    }
    //</RegisterAttachedProperty>
}
