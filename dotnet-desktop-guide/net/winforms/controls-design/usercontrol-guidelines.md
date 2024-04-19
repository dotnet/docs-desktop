---
title: User control guidelines
description: This article offers practical advice on how to design your user control for Windows Forms.
ms.date: 08/08/2023
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
f1_keywords: 
  - "UserControl"
helpviewer_keywords: 
  - "events [Windows Forms], defining within Windows Forms custom controls"
  - "custom controls [Windows Forms], events using code"
  - "property [Windows Forms], property changed events"
  - "property [Windows Forms], designer"
---

# Guidelines to designing user controls (Windows Forms .NET)

This article provides guidelines for creating user controls. We recommend that you follow these guidelines to make sure that you design a user control that's consistent with other Windows Forms controls.

## Defining events

Events commonly communicate state change and alert you to how the user is interacting with a Windows Forms control. For more information about events and delegates, see [Handle and raise events](/dotnet/standard/events/index).

When defining your own events, follow these suggestions:

- Use the <xref:System.EventHandler> event delegate when you define an event that doesn't have any associated data. Use the <xref:System.EventHandler%601> event delegate when you do have associated data.
- Derive from <xref:System.EventArgs> and extend it with your data, when you raise an event with associated data.
- Pass the control instance as the `sender` parameter.
- Create a method named `On{EventName}` that raises the event, which is marked as `protected` and `virtual` (in C#) or `Protected` and `Overridable` (in Visual Basic).

:::code language="csharp" source="./snippets/usercontrol-guidelines/csharp/UserControl1.cs" id="property_changed":::
:::code language="vb" source="./snippets/usercontrol-guidelines/vb/UserControl1.vb" id="property_changed":::

## Property changed events

If you want your control to send notifications when a property changes, define an event named `{PropertyName}Changed`. This is the naming convention used in Windows Forms. The associated event delegate type for property-changed events is <xref:System.EventHandler>, and the event data type is <xref:System.EventArgs>. The base class <xref:System.Windows.Forms.Control> defines many property-changed events, such as <xref:System.Windows.Forms.Control.BackColorChanged>, <xref:System.Windows.Forms.Control.BackgroundImageChanged>, <xref:System.Windows.Forms.Control.FontChanged>, <xref:System.Windows.Forms.Control.LocationChanged>. When your property follows this naming convention, it receives bi-directional data binding support.

The same suggestions in the [Defining events](#defining-events) section apply here, as well.

:::code language="csharp" source="./snippets/usercontrol-guidelines/csharp/UserControl1.cs" id="eventargs":::
:::code language="vb" source="./snippets/usercontrol-guidelines/vb/UserControl1.vb" id="eventargs":::

## Properties

Control properties should support the Windows Forms Visual Designer. The **Properties** window interacts with control properties, and users expect to use this to change properties of the control. Either add the <xref:System.ComponentModel.DefaultValueAttribute> to the property, or create corresponding `Reset<PropertyName>` and `ShouldSerialize<PropertyName>` methods. For more information, see [DefaultValueAttribute](designer-properties-overview.md#defaultvalueattribute) and [Reset and ShouldSerialize](designer-properties-overview.md#reset-and-shouldserialize).

Properties that you don't want exposed to the Windows Forms Visual Designer should add the <xref:System.ComponentModel.BrowsableAttribute> to the property, passing false for the parameter of the attribute. This hides the property from the **Properties** window. For more information, see [Define a property](designer-properties-overview.md#define-a-property) and [Attributes for properties](designer-overview.md#attributes-for-properties).
