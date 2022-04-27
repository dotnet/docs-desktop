---
title: "Dependency property callbacks and validation"
description: Learn how to implement dependency property callbacks and validation in Windows Presentation Foundation (WPF).
ms.date: "11/11/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "dependency properties [WPF], validation"
  - "coerce-value callbacks [WPF]"
  - "callbacks [WPF], validation"
  - "dependency properties [WPF], callbacks"
  - "validation of dependency properties [WPF]"
---
<!--The acrolinx score was 92 on 11/11/2021-->

# Dependency property callbacks and validation (WPF .NET)

This article describes how to define a dependency property and implement dependency property callbacks. The callbacks support value validation, value coercion, and other logic that's needed when a property value changes.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of dependency properties, and that you've read [Dependency properties overview](dependency-properties-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Validate-value callbacks

Validate-value callbacks provide a way for you to check whether a new dependency property value is valid before it's applied by the property system. This callback raises an exception if the value doesn't meet the validation criteria.

Validate-value callbacks can only be assigned to a dependency property once, during property registration. When registering a dependency property, you have the option to pass a <xref:System.Windows.ValidateValueCallback> reference to the <xref:System.Windows.DependencyProperty.Register(System.String,System.Type,System.Type,System.Windows.PropertyMetadata,System.Windows.ValidateValueCallback)> method. Validate-value callbacks aren't part of property metadata, and can't be overridden.

The effective value of a dependency property is its applied value. The effective value is determined through [property value precedence](dependency-property-value-precedence.md) when multiple property-based inputs exist. If a validate-value callback is registered for a dependency property, the property system will invoke its validate-value callback on value change, passing in the new value as an object. Within the callback, you can cast the value object back to the type registered with the property system, and then run your validation logic on it. The callback returns `true` if the value is valid for the property, otherwise `false`.

If a validate-value callback returns `false`, an exception is raised and the new value is not applied. Application writers must be prepared to handle these exceptions. A common use of validate-value callbacks is validating enumeration values, or constraining numeric values when they represent measurements that have limits. Validate-value callbacks are invoked by the property system in different scenarios, including:

- Object initialization, which applies a default value at creation time.
- Programmatic calls to <xref:System.Windows.DependencyObject.SetValue%2A>.
- Metadata overrides that specify a new default value.

Validate-value callbacks don't have a parameter that specifies the <xref:System.Windows.DependencyObject> instance on which the new value is set. All instances of a `DependencyObject` share the same validate-value callback, so it can't be used to validate instance-specific scenarios. For more information, see <xref:System.Windows.ValidateValueCallback>.

The following example shows how to prevent a property, typed as <xref:System.Double>, being set to <xref:System.Double.PositiveInfinity> or <xref:System.Double.NegativeInfinity>.

:::code language="csharp" source="./snippets/dependency-property-callbacks-and-validation/csharp/MainWindow.xaml.cs" id="ValueValidationScenario":::
:::code language="vb" source="./snippets/dependency-property-callbacks-and-validation/vb/MainWindow.xaml.vb" id="ValueValidationScenario":::

:::code language="csharp" source="./snippets/dependency-property-callbacks-and-validation/csharp/MainWindow.xaml.cs" id="TestValueValidationScenario":::
:::code language="vb" source="./snippets/dependency-property-callbacks-and-validation/vb/MainWindow.xaml.vb" id="TestValueValidationScenario":::

## Property-changed callbacks

Property-changed callbacks notify you when the effective value of a dependency property has changed.

Property-changed callbacks are part of dependency property metadata. If you derive from a class that defines a dependency property, or add your class as an owner of a dependency property, you can override the metadata. When overriding metadata, you have the option to provide a new <xref:System.Windows.PropertyChangedCallback> reference. Use a property-changed callback to run logic that's needed when a property value changes.

Unlike validate-value callbacks, property-changed callbacks have a parameter that specifies the <xref:System.Windows.DependencyObject> instance on which the new value is set. The next example shows how a property-changed callback can use the `DependencyObject` instance reference to trigger coerce-value callbacks.

## Coerce-value callbacks

Coerce-value callbacks provide a way for you to get notified when the effective value of a dependency property is about to change, so that you can adjust the new value before it's applied. In addition to being triggered by the property system, you can invoke coerce-value callbacks from your code.

Coerce-value callbacks are part of dependency property metadata. If you derive from a class that defines a dependency property, or add your class as an owner of a dependency property, you can override the metadata. When overriding the metadata, you have the option to provide a reference to a new <xref:System.Windows.CoerceValueCallback>. Use a coerce-value callback to evaluate new values and coerce them when necessary. The callback returns the coerced value if coercion occurred, otherwise it returns the unaltered new value.

Similar to property-changed callbacks, coerce-value callbacks have a parameter that specifies the <xref:System.Windows.DependencyObject> instance on which the new value is set. The next example shows how a coerce-value callback can use a `DependencyObject` instance reference to coerce property values.

> [!NOTE]
> Default property values can't be coerced. A dependency property has its default value set on object initialization, or when you clear other values using <xref:System.Windows.DependencyObject.ClearValue%2A>.

### Coerce-value and property-changed callbacks in combination

You can create dependencies between properties on an element, by using coerce-value callbacks and property-changed callbacks in combination. For example, changes in one property force coercion or re-evaluation in another dependency property. The next example shows a common scenario: three dependency properties that respectively store the current value, minimum value, and maximum value of a UI element. If the maximum value changes so that it's less than the current value, the current value is then set to the new maximum value. And, if the minimum value changes so that it's greater than the current value, the current value is then set to the new minimum value. In the example, the <xref:System.Windows.PropertyChangedCallback> for the current value explicitly invokes the <xref:System.Windows.CoerceValueCallback> for the minimum and maximum values.

:::code language="csharp" source="./snippets/dependency-property-callbacks-and-validation/csharp/MainWindow.xaml.cs" id="CurrentMinMaxScenario":::
:::code language="vb" source="./snippets/dependency-property-callbacks-and-validation/vb/MainWindow.xaml.vb" id="CurrentMinMaxScenario":::

## Advanced callback scenarios

### Constraints and desired values

If a locally set value of a dependency property is changed through coercion, the unchanged locally set value is retained as the *desired value*. If the coercion is based on other property values, the property system will dynamically reevaluate the coercion whenever those other values change. Within the constraints of the coercion, the property system will apply a value that's closest to the desired value. Should the coercion condition no longer apply, the property system will restore the desired value&mdash;assuming no higher [precedence](dependency-property-value-precedence.md#dependency-property-precedence-list) value is active. The following example tests coercion in the current value, minimum value, and maximum value scenario.

:::code language="csharp" source="./snippets/dependency-property-callbacks-and-validation/csharp/MainWindow.xaml.cs" id="TestCurrentMinMaxScenario":::
:::code language="vb" source="./snippets/dependency-property-callbacks-and-validation/vb/MainWindow.xaml.vb" id="TestCurrentMinMaxScenario":::

Fairly complex dependency scenarios can occur when you have multiple properties that are dependent on one another in a circular manner. Technically, there's nothing wrong with complex dependencies&mdash;except that a large number of re-evaluations can reduce performance. Also, complex dependencies that are exposed in the UI might confuse users. Treat <xref:System.Windows.PropertyChangedCallback> and <xref:System.Windows.CoerceValueCallback> as unambiguously as possible, and don't over-constrain.

### Cancel value changes

By returning <xref:System.Windows.DependencyProperty.UnsetValue> from a <xref:System.Windows.CoerceValueCallback>, you can reject a property value change. This mechanism is useful when a property value change is initiated asynchronously, but when it's applied is no longer valid for the current object state. Another scenario might be to selectively suppress a value change based on where it originated. In the following example, the `CoerceValueCallback` calls the <xref:System.Windows.DependencyPropertyHelper.GetValueSource%2A> method, which returns a <xref:System.Windows.ValueSource> structure with a <xref:System.Windows.BaseValueSource> enumeration that identifies the source of the new value.

:::code language="csharp" source="./snippets/dependency-property-callbacks-and-validation/csharp/MainWindow.xaml.cs" id="GetValueSourceScenario":::
:::code language="vb" source="./snippets/dependency-property-callbacks-and-validation/vb/MainWindow.xaml.vb" id="GetValueSourceScenario":::

## See also

- <xref:System.Windows.ValidateValueCallback>
- <xref:System.Windows.PropertyChangedCallback>
- <xref:System.Windows.CoerceValueCallback>
- [Dependency properties overview](dependency-properties-overview.md)
- [Dependency property metadata](dependency-property-metadata.md)
- [Custom dependency properties](custom-dependency-properties.md)
