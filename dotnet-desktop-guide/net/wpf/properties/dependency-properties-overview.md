---
title: "Dependency properties overview"
description: Learn about the WPF property system and the capabilities of a dependency property, which is a property that's backed by the WPF property system.
ms.date: "09/23/2021"
ms.topic: overview
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "properties [WPF], attached"
  - "properties [WPF], overview"
  - "styles [WPF]"
  - "attached properties [WPF]"
  - "data binding [WPF]"
  - "dependency properties [WPF]"
  - "resources [WPF], references to"
---
<!-- The acrolinx score was 94 on 09/23/2021-->

# Dependency properties overview (WPF .NET)

Windows Presentation Foundation (WPF) provides a set of services that can be used to extend the functionality of a type's [property](/dotnet/standard/base-types/common-type-system#properties). Collectively, these services are referred to as the WPF property system. A property that's backed by the WPF property system is known as a dependency property. This overview describes the WPF property system and the capabilities of a dependency property, including how to use existing dependency properties in XAML and in code. This overview also introduces specialized aspects of dependency properties, such as dependency property metadata, and how to create your own dependency property in a custom class.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

This article assumes basic knowledge of the .NET type system and object-oriented programming. To follow the examples in this article, it helps to understand XAML and know how to write WPF applications. For more information, see [Tutorial: Create a new WPF app with .NET](../get-started/create-app-visual-studio.md).

## Dependency properties and CLR properties

WPF properties are typically exposed as standard .NET [properties](/dotnet/standard/base-types/common-type-system#properties). You might interact with these properties at a basic level and never know that they're implemented as a dependency property. However, familiarity with some or all of the features of the WPF property system, will help you take advantage of those features.

The purpose of dependency properties is to provide a way to compute the value of a property based on the value of other inputs, such as:

- System properties, such as themes and user preference.
- Just-in-time property determination mechanisms, such as data binding and animations/storyboards.
- Multiple-use templates, such as resources and styles.
- Values known through parent-child relationships with other elements in the element tree.

Also, a dependency property can provide:

- Self-contained validation.
- Default values.
- Callbacks that monitor changes to other properties.
- A system that can coerce property values based on runtime information.

Derived classes can change some characteristics of an existing property by overriding the metadata of a dependency property, rather than overriding the actual implementation of existing properties or creating new properties.

In the SDK reference, you can identify a dependency property by the presence of a Dependency Property Information section on the managed reference page for that property. The Dependency Property Information section includes a link to the <xref:System.Windows.DependencyProperty> identifier field for that dependency property. It also includes the list of metadata options for that property, per-class override information, and other details.

## Dependency properties back CLR properties

Dependency properties and the WPF property system extend property functionality by providing a type that backs a property, as an alternative to the standard pattern of backing a property with a private field. The name of this type is <xref:System.Windows.DependencyProperty>. The other important type that defines the WPF property system is <xref:System.Windows.DependencyObject>, which defines the base class that can register and own a dependency property.

Here's some commonly used terminology:

- **Dependency property**, which is a property that's backed by a <xref:System.Windows.DependencyProperty>.

- **Dependency property identifier**, which is a `DependencyProperty` instance obtained as a return value when registering a dependency property, and then stored as a static member of a class. Many of the APIs that interact with the WPF property system use the dependency property identifier as a parameter.

- **CLR "wrapper"**, which is the `get` and `set` implementations for the property. These implementations incorporate the dependency property identifier by using it in the <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> calls. In this way, the WPF property system provides the backing for the property.

The following example defines the `IsSpinning` dependency property to show the relationship of the `DependencyProperty` identifier to the property that it backs.

:::code language="csharp" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml.cs" id="DefineDependencyProperty":::
:::code language="vb" source="./snippets/dependency-properties-overview/vb/MainWindow.xaml.vb" id="DefineDependencyProperty":::

The naming convention of the property and its backing <xref:System.Windows.DependencyProperty> field is important. The name of the field is always the name of the property, with the suffix `Property` appended. For more information about this convention and the reasons for it, see [Custom dependency properties](custom-dependency-properties.md).

## Setting property values

You can set properties either in code or in XAML.

### Setting property values in XAML

The following XAML example sets the background color of a button to red. The string value for the XAML attribute is type-converted by the WPF XAML parser into a WPF type. In the generated code, the WPF type is a <xref:System.Windows.Media.Color>, by way of a <xref:System.Windows.Media.SolidColorBrush>.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="BasicPropertySyntax":::

XAML supports several syntax forms for setting properties. Which syntax to use for a particular property depends on the value type that a property uses, and other factors, such as the presence of a type converter. For more information on XAML syntax for setting properties, see [XAML in WPF](../xaml/index.md) and [XAML syntax In detail](/dotnet/desktop/wpf/advanced/xaml-syntax-in-detail?view=netframeworkdesktop-4.8&preserve-view=true).

The following XAML example shows another button background that uses property element syntax instead of attribute syntax. Rather than setting a simple solid color, the XAML sets the button `Background` property to an image. An element represents that image, and an attribute of the nested element specifies the source of the image.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="PropertyElementSyntax":::

### Setting properties in code

Setting dependency property values in code is typically just a call to the `set` implementation exposed by the CLR "wrapper":

:::code language="csharp" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml.cs" id="ProceduralPropertySet":::
:::code language="vb" source="./snippets/dependency-properties-overview/vb/MainWindow.xaml.vb" id="ProceduralPropertySet":::

Getting a property value is essentially a call to the `get` "wrapper" implementation:

:::code language="csharp" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml.cs" id="ProceduralPropertyGet":::
:::code language="vb" source="./snippets/dependency-properties-overview/vb/MainWindow.xaml.vb" id="ProceduralPropertyGet":::

You can also call the property system APIs <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> directly. Calling the APIs directly is appropriate for some scenarios, but usually not when you're using existing properties. Typically, wrappers are more convenient, and provide better exposure of the property for developer tools.

Properties can be also set in XAML and then accessed later in code, through code-behind. For details, see [Code-behind and XAML in WPF](/dotnet/desktop/wpf/advanced/code-behind-and-xaml-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true).

## Property functionality provided by a dependency property

Unlike a property that's backed by a field, a dependency property extends the functionality of a property. Often, the added functionality represents or supports one of these features:

- [Resources](#resources)

- [Data binding](#data-binding)

- [Styles](#styles)

- [Animations](#animations)

- [Metadata overrides](#metadata-overrides)

- [Property value inheritance](#property-value-inheritance)

- [WPF Designer integration](#wpf-designer-integration)

### Resources

You can set a dependency property value by referencing a resource. Resources are typically specified as the `Resources` property value of a page root element, or of the application, since these locations offer convenient access to the resource. In this example, we define a <xref:System.Windows.Media.SolidColorBrush> resource:

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="Resource":::

Now that the resource is defined, we can reference the resource to provide a value for the `Background` property:

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="ResourceReference":::

In WPF XAML, you can use either a static or dynamic resource reference. This particular resource is referenced as a [DynamicResource](/dotnet/desktop/wpf/advanced/dynamicresource-markup-extension?view=netframeworkdesktop-4.8&preserve-view=true). A dynamic resource reference can only be used to set a dependency property, so it's specifically the dynamic resource reference usage that's enabled by the WPF property system. For more information, see [XAML resources](../systems/xaml-resources-overview.md).

> [!NOTE]
> Resources are treated as a local value, which means that if you set another local value, you'll eliminate the resource reference. For more information, see [Dependency property value precedence](dependency-property-value-precedence.md).

### Data binding

A dependency property can reference a value through data binding. Data binding works through a specific markup extension syntax in XAML, or the <xref:System.Windows.Data.Binding> object in code. With data binding, determination of the final property value is deferred until run time, at which time the value is obtained from a data source.

The following example sets the <xref:System.Windows.Controls.ContentControl.Content%2A> property for a <xref:System.Windows.Controls.Button>, by using a binding declared in XAML. The binding uses an inherited data context and an <xref:System.Windows.Data.XmlDataProvider> data source (not shown). The binding itself specifies the source property within the data source by <xref:System.Windows.Data.Binding.XPath%2A>.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="BasicInlineBinding":::

> [!NOTE]
> Bindings are treated as a local value, which means that if you set another local value, you'll eliminate the binding. For details, see [Dependency property value precedence](dependency-property-value-precedence.md).

Dependency properties, or the <xref:System.Windows.DependencyObject> class, don't natively support <xref:System.ComponentModel.INotifyPropertyChanged> for notification of changes in `DependencyObject` source property value for data binding operations. For more about how to create properties for use in data binding that can report changes to a data binding target, see [Data binding overview](/dotnet/desktop/wpf/data/data-binding-overview?view=netframeworkdesktop-4.8&preserve-view=true).

### Styles

Styles and templates are compelling reasons to use dependency properties. Styles are particularly useful for setting properties that define the application UI. Styles are typically defined as resources in XAML. Styles interact with the property system because they typically contain "setters" for particular properties, and "triggers" that change a property value based on the runtime value for another property.

The following example creates a simple style, which would be defined inside a <xref:System.Windows.FrameworkElement.Resources%2A> dictionary (not shown). Then that style is applied directly to the <xref:System.Windows.FrameworkElement.Style%2A> property for a <xref:System.Windows.Controls.Button>. The setter within the style sets the <xref:System.Windows.Controls.Control.Background%2A> property for a styled `Button` to green.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="SimpleStyleDefinition":::

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="SimpleStyle":::

For more information, see [Styling and templating](../controls/styles-templates-overview.md).

### Animations

Dependency properties can be animated. When an applied animation runs, the animated value has higher precedence than any other property value, including a local value.

The following example animates the <xref:System.Windows.Controls.Control.Background%2A> property of a <xref:System.Windows.Controls.Button>. Technically, the property element syntax sets a blank <xref:System.Windows.Media.SolidColorBrush> as the `Background`, and the <xref:System.Windows.Media.SolidColorBrush.Color%2A> property of the `SolidColorBrush` is animated.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="Animate":::

For more about animating properties, see [Animation overview](/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8&preserve-view=true) and [Storyboards overview](/dotnet/desktop/wpf/graphics-multimedia/storyboards-overview?view=netframeworkdesktop-4.8&preserve-view=true).

### Metadata overrides

You can change specific behaviors of a dependency property by overriding its metadata when you derive from the class that originally registered the dependency property. Overriding metadata relies on the <xref:System.Windows.DependencyProperty> identifier and doesn't require reimplementing the property. The metadata change is handled natively by the property system. Each class potentially holds individual metadata for all properties inherited from base classes, on a per-type basis.

The following example overrides metadata for a <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A> dependency property. Overriding metadata for this particular dependency property is part of an implementation pattern for creating controls that can use default styles from themes.

:::code language="csharp" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml.cs" id="overridemetadata":::
:::code language="vb" source="./snippets/dependency-properties-overview/vb/MainWindow.xaml.vb" id="overridemetadata":::

For more about overriding or accessing metadata for dependency properties, see [Override metadata for a dependency property](how-to-override-metadata-for-a-dependency-property.md).

### Property value inheritance

An element can inherit the value of a dependency property from its parent in the object tree.

> [!NOTE]
> Property value inheritance behavior isn't globally enabled for all dependency properties, because the calculation time for inheritance affects performance. Property value inheritance is typically only enabled in scenarios that suggest applicability. You can check whether a dependency property inherits by looking at the **Dependency Property Information** section for that dependency property in the SDK reference.

The following example shows a binding that includes the <xref:System.Windows.FrameworkElement.DataContext%2A> property to specify the source of the binding. So, bindings in child objects don't need to specify the source and can use the inherited value from `DataContext` in the parent <xref:System.Windows.Controls.StackPanel> object. Or, a child object can directly specify its own `DataContext` or a <xref:System.Windows.Data.Binding.Source%2A> in the <xref:System.Windows.Data.Binding>, and not use the inherited value.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="InheritanceBindingContext":::

For more information, see [Property value inheritance](property-value-inheritance.md).

### WPF designer integration

Custom controls with properties implemented as dependency properties integrate well with WPF Designer for Visual Studio. One example is the ability to edit direct and attached dependency properties in the **Properties** window. For more information, see [Control authoring overview](/dotnet/desktop/wpf/controls/control-authoring-overview?view=netframeworkdesktop-4.8&preserve-view=true).

## Dependency property value precedence

Any of the property-based inputs within the WPF property system can set the value of a dependency property. [Dependency property value precedence](dependency-property-value-precedence.md) exists so that the various scenarios for how properties obtain their values interact in a predictable way.

> [!NOTE]
> The SDK documentation sometimes uses the term "local value" or "locally set value" when discussing dependency properties. A locally set value is a property value that's set directly on an object instance in code, or as an element attribute in XAML.

The next example includes a style that applies to the <xref:System.Windows.Controls.Control.Background%2A> property of any button, but specifies one button with a locally set `Background` property. Technically, that button has its `Background` property set twice, although only one value applies&mdash;the value with the highest precedence. A locally set value has the highest precedence, except for a running animation, which doesn't exist here. So, the second button uses the locally set value for the `Background` property, instead of the style setter value. The first button has no local value, or other value with higher precedence than a style setter, and so uses the style setter value for the `Background` property.

:::code language="xaml" source="./snippets/dependency-properties-overview/csharp/MainWindow.xaml" id="PropertyValuePrecedence":::

### Why does dependency property precedence exist?

Locally set values have precedence over style setter values, which supports local control of element properties. For details, see [Dependency property value precedence](dependency-property-value-precedence.md).

> [!NOTE]
> A number of properties defined on WPF elements aren't dependency properties, because dependency properties were typically implemented only when a feature of the WPF property system was required. The features include data binding, styling, animation, default value support, inheritance, attached properties, and invalidation.

## Learning more about dependency properties

- Component developers or application developers might wish to create their own dependency property to add capabilities, such as data binding or styles support, or invalidation and value coercion support. For more information, see [Custom dependency properties](custom-dependency-properties.md).

- Consider dependency properties to be public properties, accessible or discoverable by any caller with access to an instance. For more information, see [Dependency property security](dependency-property-security.md).

- An attached property is a type of property that supports a specialized syntax in XAML. An attached property often doesn't have a 1:1 correspondence with a common language runtime property and isn't necessarily a dependency property. The main purpose of an attached property is to allow child elements to report property values to a parent element, even if the parent element and child element don't include that property as part of the class members listings. One primary scenario is to enable a child element to inform parent elements how to present them in the UI. For examples, see <xref:System.Windows.Controls.DockPanel.Dock%2A> and <xref:System.Windows.Controls.Canvas.Left%2A>. For more information, see [Attached properties overview](attached-properties-overview.md).

## See also

- [Custom dependency properties](custom-dependency-properties.md)
- [Read-only dependency properties](read-only-dependency-properties.md)
- [XAML in WPF](../xaml/index.md)
- [WPF architecture](/dotnet/desktop/wpf/advanced/wpf-architecture?view=netframeworkdesktop-4.8&preserve-view=true)
