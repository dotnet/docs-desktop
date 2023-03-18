---
title: "How to: Choose Between StackPanel and DockPanel"
description: Learn how to choose between StackPanel and DockPanel when you stack content in a Panel, by means of code examples in CPP, C#, Visual Basic, and XAML.
ms.date: 03/16/2023
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "controls [WPF], DockPanel"
  - "DockPanel control [WPF], StackPanel control compared to"
  - "StackPanel control [WPF], DockPanel control compared to"
  - "controls [WPF], StackPanel"
ms.assetid: f9239086-451f-42e6-81f7-ef89ef349742
---
# How to: Choose between StackPanel and DockPanel

Although you can use either <xref:System.Windows.Controls.DockPanel> or <xref:System.Windows.Controls.StackPanel> to stack child elements, the two controls do not always produce the same results. For example, the order that you place child elements can affect the size of child elements in a <xref:System.Windows.Controls.DockPanel> but not in a <xref:System.Windows.Controls.StackPanel>. This different behavior occurs because <xref:System.Windows.Controls.StackPanel> measures in the direction of stacking at [Double.PositiveInfinity](xref:System.Double.PositiveInfinity); however, <xref:System.Windows.Controls.DockPanel> measures only the available size.

The examples in this article create a <xref:System.Windows.Controls.Grid> with two panels, which looks like the following image:

:::image type="content" source="./media/how-to-choose-between-stackpanel-and-dockpanel/example.png" alt-text="A grid with two panels and hearts.":::

## XAML example

The following example demonstrates the key difference between <xref:System.Windows.Controls.DockPanel> and <xref:System.Windows.Controls.StackPanel> when designing a page in XAML.

:::code language="xaml" source="./snippets/how-to-choose-between-stackpanel-and-dockpanel/xaml/MainWindow.xaml" id="EmojiViewBox":::

## Code-based example

The following example demonstrates the key difference between <xref:System.Windows.Controls.DockPanel> and <xref:System.Windows.Controls.StackPanel>. This code is run in the `Window.Loaded` event handler:

:::code language="csharp" source="./snippets/how-to-choose-between-stackpanel-and-dockpanel/csharp/MainWindow.xaml.cs" id="EmojiViewBox":::
:::code language="vb" source="./snippets/how-to-choose-between-stackpanel-and-dockpanel/vb/MainWindow.xaml.vb" id="EmojiViewBox":::

## See also

- <xref:System.Windows.Controls.StackPanel>
- <xref:System.Windows.Controls.DockPanel>
- [Panels Overview](panels-overview.md)
