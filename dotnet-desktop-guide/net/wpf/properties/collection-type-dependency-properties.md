---
title: "Collection-type dependency properties"
description: "Learn how to implement a dependency property that's a collection type and how to assign a default collection value."
ms.date: "10/06/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "properties [WPF], dependency"
  - "properties [WPF], collection-type"
  - "dependency properties [WPF]"
  - "collection-type properties [WPF]"
---
<!-- The acrolinx score was 96 on 10/07/2021-->

# Collection-type dependency properties (WPF .NET)

This article provides guidance and suggested patterns for implementing a dependency property that's a collection type.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Implement a collection-type dependency property

In general, the implementation pattern for a dependency property is a CLR property wrapper backed by a <xref:System.Windows.DependencyProperty> identifier instead of a field or other construct. You can follow the same pattern when you implement a collection-type dependency property. The pattern is more complex if the collection element type is a <xref:System.Windows.DependencyObject> or a <xref:System.Windows.Freezable> derived class.

## Initialize the collection

When you create a dependency property, you typically specify the default value through dependency property metadata instead of specifying an initial property value. However, if your property value is a reference type, the default value should be set in the constructor of the class that registers the dependency property. The dependency property metadata shouldn't include a default reference-type value because that value will be assigned to all instances of the class, creating a singleton class.

The following example declares an `Aquarium` class that contains a collection of <xref:System.Windows.FrameworkElement> elements in a generic <xref:System.Collections.Generic.List%601>. A default collection value isn't included in the <xref:System.Windows.PropertyMetadata> passed to the <xref:System.Windows.DependencyProperty.RegisterReadOnly%28System.String%2CSystem.Type%2CSystem.Type%2CSystem.Windows.PropertyMetadata%29> method, and instead the class constructor is used to set the default collection value to a new generic `List`.

:::code language="csharp" source="./snippets/collection-type-dependency-properties/csharp/MainWindow.xaml.cs" id="SetCollectionDefaultValueInConstructor":::
:::code language="vb" source="./snippets/collection-type-dependency-properties/vb/MainWindow.xaml.vb" id="SetCollectionDefaultValueInConstructor":::

The following test code instantiates two separate `Aquarium` instances and adds a different `Fish` item to each collection. If you run the code, you'll see that each `Aquarium` instance has a single collection item, as expected.

:::code language="csharp" source="./snippets/collection-type-dependency-properties/csharp/MainWindow.xaml.cs" id="InitializeAquariums":::
:::code language="vb" source="./snippets/collection-type-dependency-properties/vb/MainWindow.xaml.vb" id="InitializeAquariums":::

But, if you comment out the class constructor and pass the default collection value as <xref:System.Windows.PropertyMetadata> to the <xref:System.Windows.DependencyProperty.RegisterReadOnly%28System.String%2CSystem.Type%2CSystem.Type%2CSystem.Windows.PropertyMetadata%29> method, you'll see that each `Aquarium` instance gets two collection items! This is because both `Fish` instances are added to the same list, which is shared by all instances of the Aquarium class. So, when the intent is for each object instance to have its own list, the default value should be set in the class constructor.

### Initialize a read-write collection

The following example declares a read-write collection-type dependency property in the `Aquarium` class, using the non-key signature methods <xref:System.Windows.DependencyProperty.Register%28System.String%2CSystem.Type%2CSystem.Type%29> and <xref:System.Windows.DependencyObject.SetValue%28System.Windows.DependencyProperty%2CSystem.Object%29>.

:::code language="csharp" source="./snippets/collection-type-dependency-properties/csharp/MainWindow.xaml.cs" id="ReadWriteDependencyProperty":::
:::code language="vb" source="./snippets/collection-type-dependency-properties/vb/MainWindow.xaml.vb" id="ReadWriteDependencyProperty":::

## FreezableCollection dependency properties

A collection-type dependency property doesn't automatically report changes in its subproperties. As a result, if you're binding to a collection, the binding might not report changes, invalidating some data binding scenarios. But, if you use <xref:System.Windows.FreezableCollection%601> for the dependency property type, changes to the properties of collection elements are properly reported and binding works as expected.

To enable subproperty binding in a collection of dependency objects, use the collection type `FreezableCollection`, with a type constraint of any <xref:System.Windows.DependencyObject> derived class.

The following example declares an `Aquarium` class that contains a `FreezableCollection` with a type constraint of <xref:System.Windows.FrameworkElement>. A default collection value isn't included in the <xref:System.Windows.PropertyMetadata> passed to the <xref:System.Windows.DependencyProperty.RegisterReadOnly%28System.String%2CSystem.Type%2CSystem.Type%2CSystem.Windows.PropertyMetadata%29> method, and instead the class constructor is used to set the default collection value to a new `FreezableCollection`.

:::code language="csharp" source="./snippets/collection-type-dependency-properties/csharp/MainWindow.xaml.cs" id="FreezableCollectionAquarium":::
:::code language="vb" source="./snippets/collection-type-dependency-properties/vb/MainWindow.xaml.vb" id="FreezableCollectionAquarium":::

## See also

- <xref:System.Windows.FreezableCollection%601>
- [XAML and Custom Classes for WPF](/dotnet/desktop/wpf/advanced/xaml-and-custom-classes-for-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
- [Data Binding Overview](../data/index.md)
- [Dependency Properties Overview](dependency-properties-overview.md)
- [Custom Dependency Properties](custom-dependency-properties.md)
- [Dependency Property Metadata](dependency-property-metadata.md)
