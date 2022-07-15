---
title: "Framework property metadata"
description: Learn how to set framework property metadata for a dependency property in Windows Presentation Foundation (WPF).
ms.date: "11/20/2021"
helpviewer_keywords:
  - "metadata [WPF], framework properties"
  - "framework property metadata [WPF]"
---
<!-- The acrolinx score was 92 on 11/20/2021-->

# Framework property metadata (WPF .NET)

You can set framework property metadata options for dependency properties at the Windows Presentation Foundation (WPF) framework level. The WPF framework level designation applies when WPF presentation APIs and executables handle rendering and data binding. Presentation APIs and executables query the <xref:System.Windows.FrameworkPropertyMetadata> of a dependency property.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Framework property metadata categories

<xref:System.Windows.FrameworkPropertyMetadata> falls into these categories:

- Metadata that affects the layout of an element, specifically the <xref:System.Windows.FrameworkPropertyMetadata.AffectsArrange%2A>, <xref:System.Windows.FrameworkPropertyMetadata.AffectsMeasure%2A>, and <xref:System.Windows.FrameworkPropertyMetadata.AffectsRender%2A> metadata flags. You might set those flags if your dependency property implementation affects a visual aspect and you're implementing <xref:System.Windows.FrameworkElement.MeasureOverride%2A> or <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> in your class. The `MeasureOverride` and `ArrangeOverride` methods provide implementation-specific behavior and rendering information to the layout system. When `AffectsArrange`, `AffectsMeasure`, or `AffectsRender` are set to `true` in the metadata of a dependency property and its effective value changes, the WPF property system will initiate a request to invalidate the element's visuals to trigger a redraw.

- Metadata that affects the layout of the parent element of an element, specifically the <xref:System.Windows.FrameworkPropertyMetadata.AffectsParentArrange%2A> and <xref:System.Windows.FrameworkPropertyMetadata.AffectsParentMeasure%2A> metadata flags. Examples of WPF dependency properties that set these flags are <xref:System.Windows.Documents.FixedPage.Left%2A?displayProperty=nameWithType> and <xref:System.Windows.Documents.Paragraph.KeepWithNext%2A?displayProperty=nameWithType>.

- Property value inheritance metadata, specifically the <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A> and <xref:System.Windows.FrameworkPropertyMetadata.OverridesInheritanceBehavior%2A> metadata flags. By default, dependency properties don't inherit values. <xref:System.Windows.FrameworkPropertyMetadata.OverridesInheritanceBehavior%2A> allows the pathway of inheritance to also travel into a visual tree, which is necessary for some control compositing scenarios. For more information, see [Property value inheritance](property-value-inheritance.md).

  > [!NOTE]
  > The term "inherits" in the context of property values is specific to dependency properties, and doesn't directly relate to managed code types and member inheritance through derived types. In the context of dependency properties, it means that child elements can inherit dependency property values from parent elements.

- Data binding metadata, specifically the <xref:System.Windows.FrameworkPropertyMetadata.BindsTwoWayByDefault%2A> and <xref:System.Windows.FrameworkPropertyMetadata.IsNotDataBindable%2A> metadata flags. By default, dependency properties in the WPF framework support one-way binding. Consider setting two-way binding as the default for properties that report state *and* are modifiable by user action, for example <xref:System.Windows.Controls.Primitives.Selector.IsSelected>. Also, consider setting two-way binding as the default when users of a control expect a property to implement it, for example [TextBox.Text](<xref:System.Windows.Controls.TextBox.Text>). `BindsTwoWayByDefault` only affects the default binding mode. To edit the data flow direction of a binding, set [Binding.Mode](<xref:System.Windows.Data.Binding.Mode>). You can use `IsNotDataBindable` to disable data binding when there's no use case for it. For more information on data bindings, see [Data binding overview](/dotnet/desktop/wpf/data).

- Journaling metadata, specifically the <xref:System.Windows.FrameworkPropertyMetadata.Journal%2A> metadata flag. The default value of the `Journal` flag is only `true` for a some dependency properties, such as <xref:System.Windows.Controls.Primitives.Selector.SelectedIndex>. User input controls should set the `Journal` flag for properties whose values hold user selections that need to be stored. The `Journal` flag is read by applications or services that support journaling, including WPF journaling services. For information on storing navigation steps, see [Navigation overview](/dotnet/desktop/wpf/app-development/navigation-overview?view=netframeworkdesktop-4.8&preserve-view=true).

<xref:System.Windows.FrameworkPropertyMetadata> derives directly from <xref:System.Windows.UIPropertyMetadata>, and implements the flags discussed here. Unless specifically set, `FrameworkPropertyMetadata` flags have a default value of `false`.

## Reading FrameworkPropertyMetadata

To retrieve metadata for a dependency property, call <xref:System.Windows.DependencyProperty.GetMetadata%2A> on the <xref:System.Windows.DependencyProperty> identifier. The `GetMetadata` call returns a `PropertyMetadata` object. If you need to query framework metadata values cast `PropertyMetadata` to <xref:System.Windows.FrameworkPropertyMetadata>.

## Specifying FrameworkPropertyMetadata

When you register a dependency property, you have the option to create and assign metadata to it. The metadata object that you assign can be <xref:System.Windows.PropertyMetadata> or one of its derived classes, like <xref:System.Windows.FrameworkPropertyMetadata>. Choose `FrameworkPropertyMetadata` for dependency properties that rely on WPF presentation APIs and executables for rendering and data binding. A more advanced option is to derive from `FrameworkPropertyMetadata` to create a custom metadata reporting class with more flags. Or, you might use <xref:System.Windows.UIPropertyMetadata> for non-framework properties that affect UI rendering.

Although metadata options are typically set during registration of a new dependency property, you can respecify them in <xref:System.Windows.DependencyProperty.OverrideMetadata%2A> or <xref:System.Windows.DependencyProperty.AddOwner%2A> calls. When overriding metadata, always override with the same metadata type that was used during property registration.

The property characteristics that are exposed by `FrameworkPropertyMetadata` are sometimes referred to as *flags*. If you're creating a `FrameworkPropertyMetadata` instance, there are two ways to populate flag values:

1. Set the flags on an instance of the <xref:System.Windows.FrameworkPropertyMetadataOptions> enumeration type. `FrameworkPropertyMetadataOptions` lets you specify metadata flags in bitwise OR combination. Then, instantiate `FrameworkPropertyMetadata` using a constructor that has a `FrameworkPropertyMetadataOptions` parameter, and pass in your `FrameworkPropertyMetadataOptions` instance. To change metadata flags after passing `FrameworkPropertyMetadataOptions` into the <xref:System.Windows.FrameworkPropertyMetadata> constructor, change the corresponding property on the new `FrameworkPropertyMetadata` instance. For example, if you set the <xref:System.Windows.FrameworkPropertyMetadataOptions.NotDataBindable?displayProperty=nameWithType> flag, you can undo that by setting <xref:System.Windows.FrameworkPropertyMetadata.IsNotDataBindable%2A?displayProperty=nameWithType> to `false`.

1. Instantiate `FrameworkPropertyMetadata` using a constructor that doesn't have a `FrameworkPropertyMetadataOptions` parameter, and then set the applicable <xref:System.Boolean> flags on `FrameworkPropertyMetadata`. Set flag values before associating your `FrameworkPropertyMetadata` instance with a dependency property, otherwise you'll get an <xref:System.InvalidOperationException>.

## Metadata override behavior

When you override framework property metadata, changed metadata values either replace or are merged with the original values:

- For a <xref:System.Windows.PropertyMetadata.PropertyChangedCallback%2A>, the default merge logic retains previous `PropertyChangedCallback` values in a table, and all are invoked on a property change. The callback order is determined by class depth, where a callback registered by the base class in the hierarchy would run first. Inherited callbacks run only once, and are owned by the class that added them into metadata.

- For a <xref:System.Windows.PropertyMetadata.DefaultValue%2A>, the new value will replace the existing default value. If you don't specify a `DefaultValue` in the override metadata and if the existing <xref:System.Windows.FrameworkPropertyMetadata> has the `Inherits` flag set, then the default value comes from the nearest ancestor that specified `DefaultValue` in metadata.

- For a <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A>, the new value will replace an existing `CoerceValueCallback` value. If you don't specify a `CoerceValueCallback` in the override metadata, the value comes from the nearest ancestor in the inheritance chain that specified a `CoerceValueCallback`.

- For `FrameworkPropertyMetadata` non-inherited flags, you can override the default `false` value with a `true` value. However, you can only override a `true` value with a `false` value for <xref:System.Windows.FrameworkPropertyMetadata.Inherits%2A>, <xref:System.Windows.FrameworkPropertyMetadata.Journal%2A>, <xref:System.Windows.FrameworkPropertyMetadata.OverridesInheritanceBehavior%2A>, and <xref:System.Windows.FrameworkPropertyMetadata.SubPropertiesDoNotAffectRender%2A>.

> [!NOTE]
> The default merge logic is implemented by the <xref:System.Windows.PropertyMetadata.Merge%2A> method. You can specify custom merge logic in a derived class that inherits a dependency property, by overriding `Merge` in that class.

## See also

- <xref:System.Windows.PropertyMetadata>
- <xref:System.Windows.DependencyProperty.GetMetadata%2A>
- <xref:System.Windows.DependencyProperty.OverrideMetadata%2A>
- <xref:System.Windows.DependencyProperty.AddOwner%2A>
- [Dependency Property Metadata](dependency-property-metadata.md)
- [Dependency Properties Overview](dependency-properties-overview.md)
- [Custom Dependency Properties](custom-dependency-properties.md)
