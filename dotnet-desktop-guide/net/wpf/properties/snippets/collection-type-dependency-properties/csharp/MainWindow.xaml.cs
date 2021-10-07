using System.Collections.Generic;
using System.Windows;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        //<AddToCollectionTest>
        private void BtnInitializeAquariumA(object sender, RoutedEventArgs e)
        {
            AquariumA aquarium1 = new();
            AquariumA aquarium2 = new();
            Fish fish1 = new();
            Fish fish2 = new();
            aquarium1.AquariumContents.Add(fish1);
            aquarium2.AquariumContents.Add(fish2);
            MessageBox.Show(
                $"Aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"Aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }
        //</AddToCollectionTest>

        private void BtnInitializeAquariumB(object sender, RoutedEventArgs e)
        {
            AquariumB aquarium1 = new();
            AquariumB aquarium2 = new();
            Fish fish1 = new();
            Fish fish2 = new();
            aquarium1.AquariumContents.Add(fish1);
            aquarium2.AquariumContents.Add(fish2);
            MessageBox.Show(
                $"Aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" +
                $"Aquarium2 contains {aquarium2.AquariumContents.Count} fish");
        }
    }

    //<SetCollectionDefaultValueInMetadata>
    public class AquariumA : DependencyObject
    {
        private static readonly DependencyPropertyKey s_aquariumContentsPropertyKey =
            DependencyProperty.RegisterReadOnly(
              "AquariumContents",
              typeof(List<FrameworkElement>),
              typeof(AquariumA),
              new FrameworkPropertyMetadata(new List<FrameworkElement>())
            );

        public static readonly DependencyProperty AquariumContentsProperty =
            s_aquariumContentsPropertyKey.DependencyProperty;

        public List<FrameworkElement> AquariumContents =>
            (List<FrameworkElement>)GetValue(AquariumContentsProperty);
    }

    public class Fish : FrameworkElement { }
    //</SetCollectionDefaultValueInMetadata>

    public class AquariumB : DependencyObject
    {
        private static readonly DependencyPropertyKey s_aquariumContentsPropertyKey =
            DependencyProperty.RegisterReadOnly(
              "AquariumContents",
              typeof(List<FrameworkElement>),
              typeof(AquariumB),
              null
            );

        public static readonly DependencyProperty AquariumContentsProperty =
            s_aquariumContentsPropertyKey.DependencyProperty;

        //<SetCollectionDefaultValueInConstructor>
        public AquariumB() => SetValue(s_aquariumContentsPropertyKey, new List<FrameworkElement>());
        //</SetCollectionDefaultValueInConstructor>

        public List<FrameworkElement> AquariumContents =>
            (List<FrameworkElement>)GetValue(AquariumContentsProperty);
    }
}
