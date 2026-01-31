using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AllTemplatesCS.Pages
{
    public partial class ScrollBarPage : Page
    {
        public ScrollBarPage()
        {
            InitializeComponent();
        }

        private void HorizontalScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (HorizontalValue != null)
                HorizontalValue.Text = $"Value: {e.NewValue:F0}";
        }

        private void VerticalScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VerticalValue != null)
                VerticalValue.Text = $"Value: {e.NewValue:F0}";
        }

        private void LargeChangeScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LargeChangeValue != null)
                LargeChangeValue.Text = $"Value: {e.NewValue:F0}";
        }
    }
}
