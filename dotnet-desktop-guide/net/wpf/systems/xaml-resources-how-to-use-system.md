---
title: "How to use system resources"
description: Learn how to define and reference Windows Presentation Foundation (WPF) Windows Operating System resources in XAML.
author: adegeo
ms.author: adegeo
ms.date: 04/09/2021
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "resource keys [WPF], SystemFonts class"
  - "resource keys [WPF], SystemParameters class"
  - "system fonts [WPF]"
  - "classes [WPF], SystemParameters"
  - "classes [WPF], SystemFonts"
#no-loc: [App.xaml, Application.xaml]
---

# How to use system resources (WPF .NET)

This example demonstrates how to use system-defined resources. System resources are provided by WPF and allow access to operating system resources, such as fonts, colors, and icons. System resources expose several system-defined values as both resources and properties to help you create visuals that are consistent with Windows.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Fonts

Use the <xref:System.Windows.SystemFonts> class to reference the fonts used by the operating system. This class contains system font values as static properties, and properties that reference resource keys that can be used to access those values dynamically at run time. For example, <xref:System.Windows.SystemFonts.CaptionFontFamily%2A> is a <xref:System.Windows.SystemFonts> value, and <xref:System.Windows.SystemFonts.CaptionFontFamilyKey%2A> is a corresponding resource key.

The following example shows how to access and use the properties of <xref:System.Windows.SystemFonts> as static values to style or customize a text block:

:::code language="xaml" source="./snippets/xaml-resources-how-to-use-system/csharp/MainWindow.xaml" id="SystemFont":::

To use the values of <xref:System.Windows.SystemFonts> in code, you don't have to use either a static value or a dynamic resource reference. Instead, use the non-key properties of the <xref:System.Windows.SystemFonts> class. Although the non-key properties are apparently defined as static properties, the run-time behavior of WPF as hosted by the system will reevaluate the properties in real time and will properly account for user-driven changes to system values. The following example shows how to specify the font settings of a button:

:::code language="csharp" source="./snippets/xaml-resources-how-to-use-system/csharp/MainWindow.xaml.cs" id="SystemFont":::
:::code language="vb" source="./snippets/xaml-resources-how-to-use-system/vb/MainWindow.xaml.vb" id="SystemFont":::

### Dynamic fonts in XAML

System font metrics can be used as either static or dynamic resources. Use a dynamic resource if you want the font metric to update automatically while the application runs; otherwise, use a static resource.

> [!NOTE]
> Dynamic resources have the keyword `Key` appended to the property name.

The following example shows how to access and use system font dynamic resources to style or customize a text block:

:::code language="xaml" source="./snippets/xaml-resources-how-to-use-system/csharp/MainWindow.xaml" id="SystemFontDynamic":::

## Parameters

Use the <xref:System.Windows.SystemParameters> class to reference system-level properties, such as the size of the primary display. This class contains both system parameter value properties, and resource keys that bind to the values. For example, <xref:System.Windows.SystemParameters.FullPrimaryScreenHeight%2A> is a <xref:System.Windows.SystemParameters> property value and <xref:System.Windows.SystemParameters.FullPrimaryScreenHeightKey%2A> is the corresponding resource key.

The following example shows how to access and use the static values of <xref:System.Windows.SystemParameters> to style or customize a button. This markup example sizes a button by applying <xref:System.Windows.SystemParameters> values to a button:

:::code language="xaml" source="./snippets/xaml-resources-how-to-use-system/csharp/MainWindow.xaml" id="SystemParams":::

To use the values of <xref:System.Windows.SystemParameters> in code, you don't have to use either static references or dynamic resource references. Instead, use the values of the <xref:System.Windows.SystemParameters> class. Although the non-key properties are apparently defined as static properties, the run-time behavior of WPF as hosted by the system will reevaluate the properties in real time, and will properly account for user-driven changes to system values. The following example shows how to set the width and height of a button by using <xref:System.Windows.SystemParameters> values:

:::code language="csharp" source="./snippets/xaml-resources-how-to-use-system/csharp/MainWindow.xaml.cs" id="SystemParams":::
:::code language="vb" source="./snippets/xaml-resources-how-to-use-system/vb/MainWindow.xaml.vb" id="SystemParams":::

### Dynamic parameters in XAML

System parameter metrics can be used as either static or dynamic resources. Use a dynamic resource if you want the parameter metric to update automatically while the application runs; otherwise, use a static resource.

> [!NOTE]
> Dynamic resources have the keyword `Key` appended to the property name.

The following example shows how to access and use system parameter dynamic resources to style or customize a button. This XAML example sizes a button by assigning <xref:System.Windows.SystemParameters> values to the button's width and height.

:::code language="xaml" source="./snippets/xaml-resources-how-to-use-system/csharp/MainWindow.xaml" id="SystemParamsDynamic":::

## See also

- [Overview of XAML resources](xaml-resources-overview.md)
- [Resources in code](xaml-resources-and-code.md)
- [How to define and reference a WPF resource](xaml-resources-how-to-define-and-reference.md)
- [How to use application resources](xaml-resources-how-to-use-application.md)
