---
title: "How to: Use a Cached Element as a Brush"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "BitmapCache [WPF], using"
  - "cached element [WPF], use as a brush"
  - "BitmapCacheBrush [WPF], using"
  - "CacheMode [WPF], using"
ms.assetid: d36e944a-866e-4baf-98c4-fd6a75f6fdd0
---
# How to: Use a Cached Element as a Brush
Use the <xref:System.Windows.Media.BitmapCacheBrush> class to reuse a cached element efficiently. To cache an element, create a new instance of the <xref:System.Windows.Media.BitmapCache> class and assign it to the element's <xref:System.Windows.UIElement.CacheMode%2A> property.  
  
## Example  
 The following code example shows how to reuse a cached element. The cached element is an <xref:System.Windows.Controls.Image> control that displays a large image. The <xref:System.Windows.Controls.Image> control is cached as a bitmap by using the <xref:System.Windows.Media.BitmapCache> class, and the cache is reused by assigning it to a <xref:System.Windows.Media.BitmapCacheBrush>. The brush is assigned to the background of twenty-five buttons to show efficient reuse.  
  
 [!code-xaml[System.Windows.Media.BitmapCacheBrush#_BitmapCacheBrushXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/system.windows.media.bitmapcachebrush/cs/window1.xaml#_bitmapcachebrushxaml)]  
  
## See also

- <xref:System.Windows.Media.BitmapCache>
- <xref:System.Windows.Media.BitmapCacheBrush>
- <xref:System.Windows.UIElement.CacheMode%2A>
- [How to: Improve Rendering Performance by Caching an Element](how-to-improve-rendering-performance-by-caching-an-element.md)
