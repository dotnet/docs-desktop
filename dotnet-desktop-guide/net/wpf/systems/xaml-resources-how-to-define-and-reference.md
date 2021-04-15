---
title: "How to define and reference a resource"
description: Learn how to define and reference Windows Presentation Foundation (WPF) resources through XAML and code.
author: adegeo
ms.author: adegeo
ms.date: 04/02/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "resources [WPF], defining"
  - "defining resources [WPF]"
  - "resources [WPF], referencing"
  - "referencing resources [WPF]"
#no-loc: [TextBlock, Setter]
---

# How to define and reference a WPF resource (WPF .NET)

This example shows how to define a resource and reference it. A resource can be referenced through XAML or through code.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## XAML example

The following example defines two types of resources: a <xref:System.Windows.Media.SolidColorBrush> resource, and several <xref:System.Windows.Style> resources.

:::code language="xaml" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/ResExample.xaml" id="ResDefine":::

### Resources

The <xref:System.Windows.Media.SolidColorBrush> resource `MyBrush` is used to provide the value of several properties that each take a <xref:System.Windows.Media.Brush> type value. This resource is referenced through the `x:Key` value.

:::code language="xaml" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/ResExample.xaml" id="ResUsed":::

In the previous example, the `MyBrush` resource is accessed with the [StaticResource Markup Extension](../../../framework/wpf/advanced/staticresource-markup-extension.md). The resource is assigned to a property that can accept the type of resource being defined. In this case the <xref:System.Windows.Controls.Control.Background%2A>, <xref:System.Windows.Controls.Control.Foreground%2A>, and <xref:System.Windows.Shapes.Shape.Fill> properties.

All resources in a resource diction must provide a key. When styles are defined though, they can omit the key, as explained in the [next section](#style-resources).

Resources are also requested by the order found within the dictionary if you use the [StaticResource Markup Extension](../../../framework/wpf/advanced/staticresource-markup-extension.md) to reference them from within another resource. Make sure that any resource that you reference is defined in the collection earlier than where that resource is requested. For more information, see [Static resources](xaml-resources-overview.md#static-resources).

If necessary, you can work around the strict creation order of resource references by using a [DynamicResource Markup Extension](../../../framework/wpf/advanced/dynamicresource-markup-extension.md) to reference the resource at runtime instead, but you should be aware that this `DynamicResource` technique has performance consequences. For more information, see [Dynamic resources](xaml-resources-overview.md#dynamic-resources).

### Style resources

The following example references styles implicitly and explicitly:

:::code language="xaml" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/ResExample.xaml" id="ResUsed":::

In the previous code example, the <xref:System.Windows.Style> resources `TitleText` and `Label`, each target a particular control type. In this case, they both target a <xref:System.Windows.Controls.TextBlock>. The styles set a variety of different properties on the targeted controls when that style resource is referenced by its resource key for the <xref:System.Windows.FrameworkElement.Style%2A> property.

The style though that targets a <xref:System.Windows.Controls.Border> control doesn't define a key. When a key is omitted, the type of object being targeted by the <xref:System.Windows.Style.TargetType> property is implicitly used as the key for the style. When a style is keyed to a type, it becomes the default style for all controls of that type, as long as these controls are within scope of the style. For more information, see [Styles, DataTemplates, and implicit keys](xaml-resources-overview.md#styles-datatemplates-and-implicit-keys).

## Code examples

The following code snippets demonstrate creating and setting resources through code

### Create a style resource

Creating a resource and assigning it to a resource dictionary can happen at any time. However, only XAML elements that use the DynamicResource syntax will be automatically updated with the resource after it's created.

Take for example the following Window. It has four buttons. The forth button is using a [DynamicResource](xaml-resources-overview.md#dynamic-resources) to style itself. However, this resource doesn't yet exist, so it just looks like a normal button:

:::code language="xaml" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/MainWindow.xaml" id="MainXaml":::

:::image type="content" source="media/xaml-resources-how-to-define-and-reference/before.png" alt-text="A window before a style is applied to a button":::

The following code is invoked when the first button is clicked and performs the following tasks:

- Creates some colors for easy reference.
- Creates a new style.
- Assigns setters to the style.
- Adds the style as a resource named `buttonStyle1` to the window's resource dictionary.
- Assigns the style directly to the button raising the `Click` event.

:::code language="csharp" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/MainWindow.xaml.cs" id="CreateStyleCode":::
:::code language="vb" source="./snippets/xaml-resources-how-to-define-and-reference/vb/MainWindow.xaml.vb" id="CreateStyleCode":::

After the code runs, the window is updated:

:::image type="content" source="media/xaml-resources-how-to-define-and-reference/after.png" alt-text="A window after a style is applied to a button":::

Notice that the forth button's style was updated. The style was automatically applied because the button used the [DynamicResource Markup Extension](../../../framework/wpf/advanced/dynamicresource-markup-extension.md) to reference a style that didn't yet exist. Once the style was created and added to the resources of the window, it was applied to the button. For more information, see [Dynamic resources](xaml-resources-overview.md#dynamic-resources).

### Find a resource

The following code traverses the logical tree of the XAML object in which is run, to find the specified resource. The resource might be defined on the object itself, it's parent, all the way to the root, the application itself. The following code searches for a resource, starting with the button itself:

:::code language="csharp" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/MainWindow.xaml.cs" id="FindResource":::
:::code language="vb" source="./snippets/xaml-resources-how-to-define-and-reference/vb/MainWindow.xaml.vb" id="FindResource":::

### Explicitly reference a resource

When you have reference to a resource, either by searching for it or by creating it, it can be assigned to a property directly:

:::code language="csharp" source="./snippets/xaml-resources-how-to-define-and-reference/csharp/MainWindow.xaml.cs" id="SetResource":::
:::code language="vb" source="./snippets/xaml-resources-how-to-define-and-reference/vb/MainWindow.xaml.vb" id="SetResource":::

## See also

- [Overview of XAML resources](xaml-resources-overview.md)
- [Styles and templates](../controls/styles-templates-overview.md)
- [How to use system resources](xaml-resources-how-to-use-system.md)
- [How to use application resources](xaml-resources-how-to-use-application.md)
