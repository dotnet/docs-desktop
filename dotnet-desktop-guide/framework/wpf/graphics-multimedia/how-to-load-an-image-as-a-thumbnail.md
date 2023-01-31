---
title: "How to: Load an Image as a Thumbnail"
description: Learn how to Load an Image as a Thumbnail.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "loading images as thumbnails [WPF]"
  - "images [WPF], loading as thumbnails"
  - "thumbnails [WPF], loading images as"
ms.assetid: 02e055a0-54df-499a-b8b6-ab6ff7535cff
---
# How to: Load an Image as a Thumbnail

The following examples show how to load an <xref:System.Windows.Controls.Image> as a thumbnail to conserve application memory.  
  
## Set the DecodePixelWidth property in XAML

 The following example sets the <xref:System.Windows.Media.Imaging.BitmapImage.DecodePixelWidth%2A> property of a <xref:System.Windows.Media.Imaging.BitmapImage> in Extensible Application Markup Language (XAML) to reduce the memory required to load the image.  
  
 [!code-xaml[ImageElementExample_snip#ImageSimpleExampleInlineMarkup](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageSimpleExample.xaml#imagesimpleexampleinlinemarkup)]  
  
## Set the DecodePixelWidth property in code

 The following example sets the <xref:System.Windows.Media.Imaging.BitmapImage.DecodePixelWidth%2A> property of a <xref:System.Windows.Media.Imaging.BitmapImage> in code to reduce the memory required to load the image.  
  
 [!code-csharp[ImageElementExample_snip#ImageSimpleExampleInlineCode1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageSimpleExample.xaml.cs#imagesimpleexampleinlinecode1)]
 [!code-vb[ImageElementExample_snip#ImageSimpleExampleInlineCode1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImageElementExample_snip/VB/ImageSimpleExample.xaml.vb#imagesimpleexampleinlinecode1)]  
  
## See also

- [Imaging Overview](imaging-overview.md)
