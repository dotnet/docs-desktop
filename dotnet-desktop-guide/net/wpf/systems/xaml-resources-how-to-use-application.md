---
title: "How to use application resources"
description: Learn how to define and reference Windows Presentation Foundation (WPF) application-scoped resources in XAML.
author: adegeo
ms.author: adegeo
ms.date: 04/08/2021
helpviewer_keywords:
  - "application resources [WPF]"
  - "resources [WPF], application resources"
#no-loc: [App.xaml, Application.xaml]
---

# How to use application resources (WPF .NET)

This example demonstrates how to use application-defined resources. Resources can be defined at the application level, generally through the _App.xaml_ or _Application.xaml_ file, whichever one your project uses. Resources that are defined by the application are globally scoped and accessible by all parts of the application.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Example

The following example shows an application definition file. The application definition file defines a resource section (a value for the <xref:System.Windows.Application.Resources%2A> property). Resources defined at the application level can be accessed by all other pages that are part of the application. In this case, the resource is a declared style. Because a complete style that includes a control template can be lengthy, this example omits the control template that is defined within the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> property setter of the style.

:::code language="xaml" source="./snippets/xaml-resources-how-to-use-application/csharp/App.xaml" id="AppResources":::

The following example shows a XAML page that references an application-level resource from the previous example. The resource is referenced with a [StaticResource Markup Extension](../../../framework/wpf/advanced/staticresource-markup-extension.md) that specifies the unique resource key for the resource. The resource "FancyBorder" isn't found in the scope of the current object and window, so the resource lookup continues beyond the current page and into application-level resources.

:::code language="xaml" source="./snippets/xaml-resources-how-to-use-application/csharp/MainWindow.xaml" id="AppResourcesExample":::

## See also

- [Overview of XAML resources](xaml-resources-overview.md)
- [Resources in code](xaml-resources-and-code.md)
- [How to define and reference a WPF resource](xaml-resources-how-to-define-and-reference.md)
- [How to use system resources](xaml-resources-how-to-use-system.md)
