using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AllTemplatesCS.Pages
{
    public partial class ThumbPage : Page
    {
        public ThumbPage()
        {
            InitializeComponent();
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is Thumb thumb)
            {
                double left = Canvas.GetLeft(thumb);
                double top = Canvas.GetTop(thumb);

                Canvas.SetLeft(thumb, left + e.HorizontalChange);
                Canvas.SetTop(thumb, top + e.VerticalChange);
            }
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double newWidth = Math.Max(ResizableBox.Width + e.HorizontalChange, 100);
            double newHeight = Math.Max(ResizableBox.Height + e.VerticalChange, 60);

            ResizableBox.Width = newWidth;
            ResizableBox.Height = newHeight;
        }
    }
}
