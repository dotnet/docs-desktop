using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace AllTemplatesCS;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ControlsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ControlsListBox.SelectedItem is ListBoxItem selectedItem)
        {
            string controlName = selectedItem.Content.ToString();
            SelectedControlTitle.Text = $"Preview: {controlName}";
            ScreenshotButton.IsEnabled = true;
            
            // Set Frame background to white for screenshots
            PreviewFrame.Background = Brushes.White;
            
            // Navigate to the appropriate page
            string pageName = $"Pages/{controlName}Page.xaml";
            try
            {
                PreviewFrame.Navigate(new Uri(pageName, UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load page for {controlName}: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    private void ScreenshotButton_Click(object sender, RoutedEventArgs e)
    {
        if (PreviewFrame.Content != null)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png",
                Title = "Save Screenshot",
                FileName = $"{SelectedControlTitle.Text.Replace("Preview: ", "")}_screenshot.png"
            };

            if (saveDialog.ShowDialog() == true)
            {
                TakeScreenshot(PreviewFrame, saveDialog.FileName);
            }
        }
    }

    private void TakeScreenshot(FrameworkElement element, string fileName)
    {
        try
        {
            const int margin = 10;
            FrameworkElement contentToCapture = element;
            
            // If it's a Frame, get the Page content, then the Page's child
            if (element is Frame frame && frame.Content is Page page)
            {
                // Get the child element of the page (e.g., StackPanel, Grid, etc.)
                if (page.Content is FrameworkElement pageChild)
                {
                    contentToCapture = pageChild;
                }
            }

            contentToCapture.UpdateLayout();

            // Get the DPI of the element to match screen resolution
            PresentationSource source = PresentationSource.FromVisual(contentToCapture);
            double dpiX = 96.0;
            double dpiY = 96.0;
            double dpiScaleX = 1.0;
            double dpiScaleY = 1.0;
            
            if (source?.CompositionTarget != null)
            {
                dpiScaleX = source.CompositionTarget.TransformToDevice.M11;
                dpiScaleY = source.CompositionTarget.TransformToDevice.M22;
                dpiX = 96.0 * dpiScaleX;
                dpiY = 96.0 * dpiScaleY;
            }

            // Get the bounds of the actual content
            Rect contentBounds = VisualTreeHelper.GetDescendantBounds(contentToCapture);
            
            double contentWidth = contentBounds.IsEmpty ? contentToCapture.ActualWidth : contentBounds.Width;
            double contentHeight = contentBounds.IsEmpty ? contentToCapture.ActualHeight : contentBounds.Height;
            
            // Scale dimensions by DPI for the bitmap
            int width = (int)((contentWidth + (margin * 2)) * dpiScaleX);
            int height = (int)((contentHeight + (margin * 2)) * dpiScaleY);

            var renderTargetBitmap = new RenderTargetBitmap(
                width,
                height,
                dpiX, dpiY, PixelFormats.Pbgra32);

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                // Draw white background
                drawingContext.DrawRectangle(Brushes.White, null, new Rect(0, 0, width, height));
                
                // Draw the content with margin offset
                var visualBrush = new VisualBrush(contentToCapture)
                {
                    Stretch = Stretch.None,
                    AlignmentX = AlignmentX.Left,
                    AlignmentY = AlignmentY.Top
                };
                
                drawingContext.DrawRectangle(
                    visualBrush, 
                    null, 
                    new Rect(margin, margin, contentWidth, contentHeight));
            }

            renderTargetBitmap.Render(drawingVisual);

            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                pngEncoder.Save(fileStream);
            }

            MessageBox.Show($"Screenshot saved to: {fileName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error taking screenshot: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
