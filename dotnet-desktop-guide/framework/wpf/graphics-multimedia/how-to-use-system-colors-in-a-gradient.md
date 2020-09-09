---
title: "How to: Use System Colors in a Gradient"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "gradients [WPF], system colors in"
  - "system colors in gradients [WPF]"
ms.assetid: 11942e7e-6300-4b50-8ed1-f50e8d20e7d2
---
# How to: Use System Colors in a Gradient
To use a system color in a gradient, you use the *\<SystemColor>*Color and *\<SystemColor>*ColorKey static properties of the <xref:System.Windows.SystemColors> class to obtain a reference to the color, where *\<SystemColor>* is the name of the desired system color. Use the *\<SystemColor>*ColorKey properties when you want to create a dynamic reference that updates automatically as the system theme changes. Otherwise, use the *\<SystemColor>*Color properties.  
  
## Example  
 The following example uses dynamic system color resources to create a gradient.  
  
 [!code-xaml[brushsamples_snip#GraphicsMMDynamicSystemColorGradientExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/DynamicSystemColorExample.xaml#graphicsmmdynamicsystemcolorgradientexamplewholepage)]  
  
 The next example uses static system color resources to create a gradient.  
  
 [!code-xaml[brushsamples_snip#GraphicsMMStaticSystemColorGradientExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/StaticSystemColorExample.xaml#graphicsmmstaticsystemcolorgradientexamplewholepage)]  
  
## See also

- <xref:System.Windows.SystemColors>
- [Paint an Area with a System Brush](how-to-paint-an-area-with-a-system-brush.md)
- [Painting with Solid Colors and Gradients Overview](painting-with-solid-colors-and-gradients-overview.md)
