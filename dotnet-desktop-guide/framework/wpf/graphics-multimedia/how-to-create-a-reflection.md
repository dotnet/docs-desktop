---
title: "How to: Create a Reflection"
description: Learn about how to use a VisualBrush to produce interesting visual effects, such as reflections.
ms.date: 03/16/2023
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "creating reflections [WPF]"
  - "brushes [WPF], creating reflections"
  - "reflections [WPF], creating"
ms.assetid: 4f017e16-ab80-43c7-98df-03b6bddbb203
---
# How to: Create a Reflection

This article shows how to use a <xref:System.Windows.Media.VisualBrush> to create a reflection. Because a <xref:System.Windows.Media.VisualBrush> can display an existing visual, you can use this capability to produce interesting visual effects, such as reflections and magnification.

:::image type="content" source="media/how-to-create-a-reflection/reflection.png" alt-text="A XAML element with latin text and two circles, whose upside down reflection is displayed below it.":::

## XAML example

The following example uses a <xref:System.Windows.Media.VisualBrush> to create a reflection of a <xref:System.Windows.Controls.Border> that contains several elements.

:::code language="xaml" source="./snippets/how-to-create-a-reflection/xaml/MainWindow.xaml" id="Reflection":::

## Code-based example

The following example uses a <xref:System.Windows.Media.VisualBrush> to create a reflection of a <xref:System.Windows.Controls.Border> that contains several elements. This code is run in the `Window.Loaded` event handler:

:::code language="csharp" source="./snippets/how-to-create-a-reflection/csharp/MainWindow.xaml.cs" id="Reflection":::
:::code language="vb" source="./snippets/how-to-create-a-reflection/vb/MainWindow.xaml.vb" id="Reflection":::

## See also

- <xref:System.Windows.Media.VisualBrush>
- [Painting with Images, Drawings, and Visuals](painting-with-images-drawings-and-visuals.md)
