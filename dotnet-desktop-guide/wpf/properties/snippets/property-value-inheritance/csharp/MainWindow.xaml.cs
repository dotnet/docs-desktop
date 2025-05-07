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

            // Code tests.
            TestAllowDropInheritanceInXaml();
            TestAllowDropInheritanceInCode();
            TestIsTransparentInheritanceInCode();
            TestDependencyPropertyWrapper();
        }

        private void TestAllowDropInheritanceInXaml()
        {
            // Test enabled property value inheritance.
            FrameworkPropertyMetadata fpm1 = (FrameworkPropertyMetadata)
                AllowDropProperty.GetMetadata(typeof(Canvas));
            Debug.Assert(fpm1.Inherits == true);
            Debug.Assert(canvas1.AllowDrop == true);
            Debug.Assert(stackPanel1.AllowDrop == true);
            Debug.Assert(label1.AllowDrop == true);

            // Test disabled property value inheritance.
            FrameworkPropertyMetadata fpm11 = (FrameworkPropertyMetadata)
                AllowDropProperty.GetMetadata(typeof(Canvas_AllowDropInheritDisabled));
            Debug.Assert(fpm11.Inherits == false);
            Debug.Assert(canvas11.AllowDrop == true);
            Debug.Assert(stackPanel11.AllowDrop == false);
            Debug.Assert(label11.AllowDrop == false);
        }

        private static void TestAllowDropInheritanceInCode()
        {
            //<CodeElementTree>
            Canvas canvas2 = new()
            {
                AllowDrop = true
            };
            StackPanel stackPanel2 = new();
            Label label2 = new();
            canvas2.Children.Add(stackPanel2);
            stackPanel2.Children.Add(label2);
            //</CodeElementTree>

            // Test enabled property value inheritance.
            FrameworkPropertyMetadata fpm2 = (FrameworkPropertyMetadata)
                AllowDropProperty.GetMetadata(typeof(Canvas));
            Debug.Assert(fpm2.Inherits == true);
            Debug.Assert(canvas2.AllowDrop == true);
            Debug.Assert(stackPanel2.AllowDrop == true);
            Debug.Assert(label2.AllowDrop == true);

            // Test disabled property value inheritance.
            Canvas_AllowDropInheritDisabled canvas3 = new()
            {
                AllowDrop = true
            };
            StackPanel stackPanel3 = new();
            Label label3 = new();
            canvas3.Children.Add(stackPanel3);
            stackPanel3.Children.Add(label3);
            FrameworkPropertyMetadata fpm3 = (FrameworkPropertyMetadata)
                AllowDropProperty.GetMetadata(typeof(Canvas_AllowDropInheritDisabled));
            Debug.Assert(fpm3.Inherits == false);
            Debug.Assert(canvas3.AllowDrop == true);
            Debug.Assert(stackPanel3.AllowDrop == false);
            Debug.Assert(label3.AllowDrop == false);
        }

        private static void TestIsTransparentInheritanceInCode()
        {
            // Test enabled property value inheritance.
            Canvas_IsTransparentInheritEnabled myCanvas1 = new()
            {
                IsTransparent = true
            };
            Canvas_IsTransparentInheritEnabled2 myCanvas2 = new();
            Canvas_IsTransparentInheritEnabled3 myCanvas3 = new();
            myCanvas1.Children.Add(myCanvas2);
            myCanvas2.Children.Add(myCanvas3);
            FrameworkPropertyMetadata fpm1 = (FrameworkPropertyMetadata)Canvas_IsTransparentInheritEnabled
                .IsTransparentProperty.GetMetadata(typeof(Canvas_IsTransparentInheritEnabled));
            Debug.Assert(fpm1.Inherits == true);
            Debug.Assert(myCanvas1.IsTransparent == true);
            Debug.Assert(myCanvas2.IsTransparent == true);
            Debug.Assert(myCanvas3.IsTransparent == true);

            // Test disabled property value inheritance.
            Canvas_IsTransparentInheritDisabled myCanvas4 = new()
            {
                IsTransparent = true
            };
            Canvas_IsTransparentInheritDisabled2 myCanvas5 = new();
            Canvas_IsTransparentInheritDisabled3 myCanvas6 = new();
            myCanvas4.Children.Add(myCanvas5);
            myCanvas5.Children.Add(myCanvas6);
            FrameworkPropertyMetadata fpm2 = (FrameworkPropertyMetadata)Canvas_IsTransparentInheritDisabled
                .IsTransparentProperty.GetMetadata(typeof(Canvas_IsTransparentInheritDisabled));
            Debug.Assert(fpm2.Inherits == false);
            Debug.Assert(myCanvas4.IsTransparent == true);
            Debug.Assert(myCanvas5.IsTransparent == false);
            Debug.Assert(myCanvas6.IsTransparent == false);
        }

        private static void TestDependencyPropertyWrapper()
        {
            // Test Canvas_IsTransparentInheritEnabled.
            Canvas_IsTransparentInheritEnabled myCanvas1 = new();
            Canvas_IsTransparentInheritEnabled2 myCanvas2 = new();
            Canvas_IsTransparentInheritEnabled3 myCanvas3 = new();
            // Test property wrapper.
            myCanvas1.IsTransparent = true;
            myCanvas2.IsTransparent = false;
            myCanvas3.IsTransparent = true;
            Debug.Assert(myCanvas1.IsTransparent == true);
            Debug.Assert(myCanvas2.IsTransparent == false);
            Debug.Assert(myCanvas3.IsTransparent == true);
            // Test individual get/set accessors.
            Canvas_IsTransparentInheritEnabled.SetIsTransparent(myCanvas1, false);
            Canvas_IsTransparentInheritEnabled.SetIsTransparent(myCanvas2, true);
            Canvas_IsTransparentInheritEnabled.SetIsTransparent(myCanvas3, false);
            Debug.Assert(Canvas_IsTransparentInheritEnabled.GetIsTransparent(myCanvas1) == false);
            Debug.Assert(Canvas_IsTransparentInheritEnabled.GetIsTransparent(myCanvas2) == true);
            Debug.Assert(Canvas_IsTransparentInheritEnabled.GetIsTransparent(myCanvas3) == false);

            // Test Canvas_IsTransparentInheritDisabled.
            Canvas_IsTransparentInheritDisabled myCanvas4 = new();
            Canvas_IsTransparentInheritDisabled2 myCanvas5 = new();
            Canvas_IsTransparentInheritDisabled3 myCanvas6 = new();
            // Test property wrapper.
            myCanvas4.IsTransparent = true;
            myCanvas5.IsTransparent = false;
            myCanvas6.IsTransparent = true;
            Debug.Assert(myCanvas4.IsTransparent == true);
            Debug.Assert(myCanvas5.IsTransparent == false);
            Debug.Assert(myCanvas6.IsTransparent == true);
            // Test individual get/set accessors.
            Canvas_IsTransparentInheritDisabled.SetIsTransparent(myCanvas4, false);
            Canvas_IsTransparentInheritDisabled.SetIsTransparent(myCanvas5, true);
            Canvas_IsTransparentInheritDisabled.SetIsTransparent(myCanvas6, false);
            Debug.Assert(Canvas_IsTransparentInheritDisabled.GetIsTransparent(myCanvas4) == false);
            Debug.Assert(Canvas_IsTransparentInheritDisabled.GetIsTransparent(myCanvas5) == true);
            Debug.Assert(Canvas_IsTransparentInheritDisabled.GetIsTransparent(myCanvas6) == false);
        }
    }

    public class Canvas_AllowDropInheritDisabled : Canvas
    {
        static Canvas_AllowDropInheritDisabled()
        {
            // Disable property value inheritance in a new property metadata object.
            FrameworkPropertyMetadata frameworkPropertyMetadata = new();
            frameworkPropertyMetadata.Inherits = false;
            // Override existing property metadata.
            AllowDropProperty.OverrideMetadata(typeof(Canvas_AllowDropInheritDisabled), frameworkPropertyMetadata);
        }
    }

    //<RegisterAttachedPropertyWithValueInheritance>
    public class Canvas_IsTransparentInheritEnabled : Canvas
    {
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata
        // (default value is 'false' and property value inheritance is enabled).
        public static readonly DependencyProperty IsTransparentProperty =
            DependencyProperty.RegisterAttached(
                name: "IsTransparent",
                propertyType: typeof(bool),
                ownerType: typeof(Canvas_IsTransparentInheritEnabled),
                defaultMetadata: new FrameworkPropertyMetadata(
                    defaultValue: false,
                    flags: FrameworkPropertyMetadataOptions.Inherits));

        // Declare a get accessor method.
        public static bool GetIsTransparent(Canvas element)
        {
            return (bool)element.GetValue(IsTransparentProperty);
        }

        // Declare a set accessor method.
        public static void SetIsTransparent(Canvas element, bool value)
        {
            element.SetValue(IsTransparentProperty, value);
        }

        // For convenience, declare a property wrapper with get/set accessors.
        public bool IsTransparent
        {
            get => (bool)GetValue(IsTransparentProperty);
            set => SetValue(IsTransparentProperty, value);
        }
    }
    //</RegisterAttachedPropertyWithValueInheritance>

    public class Canvas_IsTransparentInheritEnabled2 : Canvas_IsTransparentInheritEnabled
    {
    }

    public class Canvas_IsTransparentInheritEnabled3 : Canvas_IsTransparentInheritEnabled
    {
    }

    public class Canvas_IsTransparentInheritDisabled : Canvas
    {
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata
        // (default value is 'false' and value inheritance is disabled).
        public static readonly DependencyProperty IsTransparentProperty =
            DependencyProperty.RegisterAttached(
                name: "IsTransparent",
                propertyType: typeof(bool),
                ownerType: typeof(Canvas_IsTransparentInheritDisabled),
                defaultMetadata: new FrameworkPropertyMetadata(
                    defaultValue: false));

        // Declare a get accessor method.
        public static bool GetIsTransparent(Canvas element)
        {
            return (bool)element.GetValue(IsTransparentProperty);
        }

        // Declare a set accessor method.
        public static void SetIsTransparent(Canvas element, bool value)
        {
            element.SetValue(IsTransparentProperty, value);
        }

        // For convenience, declare a property wrapper with get/set accessors.
        public bool IsTransparent
        {
            get => (bool)GetValue(IsTransparentProperty);
            set => SetValue(IsTransparentProperty, value);
        }
    }

    public class Canvas_IsTransparentInheritDisabled2 : Canvas_IsTransparentInheritDisabled
    {
    }

    public class Canvas_IsTransparentInheritDisabled3 : Canvas_IsTransparentInheritDisabled
    {
    }
}
