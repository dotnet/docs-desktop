---
title: "Dependency property value precedence"
description: Learn how the precedence of different property-based inputs within the WPF property system determines the effective value of a dependency property.
ms.date: "09/30/2021"
helpviewer_keywords: 
  - "dependency properties [WPF], classes as owners"
  - "dependency properties [WPF], metadata"
  - "classes [WPF], owners of dependency properties"
  - "metadata [WPF], dependency properties"
---
<!-- The acrolinx score was 92 on 10/01/2021-->

# Dependency property value precedence (WPF .NET)

The workings of the Windows Presentation Foundation (WPF) property system affect the value of a dependency property. This article explains how the precedence of different property-based inputs within the WPF property system determines the effective value of a dependency property.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## The WPF property system

The WPF property system uses a variety of factors to determine the value of dependency properties, such as real-time property validation, late binding, and property change notifications for related properties. Although the order and logic used to determine dependency property values is complex, learning it can help you avoid unnecessary property settings, and also to figure out why an attempt to set a dependency property didn't result in the expected value.

### Dependency properties set in multiple places

The following XAML example shows how three different "set" operations on the button's <xref:System.Windows.Controls.Control.Background%2A> property can influence its value.

:::code language="xaml" source="./snippets/dependency-property-value-precedence/csharp/MainWindow.xaml" id="DependencyPropertyValuePrecedence":::

In the example, the `Background` property is locally set to `Red`. However, the implicit style declared in the button's scope, attempts to set the `Background` property to `Blue`. And, when the mouse is over the button, the trigger in the implicit style attempts to set the `Background` property to `Yellow`. Except for coercion and animation, a locally set property value has the highest precedence, so the button will be red&mdash;even on mouseover. But, if you remove the locally set value from the button, then it will get its `Background` value from the style. Within a style, triggers take precedence, so the button will be yellow on mouseover, and blue otherwise. The example replaces the button's default <xref:System.Windows.Controls.ControlTemplate> because the default template has a hard-coded mouseover `Background` value.

## Dependency property precedence list

The following list is the definitive order of precedence that the property system uses when assigning runtime values to dependency properties. Highest precedence is listed first.

1. **Property system coercion**. For more information about coercion, see [Coercion and animations](#coercion-and-animation).

2. **Active animations, or animations with a Hold behavior**. To have a practical effect, an animation value must have precedence over the base (unanimated) value, even if the base value was set locally. For more information, see [Coercion and animations](#coercion-and-animation).

3. **Local values**. You can set a local value through a "wrapper" property, which equates to setting an attribute or property element in XAML, or by a call to the <xref:System.Windows.DependencyObject.SetValue%2A> API using a property of a specific instance. A local value set through a binding or resource will have the same precedence as a value that's directly set.

4. **TemplatedParent template property values**. An element has a <xref:System.Windows.FrameworkElement.TemplatedParent%2A> if it was created by a template (<xref:System.Windows.Controls.ControlTemplate> or <xref:System.Windows.DataTemplate>). For more information, see [TemplatedParent](#templatedparent). Within the template specified by the `TemplatedParent`, the order of precedence is:

    1. Triggers.

    1. Property sets, typically through XAML attributes.

5. **Implicit styles**. Applies only to the <xref:System.Windows.FrameworkElement.Style%2A> property. The `Style` value is any style resource with a <xref:System.Windows.Style.TargetType%2A> value that matches the element type. The style resource must exist within the page or application. Lookup for an implicit style resource doesn't extend to styles resources in Themes.

6. **Style triggers**. A style trigger is a trigger within an explicit or implicit style. The style must exist within the page or application. Triggers in default styles have a lower precedence.

7. **Template triggers**. A template trigger is a trigger from a directly applied template, or from a template within a style. The style must exist within the page or application.

8. **Style setter values**. A style setter value is a value applied by a <xref:System.Windows.Setter> within a style. The style must exist within the page or application.

9. **Default styles**, also known as **theme styles**. For more information, see [Default (Theme) styles](#default-theme-styles). Within a default style, the order of precedence is:

    1. Active triggers.
  
    1. Setters.

10. **Inheritance**. Some dependency properties of a child element inherit their value from the parent element. So, it might not be necessary to set property values on every element throughout the application. For more information, see [Property value inheritance](property-value-inheritance.md).

11. **Default value from dependency property metadata** A dependency property can have a default value set during property system registration of that property. Derived classes that inherit a dependency property can override dependency property metadata (including the default value) on a per-type basis. For more information, see [Dependency property metadata](dependency-property-metadata.md). For an inherited property, the default value of a parent element takes precedence over the default value of a child element. So, if an inheritable property isn't set, the default value of the root or parent is used instead of the default value of the child element.

## TemplatedParent

<xref:System.Windows.FrameworkElement.TemplatedParent%2A> precedence doesn't apply to properties of elements that are declared directly in standard application markup. The `TemplatedParent` concept exists only for child items within a visual tree that come into existence through the application of a template. When the property system searches the template specified by the `TemplatedParent` for the property values of an element, it's searching the template that created the element. The property values from the `TemplatedParent` template generally act as if they were locally set values on the element, but with lesser precedence than actual local values because templates are potentially shared. For more information, see <xref:System.Windows.FrameworkElement.TemplatedParent%2A>.

## The Style property

The same order of precedence applies to all dependency properties, except the <xref:System.Windows.FrameworkElement.Style%2A> property. The `Style` property is unique in that it cannot itself be styled. Coercing or animating the `Style` property isn't recommended (and animating the `Style` property would require a custom animation class). As a result, not all precedence items apply. There are only three ways to set the `Style` property:

- **Explicit style.** The `Style` property of an element is set directly. The `Style` property value acts as if it were a local value and has the same precedence as item 3 in the [precedence list](#dependency-property-precedence-list). In most scenarios, explicit styles aren't defined inline and instead are explicitly referenced as a resource, for example `Style="{StaticResource myResourceKey}"`.

- **Implicit style.** The `Style` property of an element isn't set directly. Instead, a style gets applied when it exists at some level within the page or application, and has a resource key that matches the type of element that the style applies to, for example `<Style TargetType="x:Type Button">`. The type must match exactly, for example `<Style TargetType="x:Type Button">` won't get applied to `MyButton` type even if `MyButton` is derived from `Button`. The `Style` property value has the same precedence as item 5 in the [precedence list](#dependency-property-precedence-list). An implicit style value can be detected by calling the <xref:System.Windows.DependencyPropertyHelper.GetValueSource%2A?displayProperty=nameWithType> method, passing in the `Style` property, and checking for `ImplicitStyleReference` in the results.

- **Default style**, also known as **theme style**. The `Style` property of an element isn't set directly. Instead, it comes from runtime theme evaluation by the WPF presentation engine. Before runtime, the `Style` property value is `null`. The `Style` property value has the same precedence as item 9 in the [precedence list](#dependency-property-precedence-list).

## Default (Theme) styles

Every control that ships with WPF has a default style that can vary by theme, which is why the default style is sometimes referred to as a *theme style*.

The <xref:System.Windows.Controls.ControlTemplate> is an important item within the default style for a control. `ControlTemplate` is a setter value for the style's <xref:System.Windows.Controls.Control.Template%2A> property. If default styles didn't contain a template, a control without a custom template as part of a custom style would have no visual appearance. Not only does a template define the visual appearance of a control, it also defines the connections between properties in the visual tree of the template and the corresponding control class. Each control exposes a set of properties that can influence the visual appearance of the control without replacing the template. For example, consider the default visual appearance of a <xref:System.Windows.Controls.Primitives.Thumb> control, which is a <xref:System.Windows.Controls.Primitives.ScrollBar> component.

A <xref:System.Windows.Controls.Primitives.Thumb> control has certain customizable properties. The default template of a `Thumb` control creates a basic structure, or visual tree, with several nested <xref:System.Windows.Controls.Border> components to create a beveled look. Within the template, properties that are intended to be customizable by the `Thumb` class are exposed through [TemplateBinding](/dotnet/desktop/wpf/advanced/templatebinding-markup-extension?view=netframeworkdesktop-4.8&preserve-view=true). The default template for the `Thumb` control has various border properties that share a template binding with properties such as <xref:System.Windows.Controls.Border.Background%2A> or <xref:System.Windows.Controls.Border.BorderThickness%2A>. But, where values for properties or visual arrangements are hard-coded in the template, or are bound to values that come directly from the theme, you can only change those values by replacing the entire template. Generally, if a property comes from a templated parent and isn't exposed by a `TemplateBinding`, then the property value cannot be changed by styles because there's no convenient way to target it. But, that property might still be influenced by property value inheritance in the applied template, or by a default value.

Default styles specify a <xref:System.Windows.Style.TargetType%2A> in their definitions. Runtime theme evaluation matches the `TargetType` of a default style to the <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A> property of a control. In contrast, the lookup behavior for implicit styles uses the actual type of the control. The value of `DefaultStyleKey` is inherited by derived classes, so derived elements that might otherwise have no associated style get a default visual appearance. For example, if you derive `MyButton` from <xref:System.Windows.Controls.Button>, `MyButton` will inherit the default template of `Button`. Derived classes can override the default value of `DefaultStyleKey` in dependency property metadata. So, if you want a different visual representation for `MyButton`, you can override the dependency property metadata for `DefaultStyleKey` on `MyButton`, and then define the relevant default style including a template, that you'll package with your `MyButton` control. For more information, see [Control authoring overview](/dotnet/desktop/wpf/controls/control-authoring-overview?view=netframeworkdesktop-4.8&preserve-view=true).

## Dynamic resource

[Dynamic resource](/dotnet/desktop/wpf/advanced/dynamicresource-markup-extension?view=netframeworkdesktop-4.8&preserve-view=true) references and binding operations have the precedence of the location at which they're set. For example, a dynamic resource applied to a local value has the same precedence as item 3 in the [precedence list](#dependency-property-precedence-list). As another example, a dynamic resource binding applied to a property setter within a default style has the same precedence as item 9 in the [precedence list](#dependency-property-precedence-list). Because dynamic resource references and binding must get values from the runtime state of the application, the process for determining property value precedence for any given property extends into runtime.

Dynamic resource references aren't technically part of the property system, and have their own lookup order that interacts with the [precedence list](#dependency-property-precedence-list). Essentially, the precedence of dynamic resource references is: element to page root, application, theme, and then system. For more information, see [XAML Resources](../systems/xaml-resources-overview.md).

Although dynamic resource references and bindings have the precedence of the location at which they're set, the value is deferred. One consequence of this is that if you set a dynamic resource or binding to a local value, any change to the local value entirely replaces the dynamic resource or binding. Even if you call the <xref:System.Windows.DependencyObject.ClearValue%2A> method to clear the locally set value, the dynamic resource or binding won't be restored. In fact, if you call `ClearValue` on a property that has a dynamic resource or binding (with no literal local value), the dynamic resource or binding will be cleared.

## SetCurrentValue

The <xref:System.Windows.DependencyObject.SetCurrentValue%2A> method is another way to set a property, but it's not in the [precedence list](#dependency-property-precedence-list). `SetCurrentValue` lets you change the value of a property without overwriting the source of a previous value. For example, if a property is set by a trigger, and then you assign another value using `SetCurrentValue`, the next trigger action will set the property back to the trigger value. You can use `SetCurrentValue` whenever you want to set a property value without giving that value the precedence level of a local value. Similarly, you can use `SetCurrentValue` to change the value of a property without overwriting a binding.

## Coercion and animation

Coercion and animation both act on a *base value*. The *base value* is the dependency property value with the highest precedence, determined by evaluating upwards through the [precedence list](#dependency-property-precedence-list) until item 2 is reached.

If an animation doesn't specify both <xref:System.Windows.Media.Animation.DoubleAnimation.From> and <xref:System.Windows.Media.Animation.DoubleAnimation.To> property values for certain behaviors, or if the animation deliberately reverts to the base value when completed, then the base value can affect the animated value. To see this in practice, run the [Target Values](https://github.com/Microsoft/WPF-Samples/tree/master/Animation/TargetValues) sample application. In the sample, for the rectangle height, try setting initial local values that differ from any `From` value. The sample animations start right away by using the `From` value instead of the base value. By specifying <xref:System.Windows.Media.Animation.FillBehavior.Stop> as the <xref:System.Windows.Media.Animation.FillBehavior>, on completion an animation will reset a property value to its base value. Normal precedence is used for base value determination after an animation ends.

Multiple animations can be applied to a single property, with each animation having a different precedence. Rather than applying the animation with the highest precedence, the WPF presentation engine might composite the animation values, depending on how the animations were defined and the type of values animated. For more information, see [Animation overview](/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8&preserve-view=true).

Coercion is at the top of the [precedence list](#dependency-property-precedence-list). Even a running animation is subject to value coercion. Some existing dependency properties in WPF have built-in coercion. For custom dependency properties, you can define coercion behavior by writing a <xref:System.Windows.CoerceValueCallback> that you pass as part of metadata when you create a property. You can also override the coercion behavior of existing properties by overriding the metadata for that property in a derived class. Coercion interacts with the base value in such a way that the constraints on coercion are applied as they exist at the time, but the base value is still retained. As a result, if the constraints in coercion are later lifted, the coercion will return the closest value possible to the base value, and potentially the coercion influence on a property will cease as soon as all constraints are lifted. For more on coercion behavior, see [Dependency property callbacks and validation](dependency-property-callbacks-and-validation.md).

## Trigger behaviors

Controls often define trigger behaviors as part of their [default style](#default-theme-styles). Setting local properties on controls can potentially conflict with those triggers, preventing the triggers from responding (either visually or behaviorally) to user-driven events. A common use of a property trigger is to control state properties, such as <xref:System.Windows.Controls.Primitives.Selector.IsSelected%2A> or <xref:System.Windows.UIElement.IsEnabled%2A>. For example, by default, when a <xref:System.Windows.Controls.Button> is disabled, a theme style trigger (`IsEnabled` is `false`) sets the <xref:System.Windows.Controls.Control.Foreground%2A> value to make the `Button` appear greyed out. If you've set a local `Foreground` value, the higher precedence local property value will overrule the theme style `Foreground` value, even when the `Button` is disabled. When setting property values that override theme-level trigger behaviors for a control, be careful not to unduly interfere with the intended user experience for that control.

## ClearValue

The <xref:System.Windows.DependencyObject.ClearValue%2A> method clears any locally applied value of a dependency property for an element. But, calling `ClearValue` doesn't guarantee that the default value established in metadata during property registration is the new effective value. All other participants in the [precedence list](#dependency-property-precedence-list) are still active, and only the locally set value gets removed. For example, if you call `ClearValue` on a property that has a theme style, the theme style value will be applied as the new value, rather than the metadata-based default. If you want to set a property value to the registered metadata default value, then get the default metadata value by querying the dependency property metadata, and locally set the property value with a call to <xref:System.Windows.DependencyObject.SetValue%2A>.

## See also

- <xref:System.Windows.DependencyObject>
- <xref:System.Windows.DependencyProperty>
- [Dependency properties overview](dependency-properties-overview.md)
- [Custom Dependency Properties](custom-dependency-properties.md)
- [Dependency Property Callbacks and Validation](dependency-property-callbacks-and-validation.md)
