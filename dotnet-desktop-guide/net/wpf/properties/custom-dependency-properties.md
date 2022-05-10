---
title: "Custom dependency properties"
description: Learn how to implement a dependency property in Windows Presentation Foundation (WPF), and how to improve its performance, usability, or versatility.
ms.date: "10/20/2021"
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "implementing [WPF], wrappers"
  - "registering properties [WPF]"
  - "properties [WPF], metadata"
  - "metadata [WPF], for properties"
  - "custom dependency properties [WPF]"
  - "properties [WPF], registering"
  - "wrappers [WPF], implementing"
  - "dependency properties [WPF], custom"
---
<!-- The acrolinx score was 94 on 10/20/2021-->

# Custom dependency properties (WPF .NET)

Windows Presentation Foundation (WPF) application developers and component authors can create custom dependency properties to extend the functionality of their properties. Unlike a common language runtime (CLR) [property](/dotnet/standard/base-types/common-type-system#properties), a dependency property adds support for styling, data binding, inheritance, animations, and default values. <xref:System.Windows.Controls.Control.Background%2A>, <xref:System.Windows.FrameworkElement.Width%2A>, and <xref:System.Windows.Controls.TextBox.Text%2A> are examples of existing dependency properties in WPF classes. This article describes how to implement custom dependency properties, and presents options for improving performance, usability, and versatility.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Dependency property identifier

Dependency properties are properties that are registered with the WPF property system through <xref:System.Windows.DependencyProperty.Register%2A> or <xref:System.Windows.DependencyProperty.RegisterReadOnly%2A> calls. The `Register` method returns a <xref:System.Windows.DependencyProperty> instance that holds the registered name and characteristics of a dependency property. You'll assign the `DependencyProperty` instance to a static readonly field, known as a *dependency property identifier*, that by convention is named `<property name>Property`. For example, the identifier field for the <xref:System.Windows.Controls.Control.Background%2A> property is always <xref:System.Windows.Controls.Control.BackgroundProperty>.

The dependency property identifier is used as a backing field for getting or setting property values, rather than the standard pattern of backing a property with a private field. Not only does the property system uses the identifier, XAML processors may use it, and your code (and possibly external code) can access dependency properties through their identifiers.

Dependency properties can only be applied to classes that are derived from <xref:System.Windows.DependencyObject> types. Most WPF classes support dependency properties, because `DependencyObject` is close to the root of the WPF class hierarchy. For more information about dependency properties, and the terminology and conventions used to describe them, see [Dependency properties overview](dependency-properties-overview.md).

## Dependency property wrappers

WPF dependency properties that aren't attached properties are exposed by a CLR wrapper that implements `get` and `set` accessors. By using a property wrapper, consumers of dependency properties can get or set dependency property values, just as they would any other CLR property. The `get` and `set` accessors interact with the underlying property system through <xref:System.Windows.DependencyObject.GetValue%2A?displayProperty=nameWithType> and <xref:System.Windows.DependencyObject.SetValue%2A?displayProperty=nameWithType> calls, passing in the dependency property identifier as a parameter. Consumers of dependency properties typically don't call `GetValue` or `SetValue` directly, but if you're implementing a custom dependency property you'll use those methods in the wrapper.

## When to implement a dependency property

When you implement a property on a class that derives from <xref:System.Windows.DependencyObject>, you make it a dependency property by backing your property with a <xref:System.Windows.DependencyProperty> identifier. Whether it's beneficial to create a dependency property depends on your scenario. Although backing your property with a private field is adequate for some scenarios, consider implementing a dependency property if you want your property to support one or more of the following WPF capabilities:

- Properties that are settable within a style. For more information, see [Styles and templates](../controls/styles-templates-overview.md).

- Properties that support data binding. For more information about data binding dependency properties, see [Bind the properties of two controls](/dotnet/desktop/wpf/data/how-to-bind-the-properties-of-two-controls?view=netframeworkdesktop-4.8&preserve-view=true).

- Properties that are settable through dynamic resource references. For more information, see [XAML resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define).

- Properties that automatically inherit their value from a parent element in the element tree. For this, you'll need to register using <xref:System.Windows.DependencyProperty.RegisterAttached%2A>, even if you also create a property wrapper for CLR access. For more information, see [Property value inheritance](property-value-inheritance.md).

- Properties that are animatable. For more information, see [Animation overview](/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8&preserve-view=true).

- Notification by the WPF property system when a property value changes. Changes might be due to actions by the property system, environment, user, or styles. Your property can specify a callback method in property metadata that will get invoked each time the property system determines that your property value changed. A related concept is property value coercion. For more information, see [Dependency property callbacks and validation](dependency-property-callbacks-and-validation.md).

- Access to dependency property metadata, which is read by WPF processes. For example, you can use property metadata to:

  - Specify whether a changed dependency property value should make the layout system recompose visuals for an element.

  - Set the default value of a dependency property, by overriding metadata on derived classes.

- Visual Studio WPF designer support, such as editing the properties of a custom control in the **Properties** window. For more information, see [Control authoring overview](/dotnet/desktop/wpf/controls/control-authoring-overview?view=netframeworkdesktop-4.8&preserve-view=true).

For some scenarios, overriding the metadata of an existing dependency property is a better option than implementing a new dependency property. Whether a metadata override is practical depends on your scenario, and how closely that scenario resembles the implementation of existing WPF dependency properties and classes. For more information about overriding metadata on existing dependency properties, see [Dependency property metadata](dependency-property-metadata.md).

## Checklist for creating a dependency property

Follow these steps to create a dependency property. Some of the steps can be combined and implemented in a single line of code.

1. (Optional) Create dependency property metadata.

1. Register the dependency property with the property system, specifying a property name, an owner type, the property value type, and optionally, property metadata.

1. Define a <xref:System.Windows.DependencyProperty> identifier as a `public static readonly` field on the owner type. The identifier field name is the property name with the suffix `Property` appended.

1. Define a CLR wrapper property with the same name as the dependency property name. In the CLR wrapper, implement `get` and `set` accessors that connect with the dependency property that backs the wrapper.

### Registering the property

In order for your property to be a dependency property, you must register it with the property system. To register your property, call the <xref:System.Windows.DependencyProperty.Register%2A> method from inside the body of your class, but outside of any member definitions. The `Register` method returns a unique dependency property identifier that you'll use when calling the property system API. The reason that the `Register` call is made outside of member definitions is because you assign the return value to a `public static readonly` field of type <xref:System.Windows.DependencyProperty>. This field, which you'll create in your class, is the identifier for your dependency property. In the following example, the first argument of `Register` names the dependency property `AquariumGraphic`.

:::code language="csharp" source="./snippets/custom-dependency-properties/csharp/MainWindow.xaml.cs" id="RegisterDependencyProperty":::
:::code language="vb" source="./snippets/custom-dependency-properties/vb/MainWindow.xaml.vb" id="RegisterDependencyProperty":::

> [!NOTE]
> Defining the dependency property in the class body is the typical implementation, but it's also possible to define a dependency property in the class static constructor. This approach might make sense if you need more than one line of code to initialize the dependency property.

### Dependency property naming

The established naming convention for dependency properties is mandatory for normal behavior of the property system. The name of the identifier field that you create must be the registered name of the property with the suffix `Property`.

A dependency property name must be unique within the registering class. Dependency properties that are inherited through a base type have already been registered, and cannot be registered by a derived type. However, you can use a dependency property that was registered by a different type, even a type your class doesn't inherit from, by adding your class as an owner of the dependency property. For more information on adding a class as owner, see [Dependency property metadata](dependency-property-metadata.md#add-a-class-as-an-owner).

### Implementing a property wrapper

By convention, the name of the wrapper property must be the same as the first parameter of the <xref:System.Windows.DependencyProperty.Register%2A> call, which is the dependency property name. Your wrapper implementation will call <xref:System.Windows.DependencyObject.GetValue%2A> in the `get` accessor, and <xref:System.Windows.DependencyObject.SetValue%2A> in the `set` accessor (for read-write properties). The following example shows a wrapper&mdash;following the registration call and identifier field declaration. All public dependency properties on WPF classes use a similar wrapper model.

:::code language="csharp" source="./snippets/custom-dependency-properties/csharp/MainWindow.xaml.cs" id="RegisterDependencyPropertyWithWrapper":::
:::code language="vb" source="./snippets/custom-dependency-properties/vb/MainWindow.xaml.vb" id="RegisterDependencyPropertyWithWrapper":::

Except in rare cases, your wrapper implementation should only contain <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> code. For the reasons behind this, see [Implications for custom dependency properties](xaml-loading-and-dependency-properties.md#implications-for-custom-dependency-properties).

If your property doesn't follow established naming conventions, you might run into these issues:

- Some aspects of styles and templates won't work.

- Most tools and designers rely on the naming conventions to properly serialize XAML and provide designer environment assistance at a per-property level.

- The current implementation of the WPF XAML loader bypasses the wrappers entirely, and relies on the naming convention to process attribute values. For more information, see [XAML loading and dependency properties](xaml-loading-and-dependency-properties.md).

### Dependency property metadata

When you register a dependency property, the property system creates a metadata object to store property characteristics. Overloads of the <xref:System.Windows.DependencyProperty.Register%2A> method let you specify property metadata during registration, for example <xref:System.Windows.DependencyProperty.Register%28System.String%2CSystem.Type%2CSystem.Type%2CSystem.Windows.PropertyMetadata%29>. A common use of property metadata is to apply a custom default value for new instances that use a dependency property. If you don't provide property metadata, the property system will assign default values to many of the dependency property characteristics.

If you're creating a dependency property on a class derived from <xref:System.Windows.FrameworkElement>, you can use the more specialized metadata class <xref:System.Windows.FrameworkPropertyMetadata> rather than its base class <xref:System.Windows.PropertyMetadata>. Several <xref:System.Windows.FrameworkPropertyMetadata> constructor signatures let you specify different combinations of metadata characteristics. If you just want to specify a default value, then use <xref:System.Windows.FrameworkPropertyMetadata.%23ctor(System.Object)> and pass the default value to the `Object` parameter. Ensure that the value type matches the `propertyType` specified in the `Register` call.

Some <xref:System.Windows.FrameworkPropertyMetadata> overloads let you specify [metadata option flags](<xref:System.Windows.FrameworkPropertyMetadataOptions>) for your property. The property system converts these flags into discrete properties and the flag values are used by WPF processes, such as the layout engine.

#### Setting metadata flags

Consider the following when setting metadata flags:

- If your property value (or changes to it) affects how the layout system renders a UI element, then set one or more of the following flags:

  - <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsMeasure>, which indicates that a change in property value requires a change in UI rendering, specifically the space occupied by an object within its parent. For example, set this metadata flag for a `Width` property.

  - <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsArrange>, which indicates that a change in property value requires a change in UI rendering, specifically the position of an object within its parent. Typically, the object doesn't also change size. For example, set this metadata flag for an `Alignment` property.

  - <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsRender>, which indicates that a change has occurred that doesn't affect layout and measure, but still requires another render. For example, set this flag for a `Background` property, or any other property that affects the color of an element.

  You can use also these flags as inputs to your override implementations of the property system (or layout) callbacks. For example, you might use an <xref:System.Windows.DependencyObject.OnPropertyChanged%2A> callback to call <xref:System.Windows.UIElement.InvalidateArrange%2A> when a property of the instance reports a value change and has <xref:System.Windows.FrameworkPropertyMetadata.AffectsArrange%2A> set in metadata.

- Some properties affect the rendering characteristics of their parent element in other ways. For example, changes to the <xref:System.Windows.Documents.Paragraph.MinOrphanLines%2A> property can change the overall rendering of a flow document. Use <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsParentArrange> or <xref:System.Windows.FrameworkPropertyMetadataOptions.AffectsParentMeasure> to signal parent actions in your own properties.

- By default, dependency properties support data binding. However, you can use <xref:System.Windows.FrameworkPropertyMetadata.IsDataBindingAllowed> to disable data binding when there's no realistic scenario for it, or where data binding performance is problematic, such as on large objects.

- Although the default data binding [mode](<xref:System.Windows.Data.Binding.Mode%2A>) for dependency properties is <xref:System.Windows.Data.BindingMode.OneWay>, you can change the binding mode of a specific binding to <xref:System.Windows.Data.BindingMode.TwoWay>. For more information, see [Binding direction](../data/binding-declarations-overview.md#binding-direction). As a dependency property author, you can even choose to make two-way binding the default mode. An example of an existing dependency property that uses two-way data binding is <xref:System.Windows.Controls.MenuItem.IsSubmenuOpen%2A?displayProperty=nameWithType>, which has a state that's based on other properties and method calls. The scenario for `IsSubmenuOpen` is that its setting logic, and the compositing of <xref:System.Windows.Controls.MenuItem>, interact with the default theme style. <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> is another WPF dependency property that uses two-way binding by default.

- You can enable property inheritance for your dependency property by setting the <xref:System.Windows.FrameworkPropertyMetadataOptions.Inherits> flag. Property inheritance is useful for scenarios in which parent and child elements have a property in common and it makes sense for the child element to inherit the parent value for the common property. An example of an inheritable property is <xref:System.Windows.FrameworkElement.DataContext%2A>, which supports binding operations that use the [master-detail scenario](/dotnet/desktop/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data?view=netframeworkdesktop-4.8&preserve-view=true) for data presentation. Property value inheritance lets you specify a data context at the page or application root, which saves having to specify it for child element bindings. Although an inherited property value overrides the default value, property values can be set locally on any child element. Use property value inheritance sparingly because it has a performance cost. For more information, see [Property value inheritance](property-value-inheritance.md).

- Set the <xref:System.Windows.FrameworkPropertyMetadataOptions.Journal> flag to indicate that your dependency property should be detected or used by navigation journaling services. For example, the <xref:System.Windows.Controls.Primitives.Selector.SelectedIndex%2A> property sets the `Journal` flag to recommend that applications keep a journaling history of items selected.

## Read-only dependency properties

You can define a dependency property that's read-only. A typical scenario is a dependency property that stores internal state. For example, <xref:System.Windows.UIElement.IsMouseOver> is read-only because its state should only be determined by mouse input. For more information, see [Read-only dependency properties](read-only-dependency-properties.md).

## Collection-type dependency properties

Collection-type dependency properties have extra implementation issues to consider, such as setting a default value for reference types and data binding support for  collection elements. For more information, see [Collection-type dependency properties](collection-type-dependency-properties.md).

## Dependency property security

Typically, you'll declare dependency properties as public properties, and <xref:System.Windows.DependencyProperty> identifier fields as `public static readonly` fields. If you specify a more restrictive access level, such as `protected`, a dependency property can still be accessed through its identifier in combination with property system APIs. Even a protected identifier field is potentially accessible through WPF metadata reporting or value determination APIs, like <xref:System.Windows.LocalValueEnumerator>. For more information, see [Dependency property security](dependency-property-security.md).

For read-only dependency properties, the value returned from <xref:System.Windows.DependencyProperty.RegisterReadOnly%2A> is <xref:System.Windows.DependencyPropertyKey>, and typically you won't make `DependencyPropertyKey` a `public` member of your class. Because the WPF property system doesn't propagate the `DependencyPropertyKey` outside of your code, a read-only dependency property has better `set` security than a read-write dependency property.

## Dependency properties and class constructors

There's a general principle in managed code programming, often enforced by code analysis tools, that class constructors shouldn't call virtual methods. This is because base constructors can be called during initialization of a derived class constructor, and a virtual method called by a base constructor might run before complete initialization of the derived class. When you derive from a class that already derives from <xref:System.Windows.DependencyObject>, the property system itself calls and exposes virtual methods internally. These virtual methods are part of the WPF property system services. Overriding the methods enables derived classes to participate in value determination. To avoid potential issues with runtime initialization, you shouldn't set dependency property values within constructors of classes, unless you follow a specific constructor pattern. For more information, see [Safe constructor patterns for DependencyObjects](safe-constructor-patterns-for-dependencyobjects.md).

## See also

- [Dependency properties overview](dependency-properties-overview.md)
- [Dependency property metadata](dependency-property-metadata.md)
- [Control authoring overview](/dotnet/desktop/wpf/controls/control-authoring-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [Collection-type dependency properties](collection-type-dependency-properties.md)
- [Dependency property security](dependency-property-security.md)
- [XAML loading and dependency properties](xaml-loading-and-dependency-properties.md)
- [Safe constructor patterns for DependencyObjects](safe-constructor-patterns-for-dependencyobjects.md)
