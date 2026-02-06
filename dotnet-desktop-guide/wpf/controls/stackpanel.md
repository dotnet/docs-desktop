---
title: "StackPanel"
description: Learn how to use the StackPanel element to stack child elements horizontally or vertically in Windows Presentation Foundation (WPF) applications.
ms.date: 02/05/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "stacking elements [WPF]"
  - "StackPanel control [WPF]"
  - "controls [WPF], StackPanel"
ai-usage: ai-assisted
---
# StackPanel

The <xref:System.Windows.Controls.StackPanel> element is used to stack child elements horizontally or vertically.

The following table lists common tasks for working with the StackPanel control:

| Title | Description |
|-------|-------------|
| [Choose Between StackPanel and DockPanel](how-to-choose-between-stackpanel-and-dockpanel.md) | Learn how to choose between using a StackPanel or DockPanel to arrange content. |
| [Create a StackPanel](how-to-create-a-stackpanel.md) | Learn how to create a StackPanel to arrange child elements. |
| [Horizontally or Vertically Align Content in a StackPanel](how-to-horizontally-or-vertically-align-content-in-a-stackpanel.md) | Learn how to control the alignment of content within a StackPanel. |

## Styles and templates

The StackPanel control is a panel that arranges child elements in a single line, either horizontally or vertically. It derives from <xref:System.Windows.Controls.Panel> and doesn't define any template parts or visual states.

### Content property

The StackPanel uses the <xref:System.Windows.Controls.Panel.Children%2A> property as its content property. This property contains the collection of child elements that are arranged by the panel.

## See also

- <xref:System.Windows.Controls.Canvas>
- <xref:System.Windows.Controls.DockPanel>
- <xref:System.Windows.Controls.Grid>
- <xref:System.Windows.Controls.Panel>
- <xref:System.Windows.Controls.StackPanel>
- <xref:System.Windows.Controls.VirtualizingStackPanel>
- <xref:System.Windows.Controls.WrapPanel>
- [Layout](../advanced/layout.md)
- [ScrollViewer](scrollviewer.md)
- [Walkthrough: My first WPF desktop application](../get-started/walkthrough-my-first-wpf-desktop-application.md)
