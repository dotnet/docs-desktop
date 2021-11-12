using System;
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
        public MainWindow() => InitializeComponent();

        public void RunTests(object sender, RoutedEventArgs e)
        {
            TestValidationBehavior();
            TestCoercionBehavior();
            TestGetValueSource();
        }

        //<TestValueValidationScenario>
        public static void TestValidationBehavior()
        {
            Gauge1 gauge = new();

            Debug.WriteLine($"Test value validation scenario:");

            // Set allowed value.
            gauge.CurrentReading = 5;
            Debug.WriteLine($"Current reading: {gauge.CurrentReading}");

            try
            {
                // Set disallowed value.
                gauge.CurrentReading = double.PositiveInfinity;
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine($"Exception thrown by ValidateValueCallback: {e.Message}");
            }

            Debug.WriteLine($"Current reading: {gauge.CurrentReading}");

            // Current reading: 5
            // Exception thrown by ValidateValueCallback: '∞' is not a valid value for property 'CurrentReading'.
            // Current reading: 5
        }
        //</TestValueValidationScenario>

        //<TestCurrentMinMaxScenario>
        public static void TestCoercionBehavior()
        {
            Gauge2 gauge = new()
            {
                // Set initial values.
                MinReading = 0,
                MaxReading = 10,
                CurrentReading = 5
            };

            Debug.WriteLine($"Test current/min/max values scenario:");

            // Current reading is not coerced.
            Debug.WriteLine($"Current reading: " +
                $"{gauge.CurrentReading} (min: {gauge.MinReading}, max: {gauge.MaxReading})");

            // Current reading is coerced to max value.
            gauge.MaxReading = 3;
            Debug.WriteLine($"Current reading: " +
                $"{gauge.CurrentReading} (min: {gauge.MinReading}, max: {gauge.MaxReading})");

            // Current reading is coerced, but tracking back to the desired value.
            gauge.MaxReading = 4;
            Debug.WriteLine($"Current reading: " +
                $"{gauge.CurrentReading} (min: {gauge.MinReading}, max: {gauge.MaxReading})");

            // Current reading reverts to the desired value.
            gauge.MaxReading = 10;
            Debug.WriteLine($"Current reading: " +
                $"{gauge.CurrentReading} (min: {gauge.MinReading}, max: {gauge.MaxReading})");

            // Current reading remains at the desired value.
            gauge.MinReading = 5;
            gauge.MaxReading = 5;
            Debug.WriteLine($"Current reading: " +
                $"{gauge.CurrentReading} (min: {gauge.MinReading}, max: {gauge.MaxReading})");

            // Current reading: 5 (min=0, max=10)
            // Current reading: 3 (min=0, max=3)
            // Current reading: 4 (min=0, max=4)
            // Current reading: 5 (min=0, max=10)
            // Current reading: 5 (min=5, max=5)
        }
        //</TestCurrentMinMaxScenario>

        //<TestGetValueSourceScenario>
        public static void TestGetValueSource()
        {
            Gauge3 gauge = new()
            {
                // The GetValueSource method sees the first
                // locally set value as a default value (why?)
                CurrentReading = 5
            };

            Debug.WriteLine($"Test GetValueSource scenario:");

            // Locally set value.
            gauge.CurrentReading = 7;

            // Locally set value is rejected.
            Debug.WriteLine($"Current reading: " +
                $"{gauge.CurrentReading}");

            // Current reading: 5
        }
        //</TestGetValueSourceScenario>
    }

    //<ValueValidationScenario>
    public class Gauge1 : Control
    {
        public Gauge1() : base() { }

        // Register a dependency property with the specified property name,
        // property type, owner type, property metadata, and callbacks.
        public static readonly DependencyProperty CurrentReadingProperty =
            DependencyProperty.Register(
                name: "CurrentReading",
                propertyType: typeof(double),
                ownerType: typeof(Gauge1),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: double.NaN,
                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure),
                validateValueCallback: new ValidateValueCallback(IsValidReading));

        // CLR wrapper with get/set accessors.
        public double CurrentReading
        {
            get => (double)GetValue(CurrentReadingProperty);
            set => SetValue(CurrentReadingProperty, value);
        }

        // Validate-value callback.
        public static bool IsValidReading(object value)
        {
            double val = (double)value;
            return !val.Equals(double.NegativeInfinity) && 
                !val.Equals(double.PositiveInfinity);
        }
    }
    //</ValueValidationScenario>

    //<CurrentMinMaxScenario>
    public class Gauge2 : Control
    {
        public Gauge2() : base() { }

        // Register a dependency property with the specified property name,
        // property type, owner type, property metadata, and callbacks.
        public static readonly DependencyProperty CurrentReadingProperty =
            DependencyProperty.Register(
                name: "CurrentReading",
                propertyType: typeof(double),
                ownerType: typeof(Gauge2),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: double.NaN,
                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                    propertyChangedCallback: new PropertyChangedCallback(OnCurrentReadingChanged),
                    coerceValueCallback: new CoerceValueCallback(CoerceCurrentReading)
                ),
                validateValueCallback: new ValidateValueCallback(IsValidReading)
            );

        // CLR wrapper with get/set accessors.
        public double CurrentReading
        {
            get => (double)GetValue(CurrentReadingProperty);
            set => SetValue(CurrentReadingProperty, value);
        }

        // Validate-value callback.
        public static bool IsValidReading(object value)
        {
            double val = (double)value;
            return !val.Equals(double.NegativeInfinity) && !val.Equals(double.PositiveInfinity);
        }

        // Property-changed callback.
        private static void OnCurrentReadingChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            depObj.CoerceValue(MinReadingProperty);
            depObj.CoerceValue(MaxReadingProperty);
        }

        // Coerce-value callback.
        private static object CoerceCurrentReading(DependencyObject depObj, object value)
        {
            Gauge2 gauge = (Gauge2)depObj;
            double currentVal = (double)value;
            currentVal = currentVal < gauge.MinReading ? gauge.MinReading : currentVal;
            currentVal = currentVal > gauge.MaxReading ? gauge.MaxReading : currentVal;
            return currentVal;
        }

        // Register a dependency property with the specified property name,
        // property type, owner type, property metadata, and callbacks.
        public static readonly DependencyProperty MaxReadingProperty = DependencyProperty.Register(
            name: "MaxReading",
            propertyType: typeof(double),
            ownerType: typeof(Gauge2),
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: double.NaN,
                flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                propertyChangedCallback: new PropertyChangedCallback(OnMaxReadingChanged),
                coerceValueCallback: new CoerceValueCallback(CoerceMaxReading)
            ),
            validateValueCallback: new ValidateValueCallback(IsValidReading)
        );

        // CLR wrapper with get/set accessors.
        public double MaxReading
        {
            get => (double)GetValue(MaxReadingProperty);
            set => SetValue(MaxReadingProperty, value);
        }

        // Property-changed callback.
        private static void OnMaxReadingChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            depObj.CoerceValue(MinReadingProperty);
            depObj.CoerceValue(CurrentReadingProperty);
        }

        // Coerce-value callback.
        private static object CoerceMaxReading(DependencyObject depObj, object value)
        {
            Gauge2 gauge = (Gauge2)depObj;
            double maxVal = (double)value;
            return maxVal < gauge.MinReading ? gauge.MinReading : maxVal;
        }

        // Register a dependency property with the specified property name,
        // property type, owner type, property metadata, and callbacks.
        public static readonly DependencyProperty MinReadingProperty = DependencyProperty.Register(
        name: "MinReading",
        propertyType: typeof(double),
        ownerType: typeof(Gauge2),
        typeMetadata: new FrameworkPropertyMetadata(
            defaultValue: double.NaN,
            flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
            propertyChangedCallback: new PropertyChangedCallback(OnMinReadingChanged),
            coerceValueCallback: new CoerceValueCallback(CoerceMinReading)
        ),
        validateValueCallback: new ValidateValueCallback(IsValidReading));

        // CLR wrapper with get/set accessors.
        public double MinReading
        {
            get => (double)GetValue(MinReadingProperty);
            set => SetValue(MinReadingProperty, value);
        }

        // Property-changed callback.
        private static void OnMinReadingChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            depObj.CoerceValue(MaxReadingProperty);
            depObj.CoerceValue(CurrentReadingProperty);
        }

        // Coerce-value callback.
        private static object CoerceMinReading(DependencyObject depObj, object value)
        {
            Gauge2 gauge = (Gauge2)depObj;
            double minVal = (double)value;
            return minVal > gauge.MaxReading ? gauge.MaxReading : minVal;
        }
    }
    //</CurrentMinMaxScenario>

    public class Gauge3 : Control
    {
        public Gauge3() : base() { }

        // Register a dependency property with the specified property name,
        // property type, owner type, property metadata, and callbacks.
        public static readonly DependencyProperty CurrentReadingProperty =
            DependencyProperty.Register(
                name: "CurrentReading",
                propertyType: typeof(double),
                ownerType: typeof(Gauge3),
                typeMetadata: new FrameworkPropertyMetadata(
                    defaultValue: double.NaN,
                    flags: FrameworkPropertyMetadataOptions.AffectsMeasure,
                    propertyChangedCallback: null,
                    coerceValueCallback: new CoerceValueCallback(CoerceCurrentReading)
                )
            );

        // CLR wrapper with get/set accessors.
        public double CurrentReading
        {
            get => (double)GetValue(CurrentReadingProperty);
            set => SetValue(CurrentReadingProperty, value);
        }

        //<GetValueSourceScenario>
        // Coerce-value callback.
        private static object CoerceCurrentReading(DependencyObject depObj, object value)
        {
            // Get value source.
            ValueSource valueSource = 
                DependencyPropertyHelper.GetValueSource(depObj, CurrentReadingProperty);

            // Reject any property value change that's a locally set value.
            return valueSource.BaseValueSource == BaseValueSource.Local ? 
                DependencyProperty.UnsetValue : value;
        }
        //</GetValueSourceScenario>
    }
}
