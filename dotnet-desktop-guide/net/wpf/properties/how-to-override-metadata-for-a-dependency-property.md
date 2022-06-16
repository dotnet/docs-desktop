---
title: "How to override metadata for a dependency property"
description: "Learn how to override a dependency property in Windows Presentation Foundation (WPF) by calling the OverrideMetadata method."
ms.date: "11/04/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "metadata [WPF], overriding for dependency properties"
  - "dependency properties [WPF], overriding metadata for"
  - "overriding metadata for dependency properties [WPF]"
---
<!-- The acrolinx score was 92 on 11/04/2021-->

# How to override metadata for a dependency property (WPF .NET)

When you derive from a class that defines a dependency property, you inherit the dependency property and its metadata. This article describes how you can override the metadata of an inherited dependency property by calling the <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> method. Overriding the metadata lets you modify characteristics of the inherited dependency property to match subclass-specific requirements.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Background

A class that defines a dependency property can specify its characteristics in <xref:System.Windows.PropertyMetadata> or one of its derived types, such as <xref:System.Windows.FrameworkPropertyMetadata>. One of those characteristics is the default value of a dependency property. Many classes that define dependency properties, specify property metadata during dependency property registration. When metadata isn't specified during registration, the WPF property system assigns a `PropertyMetadata` object with default values. Derived classes that inherit dependency properties through class inheritance have the option to override the original metadata of any dependency property. In this way, derived classes can selectively modify dependency property characteristics to meet class requirements. When calling <xref:System.Windows.DependencyProperty.OverrideMetadata(System.Type,System.Windows.PropertyMetadata)>, a derived class specifies its own type as the first parameter, and a metadata instance as the second parameter.

A derived class that overrides metadata on a dependency property must do so before the property is placed in use by the property system. A dependency property is placed in use when any instance of the class that registers the property is instantiated. To help meet this requirement, the derived class should call <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> within its static constructor. Overriding the metadata of a dependency property after its owner type is instantiated won't raise exceptions, but will result in inconsistent behaviors in the property system. Also, a derived type can't override the metadata of a dependency property more than once, and attempts to do so will raise an exception.

## Example

In the following example, the derived class `TropicalAquarium` overrides the metadata of a dependency property inherited from the base class `Aquarium`. The metadata type is <xref:System.Windows.FrameworkPropertyMetadata>, which supports UI-related WPF framework characteristics such as <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsRender>. The derived class doesn't override the inherited `AffectsRender` flag, but it does update the default value of `AquariumGraphic` on derived class instances.

:::code language="csharp" source="./snippets/how-to-override-metadata-for-a-dependency-property/csharp/MainWindow.xaml.cs" id="BaseDependencyProperty":::
:::code language="vb" source="./snippets/how-to-override-metadata-for-a-dependency-property/vb/MainWindow.xaml.vb" id="BaseDependencyProperty":::
:::code language="csharp" source="./snippets/how-to-override-metadata-for-a-dependency-property/csharp/MainWindow.xaml.cs" id="InheritedDependencyProperty":::
:::code language="vb" source="./snippets/how-to-override-metadata-for-a-dependency-property/vb/MainWindow.xaml.vb" id="InheritedDependencyProperty":::

## See also

- <xref:System.Windows.DependencyProperty>
- [Dependency property metadata](dependency-property-metadata.md)
- [Dependency properties overview](dependency-properties-overview.md)
- [Custom dependency properties](custom-dependency-properties.md)
