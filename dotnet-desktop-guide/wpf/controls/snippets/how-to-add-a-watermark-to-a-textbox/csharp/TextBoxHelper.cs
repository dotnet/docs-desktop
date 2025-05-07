// <Namespaces>
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
// </Namespaces>

namespace DotnetDocsSample
{
    // <FullClass>
    public static class TextBoxHelper
    {
        // <AttachedProperty>
        public static string GetPlaceholder(DependencyObject obj) =>
            (string)obj.GetValue(PlaceholderProperty);

        public static void SetPlaceholder(DependencyObject obj, string value) =>
            obj.SetValue(PlaceholderProperty, value);

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(TextBoxHelper),
                new FrameworkPropertyMetadata(
                    defaultValue: null,
                    propertyChangedCallback: OnPlaceholderChanged)
                );
        // </AttachedProperty>

        // <OnPlaceholderChanged>
        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBoxControl)
            {
                if (!textBoxControl.IsLoaded)
                {
                    // Ensure that the events are not added multiple times
                    textBoxControl.Loaded -= TextBoxControl_Loaded;
                    textBoxControl.Loaded += TextBoxControl_Loaded;
                }

                textBoxControl.TextChanged -= TextBoxControl_TextChanged;
                textBoxControl.TextChanged += TextBoxControl_TextChanged;

                // If the adorner exists, invalidate it to draw the current text
                if (GetOrCreateAdorner(textBoxControl, out PlaceholderAdorner adorner))
                    adorner.InvalidateVisual();
            }
        }
        // </OnPlaceholderChanged>

        // <EventHandlers>
        private static void TextBoxControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBoxControl)
            {
                textBoxControl.Loaded -= TextBoxControl_Loaded;
                GetOrCreateAdorner(textBoxControl, out _);
            }
        }

        private static void TextBoxControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBoxControl
                && GetOrCreateAdorner(textBoxControl, out PlaceholderAdorner adorner))
            {
                // Control has text. Hide the adorner.
                if (textBoxControl.Text.Length > 0)
                    adorner.Visibility = Visibility.Hidden;

                // Control has no text. Show the adorner.
                else
                    adorner.Visibility = Visibility.Visible;
            }
        }
        // </EventHandlers>

        // <GetOrCreateAdorner>
        private static bool GetOrCreateAdorner(TextBox textBoxControl, out PlaceholderAdorner adorner)
        {
            // Get the adorner layer
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(textBoxControl);

            // If null, it doesn't exist or the control's template isn't loaded
            if (layer == null)
            {
                adorner = null;
                return false;
            }

            // Layer exists, try to find the adorner
            adorner = layer.GetAdorners(textBoxControl)?.OfType<PlaceholderAdorner>().FirstOrDefault();

            // Adorner never added to control, so add it
            if (adorner == null)
            {
                adorner = new PlaceholderAdorner(textBoxControl);
                layer.Add(adorner);
            }

            return true;
        }
        // </GetOrCreateAdorner>

        // <Adorner>
        public class PlaceholderAdorner : Adorner
        {
            public PlaceholderAdorner(TextBox textBox) : base(textBox) { }

            protected override void OnRender(DrawingContext drawingContext)
            {
                TextBox textBoxControl = (TextBox)AdornedElement;

                string placeholderValue = TextBoxHelper.GetPlaceholder(textBoxControl);

                if (string.IsNullOrEmpty(placeholderValue))
                    return;

                // Create the formatted text object
                FormattedText text = new FormattedText(
                                            placeholderValue,
                                            System.Globalization.CultureInfo.CurrentCulture,
                                            textBoxControl.FlowDirection,
                                            new Typeface(textBoxControl.FontFamily,
                                                         textBoxControl.FontStyle,
                                                         textBoxControl.FontWeight,
                                                         textBoxControl.FontStretch),
                                            textBoxControl.FontSize,
                                            SystemColors.InactiveCaptionBrush,
                                            VisualTreeHelper.GetDpi(textBoxControl).PixelsPerDip);

                text.MaxTextWidth = System.Math.Max(textBoxControl.ActualWidth - textBoxControl.Padding.Left - textBoxControl.Padding.Right, 10);
                text.MaxTextHeight = System.Math.Max(textBoxControl.ActualHeight, 10);

                // Render based on padding of the control, to try and match where the textbox places text
                Point renderingOffset = new Point(textBoxControl.Padding.Left, textBoxControl.Padding.Top);

                // Template contains the content part; adjust sizes to try and align the text
                if (textBoxControl.Template.FindName("PART_ContentHost", textBoxControl) is FrameworkElement part)
                {
                    Point partPosition = part.TransformToAncestor(textBoxControl).Transform(new Point(0, 0));
                    renderingOffset.X += partPosition.X;
                    renderingOffset.Y += partPosition.Y;

                    text.MaxTextWidth = System.Math.Max(part.ActualWidth - renderingOffset.X, 10);
                    text.MaxTextHeight = System.Math.Max(part.ActualHeight, 10);
                }

                // Draw the text
                drawingContext.DrawText(text, renderingOffset);
            }
        }
        // </Adorner>
    }
    // </FullClass>
}
