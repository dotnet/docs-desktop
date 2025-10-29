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
            var renderTargetBitmap = new RenderTargetBitmap(
                (int)element.ActualWidth,
                (int)element.ActualHeight,
                96, 96, PixelFormats.Pbgra32);

            renderTargetBitmap.Render(element);

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
