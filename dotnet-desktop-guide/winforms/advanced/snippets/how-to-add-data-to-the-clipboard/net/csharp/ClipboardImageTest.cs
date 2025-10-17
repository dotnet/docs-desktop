using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClipboardOperations
{
    public partial class ClipboardImageTest : Form
    {
        public ClipboardImageTest()
        {
            InitializeComponent();
            LoadImages();
        }

        private void LoadImages()
        {
            try
            {
                // Load image1.png into pictureBox1
                if (File.Exists("image1.png"))
                {
                    pictureBox1.Image = Image.FromFile("image1.png");
                }
                else
                {
                    // Create a simple colored rectangle if image doesn't exist
                    pictureBox1.Image = CreateTestImage(Color.Red, "Image 1");
                }

                // Load image2.png into pictureBox2
                if (File.Exists("image2.png"))
                {
                    pictureBox2.Image = Image.FromFile("image2.png");
                }
                else
                {
                    // Create a simple colored rectangle if image doesn't exist
                    pictureBox2.Image = CreateTestImage(Color.Blue, "Image 2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image CreateTestImage(Color backgroundColor, string text)
        {
            Bitmap bitmap = new Bitmap(150, 100);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(backgroundColor), 0, 0, 150, 100);
                g.DrawString(text, SystemFonts.DefaultFont, Brushes.White, 10, 40);
            }
            return bitmap;
        }

        private void btnSetImage1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    Clipboard.SetImage(pictureBox1.Image);
                    MessageBox.Show("Image 1 copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No image to copy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying image to clipboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetImage2_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox2.Image != null)
                {
                    Clipboard.SetImage(pictureBox2.Image);
                    MessageBox.Show("Image 2 copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No image to copy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying image to clipboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetFromClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    Image clipboardImage = Clipboard.GetImage();
                    pictureBox3.Image = clipboardImage;
                    MessageBox.Show("Image retrieved from clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No image found in clipboard!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pictureBox3.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting image from clipboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
