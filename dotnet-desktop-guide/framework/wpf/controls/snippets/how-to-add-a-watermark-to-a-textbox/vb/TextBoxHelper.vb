'<Namespaces>
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Media
'</Namespaces>

'<FullClass>
Public Class TextBoxHelper

    '<AttachedProperty>
    Public Shared Function GetPlaceholder(obj As DependencyObject) As String
        Return obj.GetValue(PlaceholderProperty)
    End Function

    Public Shared Sub SetPlaceholder(obj As DependencyObject, value As String)
        obj.SetValue(PlaceholderProperty, value)
    End Sub

    Public Shared ReadOnly PlaceholderProperty As DependencyProperty =
        DependencyProperty.RegisterAttached(
            "Placeholder",
            GetType(String),
            GetType(TextBoxHelper),
            New FrameworkPropertyMetadata(
                defaultValue:=Nothing,
                propertyChangedCallback:=AddressOf OnPlaceholderChanged)
            )
    '</AttachedProperty>

    '<OnPlaceholderChanged>
    Private Shared Sub OnPlaceholderChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim textBoxControl = TryCast(d, TextBox)

        If textBoxControl IsNot Nothing Then

            If Not textBoxControl.IsLoaded Then

                'Ensure that the events are not added multiple times
                RemoveHandler textBoxControl.Loaded, AddressOf TextBoxControl_Loaded
                AddHandler textBoxControl.Loaded, AddressOf TextBoxControl_Loaded

            End If

            RemoveHandler textBoxControl.TextChanged, AddressOf TextBoxControl_TextChanged
            AddHandler textBoxControl.TextChanged, AddressOf TextBoxControl_TextChanged

            'If the adorner exists, invalidate it to draw the current text
            Dim adorner As PlaceholderAdorner = Nothing
            If GetOrCreateAdorner(textBoxControl, adorner) Then
                adorner.InvalidateVisual()
            End If

        End If

    End Sub
    '</OnPlaceholderChanged>

    '<EventHandlers>
    Private Shared Sub TextBoxControl_Loaded(sender As Object, e As RoutedEventArgs)
        Dim textBoxControl As TextBox = TryCast(sender, TextBox)

        If textBoxControl IsNot Nothing Then
            RemoveHandler textBoxControl.Loaded, AddressOf TextBoxControl_Loaded
            GetOrCreateAdorner(textBoxControl, Nothing)
        End If
    End Sub

    Private Shared Sub TextBoxControl_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim textBoxControl As TextBox = TryCast(sender, TextBox)
        Dim adorner As PlaceholderAdorner = Nothing

        If textBoxControl IsNot Nothing AndAlso GetOrCreateAdorner(textBoxControl, adorner) Then

            If textBoxControl.Text.Length > 0 Then
                'Control has text. Hide the adorner.
                adorner.Visibility = Visibility.Hidden
            Else
                'Control has no text. Show the adorner.
                adorner.Visibility = Visibility.Visible
            End If

        End If
    End Sub
    '</EventHandlers>


    '<GetOrCreateAdorner>
    Private Shared Function GetOrCreateAdorner(textBoxControl As TextBox, ByRef adorner As PlaceholderAdorner) As Boolean

        'Get the adorner layer
        Dim layer As AdornerLayer = AdornerLayer.GetAdornerLayer(textBoxControl)

        'If nothing, it doesn't exist or the control's template isn't loaded
        If layer Is Nothing Then
            adorner = Nothing
            Return False
        End If

        'Layer exists, try to find the adorner
        adorner = layer.GetAdorners(textBoxControl)?.OfType(Of PlaceholderAdorner)().FirstOrDefault()

        'Adorner never added to control, so add it
        If adorner Is Nothing Then
            adorner = New PlaceholderAdorner(textBoxControl)
            layer.Add(adorner)
        End If

        Return True

    End Function
    '</GetOrCreateAdorner>

    '<Adorner>
    Public Class PlaceholderAdorner
        Inherits Adorner

        Public Sub New(adornedElement As UIElement)
            MyBase.New(adornedElement)
        End Sub

        Protected Overrides Sub OnRender(drawingContext As DrawingContext)
            Dim textBoxControl As TextBox = DirectCast(AdornedElement, TextBox)

            Dim placeholderValue As String = TextBoxHelper.GetPlaceholder(textBoxControl)

            If String.IsNullOrEmpty(placeholderValue) Then
                Return
            End If

            'Create the formatted text object
            Dim text As New FormattedText(
                placeholderValue,
                System.Globalization.CultureInfo.CurrentCulture,
                textBoxControl.FlowDirection,
                New Typeface(textBoxControl.FontFamily,
                             textBoxControl.FontStyle,
                             textBoxControl.FontWeight,
                             textBoxControl.FontStretch),
                textBoxControl.FontSize,
                SystemColors.InactiveCaptionBrush,
                VisualTreeHelper.GetDpi(textBoxControl).PixelsPerDip)

            text.MaxTextWidth = Math.Max(textBoxControl.ActualWidth - textBoxControl.Padding.Left - textBoxControl.Padding.Right, 10)
            text.MaxTextHeight = Math.Max(textBoxControl.ActualHeight, 10)

            'Render based on padding of the control, to try and match where the textbox places text
            Dim renderingOffset As New Point(textBoxControl.Padding.Left, textBoxControl.Padding.Top)

            'Template contains the content part; adjust sizes to try and align the text
            Dim part As FrameworkElement = TryCast(textBoxControl.Template.FindName("PART_ContentHost", textBoxControl), FrameworkElement)

            If part IsNot Nothing Then
                Dim partPosition As Point = part.TransformToAncestor(textBoxControl).Transform(New Point(0, 0))
                renderingOffset.X += partPosition.X
                renderingOffset.Y += partPosition.Y

                text.MaxTextWidth = Math.Max(part.ActualWidth - renderingOffset.X, 10)
                text.MaxTextHeight = Math.Max(part.ActualHeight, 10)
            End If

            ' Draw the text
            drawingContext.DrawText(text, renderingOffset)
        End Sub

    End Class
    '</Adorner>
End Class
'</FullClass>
