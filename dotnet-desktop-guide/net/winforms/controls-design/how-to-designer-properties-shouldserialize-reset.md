---
title: How to use the Reset and ShouldSerialize methods
description: Learn how to implement the Reset and ShouldSerialize methods to control a property during design-time in Windows Forms.
ms.date: 07/20/2023
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
f1_keywords:
  - "Reset"
  - "ShouldSerialize"
helpviewer_keywords:
  - "design-time properties"
  - "designer properties"
  - "reset property"
---

# Use Reset and ShouldSerialize to control a property (Windows Forms .NET)

In this article, you learn how to create the `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods to manage a property for the **Properties** window in Visual Studio. `Reset` and `ShouldSerialize` are optional methods that you can provide for a property, if the property doesn't have a simple default value. If the property has a simple default value, you should apply the <xref:System.ComponentModel.DefaultValueAttribute> and supply the default value to the attribute class constructor instead. Either of these mechanisms enables the following features in the designer:

- The property provides visual indication in the property browser if it has been modified from its default value.
- The user can right-click on the property and choose **Reset** to restore the property to its default value.
- The designer generates more efficient code.

For more information about properties, see [Reset and ShouldSerialize](designer-properties-overview.md#reset-and-shouldserialize).

## Supporting code

This article demonstrates the `Reset` and `ShouldSerialize` methods by creating a compass rose control. If you're working with your own user control, you can skip this section.

01. Add the following enumeration to your code:

    :::code language="csharp" source="./snippets/how-to-designer-properties-shouldserialize-reset/csharp/Directions.cs" id="enum":::
    :::code language="vb" source="./snippets/how-to-designer-properties-shouldserialize-reset/vb/Directions.vb" id="enum":::

01. Add a user control named `CompassRose`.
01. Add a property named `Direction` of type `Directions` to the user control.

    :::code language="csharp" source="./snippets/how-to-designer-properties-shouldserialize-reset/csharp/CompassRose.cs" id="property":::
    :::code language="vb" source="./snippets/how-to-designer-properties-shouldserialize-reset/vb/CompassRose.vb" id="property":::

## Reset

The `Reset<PropertyName>` method resets the corresponding `<PropertyName>` property to its default value.

The following code resets the `Direction` property to `None`, which is considered the default value for the compass rose control:

:::code language="csharp" source="./snippets/how-to-designer-properties-shouldserialize-reset/csharp/CompassRose.cs" id="reset":::
:::code language="vb" source="./snippets/how-to-designer-properties-shouldserialize-reset/vb/CompassRose.vb" id="reset":::

## ShouldSerialize

The `ShouldSerialize<PropertyName>` method returns a boolean value that indicates whether or not the backing property has changed from its default value and should be serialized into the designer's code.

The following code returns true when the `Direction` property doesn't equal `None`, indicating that a direction has been chosen:

:::code language="csharp" source="./snippets/how-to-designer-properties-shouldserialize-reset/csharp/CompassRose.cs" id="shouldserialize":::
:::code language="vb" source="./snippets/how-to-designer-properties-shouldserialize-reset/vb/CompassRose.vb" id="shouldserialize":::

## Example

The following code shows the `Reset` and `ShouldSerialize` methods for the `Direction` property:

:::code language="csharp" source="./snippets/how-to-designer-properties-shouldserialize-reset/csharp/CompassRose.cs" id="control":::
:::code language="vb" source="./snippets/how-to-designer-properties-shouldserialize-reset/vb/CompassRose.vb" id="control":::
