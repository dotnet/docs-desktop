---
title: "Dependency property metadata"
description: Learn about dependency property metadata in Windows Presentation Foundation (WPF) and how to create, assign, and override metadata.
ms.date: "11/02/2021"
helpviewer_keywords:
  - "APIs [WPF], metadata"
  - "dependency properties [WPF], metadata"
  - "metadata [WPF], for dependency properties"
  - "overriding metadata [WPF]"
---
<!-- The acrolinx score was 92 on 11/02/2021-->

# Dependency property metadata (WPF .NET)

The Windows Presentation Foundation (WPF) property system includes a dependency property metadata reporting system. The information available through the metadata reporting system exceeds what is available through reflection or general common language runtime (CLR) characteristics. When you register a dependency property, you have the option to create and assign metadata to it. If you derive from a class that defines a dependency property, you can override the metadata for the inherited dependency property. And, if you add your class as an owner of a dependency property, you can override the metadata of the inherited dependency property.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## How metadata is used

You can query dependency property metadata to examine the characteristics of a dependency property. When the property system processes a dependency property, it accesses its metadata. The metadata object for a dependency property contains the following types of information:

- The default value of the dependency property, which is set by the property system when no other value applies, such as a local, style, or inheritance value. For more information about value precedence during run-time assignment of dependency property values, see [Dependency property value precedence](dependency-property-value-precedence.md).

- References to coercion value callbacks and property change callbacks on the owner type. You can only obtain references to callbacks that have a `public` access modifier or are within your permitted access scope. For more information about dependency property callbacks, see [Dependency property callbacks and validation](dependency-property-callbacks-and-validation.md).

- WPF framework-level dependency property characteristics (if the dependency property is a WPF framework property). WPF processes, such as the framework layout engine and the property inheritance logic, query WPF framework-level metadata. For more information, see [Framework property metadata](framework-property-metadata.md).

## Metadata APIs

The <xref:System.Windows.PropertyMetadata> class stores most of the metadata used by the property system. Metadata instances can be created and assigned by:

- Types that register dependency properties with the property system.

- Types that inherit from a class that defines a dependency property.

- Types that add themselves as an owner of a dependency property.

If a type registers a dependency property without specifying metadata, the property system assigns a `PropertyMetadata` object with default values for that type to the dependency property.

To retrieve metadata for a dependency property, call one of the <xref:System.Windows.DependencyProperty.GetMetadata%2A> overloads on the <xref:System.Windows.DependencyProperty> identifier. The metadata is returned as a `PropertyMetadata` object.

More specific metadata classes, derived from `PropertyMetadata`, exist for different architectural areas. For example, <xref:System.Windows.UIPropertyMetadata> supports animation reporting, and <xref:System.Windows.FrameworkPropertyMetadata> supports WPF framework properties. Dependency properties can also be registered with the `PropertyMetadata` derived classes. Although `GetMetadata` returns a `PropertyMetadata` object, when applicable you can cast to a derived type to examine type-specific properties.

The property characteristics that are exposed by `FrameworkPropertyMetadata` are sometimes referred to as *flags*. When you create a `FrameworkPropertyMetadata` instance, you have the option to pass an instance of the enumeration type <xref:System.Windows.FrameworkPropertyMetadataOptions> into the `FrameworkPropertyMetadata` constructor. `FrameworkPropertyMetadataOptions` lets you specify metadata flags in bitwise combination. The `FrameworkPropertyMetadata` uses `FrameworkPropertyMetadataOptions` to keep the length of its constructor signature reasonable. On dependency property registration, the metadata flags that you set on `FrameworkPropertyMetadataOptions` are exposed within `FrameworkPropertyMetadata` as `Boolean` properties rather than a bitwise combination of flags, to make querying metadata characteristics more intuitive.

## Override or create new metadata?

When you inherit a dependency property, you have the option to change characteristics of the dependency property by overriding its metadata. However, you might not always be able to accomplish your dependency property scenario by overriding metadata, and sometimes it's necessary to define a custom dependency property in your class with new metadata. Custom dependency properties have the same capabilities as dependency properties defined by WPF types. For more information, see [Custom dependency properties](custom-dependency-properties.md).

One characteristic of a dependency property that you can't override is its value type. If an inherited dependency property has the approximate behavior you need, but your scenario requires a different value type, consider implementing a custom dependency property. You might be able to link the property values through type conversion or other implementation in your derived class.

### Scenarios for overriding metadata

Example scenarios for overriding existing dependency property metadata are:

- Changing the default value, which is a common scenario.

- Changing or adding property-change callbacks, which might be necessary if an inherited dependency property interacts with other dependency properties differently than its base implementation does. One of the characteristics of a programming model that supports both code and markup, is that property values might be set in any order. This factor can affect how you implement property-change callbacks. For more information, see [Dependency property callbacks and validation](dependency-property-callbacks-and-validation.md).

- Changing WPF [framework property metadata](<xref:System.Windows.FrameworkPropertyMetadata>) options. Typically, metadata options are set during registration of a new dependency property, but you can respecify them in <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> or <xref:System.Windows.DependencyProperty.AddOwner%2A> calls. For more information about overriding framework property metadata, see [Specifying FrameworkPropertyMetadata](framework-property-metadata.md#specifying-frameworkpropertymetadata). For how to set framework property metadata options when registering a dependency property, see [Custom dependency properties](custom-dependency-properties.md).

> [!NOTE]
> Since validation callbacks aren't part of metadata, they can't be changed by overriding metadata. For more information, see [Validation value callbacks](dependency-property-callbacks-and-validation.md#validate-value-callbacks).

## Overriding metadata

When implementing a new dependency property, you can set its metadata by using overloads of the <xref:System.Windows.DependencyProperty.Register%2A> method. If your class inherits a dependency property, you can override inherited metadata values using the <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> method. For example, you might use `OverrideMetadata` to set type-specific values. For more information and code samples, see [Override metadata for a dependency property](how-to-override-metadata-for-a-dependency-property.md).

An example of a WPF dependency property, is <xref:System.Windows.UIElement.Focusable%2A>. The <xref:System.Windows.FrameworkElement> class registers `Focusable`. The <xref:System.Windows.Controls.Control> class derives from `FrameworkElement`, inherits the `Focusable` dependency property, and overrides the inherited property metadata. The override changes the default property value from `false` to `true`, but preserves other inherited metadata values.

Since most existing dependency properties aren't virtual properties, their inherited implementation shadows the existing member. When you override a metadata characteristic, the new metadata value either replaces the original value or they're merged:

- For a <xref:System.Windows.PropertyMetadata.DefaultValue%2A>, the new value will replace the existing default value. If you don't specify a `DefaultValue` in the override metadata, the value comes from the nearest ancestor that specified `DefaultValue` in metadata.

- For a <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A>, the default merge logic stores all `PropertyChangedCallback` values in a table, and all are invoked on a property change. The callback order is determined by class depth, where a callback registered by the base class in the hierarchy would run first.

- For a <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A>, the new value will replace the existing `CoerceValueCallback` value. If you don't specify a `CoerceValueCallback` in the override metadata, the value comes from the nearest ancestor that specified `CoerceValueCallback` in metadata.

> [!NOTE]
> The default merge logic is implemented by the <xref:System.Windows.PropertyMetadata.Merge%2A> method. You can specify custom merge logic in a derived class that inherits a dependency property, by overriding `Merge` in that class.

## Add a class as an owner

To "inherit" a dependency property that's registered in a different class hierarchy, use the <xref:System.Windows.DependencyProperty.AddOwner%2A> method. This method is typically used when the adding class isn't derived from the type that registered the dependency property. In the `AddOwner` call, the adding class can create and assign type-specific metadata for the inherited dependency property. To be a full participant in the property system, through code and markup, the adding class should implement these public members:

- A dependency property identifier field. The value of the dependency property identifier is the return value of the `AddOwner` call. This field should be a `public static readonly` field of type <xref:System.Windows.DependencyProperty>.

- A CLR wrapper that implements `get` and `set` accessors. By using a property wrapper, consumers of dependency properties can get or set dependency property values, just as they would any other CLR property. The `get` and `set` accessors interact with the underlying property system through <xref:System.Windows.DependencyObject.GetValue%2A?displayProperty=nameWithType> and <xref:System.Windows.DependencyObject.SetValue%2A?displayProperty=nameWithType> calls, passing in the dependency property identifier as a parameter. Implement the wrapper the same way you would when registering a custom dependency property. For more information, see [Custom dependency properties](custom-dependency-properties.md)

A class that calls `AddOwner` has the same requirements for exposing the object model of the inherited dependency property as a class that defines a new custom dependency property. For more information, see [Add an owner type for a dependency property](/dotnet/desktop/wpf/advanced/how-to-add-an-owner-type-for-a-dependency-property?view=netframeworkdesktop-4.8&preserve-view=true).

## Attached property metadata

In WPF, most UI-related attached properties on WPF types are implemented as dependency properties. Attached properties implemented as dependency properties support dependency property concepts, such as metadata that derived classes can override. Metadata for an attached property is generally no different than for a dependency property. You can override the default value, property change callbacks, and WPF framework properties for the inherited attached property, on instances of the overriding class. For more information, see [Attached property metadata](attached-properties-overview.md)

> [!NOTE]
> Always use <xref:System.Windows.DependencyProperty.RegisterAttached%2A> to register properties where you specify <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A> in the metadata. Although property value inheritance might appear to work for nonattached dependency properties, the value inheritance behavior for a nonattached property through certain object-object divisions in the runtime tree is undefined. The `Inherits` property isn't relevant for nonattached properties. For more information, see <xref:System.Windows.DependencyProperty.RegisterAttached(System.String,System.Type,System.Type,System.Windows.PropertyMetadata)>, and the remarks section of <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A>.

### Add a class as owner of an attached property

To inherit an attached property from another class, but expose it as a nonattached dependency property on your class:

- Call <xref:System.Windows.DependencyProperty.AddOwner%2A> to add your class as an owner of the attached dependency property.

- Assign the return value of the `AddOwner` call to a `public static readonly` field, for use as the dependency property identifier.

- Define a CLR wrapper, which adds the property as a class member and supports nonattached property usage.

## See also

- <xref:System.Windows.PropertyMetadata>
- <xref:System.Windows.DependencyObject>
- <xref:System.Windows.DependencyProperty>
- <xref:System.Windows.DependencyProperty.GetMetadata%2A>
- <xref:System.Windows.DependencyProperty.AddOwner%2A>
- [Dependency properties overview](dependency-properties-overview.md)
- [Framework property metadata](framework-property-metadata.md)
