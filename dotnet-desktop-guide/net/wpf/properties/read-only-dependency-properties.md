---
title: "Read-only dependency properties"
description: Learn about dependency properties in Windows Presentation Foundation (WPF) and how to create a read-only dependency property.
ms.date: "11/29/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "dependency properties [WPF], read-only"
  - "read-only dependency properties [WPF]"
---
<!-- The acrolinx score was 94 on 11/29/2021-->

# Read-only dependency properties (WPF .NET)

You can use read-only dependency properties to prevent property values being set from outside your code. This article discusses existing read-only dependency properties and the scenarios and techniques for creating a custom read-only dependency property.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Existing read-only dependency properties

Read-only dependency properties typically report state, and shouldn't be modifiable through a `public` accessor. For example, the Windows Presentation Foundation (WPF) framework implements the <xref:System.Windows.UIElement.IsMouseOver%2A> property as read-only because its value should only be determined by mouse input. If `IsMouseOver` allowed other inputs, its value might become inconsistent with mouse input. Though not settable through a `public` accessor, many existing read-only dependency properties have values determined by multiple inputs.

## Uses of read-only dependency properties

Read-only dependency properties aren't applicable in several scenarios where dependency properties normally offer a solution. Non-applicable scenarios include data binding, applying a style to a value, validation, animation, and inheritance. However, a read-only dependency property can be used as a property trigger in a style. For example, <xref:System.Windows.UIElement.IsMouseOver%2A> is commonly used to trigger changes to the background, foreground, or other visible property of a control when the mouse is over it. The WPF property system detects and reports changes in read-only dependency properties, thus supporting property trigger functionality. Read-only dependency properties are also useful when implementing a collection-type dependency property where only the collection elements need to be writeable, not the collection object itself. For more information, see [Collection-type dependency properties](collection-type-dependency-properties.md).

> [!NOTE]
> Only dependency properties, not regular common language runtime properties, can be used as property triggers in a style.

## Creating custom read-only dependency properties

Before creating a dependency property that's read-only, check the [non-applicable scenarios](#uses-of-read-only-dependency-properties).

The process of creating a read-only dependency property is in many ways similar to creating read-write dependency properties, with these distinctions:

- When registering your read-only property, call <xref:System.Windows.DependencyProperty.RegisterReadOnly%2A> instead of <xref:System.Windows.DependencyProperty.Register%2A>.

- When implementing the CLR property wrapper, make sure it doesn't have a public `set` accessor.

- `RegisterReadOnly` returns <xref:System.Windows.DependencyPropertyKey> instead of <xref:System.Windows.DependencyProperty>. Store the `DependencyPropertyKey` in a nonpublic class member.

You can determine the value of your read-only dependency property using whatever logic you choose. The recommended way to set the property value, either initially or as part of runtime logic, is to use the overload of <xref:System.Windows.DependencyObject.SetValue%2A> that accepts a parameter of type `DependencyPropertyKey`. Using `SetValue` is preferable to circumventing the property system and setting the backing field directly.

How and where you set the value of a read-only dependency property within your application will affect the access level you assign to the class member that stores the `DependencyPropertyKey`. If you only set the property value from within the class that registers the dependency property, you can use a `private` access modifier. For scenarios where the values of dependency properties affect each other, you can use paired <xref:System.Windows.PropertyChangedCallback> and <xref:System.Windows.CoerceValueCallback> callbacks to trigger value changes. For more information, see [Dependency property metadata](dependency-property-metadata.md).

If you need to change the value of a read-only dependency property from outside the class that registers it, you can use an `internal` access modifier for the `DependencyPropertyKey`. For example, you might call `SetValue` from an event handler in the same assembly. The following example defines an Aquarium class that calls `RegisterReadOnly` to create the read-only dependency property `FishCount`. The `DependencyPropertyKey` is assigned to an `internal static readonly` field, so that code in the same assembly can change the read-only dependency property value.

:::code language="csharp" source="./snippets/read-only-dependency-properties/csharp/MainWindow.xaml.cs" id="RegisterReadOnlyDependencyProperty":::
:::code language="vb" source="./snippets/read-only-dependency-properties/vb/MainWindow.xaml.vb" id="RegisterReadOnlyDependencyProperty":::

Because the WPF property system doesn't propagate the <xref:System.Windows.DependencyPropertyKey> outside your code, read-only dependency properties have better write security than read-write dependency properties. Use a read-only dependency property when you want to limit write-access to those who have a reference to the `DependencyPropertyKey`.

In contrast, the dependency property identifier for read-write dependency properties is accessible through the property system, no matter what access modifier you assign it. For more information, see [Dependency property security](dependency-property-security.md).

## See also

- [Dependency properties overview](dependency-properties-overview.md)
- [Implement a Dependency property](how-to-implement-a-dependency-property.md)
- [Custom dependency properties](custom-dependency-properties.md)
- [Collection-type dependency properties](collection-type-dependency-properties.md)
- [Dependency property security](dependency-property-security.md)
- [Styles and templates in WPF](../controls/styles-templates-overview.md)
