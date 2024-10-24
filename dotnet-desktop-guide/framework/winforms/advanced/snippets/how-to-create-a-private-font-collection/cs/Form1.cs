using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fonts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <DrawFont>
        // Helper function to print text in a font and style
        private float DrawFont(Graphics graphicsObj,
                               FontFamily family,
                               FontStyle style,
                               SolidBrush colorBrush,
                               PointF location,
                               string styleName)
        {
            // The string to print, which contains the family name and style
            string familyNameAndStyle = $"{family.Name} {styleName}";

            // Create the font object
            using (Font fontObject = new Font(family.Name, 16, style, GraphicsUnit.Pixel))
            {
                // Draw the string
                graphicsObj.DrawString(familyNameAndStyle, fontObject, colorBrush, location);

                // Return the height of the font
                return fontObject.Height;
            }
        }

        // The OnPaint method of a form, which provides the graphics object
        protected override void OnPaint(PaintEventArgs e)
        {
            PointF pointF = new PointF(10, 0);
            SolidBrush solidBrush = new SolidBrush(Color.Black);

            FontFamily[] fontFamilies;
            PrivateFontCollection privateFontCollection = new PrivateFontCollection(); // Dispose later

            // Add three font files to the private collection.
            privateFontCollection.AddFontFile(System.Environment.ExpandEnvironmentVariables("%systemroot%\\Fonts\\Arial.ttf"));
            privateFontCollection.AddFontFile(System.Environment.ExpandEnvironmentVariables("%systemroot%\\Fonts\\CourBI.ttf"));
            privateFontCollection.AddFontFile(System.Environment.ExpandEnvironmentVariables("%systemroot%\\Fonts\\TimesBD.ttf"));

            // Get the array of FontFamily objects.
            fontFamilies = privateFontCollection.Families;

            // Process each font in the collection
            for (int i = 0; i < fontFamilies.Length; i++)
            {
                // Draw the font in every style

                // Regular
                if (fontFamilies[i].IsStyleAvailable(FontStyle.Regular))
                    pointF.Y += DrawFont(e.Graphics, fontFamilies[i], FontStyle.Regular, solidBrush, pointF, "Regular");

                // Bold
                if (fontFamilies[i].IsStyleAvailable(FontStyle.Bold))
                    pointF.Y += DrawFont(e.Graphics, fontFamilies[i], FontStyle.Bold, solidBrush, pointF, "Bold");

                // Italic
                if (fontFamilies[i].IsStyleAvailable(FontStyle.Italic))
                    pointF.Y += DrawFont(e.Graphics, fontFamilies[i], FontStyle.Italic, solidBrush, pointF, "Italic");

                // Bold and Italic
                if (fontFamilies[i].IsStyleAvailable(FontStyle.Bold) &&
                    fontFamilies[i].IsStyleAvailable(FontStyle.Italic))
                    pointF.Y += DrawFont(e.Graphics, fontFamilies[i], FontStyle.Bold | FontStyle.Italic, solidBrush, pointF, "BoldItalic");

                // Underline
                if (fontFamilies[i].IsStyleAvailable(FontStyle.Underline))
                    pointF.Y += DrawFont(e.Graphics, fontFamilies[i], FontStyle.Underline, solidBrush, pointF, "Underline");

                // Strikeout
                if (fontFamilies[i].IsStyleAvailable(FontStyle.Strikeout))
                    pointF.Y += DrawFont(e.Graphics, fontFamilies[i], FontStyle.Strikeout, solidBrush, pointF, "Strikeout");

                // Extra space between font families
                pointF.Y += 10;
            }

            privateFontCollection.Dispose();
        }
        // </DrawFont>
    }
}
