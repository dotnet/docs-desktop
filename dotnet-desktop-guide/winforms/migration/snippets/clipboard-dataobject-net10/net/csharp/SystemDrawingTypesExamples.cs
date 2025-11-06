using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class SystemDrawingTypesExamples
    {
        // <SystemDrawingTypes>
        public static void SystemDrawingTypesExample()
        {
            // Geometric types
            Point location = new Point(100, 200);
            Rectangle bounds = new Rectangle(0, 0, 500, 300);
            Size dimensions = new Size(800, 600);

            Clipboard.SetData("Location", location);
            Clipboard.SetData("Bounds", bounds);
            Clipboard.SetData("Size", dimensions);

            // Color information
            Color backgroundColor = Color.FromArgb(255, 128, 64, 192);
            Clipboard.SetData("BackColor", backgroundColor);

            // Bitmap data (use with caution for large images)
            Bitmap smallIcon = new Bitmap(16, 16);
            Clipboard.SetData("Icon", smallIcon);
        }
        // </SystemDrawingTypes>
    }
}