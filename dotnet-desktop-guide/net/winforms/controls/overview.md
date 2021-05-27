---
title: "Overview of Using Controls"
description: Learn about how controls are used in Windows Forms for .NET. Controls are reusable components that provide functionality to the user. Many ready-to-use controls are provided. You can also make new controls.
ms.date: 10/26/2020
ms.topic: overview
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Windows Forms, controls"
  - "controls [Windows Forms]"
  - "custom controls [Windows Forms]"
---
# Overview of using controls (Windows Forms .NET)

Windows Forms controls are reusable components that encapsulate user interface functionality and are used in client-side, Windows-based applications. Not only does Windows Forms provide many ready-to-use controls, it also provides the infrastructure for developing your own controls. You can combine existing controls, extend existing controls, or author your own custom controls. For more information, see [Types of custom controls](custom.md).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Adding controls

Controls are added through the Visual Studio Designer. With the Designer, you can place, size, align, and move controls. Alternatively, controls can be added through code. For more information, see [Add a control (Windows Forms)](how-to-add-to-a-form.md).

## Layout options

The position a control appears on a parent is determined by the value of the <xref:System.Windows.Forms.Control.Location> property relative to the top-left of the parent surface. The top-left position coordinate in the parent is `(x0,y0)`. The size of the control is determined by the <xref:System.Windows.Forms.Control.Size> property and represents the width and height of the control.

Besides manual positioning and sizing, various container controls are provided that help with automatic placement of controls.

For more information, see [Position and layout of controls](layout.md).
<!-- TODO

## Control events

-->

## See also

- [Position and layout of controls](layout.md)
- [Label control overview](labels.md)
- [Add a control to a form](how-to-add-to-a-form.md)
