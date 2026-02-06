---
title: "Viewbox"
description: Learn how the Viewbox control is used to stretch or scale a child element in Windows Presentation Foundation (WPF) applications.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], Viewbox"
  - "stretching elements [WPF], Viewbox control"
  - "Viewbox control [WPF]"
  - "scaling elements [WPF], Viewbox control"
ai-usage: ai-assisted
---
# Viewbox

The <xref:System.Windows.Controls.Viewbox> control is used to stretch or scale a child element. This control derives from the <xref:System.Windows.Controls.Decorator> class and provides a simple way to scale its content to fill available space while maintaining aspect ratio.

| Title | Description |
|---|---|
| [Apply Stretch Properties to the Contents of a Viewbox](how-to-apply-stretch-properties-to-the-contents-of-a-viewbox.md) | Learn how to change the stretch and stretch direction properties of a Viewbox. |

## Styles and templates

You can customize the appearance of the <xref:System.Windows.Controls.Viewbox> control by modifying its default style and template.

### Content property

The <xref:System.Windows.Controls.Decorator.Child%2A> property is the content property for the Viewbox control. This property contains the single child element that the Viewbox scales or stretches.

### Parts

This control doesn't define any template parts.

### Visual states

This control doesn't define any visual states.

## See also

- <xref:System.Windows.Controls.Image>
- <xref:System.Windows.Controls.Viewbox>
- <xref:System.Windows.Media.Stretch>
- <xref:System.Windows.Controls.StretchDirection>
- [WPF Controls Gallery Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Getting%20Started/ControlsAndLayout)
