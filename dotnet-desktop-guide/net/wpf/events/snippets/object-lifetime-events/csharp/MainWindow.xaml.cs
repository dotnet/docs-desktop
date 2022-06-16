using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CodeSampleCsharp
{
    //<LifetimeEventsCodeBehind>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        // Handler for the Initialized lifetime event (attached in XAML).
        private void InitHandler(object sender, System.EventArgs e) => 
            Debug.WriteLine($"Initialized event on {((FrameworkElement)sender).Name}.");

        // Handler for the Loaded lifetime event (attached in XAML).
        private void LoadHandler(object sender, RoutedEventArgs e) => 
            Debug.WriteLine($"Loaded event on {((FrameworkElement)sender).Name}.");

        // Handler for the Unloaded lifetime event (attached in XAML).
        private void UnloadHandler(object sender, RoutedEventArgs e) =>
            Debug.WriteLine($"Unloaded event on {((FrameworkElement)sender).Name}.");

        // Remove nested controls.
        private void Button_Click(object sender, RoutedEventArgs e) => 
            canvas.Children.Clear();
    }

    // Custom control.
    public class ComponentWrapper : ComponentWrapperBase { }

    // Custom base control.
    public class ComponentWrapperBase : StackPanel
    {
        public ComponentWrapperBase()
        {
            // Assign handler for the Initialized lifetime event (attached in code-behind).
            Initialized += (object sender, System.EventArgs e) => 
                Debug.WriteLine($"Initialized event on componentWrapperBase.");

            // Assign handler for the Loaded lifetime event (attached in code-behind).
            Loaded += (object sender, RoutedEventArgs e) => 
                Debug.WriteLine($"Loaded event on componentWrapperBase.");

            // Assign handler for the Unloaded lifetime event (attached in code-behind).
            Unloaded += (object sender, RoutedEventArgs e) => 
                Debug.WriteLine($"Unloaded event on componentWrapperBase.");
        }
    }

    /* Output:
    Initialized event on textBox1.
    Initialized event on textBox2.
    Initialized event on componentWrapperBase.
    Initialized event on componentWrapper.
    Initialized event on outerStackPanel.

    Loaded event on outerStackPanel.
    Loaded event on componentWrapperBase.
    Loaded event on componentWrapper.
    Loaded event on textBox1.
    Loaded event on textBox2.

    Unloaded event on outerStackPanel.
    Unloaded event on componentWrapperBase.
    Unloaded event on componentWrapper.
    Unloaded event on textBox1.
    Unloaded event on textBox2.
    */
    //</LifetimeEventsCodeBehind>
}
