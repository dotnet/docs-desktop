---
title: "How to register an attached property"
description: "Learn about the Windows Presentation Foundation (WPF) property system and how to register an attached property and provide public accessors."
ms.date: "10/15/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "attached properties [WPF], registering"
  - "registering attached properties [WPF]"
---
<!-- The acrolinx score was 96 on 10/15/2021-->

# How to register an attached property (WPF .NET)

This article describes how to register an attached property and provide public accessors that let you access the attached property through Extensible Application Markup Language (XAML) and code. Attached properties enable extra property/value pairs to be set on any XAML element, even though the element doesn't define those extra properties in its object model. The extra properties are globally accessible. Attached properties are typically defined as a specialized form of dependency property that doesn't have a conventional property wrapper. Most attached properties for Windows Presentation Foundation (WPF) types are also implemented as dependency properties. You can create dependency properties on any <xref:System.Windows.DependencyObject> derived type.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Example

The following example shows how to register an attached property as a dependency property, by using the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method. The provider class has the option of specifying a default value in property metadata. For more information on property metadata, see [Dependency property metadata](custom-dependency-properties.md#dependency-property-metadata). In this example, the `HasFish` property has a <xref:System.Boolean> value type, with its default value set to `false`.

The provider class for an attached property must provide static get/set accessor methods that follow the naming convention `Get<property name>` and `Set<property name>`. The XAML reader uses the accessors to recognize the XAML attribute for the attached property and resolve its value to the appropriate type. These accessors are necessary even if an attached property isn't registered as a dependency property.

:::code language="csharp" source="./snippets/how-to-register-an-attached-property/csharp/MainWindow.xaml.cs" id="RegisterAttachedProperty":::
:::code language="vb" source="./snippets/how-to-register-an-attached-property/vb/MainWindow.xaml.vb" id="RegisterAttachedProperty":::

## See also

- <xref:System.Windows.DependencyProperty>
- [Attached properties overview](attached-properties-overview.md)
- [Dependency properties overview](dependency-properties-overview.md)
- [Custom dependency properties](custom-dependency-properties.md)
- [How-to topics](/dotnet/desktop/wpf/advanced/properties-how-to-topics?view=netframeworkdesktop-4.8&preserve-view=true)
