---
title: "XAML loading and dependency properties"
description: "Learn about Extensible Application Markup Language (XAML) loading of dependency property in Windows Presentation Foundation (WPF)."
ms.date: "12/22/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "custom dependency properties [WPF]"
  - "dependency properties [WPF], XAML loading"
  - "loading XML data [WPF]"
---
<!-- The acrolinx score was 92 on 10/14/2021-->

# XAML loading and dependency properties (WPF .NET)

The Windows Presentation Foundation (WPF) implementation of its Extensible Application Markup Language (XAML) processor is inherently dependency property aware. As such, the XAML processor uses WPF property system methods to load XAML and process dependency property attributes, and entirely bypasses dependency property wrappers by using WPF property system methods like <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A>. So, if you add custom logic to the property wrapper of your custom dependency property, it won't be called by the XAML processor when a property value is set in XAML.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## WPF XAML loader performance

It's computationally less expensive for the WPF XAML processor to directly call <xref:System.Windows.DependencyObject.SetValue%2A> to set the value of a dependency property, rather than use the property wrapper of a dependency property.

If the XAML processor did use the property wrapper, it would require inferring the entire object model of the backing code based only on the type and member relationships indicated in markup. Although the type can be identified from markup by using a combination of `xmlns` and assembly attributes, identifying the members, determining which members can be set as an attribute, and resolving supported property value types, would require extensive reflection using <xref:System.Reflection.PropertyInfo>.

The WPF property system maintains a storage table of dependency properties implemented on a given <xref:System.Windows.DependencyObject> derived type. The XAML processor uses that table to infer the dependency property identifier for a dependency property. For example, by convention the dependency property identifier for a dependency property named `ABC` is `ABCProperty`. The XAML processor can efficiently set the value of any dependency property by calling the `SetValue` method on its containing type using the dependency property identifier.

For more information on dependency property wrappers, see [Custom dependency properties](custom-dependency-properties.md).

## Implications for custom dependency properties

The WPF XAML processor bypasses property wrappers and directly calls <xref:System.Windows.DependencyObject.SetValue%2A> to set a dependency property value. So, avoid putting any extra logic in the `set` accessor of your custom dependency property because that logic won't run when a property value is set in XAML. The `set` accessor should only contain a `SetValue` call.

Similarly, aspects of the WPF XAML processor that get property values bypass the property wrapper and directly call <xref:System.Windows.DependencyObject.GetValue%2A>. So, also avoid putting any extra logic in the `get` accessor of your custom dependency property because that logic won't run when a property value is read in XAML. The `get` accessor should only contain a `GetValue` call.

## Dependency property with wrapper example

The following example shows a recommended dependency property definition with property wrappers. The dependency property identifier is stored as a `public static readonly` field, and the `get` and `set` accessors contain no code beyond the necessary WPF property system methods that back the dependency property value. If you have code that needs to run when the value of your dependency property changes, consider putting that code in the <xref:System.Windows.PropertyChangedCallback> for your dependency property. For more information, see [Property-changed callbacks](dependency-property-callbacks-and-validation.md#property-changed-callbacks).

:::code language="csharp" source="./snippets/xaml-loading-and-dependency-properties/csharp/MainWindow.xaml.cs" id="DependencyPropertyWithWrapper":::
:::code language="vb" source="./snippets/xaml-loading-and-dependency-properties/vb/MainWindow.xaml.vb" id="DependencyPropertyWithWrapper":::

## See also

- [Dependency properties overview](dependency-properties-overview.md)
- [XAML in WPF](../xaml/index.md)
- [Custom dependency properties](custom-dependency-properties.md)
- [Dependency property metadata](dependency-property-metadata.md)
- [Collection-type dependency properties](collection-type-dependency-properties.md)
- [Dependency property security](dependency-property-security.md)
- [Safe constructor patterns for DependencyObjects](safe-constructor-patterns-for-dependencyobjects.md)
