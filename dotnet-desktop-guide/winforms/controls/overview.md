---
title: "Overview of Using Controls"
description: Learn about how controls are used in Windows Forms for .NET. Controls are reusable components that provide functionality to the user. Many ready-to-use controls are provided. You can also make new controls.
ms.date: 03/31/2025
ms.service: dotnet-desktop
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Windows Forms, controls"
  - "controls [Windows Forms]"
  - "custom controls [Windows Forms]"
---
# Overview of using controls

Windows Forms controls are reusable components that encapsulate user interface functionality and are used in client-side, Windows-based applications. Not only does Windows Forms provide many ready-to-use controls, it also provides the infrastructure for developing your own controls. You can combine existing controls, extend existing controls, or author your own custom controls. For more information, see [Create new controls overview](../controls-design/overview.md).

## Adding controls

Controls are added through the Visual Studio Designer. With the Designer, you can place, size, align, and move controls. Alternatively, controls can be added through code. For more information, see [Add a control (Windows Forms)](how-to-add-to-a-form.md).

## Layout options

The position a control appears on a parent is determined by the value of the <xref:System.Windows.Forms.Control.Location> property relative to the top-left of the parent surface. The top-left position coordinate in the parent is `(x0,y0)`. The size of the control is determined by the <xref:System.Windows.Forms.Control.Size> property and represents the width and height of the control.

Besides manual positioning and sizing, various container controls are available that help with automatic placement of controls.

For more information, see [Position and layout of controls](layout.md) and [How to dock and anchor controls](how-to-dock-and-anchor.md).

## Control events

Controls have more than 60 events through the base class <xref:System.Windows.Forms.Control>. These include the <xref:System.Windows.Forms.Control.Paint> event, which causes a control to be drawn, events related to displaying a window, such as the <xref:System.Windows.Forms.Control.Resize> and <xref:System.Windows.Forms.Control.Layout> events, and low-level mouse and keyboard events. Some low-level events are synthesized by <xref:System.Windows.Forms.Control> into semantic events such as <xref:System.Windows.Forms.Control.Click> and <xref:System.Windows.Forms.Control.DoubleClick>. Most shared events fall under these categories:

- Mouse events
- Keyboard events
- Property changed events
- Other events

Not every control responds to every event. For example, the <xref:System.Windows.Forms.Label> control doesn't respond to keyboard input, and the <xref:System.Windows.Forms.Control.PreviewKeyDown?displayProperty=nameWithType> event isn't raised.

Often, a control is a wrapper for an underlying Win32 control, and using the <xref:System.Windows.Forms.Control.Paint> event to draw on top of the control might be limited or do nothing at all, since the control is ultimately drawn by Windows.

For more information, see [Control events](events.md) and [How to handle a control event](how-to-add-an-event-handler.md).

## Control accessibility

Windows Forms has accessibility support for screen readers and voice input utilities for verbal commands. However, you must design your UI with accessibility in mind. Windows Forms controls expose various properties to handle accessibility. For more information about these properties, see [Providing Accessibility Information for Controls](provide-accessibility-information.md).

## See also

- [Position and layout of controls](layout.md)
- [Label control overview](labels.md)
- [Control events](events.md)
- [Create new controls overview](../controls-design/overview.md)
