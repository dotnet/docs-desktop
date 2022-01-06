---
title: "How to implement a dependency property"
description: "Define a dependency property in Windows Presentation Foundation (WPF), by backing a common language runtime property with a DependencyProperty field."
ms.date: "10/15/2021"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dependency properties [WPF], backing properties with"
  - "properties [WPF], backing with dependency properties"
---
<!-- The acrolinx score was 96 on 10/15/2021-->

# How to implement a dependency property (WPF .NET)

This article describes how to implement a dependency property by using a <xref:System.Windows.DependencyProperty> field to back a common language runtime (CLR) property. Dependency properties support several advanced Windows Presentation Foundation (WPF) property system features. These features include styles, data binding, inheritance, animation, and default values. If you want properties that you define to support those features, then implement your properties as a dependency property.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Example  

The following example shows how to register a dependency property, by calling the <xref:System.Windows.DependencyProperty.Register%2A> method. The `Register` method returns a <xref:System.Windows.DependencyProperty> instance called a *dependency property identifier*. The identifier is stored in a `static readonly` field, and holds the name and characteristics of a dependency property.

The identifier field must follow the naming convention `<property name>Property`. For instance, if you register a dependency property with the name `Location`, then the identifier field should be named `LocationProperty`. If you fail to follow this naming pattern, then WPF designers might not report your property correctly, and aspects of the property system style application might not behave as expected.

In the following example, the [name](<xref:System.Windows.DependencyProperty.Name>) of the dependency property and its CLR accessor is `HasFish`, so the identifier field is named `HasFishProperty`. The dependency property type is <xref:System.Boolean> and the owner type that registers the dependency property is `Aquarium`.  

You can specify default [metadata](<xref:System.Windows.FrameworkPropertyMetadata>) for a dependency property. This example sets a default value of `false` for the `HasFish` dependency property.

:::code language="csharp" source="./snippets/how-to-implement-a-dependency-property/csharp/MainWindow.xaml.cs" id="DefineDependencyProperty":::
:::code language="vb" source="./snippets/how-to-implement-a-dependency-property/vb/MainWindow.xaml.vb" id="DefineDependencyProperty":::  

For more information about how and why to implement a dependency property, rather than just backing a CLR property with a private field, see [Dependency properties overview](dependency-properties-overview.md).

## See also

- [Dependency properties overview](dependency-properties-overview.md)
- [How-to topics](/dotnet/desktop/wpf/advanced/properties-how-to-topics?view=netframeworkdesktop-4.8&preserve-view=true)
