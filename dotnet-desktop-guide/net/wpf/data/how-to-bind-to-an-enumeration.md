---
title: How to bind to an enumeration
description: Learn how to use data binding to bind an enumeration to a collection object in XAML and in code for Windows Presentation Foundation.
author: adegeo
ms.author: adegeo
ms.date: 04/30/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "binding data [WPF], enumeration"
  - "data binding [WPF], enumeration"
  - "enumeration [WPF]"
---

# How to bind to an enumeration (WPF .NET)

This example shows how to bind to an enumeration. Unfortunately there isn't a direct way to use an enumeration as a data binding source. However, the <xref:System.Enum.GetValues(System.Type)?displayProperty=nameWithType> method returns a collection of values. These values can be wrapped in an <xref:System.Windows.Data.ObjectDataProvider> and used as a data source.

The <xref:System.Windows.Data.ObjectDataProvider> type provides a convenient way to create an object in XAML and use it as a data source.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Reference the enumeration

Use the <xref:System.Windows.Data.ObjectDataProvider> type to wrap an array of enumeration values provided by the enumeration type itself.

01. Create a new `ObjectDataProvider` as a XAML resource, either in your application XAML or the XAML of the object you're working with. This example uses a window and creates the `ObjectDataProvider` with a resource key of `EnumDataSource`.

    :::code language="xaml" source="./snippets/how-to-bind-to-an-enumeration/csharp/BindEnum.xaml" id="Resources":::

    In this example, the `ObjectDataProvider` uses three properties to retrieve the enumeration:

    | Property           | Description                                                                                                                                                            |
    |--------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | `ObjectType`       | The type of object to be returned by the data provider. In this example, <xref:System.Enum?displayProperty=fullName>. The `sys:` XAML namespace is mapped to `System`. |
    | `MethodName`       | The name of the method to run on the `System.Enum` type. In this example, <xref:System.Enum.GetValues%2A?displayProperty=nameWithType>.                                |
    | `MethodParameters` | A collection of values to provide to the `MethodName` method. In this example, the method takes the `System.Type` of the enumeration.                                  |

    Effectively, the XAML is breaking down a method call, method name, parameters, and the return type. The `ObjectDataProvider` configured in the previous example is the equivalent of the following code:

    :::code language="csharp" source="./snippets/how-to-bind-to-an-enumeration/csharp/BindEnum.xaml.cs" id="EnumGetValues":::
    :::code language="vb" source="./snippets/how-to-bind-to-an-enumeration/vb/BindEnum.xaml.vb" id="EnumGetValues":::

02. Reference the `ObjectDataProvider` resource. The following XAML lists the enumeration values in a <xref:System.Windows.Controls.ListBox> control:

    :::code language="xaml" source="./snippets/how-to-bind-to-an-enumeration/csharp/BindEnum.xaml" id="ListBox":::

## Full XAML

The following XAML code represents a simple window that does the following:

01. Wraps the <xref:System.Windows.HorizontalAlignment> enumeration in a <xref:System.Windows.Data.ObjectDataProvider> data source as a resource.
01. Provides a <xref:System.Windows.Controls.ListBox> control to list all enumeration values.
01. Binds a <xref:System.Windows.Controls.Button> control's <xref:System.Windows.FrameworkElement.HorizontalAlignment> property to the selected item in the `ListBox`.

:::code language="xaml" source="./snippets/how-to-bind-to-an-enumeration/csharp/BindEnumFull.xaml":::

## See also

- [Data binding overview](index.md)
- [Binding sources overview](binding-sources-overview.md)
- [StaticResource Markup Extension](../../../framework/wpf/advanced/staticresource-markup-extension.md)
- [An alternative way to bind to an enumeration](https://brianlagunas.com/a-better-way-to-data-bind-enums-in-wpf/)
