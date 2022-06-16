---
title: "Attached properties overview"
description: "Learn about the WPF property system and the capabilities of an attached property, which are global properties settable on any object."
ms.date: "10/14/2021"
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "attached properties [WPF Designer]"
---
<!-- The acrolinx score was 95 on 10/14/2021-->

# Attached properties overview (WPF .NET)

An attached property is a Extensible Application Markup Language (XAML) concept. Attached properties enable extra property/value pairs to be set on any XAML element that derives from <xref:System.Windows.DependencyObject>, even though the element doesn't define those extra properties in its object model. The extra properties are globally accessible. Attached properties are typically defined as a specialized form of dependency property that doesn't have a conventional property wrapper.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with XAML and know how to write Windows Presentation Foundation (WPF) applications.

## Why use attached properties

An attached property lets a child element specify a unique value for a property that's defined in a parent element. A common scenario is a child element specifying how it should be rendered in the UI by its parent element. For example, <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> is an attached property because it's set on child elements of a <xref:System.Windows.Controls.DockPanel>, not the `DockPanel` itself. The `DockPanel` class defines a static <xref:System.Windows.DependencyProperty> field, named <xref:System.Windows.Controls.DockPanel.DockProperty>, and then provides <xref:System.Windows.Controls.DockPanel.GetDock%2A> and <xref:System.Windows.Controls.DockPanel.SetDock%2A> methods as public accessors for the attached property.

## Attached properties in XAML

In XAML, you set attached properties by using the syntax `<attached property provider type>.<property name>`, where the attached property provider is the class that defines the attached property. The following example shows how a child element of <xref:System.Windows.Controls.DockPanel> can set the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> property value.

:::code language="xaml" source="./snippets/attached-properties-overview/csharp/MainWindow.xaml" id="SetAttachedPropertyInXaml":::

The usage is similar to a static property in that you reference the type that owns and registers the attached property (for example, <xref:System.Windows.Controls.DockPanel>), not the instance name.

When you specify an attached property using a XAML attribute, only the set action is applicable. You can't directly get a property value through XAML, although there are some indirect mechanisms for comparing values, such as [triggers in styles](../controls/styles-templates-overview.md#triggers).

### Attached properties in WPF

Attached properties are a XAML concept, dependency properties are a WPF concept. In WPF, most UI-related attached properties on WPF types are implemented as dependency properties. WPF attached properties that are implemented as dependency properties support dependency property concepts, such as property metadata including default values from metadata.

## Attached property usage models

Although any object can set an attached property value, that doesn't mean setting a value will produce a tangible result or the value will be used by another object. The main purpose of attached properties is to provide a way for objects from a wide variety of class hierarchies and logical relationships to report common information to the type that defines the attached property. Attached property usage typically follows one of these models:

- The type that defines the attached property is the parent of the elements that set values for the attached property. The parent type iterates its child objects through internal logic that acts on the object tree structure, obtains the values, and acts on those values in some manner.
- The type that defines the attached property is used as the child element for various possible parent elements and content models.
- The type that defines the attached property represents a service. Other types set values for the attached property. Then, when the element that set the property is evaluated in the context of the service, the attached property values are obtained through internal logic of the service class.

### An example of a parent-defined attached property

The typical scenario where WPF defines an attached property is when a parent element supports a child element collection, and the parent element implements a behavior based on data reported by each of its child elements.

<xref:System.Windows.Controls.DockPanel> defines the <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> attached property. `DockPanel` has class-level code, specifically <xref:System.Windows.Controls.DockPanel.MeasureOverride%2A> and <xref:System.Windows.Controls.DockPanel.ArrangeOverride%2A>, that's part of its rendering logic. A `DockPanel` instance checks whether any of its immediate child elements have set a value for `DockPanel.Dock`. If so, those values become inputs to the rendering logic applied to each child element. Although it's theoretically possible for attached properties to influence elements beyond the immediate parent, the defined behavior for a nested `DockPanel` instance is to only interact with its immediate child element collection. So, if you set `DockPanel.Dock` on an element that has no `DockPanel` parent, no error or exception will be raised and you would have created a global property value that won't be consumed by any `DockPanel`.

## Attached properties in code

Attached properties in WPF don't have the typical CLR `get` and `set` wrapper methods because the properties might be set from outside of the CLR namespace. To permit a XAML processor to set those values when parsing XAML, the class that defines the attached property must implement dedicated accessor methods in the form of `Get<property name>` and `Set<property name>`.

You can also use the dedicated accessor methods to get and set an attached property in code, as shown in the following example. In the example, `myTextBox` is an instance of the <xref:System.Windows.Controls.TextBox> class.

:::code language="csharp" source="./snippets/attached-properties-overview/csharp/MainWindow.xaml.cs" id="SetAttachedPropertyInCode":::
:::code language="vb" source="./snippets/attached-properties-overview/vb/MainWindow.xaml.vb" id="SetAttachedPropertyInCode":::

If you don't add `myTextBox` as a child element of `myDockPanel`, calling `SetDock` won't raise an exception or have any effect. Only a <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType> value set on a child element of a `DockPanel` can affect rendering, and the rendering will be the same whether you set the value before or after adding the child element to the `DockPanel`.

From a code perspective, an attached property is like a backing field that has method accessors instead of property accessors, and can be set on any object without first needing to be defined on those objects.

## Attached property metadata

Metadata for an attached property is generally no different than for a dependency property. When registering an attached property, use <xref:System.Windows.FrameworkPropertyMetadata> to specify characteristics of the property, such as whether the property affects rendering or measurement. When you specify a default value by overriding attached property metadata, that value becomes the default for the implicit attached property on instances of the overriding class. If an attached property value isn't otherwise set, the default value is reported when the property is queried by using the `Get<property name>` accessor with an instance of the class where you specified the metadata.

To enable property value inheritance on a property, use attached properties instead of non-attached dependency properties. For more information, see [Property value inheritance](property-value-inheritance.md).

## Custom attached properties

### When to create an attached property

Creating an attached property is useful when:

- You need a property setting mechanism available to classes other than the defining class. A common scenario is for UI layout, for instance <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.Panel.ZIndex%2A?displayProperty=nameWithType>, and <xref:System.Windows.Controls.Canvas.Top%2A?displayProperty=nameWithType> are all examples of existing layout properties. In the layout scenario, child elements of a layout-controlling element are able to express layout requirements to their layout parent and to set a value for an attached property defined by the parent.

- One of your classes represents a service, and you want other classes to integrate the service more transparently.
- You want Visual Studio WPF Designer support, such as the ability to edit a property through the **Properties** window. For more information, see [Control authoring overview](/dotnet/desktop/wpf/controls/control-authoring-overview?view=netframeworkdesktop-4.8&preserve-view=true).
- You want to use property value inheritance.

### How to create an attached property

If your class defines an attached property solely for use by other types, then your class doesn't need to derive from <xref:System.Windows.DependencyObject>. Otherwise, follow the WPF model of having an attached property also be a dependency property, by deriving your class from `DependencyObject`.

Define your attached property as a dependency in the defining class by declaring a `public static readonly` field of type <xref:System.Windows.DependencyProperty>. Then, assign the return value of the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method to the field, which is also known as the *dependency property identifier*. Follow the WPF property naming convention that distinguishes fields from the properties that they represent, by naming the identifier field `<property name>Property`. Also, provide static `Get<property name>` and `Set<property name>` accessor methods, which lets the property system access your attached property.

The following example shows how to register a dependency property using the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method, and how to define the accessor methods. In the example, the name of the attached property is `HasFish`, so the identifier field is named `HasFishProperty`, and the accessor methods are named `GetHasFish` and `SetHasFish`.

:::code language="csharp" source="./snippets/attached-properties-overview/csharp/MainWindow.xaml.cs" id="RegisterAttachedProperty":::
:::code language="vb" source="./snippets/attached-properties-overview/vb/MainWindow.xaml.vb" id="RegisterAttachedProperty":::

#### The Get accessor

The `get` accessor method signature is `public static object Get<property name>(DependencyObject target)`, where:

- `target` is the <xref:System.Windows.DependencyObject> from which the attached property is read. The `target` type can be more specific than `DependencyObject`. For example, the <xref:System.Windows.Controls.DockPanel.GetDock%2A?displayProperty=nameWithType> accessor method types the `target` as <xref:System.Windows.UIElement> because the attached property is intended to be set on `UIElement` instances. `UiElement` indirectly derives from `DependencyObject`.
- The return type can be more specific than `object`. For example, the <xref:System.Windows.Controls.DockPanel.GetDock%2A> method types the returned value as <xref:System.Windows.Controls.Dock> because the return value should be a `Dock` enumeration.

> [!NOTE]
> The `get` accessor for an attached property is required for data binding support in design tools, such as Visual Studio or Blend for Visual Studio.

#### The Set accessor

The `set` accessor method signature is `public static void Set<property name>(DependencyObject target, object value)`, where:

- `target` is the <xref:System.Windows.DependencyObject> on which the attached property is written. The `target` type can be more specific than `DependencyObject`. For example, the <xref:System.Windows.Controls.DockPanel.SetDock%2A> method types the `target` as <xref:System.Windows.UIElement> because the attached property is intended to be set on <xref:System.Windows.UIElement> instances. `UiElement` indirectly derives from `DependencyObject`.
- The `value` type can be more specific than `object`. For example, the <xref:System.Windows.Controls.DockPanel.SetDock%2A> method requires a <xref:System.Windows.Controls.Dock> value. The XAML loader needs to be able to generate the `value` type from the markup string that represents the attached property value. So, there must be type conversion, value serializer, or markup extension support for the type you use.

### Attached property attributes

WPF defines several .NET attributes that provide information about attached properties to reflection processes and also to consumers of reflection and property information, such as designers. Designers use WPF defined .NET attributes to limit the properties shown in the properties window, to avoid overwhelming users with a global list of all attached properties. You might consider applying these attributes to your own custom attached properties. The purpose and syntax of .NET attributes is described in these reference pages:

- <xref:System.Windows.AttachedPropertyBrowsableAttribute>
- <xref:System.Windows.AttachedPropertyBrowsableForChildrenAttribute>
- <xref:System.Windows.AttachedPropertyBrowsableForTypeAttribute>
- <xref:System.Windows.AttachedPropertyBrowsableWhenAttributePresentAttribute>

## Learn more

- For more information about creating an attached property, see [Register an attached property](how-to-register-an-attached-property.md).
- For more advanced usage scenarios for dependency properties and attached properties, see [Custom dependency properties](custom-dependency-properties.md).
- You can register a property as both an attached property and a dependency property, and include conventional property wrappers. In this way, a property can be set on an element by using property wrappers, and also on any other element by using XAML attached property syntax. For an example, see <xref:System.Windows.FrameworkElement.FlowDirection%2A?displayProperty=nameWithType>.

## See also

- <xref:System.Windows.DependencyProperty>
- [Dependency properties overview](dependency-properties-overview.md)
- [Custom dependency properties](custom-dependency-properties.md)
- [XAML in WPF](../xaml/index.md)
- [How to: Register an attached property](how-to-register-an-attached-property.md)
