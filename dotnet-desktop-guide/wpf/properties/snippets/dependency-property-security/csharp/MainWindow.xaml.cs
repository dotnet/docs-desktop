using System;
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

            DependencyPropertyAccessTests();
        }

        //<DependencyPropertyAccessTests>
        /// <summary>
        ///  Test get/set access to dependency properties exposed through the WPF property system.
        /// </summary>
        public static void DependencyPropertyAccessTests()
        {
            // Instantiate a class that implements read-write and read-only dependency properties.
            Aquarium _aquarium = new();
            // Access each dependency property using the LocalValueEnumerator method.
            LocalValueEnumerator localValueEnumerator = _aquarium.GetLocalValueEnumerator();
            while (localValueEnumerator.MoveNext())
            {
                DependencyProperty dp = localValueEnumerator.Current.Property;
                string dpType = dp.ReadOnly ? "read-only" : "read-write";
                // Test read access.
                Debug.WriteLine($"Attempting to get a {dpType} dependency property value...");
                Debug.WriteLine($"Value ({dpType}): {(int)_aquarium.GetValue(dp)}");
                // Test write access.
                try
                {
                    Debug.WriteLine($"Attempting to set a {dpType} dependency property value to 2...");
                    _aquarium.SetValue(dp, 2);
                }
                catch (InvalidOperationException e)
                {
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    Debug.WriteLine($"Value ({dpType}): {(int)_aquarium.GetValue(dp)}");
                }
            }

            // Test output:

            // Attempting to get a read-write dependency property value...
            // Value (read-write): 1
            // Attempting to set a read-write dependency property value to 2...
            // Value (read-write): 2

            // Attempting to get a read-only dependency property value...
            // Value (read-only): 1
            // Attempting to set a read-only dependency property value to 2...
            // 'FishCountReadOnly' property was registered as read-only
            // and cannot be modified without an authorization key.
            // Value (read-only): 1
        }
    }

    public class Aquarium : DependencyObject
    {
        public Aquarium()
        {
            // Assign locally-set values.
            SetValue(FishCountProperty, 1);
            SetValue(FishCountReadOnlyPropertyKey, 1);
        }

        // Failed attempt to restrict write-access by assigning the
        // DependencyProperty identifier to a non-public field.
        private static readonly DependencyProperty FishCountProperty =
            DependencyProperty.Register(
              name: "FishCount",
              propertyType: typeof(int),
              ownerType: typeof(Aquarium),
              typeMetadata: new PropertyMetadata());

        // Successful attempt to restrict write-access by assigning the
        // DependencyPropertyKey to a non-public field.
        private static readonly DependencyPropertyKey FishCountReadOnlyPropertyKey =
            DependencyProperty.RegisterReadOnly(
              name: "FishCountReadOnly",
              propertyType: typeof(int),
              ownerType: typeof(Aquarium),
              typeMetadata: new PropertyMetadata());

        // Declare public get accessors.
        public int FishCount => (int)GetValue(FishCountProperty);
        public int FishCountReadOnly => (int)GetValue(FishCountReadOnlyPropertyKey.DependencyProperty);
    }
    //</DependencyPropertyAccessTests>
}
