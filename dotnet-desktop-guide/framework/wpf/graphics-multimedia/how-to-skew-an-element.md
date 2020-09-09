---
title: "How to: Skew an Element"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "skewing elements [WPF]"
  - "graphics [WPF], skewing elements"
  - "classes [WPF], SkewTransform"
ms.assetid: 56b65f2f-dc6e-4238-923f-ca44ec53c52f
---
# How to: Skew an Element
This example shows how to use a <xref:System.Windows.Media.SkewTransform> to skew an element. A skew, which is also known as a shear, is a transformation that stretches the coordinate space in a non-uniform manner. One typical use of a <xref:System.Windows.Media.SkewTransform> is for simulating 3D depth in 2D objects.  
  
 Use the <xref:System.Windows.Media.SkewTransform.CenterX%2A> and <xref:System.Windows.Media.SkewTransform.CenterY%2A> properties to specify the center point of the <xref:System.Windows.Media.SkewTransform>.  
  
 Use the <xref:System.Windows.Media.SkewTransform.AngleX%2A> and <xref:System.Windows.Media.SkewTransform.AngleY%2A> properties to specify the skew angle of the x-axis and y-axis, and to skew the current coordinate system along these axes.  
  
 To predict the effect of a skew transformation, consider that <xref:System.Windows.Media.SkewTransform.AngleX%2A> skews x-axis values relative to the original coordinate system. Therefore, for an <xref:System.Windows.Media.SkewTransform.AngleX%2A> of 30, the y-axis rotates 30 degrees through the origin and skews the values in x- by 30 degrees from that origin. Likewise, an <xref:System.Windows.Media.SkewTransform.AngleY%2A> of 30 skews the y- values of the shape by 30 degrees from the origin. Note that this is not the same effect as translating (moving) the coordinate system by 30 degrees in x- or y-.  
  
 The following example applies a horizontal skew of 45 degrees to a <xref:System.Windows.Shapes.Rectangle> from a center point of (0,0).  
  
## Example  
 [!code-xaml[transformsSample#41](~/samples/snippets/csharp/VS_Snippets_Wpf/transformsSample/CS/SkewTransformExample.xaml#41)]  
  
 The following example applies a horizontal skew of 45 degrees to a <xref:System.Windows.Shapes.Rectangle> from a center point of (25,25).  
  
 [!code-xaml[transformsSample#42](~/samples/snippets/csharp/VS_Snippets_Wpf/transformsSample/CS/SkewTransformExample.xaml#42)]  
  
 The following example applies a vertical skew of 45 degrees to a <xref:System.Windows.Shapes.Rectangle> from a center point of (25,25).  
  
 [!code-xaml[transformsSample#43](~/samples/snippets/csharp/VS_Snippets_Wpf/transformsSample/CS/SkewTransformExample.xaml#43)]  
  
 The following illustration shows the different skews that are used in this example.  
  
 ![SkewTransform examples](./media/img-wcpsdk-graphicsmm-skewtransformexample.gif "img_wcpsdk_graphicsmm_skewtransformexample")  
The three SkewTransform examples illustrated  
  
 For the complete sample, see [2D Transforms Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/2DTransforms).  
  
## See also

- <xref:System.Windows.Media.Transform>
- <xref:System.Windows.Media.SkewTransform>
- [Transforms Overview](transforms-overview.md)
- [How-to Topics](transformations-how-to-topics.md)
