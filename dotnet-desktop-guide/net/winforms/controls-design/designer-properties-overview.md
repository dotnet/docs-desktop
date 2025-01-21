---
title: Design-time properties overview
description: Learn about how the Windows Forms Designer interacts with control and form properties during design-time.
ms.date: 07/14/2023
ms.topic: overview
no-loc: ["UserControl"]
dev_langs:
- "csharp"
- "vb"
f1_keywords: 
- "UserControl"
helpviewer_keywords: 
- "controls [Windows Forms], composite"
---

# Design-time properties for custom controls (Windows Forms .NET)

This article teaches you about how properties are handled for controls in the Windows Forms Visual Designer in Visual Studio.

Every control inherits many properties from the base class <xref:System.Windows.Forms.Control?displayProperty=nameWithType>, such as:

- <xref:System.Windows.Forms.Control.Enabled%2A>
- <xref:System.Windows.Forms.Control.Font%2A>
- <xref:System.Windows.Forms.Control.ForeColor%2A>
- <xref:System.Windows.Forms.Control.Focused%2A>
- <xref:System.Windows.Forms.Control.Visible%2A>
- <xref:System.Windows.Forms.Control.Width%2A>

When creating a control, you can define new properties and control how they appear in the designer.

## Define a property

Any public property with a **get** accessor defined by a control is automatically visible in the Visual Studio **Properties** window. If the property also defines a **set** accessor, the property can be changed in the **Properties** window. However, properties can be explicitly displayed or hidden from the **Properties** window by applying the <xref:System.ComponentModel.BrowsableAttribute>. This attribute takes a single boolean parameter to indicate whether or not it's displayed. For more information about attributes, see [Attributes (C#)](/dotnet/csharp/programming-guide/concepts/attributes/index) or [Attributes overview (Visual Basic)](/dotnet/visual-basic/programming-guide/concepts/attributes/index).

:::code language="csharp" source="./snippets/designer-properties-overview/csharp/CompassRose.cs" id="browsable":::
:::code language="vb" source="./snippets/designer-properties-overview/vb/CompassRose.vb" id="browsable":::

> [!NOTE]
> Complex properties that can't be implicitly converted to and from a string require a type converter.

## Serialized properties

Properties set on a control are serialized into the designer's code-behind file. This happens when the value of a property is set to something other than its default value.

When the designer detects a change to a property, it evaluates all properties for the control and serializes any property whose value doesn't match the default value for the property. The value of a property is serialized into the designer's code-behid file. Default values help the designer to determine which property values should be serialized.

## Default values

A property is considered to have a default value when it either applies the <xref:System.ComponentModel.DefaultValueAttribute> attribute, or the property's class contains property-specific `Reset` and `ShouldSerialize` methods. For more information about attributes, see [Attributes (C#)](/dotnet/csharp/programming-guide/concepts/attributes/index) or [Attributes overview (Visual Basic)](/dotnet/visual-basic/programming-guide/concepts/attributes/index).

By setting a default value, you enable the following:

- The property provides visual indication in the **Properties** window if it has been modified from its default value.
- The user can right-click on the property and choose **Reset** to restore the property to its default value.
- The designer generates more efficient code.

If a property uses a simple type, such as a primitive type, the default value can be set by applying the `DefaultValueAttribute` to the property. However, properties with this attribute don't automatically start with that assigned value. You must set the property's backing field to the same default value. You can set the property on the declaration or in the class's constructor.

When a property is a complex type, or you want to control the designer's reset and serialization behavior, define the `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods on the class. For example, if the control defines an `Age` property, the methods are named `ResetAge` and `ShouldSerializeAge`.

> [!IMPORTANT]
> Either apply the `DefaultValueAttribute` to the property, or provide both `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods. Don't mix the two ways of defining the default value.

Properties can be "reset" to their default values through the **Properties** window by right-clicking on the property name and selecting **Reset**.

:::image type="content" source="media/designer-properties-overview/vs-properties-reset.png" alt-text="The Reset context menu item in the properties grid.":::

The availability of the **Properties** > **Right-click** > **Reset** context menu option is enabled when:

- The property has the <xref:System.ComponentModel.DefaultValueAttribute> attribute applied, and the value of the property doesn't match the attribute's value.
- The property's class defines a `Reset<PropertyName>` method without a `ShouldSerialize<PropertyName>`.
- The property's class defines a `Reset<PropertyName>` method and the `ShouldSerialize<PropertyName>` returns true.

### DefaultValueAttribute

If a property's value doesn't match the value provided by <xref:System.ComponentModel.DefaultValueAttribute>, the property is considered changed and can be reset through the **Properties** window.

> [!IMPORTANT]
> This attribute shouldn't be used on properties that have corresponding `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods.

The following code declares two properties, an enumeration with a default value of `North` and an integer with a default value of 10.

:::code language="csharp" source="./snippets/designer-properties-overview/csharp/CompassRose.cs" id="defaultvalue":::
:::code language="vb" source="./snippets/designer-properties-overview/vb/CompassRose.vb" id="defaultvalue":::

### Reset and ShouldSerialize

As previously mentioned, the `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods provide the opportunity to guide not only the reset behavior of a property, but also in determining if a value is changed and should be serialized into the designer's code-behind file. Both methods work together and you shouldn't define one without the other.

> [!IMPORTANT]
> The `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods shouldn't be created for a property that has a <xref:System.ComponentModel.DefaultValueAttribute>.

When `Reset<PropertyName>` is defined, the **Properties** window displays a **Reset** context menu option for that property. When **Reset** is selected, the `Reset<PropertyName>` method is invoked. The **Reset** context menu option is enabled or disabled by what is returned by the `ShouldSerialize<PropertyName>` method. When `ShouldSerialize<PropertyName>` returns `true`, it indicates that the property has changed from its default value and should be serialized into the code-behind file and enables the **Reset** context menu option. When `false` is returned, the **Reset** context menu option is disabled and the code-behind has the property-set code removed.

> [!TIP]
> Both methods can and should be defined with private scope so that they don't make up the public API of the control.

The following code snippet declares a property named `Direction`. This property's designer behavior is controlled by the `ResetDirection` and `ShouldSerializeDirection` methods.

:::code language="csharp" source="./snippets/designer-properties-overview/csharp/CompassRose.cs" id="shouldserialize_reset":::
:::code language="vb" source="./snippets/designer-properties-overview/vb/CompassRose.vb" id="shouldserialize_reset":::

## Type converters

While type converters typically convert one type to another, they also provide string-to-value conversion for the property grid and other design-time controls. String-to-value conversion allows complex properties to be represented in these design-time controls.

Most built-in data types (numbers, enumerations, and others) have default type converters that provide string-to-value conversions and perform validation checks. The default type converters are in the `System.ComponentModel` namespace and are named after the type being converted. The converter type names use the following format: `{type name}Converter`. For example, <xref:System.ComponentModel.StringConverter>, <xref:System.ComponentModel.TimeSpanConverter>, and <xref:System.ComponentModel.Int32Converter>.

Type converters are used extensively at design-time with the **Properties** window. A type converter can be applied to a property or a type, using the <xref:System.ComponentModel.TypeConverterAttribute>.

The **Properties** window uses converters to display the property as a string value when the `TypeConverterAttribute` is declared on the property. When the `TypeConverterAttribute` is declared on a type, the **Properties** window uses the converter on every property of that type. The type converter also helps with serializing the property value in the designer's code-behind file.

<!--

Example is available at https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2013/ayybcxe5(v=vs.120)#type-converters-that-provide-a-list-of-standard-values-to-a-properties-window

This should be converted into examples

-->

## Type editors

The **Properties** window automatically uses a type editor for a property when the type of the property is a built-in or known type. For example, a boolean value is edited as a combo box with **True** and **False** values and the <xref:System.DateTime> type uses a calendar dropdown.

> [!IMPORTANT]
> Custom type editors have changed since .NET Framework. For more information, see [The designer changes since .NET Framework (Windows Forms .NET)](designer-differences-framework.md).
