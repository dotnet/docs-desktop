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

            // <ProceduralPropertySet>
            Button myButton = new();
            myButton.Width = 200.0;
            // </ProceduralPropertySet>

            // <ProceduralPropertyGet>
            double whatWidth = myButton.Width;
            // </ProceduralPropertyGet>
        }

        // <DefineDependencyProperty>
        public static readonly DependencyProperty IsSpinningProperty = DependencyProperty.Register(
            "IsSpinning", typeof(bool),
            typeof(MainWindow)
            );

        public bool IsSpinning
        {
            get => (bool)GetValue(IsSpinningProperty);
            set => SetValue(IsSpinningProperty, value);
        }
        // </DefineDependencyProperty>
    }

    // <OverrideMetadata>
    public class SpinnerControl : ItemsControl
    {
        static SpinnerControl() => DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SpinnerControl),
                new FrameworkPropertyMetadata(typeof(SpinnerControl))
            );
    }
    // </OverrideMetadata>
}
