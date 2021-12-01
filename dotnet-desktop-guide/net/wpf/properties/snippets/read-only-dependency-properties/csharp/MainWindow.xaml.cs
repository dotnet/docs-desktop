using System.Windows;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Aquarium _aquarium = new();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Test setting a value.
            _aquarium.SetValue(Aquarium.FishCountPropertyKey, _aquarium.FishCount + 1);
            lblFishCount.Content = $"Aquarium fish count: {_aquarium.FishCount}";
        }
    }

    //<RegisterReadOnlyDependencyProperty>
    public class Aquarium : DependencyObject
    {
        // Register a dependency property with the specified property name,
        // property type, owner type, and property metadata.
        // Assign DependencyPropertyKey to a nonpublic field.
        internal static readonly DependencyPropertyKey FishCountPropertyKey =
            DependencyProperty.RegisterReadOnly(
              name: "FishCount",
              propertyType: typeof(int),
              ownerType: typeof(Aquarium),
              typeMetadata: new FrameworkPropertyMetadata());

        // Declare a public get accessor.
        public int FishCount =>
            (int)GetValue(FishCountPropertyKey.DependencyProperty);
    }
    //</RegisterReadOnlyDependencyProperty>
}
