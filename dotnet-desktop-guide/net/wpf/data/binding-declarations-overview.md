---
title: Binding declarations overview
description: Learn how to declare a data binding in XAML or code for your application development in Windows Presentation Foundation (WPF).
ms.date: 04/27/2021
author: adegeo
ms.author: adegeo
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "markup extensions [WPF]"
  - "data binding [WPF], declarations"
  - "object element syntax [WPF]"
  - "binding data [WPF], declarations"
  - "syntax [WPF], object elements"
  - "binding declarations [WPF]"
---

# Binding declarations overview (WPF .NET)

Typically, developers declare the bindings directly in the XAML markup of the UI elements they want to bind data to. However, you can also declare bindings in code. This article describes how to declare bindings in both XAML and in code.

## Prerequisites

Before reading this article, it's important that you're familiar with the concept and usage of markup extensions. For more information about markup extensions, see [Markup Extensions and WPF XAML](../../../framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).

This article doesn't cover data binding concepts. For a discussion of data binding concepts, see [Data binding overview](index.md#basic-data-binding-concepts).

## Declare a binding in XAML

<xref:System.Windows.Data.Binding> is a markup extension. When you use the binding extension to declare a binding, the declaration consists of a series of clauses following the `Binding` keyword and separated by commas (,). The clauses in the binding declaration can be in any order and there are many possible combinations. The clauses are *Name*=*Value* pairs, where *Name* is the name of the <xref:System.Windows.Data.Binding> property and *Value* is the value you're setting for the property.

When creating binding declaration strings in markup, they must be attached to the specific dependency property of a target object. The following example shows how to bind the <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> property using the binding extension, specifying the <xref:System.Windows.Data.Binding.Source%2A> and <xref:System.Windows.Data.Binding.Path%2A> properties.

:::code language="xaml" source="./snippets/binding-declarations-overview/csharp/ExampleBinding.xaml" range="38":::

You can specify most of the properties of the <xref:System.Windows.Data.Binding> class this way. For more information about the binding extension and for a list of <xref:System.Windows.Data.Binding> properties that cannot be set using the binding extension, see the [Binding Markup Extension (.NET Framework)](../../../framework/wpf/advanced/binding-markup-extension.md) overview.

### Object element syntax

Object element syntax is an alternative to creating the binding declaration. In most cases, there's no particular advantage to using either the markup extension or the object element syntax. However, when the markup extension doesn't support your scenario, such as when your property value is of a non-string type for which no type conversion exists, you need to use the object element syntax.

The previous section demonstrated how to bind with a XAML extension. The following example demonstrates doing the same binding but uses object element syntax:

:::code language="xaml" source="./snippets/binding-declarations-overview/csharp/ExampleBinding.xaml" range="40-44":::

For more information about the different terms, see [XAML Syntax In Detail (.NET Framework)](../../../framework/wpf/advanced/xaml-syntax-in-detail.md).

### MultiBinding and PriorityBinding

<xref:System.Windows.Data.MultiBinding> and <xref:System.Windows.Data.PriorityBinding> don't support the XAML extension syntax. That's why you must use the object element syntax if you're declaring a <xref:System.Windows.Data.MultiBinding> or a <xref:System.Windows.Data.PriorityBinding> in XAML.

## Create a binding in code

Another way to specify a binding is to set properties directly on a <xref:System.Windows.Data.Binding> object in code, and then assign the binding to a property. The following example shows how to create a <xref:System.Windows.Data.Binding> object in code.

:::code language="csharp" source="./snippets/binding-declarations-overview/csharp/DataBindingCode.xaml.cs" id="SetBinding":::
:::code language="vb" source="./snippets/binding-declarations-overview/vb/DataBindingCode.xaml.vb" id="SetBinding":::

The previous code set the following on the binding:

- A path of the property on the data source object.
- The mode of the binding.
- The data source, in this case, a simple object instance representing a person.
- An optional converter that processes the value coming in from the data source object before it's assigned to the target property.

When the object you're binding is a <xref:System.Windows.FrameworkElement> or a <xref:System.Windows.FrameworkContentElement>, you can call the `SetBinding` method on your object directly instead of using <xref:System.Windows.Data.BindingOperations.SetBinding%2A?displayProperty=nameWithType>. For an example, see [How to: Create a Binding in Code](../../../framework/wpf/data/how-to-create-a-binding-in-code.md).

The previous example uses a simple data object type of `Person`. The following is the code for that object:

:::code language="csharp" source="./snippets/binding-declarations-overview/csharp/Person.cs" id="Person":::
:::code language="vb" source="./snippets/binding-declarations-overview/vb/Person.vb" id="Person":::

## Binding path syntax

Use the <xref:System.Windows.Data.Binding.Path%2A> property to specify the source value you want to bind to:

- In the simplest case, the <xref:System.Windows.Data.Binding.Path%2A> property value is the name of the property of the source object to use for the binding, such as `Path=PropertyName`.

- Subproperties of a property can be specified by a similar syntax as in C#. For instance, the clause `Path=ShoppingCart.Order` sets the binding to the subproperty `Order` of the object or property `ShoppingCart`.

- To bind to an attached property, place parentheses around the attached property. For example, to bind to the attached property <xref:System.Windows.Controls.DockPanel.Dock%2A?displayProperty=nameWithType>, the syntax is `Path=(DockPanel.Dock)`.

- Indexers of a property can be specified within square brackets following the property name where the indexer is applied. For instance, the clause `Path=ShoppingCart[0]` sets the binding to the index that corresponds to how your property's internal indexing handles the literal string "0". Nested indexers are also supported.

- Indexers and subproperties can be mixed in a `Path` clause; for example, `Path=ShoppingCart.ShippingInfo[MailingAddress,Street].`

- Inside indexers. You can have multiple indexer parameters separated by commas (`,`). The type of each parameter can be specified with parentheses. For example, you can have `Path="[(sys:Int32)42,(sys:Int32)24]"`, where `sys` is mapped to the `System` namespace.

- When the source is a collection view, the current item can be specified with a slash (`/`). For example, the clause `Path=/` sets the binding to the current item in the view. When the source is a collection, this syntax specifies the current item of the default collection view.

- Property names and slashes can be combined to traverse properties that are collections. For example, `Path=/Offices/ManagerName` specifies the current item of the source collection, which contains an `Offices` property that is also a collection. Its current item is an object that contains a `ManagerName` property.

- Optionally, a period (`.`) path can be used to bind to the current source. For example, `Text="{Binding}"` is equivalent to `Text="{Binding Path=.}"`.

### Escaping mechanism

- Inside indexers (`[ ]`), the caret character (`^`) escapes the next character.

- If you set <xref:System.Windows.Data.Binding.Path%2A> in XAML, you also need to escape (using XML entities) certain characters that are special to the XML language definition:

  - Use `&amp;` to escape the character "`&`".

  - Use `&gt;` to escape the end tag "`>`".

- Additionally, if you describe the entire binding in an attribute using the markup extension syntax, you need to escape (using backslash `\`) characters that are special to the WPF markup extension parser:

  - Backslash (`\`) is the escape character itself.

  - The equal sign (`=`) separates property name from property value.

  - Comma (`,`) separates properties.

  - The right curly brace (`}`) is the end of a markup extension.

## Binding direction

Use the <xref:System.Windows.Data.Binding.Mode%2A?displayProperty=nameWithType> property to specify the direction of the binding. The following modes are the available options for binding updates:

| Binding mode                                                                       | Description                                                                                                                                        |
|------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| <xref:System.Windows.Data.BindingMode.TwoWay?displayProperty=nameWithType>         | Updates the target property or the property whenever either the target property or the source property changes.                                    |
| <xref:System.Windows.Data.BindingMode.OneWay?displayProperty=nameWithType>         | Updates the target property only when the source property changes.                                                                                 |
| <xref:System.Windows.Data.BindingMode.OneTime?displayProperty=nameWithType>        | Updates the target property only when the application starts or when the <xref:System.Windows.FrameworkElement.DataContext%2A> undergoes a change. |
| <xref:System.Windows.Data.BindingMode.OneWayToSource?displayProperty=nameWithType> | Updates the source property when the target property changes.                                                                                      |
| <xref:System.Windows.Data.BindingMode.Default?displayProperty=nameWithType>        | Causes the default <xref:System.Windows.Data.Binding.Mode%2A> value of target property to be used.                                                 |

For more information, see the <xref:System.Windows.Data.BindingMode> enumeration.

The following example shows how to set the <xref:System.Windows.Data.Binding.Mode%2A> property:

```xaml
<TextBlock Name="IncomeText" Text="{Binding Path=TotalIncome, Mode=OneTime}" />
```

To detect source changes (applicable to <xref:System.Windows.Data.BindingMode.OneWay> and <xref:System.Windows.Data.BindingMode.TwoWay> bindings), the source must implement a suitable property change notification mechanism such as <xref:System.ComponentModel.INotifyPropertyChanged>. For more information, see [Providing change notifications](binding-sources-overview.md#provide-change-notifications).

For <xref:System.Windows.Data.BindingMode.TwoWay> or <xref:System.Windows.Data.BindingMode.OneWayToSource> bindings, you can control the timing of the source updates by setting the <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> property. For more information, see <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A>.

## Default behaviors

The default behavior is as follows if not specified in the declaration:

- A default converter is created that tries to do a type conversion between the binding source value and the binding target value. If a conversion cannot be made, the default converter returns `null`.

- If you don't set <xref:System.Windows.Data.Binding.ConverterCulture%2A>, the binding engine uses the `Language` property of the binding target object. In XAML, this defaults to `en-US` or inherits the value from the root element (or any element) of the page, if one has been explicitly set.

- As long as the binding already has a data context (for example, the inherited data context coming from a parent element), and whatever item or collection being returned by that context is appropriate for binding without requiring further path modification, a binding declaration can have no clauses at all: `{Binding}`. This is often the way a binding is specified for data styling, where the binding acts upon a collection. For more information, see [Using Entire Objects as a Binding Source](../../../framework/wpf/data/binding-sources-overview.md#using-entire-objects-as-a-binding-source).

- The default <xref:System.Windows.Data.Binding.Mode%2A> varies between one-way and two-way depending on the dependency property that is being bound. You can always declare the binding mode explicitly to ensure that your binding has the desired behavior. In general, user-editable control properties, such as <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> and <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A?displayProperty=nameWithType>, default to two-way bindings, but most other properties default to one-way bindings.

- The default <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> value varies between <xref:System.Windows.Data.UpdateSourceTrigger.PropertyChanged> and <xref:System.Windows.Data.UpdateSourceTrigger.LostFocus> depending on the bound dependency property as well. The default value for most dependency properties is <xref:System.Windows.Data.UpdateSourceTrigger.PropertyChanged>, while the <xref:System.Windows.Controls.TextBox.Text%2A?displayProperty=nameWithType> property has a default value of <xref:System.Windows.Data.UpdateSourceTrigger.LostFocus>.

## See also

- [Data binding overview](index.md)
- [Binding sources overview](binding-sources-overview.md)
- [PropertyPath XAML Syntax (.NET Framework)](../../../framework/wpf/advanced/propertypath-xaml-syntax.md)
