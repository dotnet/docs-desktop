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
                $"aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }
        //</InitializeAquariums>

        private void InitializeFreezableAquariums(object sender, RoutedEventArgs e)
        {
            FreezableCollectionAquarium.InitializeAquariums();
        }
    }

    //<SetCollectionDefaultValueInConstructor>
    public class Aquarium : DependencyObject
    {
        // Register a dependency property with the specified property name,
        // property type, owner type, and property metadata.
        private static readonly DependencyPropertyKey s_aquariumContentsPropertyKey =
            DependencyProperty.RegisterReadOnly(
              name: "AquariumContents",
              propertyType: typeof(List<FrameworkElement>),
              ownerType: typeof(Aquarium),
              typeMetadata: new FrameworkPropertyMetadata()
              //typeMetadata: new FrameworkPropertyMetadata(new List<FrameworkElement>())
            );

        // Set the default collection value in a class constructor.
        public Aquarium() => SetValue(s_aquariumContentsPropertyKey, new List<FrameworkElement>());

        // Declare a public get accessor.
        public List<FrameworkElement> AquariumContents =>
            (List<FrameworkElement>)GetValue(s_aquariumContentsPropertyKey.DependencyProperty);
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
                $"aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }

        //<ReadWriteDependencyProperty>
        public class Aquarium : DependencyObject
        {
            // Register a dependency property with the specified property name,
            // property type, and owner type. Store the dependency property
            // identifier as a public static readonly member of the class.
            public static readonly DependencyProperty AquariumContentsProperty =
                DependencyProperty.Register(
                  name: "AquariumContents",
                  propertyType: typeof(List<FrameworkElement>),
                  ownerType: typeof(Aquarium)
                );

            // Set the default collection value in a class constructor.
            public Aquarium() => SetValue(AquariumContentsProperty, new List<FrameworkElement>());

            // Declare public get and set accessors.
            public List<FrameworkElement> AquariumContents
            {
                get => (List<FrameworkElement>)GetValue(AquariumContentsProperty);
                set => SetValue(AquariumContentsProperty, value);
            }
        }
        //</ReadWriteDependencyProperty>

        public class Fish : FrameworkElement { }
    }

    public class FreezableCollectionAquarium
    {
        public static void InitializeAquariums()
        {
            Aquarium aquarium1 = new();
            Aquarium aquarium2 = new();
            aquarium1.AquariumContents.Add(new Fish());
            aquarium2.AquariumContents.Add(new Fish());
            MessageBox.Show(
                $"FreezableCollection aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"FreezableCollection aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }

        //<FreezableCollectionAquarium>
        public class Aquarium : DependencyObject
        {
            // Register a dependency property with the specified property name,
            // property type, and owner type.
            private static readonly DependencyPropertyKey s_aquariumContentsPropertyKey =
                DependencyProperty.RegisterReadOnly(
                  name: "AquariumContents",
                  propertyType: typeof(FreezableCollection<FrameworkElement>),
                  ownerType: typeof(Aquarium),
                  typeMetadata: new FrameworkPropertyMetadata()
                );

            // Store the dependency property identifier as a static member of the class.
            public static readonly DependencyProperty AquariumContentsProperty =
                s_aquariumContentsPropertyKey.DependencyProperty;

            // Set the default collection value in a class constructor.
            public Aquarium() => SetValue(s_aquariumContentsPropertyKey, new FreezableCollection<FrameworkElement>());

            // Declare a public get accessor.
            public FreezableCollection<FrameworkElement> AquariumContents =>
                (FreezableCollection<FrameworkElement>)GetValue(AquariumContentsProperty);
        }
        //</FreezableCollectionAquarium>

        public class Fish : FrameworkElement { }
    }
}
