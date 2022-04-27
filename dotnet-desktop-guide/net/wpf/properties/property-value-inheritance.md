---
title: "Dependency property value inheritance"
description: "Learn how dependency property value inheritance can be used to propagate property values in Windows Presentation Foundation (WPF)."
ms.date: "12/29/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "inheritance [WPF], property values"
  - "value inheritance [WPF]"
  - "properties [WPF], value inheritance"
---
<!-- The acrolinx score was 91 on 12/29/2021-->

# Property value inheritance (WPF .NET)

Property value inheritance is a feature of the Windows Presentation Foundation (WPF) property system and applies to dependency properties. Property value inheritance lets child elements in a tree of elements obtain the value of a particular property from the nearest parent element. Since a parent element might also have obtained its property value through property value inheritance, the system potentially recurses back to the page root.

The WPF property system doesn't enable property value inheritance by default, and value inheritance is inactive unless specifically enabled in dependency property [metadata](<xref:System.Windows.FrameworkPropertyMetadata.Inherits>). Even with property value inheritance enabled, a child element will only inherit a property value in the absence of a higher [precedence](dependency-property-value-precedence.md#dependency-property-precedence-list) value.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Inheritance through an element tree

Property value inheritance isn't the same concept as class inheritance in object-oriented programming, where derived classes inherit base class members. That kind of inheritance is also active in WPF, although in XAML the inherited base class properties are exposed as attributes of XAML elements that represent derived classes.

Property value inheritance is the mechanism by which a dependency property value propagates from parent to child elements within a tree of elements that contain the property. In XAML markup, a tree of elements is visible as nested elements.

The following example shows nested elements in XAML. WPF registers the <xref:System.Windows.UIElement.AllowDrop%2A> dependency property on the <xref:System.Windows.UIElement> class with property [metadata](framework-property-metadata.md) that enables property value [inheritance](<xref:System.Windows.FrameworkPropertyMetadata.Inherits>) and sets the default value to `false`. The `AllowDrop` dependency property exists on <xref:System.Windows.Controls.Canvas>, <xref:System.Windows.Controls.StackPanel>, and <xref:System.Windows.Controls.Label> elements since they all derive from `UIElement`. Since the `AllowDrop` dependency property on `canvas1` is set to `true`, the descendant `stackPanel1` and `label1` elements inherit `true` as their `AllowDrop` value.

:::code language="xaml" source="./snippets/property-value-inheritance/csharp/MainWindow.xaml" id="XamlElementTree":::

You can also create a tree of elements programmatically by adding element objects to the child element collection of another element object. At run time, property value inheritance operates on the resultant object tree. In the following example, `stackPanel2` is added to the [child collection](<xref:System.Windows.Controls.UIElementCollection>) of `canvas2`. Similarly, `label2` is added to the child collection of `stackPanel2`. Since the <xref:System.Windows.UIElement.AllowDrop%2A> dependency property on `canvas2` is set to `true`, the descendant `stackPanel2` and `label2` elements inherit `true` as their `AllowDrop` value.

:::code language="csharp" source="./snippets/property-value-inheritance/csharp/MainWindow.xaml.cs" id="CodeElementTree":::
:::code language="vb" source="./snippets/property-value-inheritance/vb/MainWindow.xaml.vb" id="CodeElementTree":::

## Practical applications of property value inheritance

Specific WPF dependency properties have value inheritance enabled by default, such as <xref:System.Windows.UIElement.AllowDrop%2A> and <xref:System.Windows.FrameworkElement.FlowDirection%2A>. Typically, properties with value inheritance enabled by default are implemented on base UI element classes, so they exist on derived classes. For example, since `AllowDrop` is implemented on the <xref:System.Windows.UIElement> base class, that dependency property also exists on every control derived from `UIElement`. WPF enables value inheritance on dependency properties for which it's convenient for a user to set the property value once on a parent element and have that property value propagate to descendant elements in the element tree.

The property value inheritance model assigns property values, both inherited and uninherited, according to [dependency property value precedence](dependency-property-value-precedence.md#dependency-property-precedence-list). So, a parent element property value will only get applied to a child element, if the child element property doesn't have a higher precedence value, such as a locally set value, or a value obtained through styles, templates, or data binding.

The <xref:System.Windows.FrameworkElement.FlowDirection%2A> dependency property sets the layout direction of text and child UI elements within a parent element. Typically, you would expect the flow direction of text and UI elements within a page to be consistent. Since value inheritance is enabled in the property [metadata](<xref:System.Windows.FrameworkPropertyMetadata>) of `FlowDirection`, a value need only be set once at the top of the element tree for a page. In the rare case where a mix of flow directions is intended for a page, a different flow direction can be set on an element in the tree by assigning a locally set value. The new flow direction will then propagate to descendant elements below that level.

## Making a custom property inheritable

You can make a custom dependency property inheritable by enabling the <xref:System.Windows.FrameworkPropertyMetadata.Inherits> property in an instance of <xref:System.Windows.FrameworkPropertyMetadata>, and then registering your custom dependency property with that metadata instance. By default, `Inherits` is set to `false` in `FrameworkPropertyMetadata`. Making a property value inheritable affects performance, so only set `Inherits` to `true` if that feature is needed.

When you register a dependency property with `Inherits` enabled in metadata, use the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method as described in [Register an attached property](how-to-register-an-attached-property.md). Also, assign a default value to the property so that an inheritable value exists. You might also want to create a property wrapper with `get` and `set` accessors on the owner type, just as you would for a nonattached dependency property. That way you can set the property value using the property wrapper on an owner or derived type. The following example creates a dependency property named `IsTransparent`, with `Inherits` enabled and a default value of `false`. The example also includes a property wrapper with `get` and `set` accessors.

:::code language="csharp" source="./snippets/property-value-inheritance/csharp/MainWindow.xaml.cs" id="RegisterAttachedPropertyWithValueInheritance":::
:::code language="vb" source="./snippets/property-value-inheritance/vb/MainWindow.xaml.vb" id="RegisterAttachedPropertyWithValueInheritance":::

Attached properties are conceptually similar to global properties. You can check their value on any <xref:System.Windows.DependencyObject> and get a valid result. The typical scenario for attached properties is to set property values on child elements, and that scenario is more effective if the property in question is implicitly present as an attached property on each <xref:System.Windows.DependencyObject> element in the tree.

## Inheriting property values across tree boundaries

Property inheritance works by traversing a tree of elements. This tree is often parallel to the logical tree. However, whenever you include a WPF core-level object, such as a <xref:System.Windows.Media.Brush>, in the markup that defines an element tree, you've created a discontinuous logical tree. A true logical tree doesn't conceptually extend through the `Brush`, because the logical tree is a WPF framework-level concept. You can use the helper methods of <xref:System.Windows.LogicalTreeHelper> to analyze and view the extent of a logical tree. Property value inheritance is able to pass inherited values through a discontinuous logical tree, but only if the inheritable property was registered as an attached property and there isn't a deliberate inheritance-blocking boundary, such as a <xref:System.Windows.Controls.Frame>.

> [!NOTE]
> Although property value inheritance might appear to work for nonattached dependency properties, the inheritance behavior for a nonattached property through some element boundaries in the runtime tree is undefined. Whenever you specify <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A> in property metadata, register your properties using <xref:System.Windows.DependencyProperty.RegisterAttached%2A>.

## See also

- [Dependency property metadata](dependency-property-metadata.md)
- [Attached properties overview](attached-properties-overview.md)
- [Register an attached property](how-to-register-an-attached-property.md)
- [Custom dependency properties](custom-dependency-properties.md)
- [Dependency property value precedence](dependency-property-value-precedence.md)
- [Framework property metadata](framework-property-metadata.md)
