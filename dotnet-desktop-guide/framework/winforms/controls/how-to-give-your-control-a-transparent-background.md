---
title: "How to: Give Your Control a Transparent Background"
description: Learn how to give your control a transparent background using the properties window at design time. 
ms.date: 06/12/2024
helpviewer_keywords: 
  - "transparent backgrounds [Windows Forms], custom controls"
  - "custom controls [Windows Forms], transparent background"
  - "transparency [Windows Forms], Windows Forms custom controls"
ms.assetid: 32433e63-f4e9-4305-9857-6de3edeb944a
---
# How to: Give Your Control a Transparent Background

The background color for most controls can be set to <xref:System.Drawing.Color.Transparent%2A> in the **Properties** window at design time, or in code in the form's constructor.

Windows Forms controls don't support _true transparency_. Controls are drawn to the screen in two parts. First, the background is painted, followed by the control's appearance. While you make a control "transparent" by setting the <xref:System.Windows.Forms.ButtonBase.BackColor%2A> to <xref:System.Drawing.Color.Transparent%2A>, this actually passes the background painting to the parent control. If the parent control supports the `BackgroundImage` property, and the property is set, then this image is drawn as the background of the control. If the property isn't supported or isn't set, the `BackColor` of the parent is used to draw the background of the control.

A better way to think of control "transparency" is to think of it as inheriting the **background** paint operation of the parent. You can't see other controls under a "transparent" control.

> [!NOTE]
> The <xref:System.Windows.Controls.Button> control allows you to set the `BackColor` to `Transparent`, but it has no effect on the control.

## To give your control a transparent background

- In the Properties window, choose the <xref:System.Windows.Forms.ButtonBase.BackColor%2A> property and set it to <xref:System.Drawing.Color.Transparent%2A>

## See also

- <xref:System.Drawing.Color.FromArgb%2A>
- [Developing Custom Windows Forms Controls with the .NET Framework](developing-custom-windows-forms-controls.md)
- [Using Managed Graphics Classes](../advanced/using-managed-graphics-classes.md)
- [How to: Draw Opaque and Semitransparent Lines](../advanced/how-to-draw-opaque-and-semitransparent-lines.md)
