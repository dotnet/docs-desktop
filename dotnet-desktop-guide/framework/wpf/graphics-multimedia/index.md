---
title: "Graphics and Multimedia"
description: Discover media features of Windows Presentation Foundation (WPF). Add graphics, transition effects, sound, and video to your applications. 
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "media [WPF], features"
  - "video effects [WPF]"
  - "sound effects [WPF]"
  - "animation [WPF], features"
  - "graphics features [WPF]"
  - "transition effects [WPF]"
ms.assetid: 1817d9dc-3d6c-46cb-afc8-63b0bae35e37
---
# Graphics and Multimedia

<a name="introduction"></a>
Windows Presentation Foundation (WPF) provides support for multimedia, vector graphics, animation, and content composition, making it easy for developers to build interesting user interfaces and content. Using Visual Studio, you can create vector graphics or complex animations and integrate media into your applications.

This topic introduces the graphics, animation, and media features of WPF, which enable you to add graphics, transition effects, sound, and video to your applications.

> [!NOTE]
> Using WPF types in a Windows service is strongly discouraged. If you attempt to use WPF types in a Windows service, the service may not work as expected.

<a name="whats_new_with_graphics_and_multimedia_in_wpf_4"></a>

## What's New with Graphics and Multimedia in WPF 4

Several changes have been made related to graphics and animations.

- Layout Rounding

  When an object edge falls in the middle of a pixel device, the DPI-independent graphics system can create rendering artifacts, such as blurry or semi-transparent edges. Previous versions of WPF included pixel snapping to help handle this case. Silverlight 2 introduced layout rounding, which is another way to move elements so that edges fall on whole pixel boundaries. WPF now supports layout rounding with the <xref:System.Windows.FrameworkElement.UseLayoutRounding%2A> attached property on <xref:System.Windows.FrameworkElement>.

- Cached Composition

  By using the new <xref:System.Windows.Media.BitmapCache> and <xref:System.Windows.Media.BitmapCacheBrush> classes, you can cache a complex part of the visual tree as a bitmap and greatly improve rendering time. The bitmap remains responsive to user input, such as mouse clicks, and you can paint it onto other elements just like any brush.

- Pixel Shader 3 Support

  WPF 4 builds on top of the <xref:System.Windows.Media.Effects.ShaderEffect> support introduced in WPF 3.5 SP1 by allowing applications to write effects by using Pixel Shader (PS) version 3.0. The PS 3.0 shader model is more sophisticated than PS 2.0, which allows for even more effects on supported hardware.

- Easing Functions

  You can enhance animations with easing functions, which give you additional control over the behavior of animations. For example, you can apply an <xref:System.Windows.Media.Animation.ElasticEase> to an animation to give the animation a springy behavior. For more information, see the easing types in the <xref:System.Windows.Media.Animation> namespace.

<a name="graphics_and_rendering"></a>

## Graphics and Rendering

WPF includes support for high quality 2D graphics. The functionality includes brushes, geometries, images, shapes and transformations. For more information, see [Graphics](graphics.md). The rendering of graphical elements is based on the <xref:System.Windows.Media.Visual> class. The structure of visual objects on the screen is described by the visual tree. For more information, see [WPF Graphics Rendering Overview](wpf-graphics-rendering-overview.md).

### 2D Shapes

WPF provides a library of commonly used, vector-drawn 2D shapes, such as rectangles and ellipses, which the following illustration shows.

![Diagram showing ellipses and rectangles.](./media/index/two-deminsional-shapes-ellipses-rectangles.png)

These intrinsic WPF shapes are not just shapes: they are programmable elements that implement many of the features that you expect from most common controls, which include keyboard and mouse input. The following example shows how to handle the <xref:System.Windows.UIElement.MouseUp> event raised by clicking an <xref:System.Windows.Shapes.Ellipse> element.

```xaml
<Window
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  x:Class="Window1" >
  <Ellipse Fill="LightBlue" MouseUp="ellipseButton_MouseUp" />
</Window>
```

```csharp
public partial class Window1  : Window
{
    void ellipseButton_MouseUp(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("You clicked the ellipse!");
    }
}
```

```vb
Partial Public Class Window1
    Inherits Window
    Private Sub ellipseButton_MouseUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        MessageBox.Show("You clicked the ellipse!")
    End Sub
End Class
```

The following illustration shows the output for the preceding XAML markup and code-behind.

![A message box saying "You clicked the ellipse!"](./media/index/messagebox-text-output.png)

For more information, see [Shapes and Basic Drawing in WPF Overview](shapes-and-basic-drawing-in-wpf-overview.md). For an introductory sample, see [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements).

### 2D Geometries

When the 2D shapes that WPF provides are not sufficient, you can use WPF support for geometries and paths to create your own. The following illustration shows how you can use geometries to create shapes, as a drawing brush, and to clip other WPF elements.

![Screenshot showing how you can use geometries to create shapes.](./media/index/use-geometries-create-shapes.png)

For more information, see [Geometry Overview](geometry-overview.md). For an introductory sample, see [Geometries Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/Geometry).

### 2D Effects

WPF provides a library of 2D classes that you can use to create a variety of effects. The 2D rendering capability of WPF provides the ability to paint UI elements that have gradients, bitmaps, drawings, and videos; and to manipulate them by using rotation, scaling, and skewing. The following illustration gives an example of the many effects you can achieve by using WPF brushes.

![Illustration showing the different WPF brushes and paint elements.](./media/index/brushes-paint-elements.png)

For more information, see [WPF Brushes Overview](wpf-brushes-overview.md). For an introductory sample, see [Brushes Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/Brushes).

<a name="rendering"></a>

## 3D Rendering

WPF provides a set of 3D rendering capabilities that integrate with 2D graphics support in WPF in order for you to create more exciting layout, UI, and data visualization. At one end of the spectrum, WPF enables you to render 2D images onto the surfaces of 3D shapes, which the following illustration demonstrates.

![Screenshot of a sample showing 3D shapes with different textures.](./media/index/visual-three-dimensional-shape.png)

For more information, see [3D Graphics Overview](3-d-graphics-overview.md). For an introductory sample, see [3D Solids Sample](https://github.com/microsoft/WPF-Samples/tree/master/Animation/AnimationExamples).

<a name="animation"></a>

## Animation

Use animation to make controls and elements grow, shake, spin, and fade; and to create interesting page transitions, and more. Because WPF enables you to animate most properties, not only can you animate most WPF objects, you can also use WPF to animate custom objects that you create.

![Screenshot of an animated cube.](./media/index/animate-custom-objects.png)

For more information, see [Animation Overview](animation-overview.md). For an introductory sample, see [Animation Example Gallery](https://github.com/Microsoft/WPF-Samples/tree/master/Animation/AnimationExamples).

<a name="media"></a>

## Media

Images, video, and audio are media-rich ways of conveying information and user experiences.

### Images

Images, which include icons, backgrounds, and even parts of animations, are a core part of most applications. Because you frequently need to use images, WPF exposes the ability to work with them in a variety of ways. The following illustration shows just one of those ways.

![Styling sample screenshot](../controls/media/stylingintro-eventtriggers.png "StylingIntro_EventTriggers")

For more information, see [Imaging Overview](imaging-overview.md).

### Video and Audio

A core feature of the graphics capabilities of WPF is to provide native support for working with multimedia, which includes video and audio. The following example shows how to insert a media player into an application.

```xaml
<MediaElement Source="media\numbers.wmv" Width="450" Height="250" />
```

<xref:System.Windows.Controls.MediaElement> is capable of playing both video and audio, and is extensible enough to allow the easy creation of custom UIs.

For more information, see the [Multimedia Overview](multimedia-overview.md).

## See also

- <xref:System.Windows.Media>
- <xref:System.Windows.Media.Animation>
- <xref:System.Windows.Media.Media3D>
- [2D Graphics and Imaging](../advanced/optimizing-performance-2d-graphics-and-imaging.md)
- [Shapes and Basic Drawing in WPF Overview](shapes-and-basic-drawing-in-wpf-overview.md)
- [Painting with Solid Colors and Gradients Overview](painting-with-solid-colors-and-gradients-overview.md)
- [Painting with Images, Drawings, and Visuals](painting-with-images-drawings-and-visuals.md)
- [Animation and Timing How-to Topics](animation-and-timing-how-to-topics.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
- [Multimedia Overview](multimedia-overview.md)
