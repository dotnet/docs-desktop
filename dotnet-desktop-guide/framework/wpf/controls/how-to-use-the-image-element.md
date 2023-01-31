---
title: "How to: Use the Image Element"
description: Learn how to use the Image Element.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [WPF], Image"
  - "Image control [WPF]"
  - "rendering images [WPF]"
ms.assetid: 5b92e74b-1b56-4756-ac64-d5e9e08d9854
---
# How to: Use the Image Element

This example shows how to include images in an application by using the <xref:System.Windows.Controls.Image> element.  
  
## Define an image

 The following example shows how to render an image 200 pixels wide. In this Extensible Application Markup Language (XAML) example, both attribute syntax and property tag syntax are used to define the image. For more information on attribute syntax and property syntax, see [Dependency Properties Overview](../advanced/dependency-properties-overview.md). A <xref:System.Windows.Media.Imaging.BitmapImage> is used to define the image's source data and is explicitly defined for the property tag syntax example. In addition, the <xref:System.Windows.Media.Imaging.BitmapImage.DecodePixelWidth%2A> of the <xref:System.Windows.Media.Imaging.BitmapImage> is set to the same width as the <xref:System.Windows.FrameworkElement.Width%2A> of the <xref:System.Windows.Controls.Image>. This is done to ensure that the minimum amount of memory is used rendering the image.  
  
> [!NOTE]
> In general, if you want to specify the size of a rendered image, specify only the <xref:System.Windows.FrameworkElement.Width%2A> or the <xref:System.Windows.FrameworkElement.Height%2A> but not both. If you only specify one, the image's aspect ratio is preserved. Otherwise, the image may unexpectedly appear stretched or warped. To control the image's stretching behavior, use the <xref:System.Windows.Controls.Image.Stretch%2A> and <xref:System.Windows.Controls.Image.StretchDirection%2A> properties.  
  
> [!NOTE]
> When you specify the size of an image with either <xref:System.Windows.FrameworkElement.Width%2A> or <xref:System.Windows.FrameworkElement.Height%2A>, you should also set either <xref:System.Windows.Media.Imaging.BitmapImage.DecodePixelWidth%2A> or <xref:System.Windows.Media.Imaging.BitmapImage.DecodePixelHeight%2A> to the same respective size.  
  
 The <xref:System.Windows.Controls.Image.Stretch%2A> property determines how the image source is stretched to fill the image element. For more information, see the <xref:System.Windows.Media.Stretch> enumeration.  
  
 [!code-xaml[ImageElementExample_snip#ImageSimpleExampleInlineMarkup](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageSimpleExample.xaml#imagesimpleexampleinlinemarkup)]  
  
## Render an image

 The following example shows how to render an image 200 pixels wide using code.  
  
> [!NOTE]
> Setting <xref:System.Windows.Media.Imaging.BitmapImage> properties must be done within a <xref:System.Windows.Media.Imaging.BitmapImage.BeginInit%2A> and <xref:System.Windows.Media.Imaging.BitmapImage.EndInit%2A> block.  
  
 [!code-csharp[ImageElementExample_snip#ImageSimpleExampleInlineCode1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageSimpleExample.xaml.cs#imagesimpleexampleinlinecode1)]
 [!code-vb[ImageElementExample_snip#ImageSimpleExampleInlineCode1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImageElementExample_snip/VB/ImageSimpleExample.xaml.vb#imagesimpleexampleinlinecode1)]  
  
## See also

- [Imaging Overview](../graphics-multimedia/imaging-overview.md)
