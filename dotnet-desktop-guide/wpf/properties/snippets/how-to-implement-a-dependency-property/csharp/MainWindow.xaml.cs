using System.Windows;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
    }

    // <DefineDependencyProperty>
    public class Aquarium : DependencyObject
    {
        public static readonly DependencyProperty HasFishProperty =
            DependencyProperty.Register(
                name: "HasFish",
                propertyType: typeof(bool),
                ownerType: typeof(Aquarium),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: false));

        public bool HasFish
        {
            get => (bool)GetValue(HasFishProperty);
            set => SetValue(HasFishProperty, value);
        }
    }
    // </DefineDependencyProperty>
}
