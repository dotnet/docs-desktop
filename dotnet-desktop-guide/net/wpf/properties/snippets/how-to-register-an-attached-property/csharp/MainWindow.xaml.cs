using System.Windows;
using System.Windows.Controls;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
    }

    //<RegisterAttachedProperty>
    public class Aquarium : DependencyObject
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
