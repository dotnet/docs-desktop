using System;
using System.Windows;
using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class RepeatButtonPage : Page
    {
        private int counterValue = 50;
        private int volumeValue = 75;
        private int scrollValue = 0;

        public RepeatButtonPage()
        {
            InitializeComponent();
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            counterValue = Math.Min(counterValue + 1, 100);
            CounterValue.Text = counterValue.ToString();
        }

        private void DecrementButton_Click(object sender, RoutedEventArgs e)
        {
            counterValue = Math.Max(counterValue - 1, 0);
            CounterValue.Text = counterValue.ToString();
        }

        private void VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            volumeValue = Math.Min(volumeValue + 2, 100);
            VolumeBar.Value = volumeValue;
        }

        private void VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            volumeValue = Math.Max(volumeValue - 2, 0);
            VolumeBar.Value = volumeValue;
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            scrollValue = Math.Min(scrollValue + 1, 200);
            ScrollPosition.Text = $"Position: {scrollValue}";
        }

        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            scrollValue = Math.Max(scrollValue - 1, 0);
            ScrollPosition.Text = $"Position: {scrollValue}";
        }
    }
}
