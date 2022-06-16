using System;
using System.Collections.Generic;
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
            TestUnsafeConstructorPattern();
        }

        //<TestUnsafeConstructorPattern>
        private static void TestUnsafeConstructorPattern()
        {
            //Aquarium aquarium = new();
            //Debug.WriteLine($"Aquarium temperature (C): {aquarium.TempCelcius}");

            // Instantiate and set tropical aquarium temperature.
            TropicalAquarium tropicalAquarium = new(tempCelcius: 25);
            Debug.WriteLine($"Tropical aquarium temperature (C): " +
                $"{tropicalAquarium.TempCelcius}");

            /* Test output:
            Derived class static constructor running.
            Base class ValidateValueCallback running.
            Base class ValidateValueCallback running.
            Base class ValidateValueCallback running.
            Base class parameterless constructor running.
            Base class ValidateValueCallback running.
            Derived class CoerceValueCallback running.
            Derived class CoerceValueCallback: null reference exception.
            Derived class OnPropertyChanged event running.
            Derived class OnPropertyChanged event: null reference exception.
            Derived class PropertyChangedCallback running.
            Derived class PropertyChangedCallback: null reference exception.
            Aquarium temperature (C): 20
            Derived class parameterless constructor running.
            Derived class parameter constructor running.
            Base class ValidateValueCallback running.
            Derived class CoerceValueCallback running.
            Derived class OnPropertyChanged event running.
            Derived class PropertyChangedCallback running.
            Tropical aquarium temperature (C): 25
            */
        }
    }

    public class Aquarium : DependencyObject
    {
        // Register a dependency property with the specified property name,
        // property type, owner type, property metadata with default value,
        // and validate-value callback.
        public static readonly DependencyProperty TempCelciusProperty =
            DependencyProperty.Register(
                name: "TempCelcius",
                propertyType: typeof(int),
                ownerType: typeof(Aquarium),
                typeMetadata: new PropertyMetadata(defaultValue: 0),
                validateValueCallback: 
                    new ValidateValueCallback(ValidateValueCallback));

        // Parameterless constructor.
        public Aquarium()
        {
            Debug.WriteLine("Base class parameterless constructor running.");

            // Set typical aquarium temperature.
            TempCelcius = 20;

            Debug.WriteLine($"Aquarium temperature (C): {TempCelcius}");
        }

        // Declare public read-write accessors.
        public int TempCelcius
        {
            get => (int)GetValue(TempCelciusProperty);
            set => SetValue(TempCelciusProperty, value);
        }

        // Validate-value callback.
        public static bool ValidateValueCallback(object value)
        {
            Debug.WriteLine("Base class ValidateValueCallback running.");
            double val = (int)value;
            return val >= 0;
        }
    }

    public class TropicalAquarium : Aquarium
    {
        // Class field.
        private static List<int> s_temperatureLog;

        // Static constructor.
        static TropicalAquarium()
        {
            Debug.WriteLine("Derived class static constructor running.");

            // Create a new metadata instance with callbacks specified.
            PropertyMetadata newPropertyMetadata = new(
                defaultValue: 0,
                propertyChangedCallback: new PropertyChangedCallback(PropertyChangedCallback),
                coerceValueCallback: new CoerceValueCallback(CoerceValueCallback));

            // Call OverrideMetadata on the dependency property identifier.
            TempCelciusProperty.OverrideMetadata(
                forType: typeof(TropicalAquarium),
                typeMetadata: newPropertyMetadata);
        }

        // Parameterless constructor.
        public TropicalAquarium()
        {
            Debug.WriteLine("Derived class parameterless constructor running.");
            s_temperatureLog = new List<int>();
        }

        // Parameter constructor.
        public TropicalAquarium(int tempCelcius) : this()
        {
            Debug.WriteLine("Derived class parameter constructor running.");
            TempCelcius = tempCelcius;
            s_temperatureLog.Add(tempCelcius);
        }

        // Property-changed callback.
        private static void PropertyChangedCallback(DependencyObject depObj, 
            DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("Derived class PropertyChangedCallback running.");
            try
            {
                s_temperatureLog.Add((int)e.NewValue);
            }
            catch (NullReferenceException)
            {
                Debug.WriteLine("Derived class PropertyChangedCallback: null reference exception.");
            }
        }

        // Coerce-value callback.
        private static object CoerceValueCallback(DependencyObject depObj, object value)
        {
            Debug.WriteLine("Derived class CoerceValueCallback running.");
            try
            {
                s_temperatureLog.Add((int)value);
            }
            catch (NullReferenceException)
            {
                Debug.WriteLine("Derived class CoerceValueCallback: null reference exception.");
            }
            return value;
        }

        // OnPropertyChanged event.
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("Derived class OnPropertyChanged event running.");
            try
            {
                s_temperatureLog.Add((int)e.NewValue);
            }
            catch (NullReferenceException)
            {
                Debug.WriteLine("Derived class OnPropertyChanged event: null reference exception.");
            }

            // Mandatory call to base implementation.
            base.OnPropertyChanged(e);
        }
    }
    //</TestUnsafeConstructorPattern>
}
