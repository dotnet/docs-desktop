using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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

            SetAttachedPropertyInCode();

            // Test get/set accessors.
            Aquarium aquarium = new();
            Aquarium.SetHasFish(aquarium, true);
            bool hasFish = Aquarium.GetHasFish(aquarium);
            Debug.WriteLine($"Has fish: {hasFish}");
        }

        public static void SetAttachedPropertyInCode()
        {
            //<SetAttachedPropertyInCode>
            DockPanel myDockPanel = new();
            TextBox myTextBox = new();
            myTextBox.Text = "Enter text";

            // Add child element to the DockPanel.
            myDockPanel.Children.Add(myTextBox);

            // Set the attached property value.
            DockPanel.SetDock(myTextBox, Dock.Top);
            //</SetAttachedPropertyInCode>
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
