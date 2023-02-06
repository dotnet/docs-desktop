---
title: "Dependency properties overview"
description: A property that is backed by the WPF property system is known as a dependency property. This overview describes the WPF property system and the capabilities of a dependency property.
ms.date: "06/06/2018"
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
ms.assetid: d119d00c-3afb-48d6-87a0-c4da4f83dee5
---
# Dependency properties overview

Windows Presentation Foundation (WPF) provides a set of services that can be used to extend the functionality of a type's [property](/dotnet/standard/base-types/common-type-system#properties). Collectively, these services are typically referred to as the WPF property system. A property that is backed by the WPF property system is known as a dependency property. This overview describes the WPF property system and the capabilities of a dependency property. This includes how to use existing dependency properties in XAML and in code. This overview also introduces specialized aspects of dependency properties, such as dependency property metadata, and how to create your own dependency property in a custom class.

## Prerequisites

This topic assumes that you have some basic knowledge of the .NET type system and object-oriented programming. In order to follow the examples in this topic, you should also understand XAML and know how to write WPF applications. For more information, see [Walkthrough: My first WPF desktop application](../getting-started/walkthrough-my-first-wpf-desktop-application.md).  
  
## Dependency properties and CLR properties

 In WPF, properties are typically exposed as standard .NET [properties](/dotnet/standard/base-types/common-type-system#properties). At a basic level, you could interact with these properties directly and never know that they are implemented as a dependency property. However, you should become familiar with some or all of the features of the WPF property system, so that you can take advantage of these features.

The purpose of dependency properties is to provide a way to compute the value of a property based on the value of other inputs. These other inputs might include system properties such as themes and user preference, just-in-time property determination mechanisms such as data binding and animations/storyboards, multiple-use templates such as resources and styles, or values known through parent-child relationships with other elements in the element tree. In addition, a dependency property can be implemented to provide self-contained validation, default values, callbacks that monitor changes to other properties, and a system that can coerce property values based on potentially runtime information. Derived classes can also change some specific characteristics of an existing property by overriding dependency property metadata, rather than overriding the actual implementation of existing properties or creating new properties.

In the SDK reference, you can identify which property is a dependency property by the presence of the Dependency Property Information section on the managed reference page for that property. The Dependency Property Information section includes a link to the <xref:System.Windows.DependencyProperty> identifier field for that dependency property, and also includes a list of the metadata options that are set for that property, per-class override information, and other details.

## Dependency properties back CLR properties

Dependency properties and the WPF property system extend property functionality by providing a type that backs a property, as an alternative implementation to the standard pattern of backing the property with a private field. The name of this type is <xref:System.Windows.DependencyProperty>. The other important type that defines the WPF property system is <xref:System.Windows.DependencyObject>. <xref:System.Windows.DependencyObject> defines the base class that can register and own a dependency property.

The following lists the terminology that is used with dependency properties:

- **Dependency property:** A property that is backed by a <xref:System.Windows.DependencyProperty>.

- **Dependency property identifier:** A <xref:System.Windows.DependencyProperty> instance, which is obtained as a return value when registering a dependency property, and then stored as a static member of a class. This identifier is used as a parameter for many of the APIs that interact with the WPF property system.

- **CLR "wrapper":** The actual get and set implementations for the property. These implementations incorporate the dependency property identifier by using it in the <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> calls, thus providing the backing for the property using the WPF property system.

The following example defines the `IsSpinning` dependency property, and shows the relationship of the <xref:System.Windows.DependencyProperty> identifier to the property that it backs.

[!code-csharp[PropertiesOvwSupport#DPFormBasic](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page4.xaml.cs#dpformbasic)]
[!code-vb[PropertiesOvwSupport#DPFormBasic](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page4.xaml.vb#dpformbasic)]  
  
The naming convention of the property and its backing <xref:System.Windows.DependencyProperty> field is important. The name of the field is always the name of the property, with the suffix `Property` appended. For more information about this convention and the reasons for it, see [Custom Dependency Properties](custom-dependency-properties.md).  

## Setting property values

You can set properties either in code or in XAML.

### Setting property values in XAML

The following XAML example specifies the background color of a button as red. This example illustrates a case where the simple string value for a XAML attribute is type-converted by the WPF XAML parser into a WPF type (a <xref:System.Windows.Media.Color>, by way of a <xref:System.Windows.Media.SolidColorBrush>) in the generated code.

[!code-xaml[PropertiesOvwSupport#MostBasicProperty](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/Page1.xaml#mostbasicproperty)]

XAML supports a variety of syntax forms for setting properties. Which syntax to use for a particular property will depend on the value type that a property uses, as well as other factors such as the presence of a type converter. For more information on XAML syntax for property setting, see [XAML in WPF](xaml-in-wpf.md) and [XAML Syntax In Detail](xaml-syntax-in-detail.md).

As an example of non-attribute syntax, the following XAML example shows another button background. This time rather than setting a simple solid color, the background is set to an image, with an element representing that image and the source of that image specified as an attribute of the nested element. This is an example of property element syntax.

[!code-xaml[PropertiesOvwSupport#PESyntaxProperty](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/Page1.xaml#pesyntaxproperty)]

### Setting properties in code

 Setting dependency property values in code is typically just a call to the set implementation exposed by the CLR "wrapper".

[!code-csharp[PropertiesOvwSupport#ProceduralPropertySet](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/Page1.xaml.cs#proceduralpropertyset)]
[!code-vb[PropertiesOvwSupport#ProceduralPropertySet](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page1.xaml.vb#proceduralpropertyset)]

Getting a property value is also essentially a call to the get "wrapper" implementation:

[!code-csharp[PropertiesOvwSupport#ProceduralPropertyGet](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/Page1.xaml.cs#proceduralpropertyget)]
 [!code-vb[PropertiesOvwSupport#ProceduralPropertyGet](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page1.xaml.vb#proceduralpropertyget)]

You can also call the property system APIs <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> directly. This is not typically necessary if you are using existing properties (the wrappers are more convenient, and provide better exposure of the property for developer tools), but calling the APIs directly is appropriate for certain scenarios.

Properties can be also set in XAML and then accessed later in code, through code-behind. For details, see [Code-Behind and XAML in WPF](code-behind-and-xaml-in-wpf.md).

## Property functionality provided by a dependency property

A dependency property provides functionality that extends the functionality of a property as opposed to a property that is backed by a field. Often, such functionality represents or supports one of the following specific features:

- [Resources](#resources)

- [Data binding](#data-binding)

- [Styles](#styles)

- [Animations](#animations)

- [Metadata overrides](#metadata-overrides)

- [Property value inheritance](#property-value-inheritance)

- [WPF Designer integration](#wpf-designer-integration)

### Resources

A dependency property value can be set by referencing a resource. Resources are typically specified as the `Resources` property value of a page root element, or of the application (these locations enable the most convenient access to the resource). The following example shows how to define a <xref:System.Windows.Media.SolidColorBrush> resource.

[!code-xaml[PropertiesOvwSupport#ResourcesResource](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page2.xaml#resourcesresource)]

Once the resource is defined, you can reference the resource and use it to provide a property value:

[!code-xaml[PropertiesOvwSupport#ResourcesReference](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page2.xaml#resourcesreference)]

This particular resource is referenced as a [DynamicResource Markup Extension](dynamicresource-markup-extension.md) (in WPF XAML, you can use either a static or dynamic resource reference). To use a dynamic resource reference, you must be setting to a dependency property, so it is specifically the dynamic resource reference usage that is enabled by the WPF property system. For more information, see [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define).

> [!NOTE]
> Resources are treated as a local value, which means that if you set another local value, you will eliminate the resource reference. For more information, see [Dependency Property Value Precedence](dependency-property-value-precedence.md).

### Data binding

A dependency property can reference a value through data binding. Data binding works through a specific markup extension syntax in XAML, or the <xref:System.Windows.Data.Binding> object in code. With data binding, the final property value determination is deferred until run time, at which time the value is obtained from a data source.

The following example sets the <xref:System.Windows.Controls.ContentControl.Content%2A> property for a <xref:System.Windows.Controls.Button>, using a binding declared in XAML. The binding uses an inherited data context and an <xref:System.Windows.Data.XmlDataProvider> data source (not shown). The binding itself specifies the desired source property by <xref:System.Windows.Data.Binding.XPath%2A> within the data source.

[!code-xaml[PropertiesOvwSupport#BasicInlineBinding](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml#basicinlinebinding)]

> [!NOTE]
> Bindings are treated as a local value, which means that if you set another local value, you will eliminate the binding. For details, see [Dependency Property Value Precedence](dependency-property-value-precedence.md).

Dependency properties, or the <xref:System.Windows.DependencyObject> class, do not natively support <xref:System.ComponentModel.INotifyPropertyChanged> for purposes of producing notifications of changes in <xref:System.Windows.DependencyObject> source property value for data binding operations. For more information on how to create properties for use in data binding that can report changes to a data binding target, see [Data Binding Overview](../data/data-binding-overview.md).

### Styles

Styles and templates are two of the chief motivating scenarios for using dependency properties. Styles are particularly useful for setting properties that define application user interface (UI). Styles are typically defined as resources in XAML. Styles interact with the property system because they typically contain "setters" for particular properties, as well as "triggers" that change a property value based on the real-time value for another property.

The following example creates a simple style (which would be defined inside a <xref:System.Windows.FrameworkElement.Resources%2A> dictionary, not shown), then applies that style directly to the <xref:System.Windows.FrameworkElement.Style%2A> property for a <xref:System.Windows.Controls.Button>. The setter within the style sets the <xref:System.Windows.Controls.Control.Background%2A> property for a styled <xref:System.Windows.Controls.Button> to green.

[!code-xaml[PropertiesOvwSupport#SimpleStyleDef](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml#simplestyledef)]

[!code-xaml[PropertiesOvwSupport#SimpleStyle](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml#simplestyle)]

For more information, see [Styling and Templating](../controls/styles-templates-overview.md).

### Animations

Dependency properties can be animated. When an animation is applied and is running, the animated value operates at a higher precedence than any value (such as a local value) that the property otherwise has.

The following example animates the <xref:System.Windows.Controls.Control.Background%2A> on a <xref:System.Windows.Controls.Button> property (technically, the <xref:System.Windows.Controls.Control.Background%2A> is animated by using property element syntax to specify a blank <xref:System.Windows.Media.SolidColorBrush> as the <xref:System.Windows.Controls.Control.Background%2A>, then the <xref:System.Windows.Media.SolidColorBrush.Color%2A> property of that <xref:System.Windows.Media.SolidColorBrush> is the property that is directly animated).

[!code-xaml[PropertiesOvwSupport#MiniAnimate](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml#minianimate)]

For more information on animating properties, see [Animation Overview](../graphics-multimedia/animation-overview.md) and [Storyboards Overview](../graphics-multimedia/storyboards-overview.md).

### Metadata overrides

You can change certain behaviors of a dependency property by overriding the metadata for that property when you derive from the class that originally registers the dependency property. Overriding metadata relies on the <xref:System.Windows.DependencyProperty> identifier. Overriding metadata does not require reimplementing the property. The metadata change is handled natively by the property system; each class potentially holds individual metadata for all properties that are inherited from base classes, on a per-type basis.

The following example overrides metadata for a dependency property <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A>. Overriding this particular dependency property metadata is part of an implementation pattern that creates controls that can use default styles from themes.

[!code-csharp[PropertiesOvwSupport#OverrideMetadata](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml.cs#overridemetadata)]
[!code-vb[PropertiesOvwSupport#OverrideMetadata](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page3.xaml.vb#overridemetadata)]

For more information about overriding or obtaining property metadata, see [Dependency Property Metadata](dependency-property-metadata.md).

### Property value inheritance

An element can inherit the value of a dependency property from its parent in the object tree.

> [!NOTE]
> Property value inheritance behavior is not globally enabled for all dependency properties, because the calculation time for inheritance does have some performance impact. Property value inheritance is typically only enabled for properties where a particular scenario suggests that property value inheritance is appropriate. You can determine whether a dependency property inherits by looking at the **Dependency Property Information** section for that dependency property in the SDK reference.

The following example shows a binding, and sets the <xref:System.Windows.FrameworkElement.DataContext%2A> property that specifies the source of the binding, which was not shown in the earlier binding example. Any subsequent bindings in child objects do not need to specify the source, they can use the inherited value from <xref:System.Windows.FrameworkElement.DataContext%2A> in the parent <xref:System.Windows.Controls.StackPanel> object. (Alternatively, a child object could instead choose to directly specify its own <xref:System.Windows.FrameworkElement.DataContext%2A> or a <xref:System.Windows.Data.Binding.Source%2A> in the <xref:System.Windows.Data.Binding>, and to deliberately not use the inherited value for data context of its bindings.)

[!code-xaml[PropertiesOvwSupport#InheritanceContext](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml#inheritancecontext)]

For more information, see [Property Value Inheritance](property-value-inheritance.md).

### WPF designer integration

A custom control with properties that are implemented as dependency properties will receive appropriate WPF Designer for Visual Studio support. One example is the ability to edit direct and attached dependency properties with the **Properties** window. For more information, see [Control Authoring Overview](../controls/control-authoring-overview.md).

## Dependency property value precedence

When you get the value of a dependency property, you are potentially obtaining a value that was set on that property through any one of the other property-based inputs that participate in the WPF property system. Dependency property value precedence exists so that a variety of scenarios for how properties obtain their values can interact in a predictable way.

Consider the following example. The example includes a style that applies to all buttons and their <xref:System.Windows.Controls.Control.Background%2A> properties, but then also specifies one button with a locally set <xref:System.Windows.Controls.Control.Background%2A> value.

> [!NOTE]
> The SDK documentation uses the terms "local value" or "locally set value" occasionally when discussing dependency properties. A locally set value is a property value that is set directly on an object instance in code, or as an attribute on an element in XAML.  
  
In principle, for the first button, the property is set twice, but only one value applies: the value with the highest precedence. A locally set value has the highest precedence (except for a running animation, but no animation applies in this example) and thus the locally set value is used instead of the style setter value for the background on the first button. The second button has no local value (and no other value with higher precedence than a style setter) and thus the background in that button comes from the style setter.

[!code-xaml[PropertiesOvwSupport#MiniPrecedence](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml#miniprecedence)]  

### Why does dependency property precedence exist?

Typically, you would not want styles to always apply and to obscure even a locally set value of an individual element (otherwise, it would be difficult to use either styles or elements in general). Therefore, the values that come from styles operate at a lower precedent than a locally set value. For a more thorough listing of dependency properties and where a dependency property effective value might come from, see [Dependency Property Value Precedence](dependency-property-value-precedence.md).

> [!NOTE]
> There are a number of properties defined on WPF elements that are not dependency properties. By and large, properties were implemented as dependency properties only when there were needs to support at least one of the scenarios enabled by the property system: data binding, styling, animation, default value support, inheritance, attached properties, or invalidation.

## Learning more about dependency properties  

- An attached property is a type of property that supports a specialized syntax in XAML. An attached property often does not have a 1:1 correspondence with a common language runtime (CLR) property, and is not necessarily a dependency property. The typical purpose of an attached property is to allow child elements to report property values to a parent element, even if the parent element and child element do not both possess that property as part of the class members listings. One primary scenario is to enable child elements to inform the parent how they should be presented in UI; for an example, see <xref:System.Windows.Controls.DockPanel.Dock%2A> or <xref:System.Windows.Controls.Canvas.Left%2A>. For details, see [Attached Properties Overview](attached-properties-overview.md).

- Component developers or application developers may wish to create their own dependency property, in order to enable capabilities such as data binding or styles support, or for invalidation and value coercion support. For details, see [Custom Dependency Properties](custom-dependency-properties.md).

- Consider dependency properties to be public properties, accessible or at least discoverable by any caller that has access to an instance. For more information, see [Dependency Property Security](dependency-property-security.md).

## See also

- [Custom Dependency Properties](custom-dependency-properties.md)
- [Read-Only Dependency Properties](read-only-dependency-properties.md)
- [XAML in WPF](xaml-in-wpf.md)
- [WPF Architecture](wpf-architecture.md)
