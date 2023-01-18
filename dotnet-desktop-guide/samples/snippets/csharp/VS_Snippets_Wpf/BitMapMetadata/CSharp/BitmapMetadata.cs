using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace SDKSample
{
    public class app : Application
    {
        Window mainWindow;

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        private void CreateAndShowMainWindow ()
        {

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "Image Metadata";

            // <SnippetSetQuery>
            using (var imageStream = new System.IO.FileStream("smiley.jpg", FileMode.Open,
                                                                            FileAccess.ReadWrite,
                                                                            FileShare.ReadWrite))
            {
                var decoder = new JpegBitmapDecoder(imageStream,
                                                       BitmapCreateOptions.PreservePixelFormat,
                                                       BitmapCacheOption.Default);

                BitmapFrame frame = decoder.Frames[0];
                decoder.Metadata.Comment = "This file was edited in WPF";

                // Try to set the metadata directly on the image
                InPlaceBitmapMetadataWriter inplaceMetadata = frame.CreateInPlaceBitmapMetadataWriter();
                inplaceMetadata.SetQuery("System.Title", "Yellow Smile");

                if (!inplaceMetadata.TrySave())
                {
                    // In place metadata save failed, must rencode image
                    using (var saveStream = File.Create("smiley.jpg"))
                    {
                        var encoder = new JpegBitmapEncoder();

                        // Duplicate each frame
                        foreach (var cloneFrame in decoder.Frames)
                            encoder.Frames.Add(BitmapFrame.Create(cloneFrame));

                        // Set metadata
                        ((BitmapMetadata)encoder.Frames[0].Metadata).SetQuery("System.Title", "Yellow Smile");

                        encoder.Save(saveStream);
                    }
                }
            }
            // </SnippetSetQuery>

            // Draw the Image
            Image myImage = new Image();
            myImage.Source = new BitmapImage(new Uri("smiley.png", UriKind.Relative));
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(20);

            TextBlock myTextBlock = new TextBlock();

            // <SnippetGetQuery>
            // Add the metadata of the bitmap image to the text block.
            var metadataValue = string.Empty;

            using (var imageStream = new System.IO.FileStream("smiley.jpg", FileMode.Open,
                                                                            FileAccess.ReadWrite,
                                                                            FileShare.ReadWrite))
            {
                var decoder = new JpegBitmapDecoder(imageStream,
                                                        BitmapCreateOptions.PreservePixelFormat,
                                                        BitmapCacheOption.Default);

                var metadata = (BitmapMetadata)decoder.Frames[0].Metadata;

                metadataValue = $"The Description metadata of this image is: {metadata.GetQuery("System.Title")}";
            }
            // </SnippetGetQuery>
            myTextBlock.Text = metadataValue;

            // Define a StackPanel to host Controls
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.Height = 200;
            myStackPanel.VerticalAlignment = VerticalAlignment.Top;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Center;

            // Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage);
            myStackPanel.Children.Add(myTextBlock);

            // Add the StackPanel as the Content of the Parent Window Object
            mainWindow.Content = myStackPanel;
            mainWindow.Show();
        }

    }

    // Define a static entry class
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {
            app app = new app ();
            app.Run ();
        }
    }
}
