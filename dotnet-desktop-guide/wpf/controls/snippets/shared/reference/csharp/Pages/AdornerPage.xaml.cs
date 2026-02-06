using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllTemplatesCS.Pages;

/// <summary>
/// Interaction logic for AdornerPage.xaml
/// </summary>
public partial class AdornerPage : Page
{
    private SimpleSelectionAdorner? _adorner;
    private AdornerLayer? _adornerLayer;

    public AdornerPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        _adornerLayer = AdornerLayer.GetAdornerLayer(AdornedTextBlock);
        _adorner = new SimpleSelectionAdorner(AdornedTextBlock);
        _adornerLayer.Add(_adorner);
    }
}

/// <summary>
/// A simple adorner that draws a selection border and corner handles around an element.
/// </summary>
public class SimpleSelectionAdorner : Adorner
{
    private const double HandleSize = 8;
    private readonly Pen _borderPen;
    private readonly Brush _handleBrush;
    private readonly Pen _handlePen;

    public SimpleSelectionAdorner(UIElement adornedElement) : base(adornedElement)
    {
        _borderPen = new Pen(Brushes.Red, 2) { DashStyle = DashStyles.Dash };
        _handleBrush = Brushes.White;
        _handlePen = new Pen(Brushes.Red, 2);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        Rect adornedElementRect = new(AdornedElement.RenderSize);

        // Draw the selection border
        drawingContext.DrawRectangle(null, _borderPen, adornedElementRect);

        // Draw corner handles
        DrawHandle(drawingContext, adornedElementRect.TopLeft);
        DrawHandle(drawingContext, adornedElementRect.TopRight);
        DrawHandle(drawingContext, adornedElementRect.BottomLeft);
        DrawHandle(drawingContext, adornedElementRect.BottomRight);

        // Draw mid-point handles
        DrawHandle(drawingContext, new Point(adornedElementRect.Left + adornedElementRect.Width / 2, adornedElementRect.Top));
        DrawHandle(drawingContext, new Point(adornedElementRect.Left + adornedElementRect.Width / 2, adornedElementRect.Bottom));
        DrawHandle(drawingContext, new Point(adornedElementRect.Left, adornedElementRect.Top + adornedElementRect.Height / 2));
        DrawHandle(drawingContext, new Point(adornedElementRect.Right, adornedElementRect.Top + adornedElementRect.Height / 2));
    }

    private void DrawHandle(DrawingContext drawingContext, Point center)
    {
        Rect handleRect = new(
            center.X - HandleSize / 2,
            center.Y - HandleSize / 2,
            HandleSize,
            HandleSize);

        drawingContext.DrawRectangle(_handleBrush, _handlePen, handleRect);
    }
}
