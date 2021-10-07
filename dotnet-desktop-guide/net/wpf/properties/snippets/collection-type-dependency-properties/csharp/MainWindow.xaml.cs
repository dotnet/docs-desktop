using System.Collections.Generic;
using System.Windows;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        //<InitializeAquariums>
        private void InitializeAquariums(object sender, RoutedEventArgs e)
        {
            Aquarium aquarium1 = new();
            Aquarium aquarium2 = new();
            aquarium1.AquariumContents.Add(new Fish());
            aquarium2.AquariumContents.Add(new Fish());
            MessageBox.Show(
                $"Aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"Aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }
        //</InitializeAquariums>
    }

    //<SetCollectionDefaultValueInConstructor>
    public class Aquarium : DependencyObject
    {
        // Register a dependency property with the specified property name,
        // property type, owner type, and property metadata.
        private static readonly DependencyPropertyKey s_aquariumContentsPropertyKey =
            DependencyProperty.RegisterReadOnly(
              "AquariumContents",
              typeof(List<FrameworkElement>),
              typeof(Aquarium),
              new FrameworkPropertyMetadata()
            );

        // Store the dependency property identifier as a static member of the class.
        public static readonly DependencyProperty AquariumContentsProperty =
            s_aquariumContentsPropertyKey.DependencyProperty;

        // Set the default collection value in a class constructor.
        public Aquarium() => SetValue(s_aquariumContentsPropertyKey, new List<FrameworkElement>());

        // Declare a read-only property.
        public List<FrameworkElement> AquariumContents =>
            (List<FrameworkElement>)GetValue(AquariumContentsProperty);
    }

    public class Fish : FrameworkElement { }
    //</SetCollectionDefaultValueInConstructor>

    public class ReadWriteAquariumContents
    {
        private static void InitializeAquariums()
        {
            Aquarium aquarium1 = new();
            Aquarium aquarium2 = new();
            aquarium1.AquariumContents.Add(new Fish());
            aquarium2.AquariumContents.Add(new Fish());
            aquarium2.AquariumContents = new List<FrameworkElement>();
            MessageBox.Show(
                $"Aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"Aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }

        //<ReadWriteDependencyProperty>
        public class Aquarium : DependencyObject
        {
            // Register a dependency property with the specified property name,
            // property type, and owner type.
            private static readonly DependencyProperty s_aquariumContentsProperty =
                DependencyProperty.Register(
                  "AquariumContents",
                  typeof(List<FrameworkElement>),
                  typeof(Aquarium)
                );

            // Store the dependency property identifier as a static member of the class.
            public static readonly DependencyProperty AquariumContentsProperty =
                s_aquariumContentsProperty;

            // Set the default collection value in a class constructor.
            public Aquarium() => SetValue(s_aquariumContentsProperty, new List<FrameworkElement>());

            // Declare a read-write property.
            public List<FrameworkElement> AquariumContents
            {
                get => (List<FrameworkElement>)GetValue(AquariumContentsProperty);
                set => SetValue(AquariumContentsProperty, value);
            }
        }
        //</ReadWriteDependencyProperty>

        public class Fish : FrameworkElement { }
    }
}
