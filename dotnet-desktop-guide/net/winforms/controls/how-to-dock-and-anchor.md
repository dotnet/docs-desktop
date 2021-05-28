---
title: How to dock and anchor controls
description: Learn how to s
ms.date: 05/25/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Anchor property [Windows Forms], enabling resizable forms"
  - "Windows Forms controls, screen resolutions"
  - "resizing forms [Windows Forms]"
  - "Windows Forms controls, size"
  - "screen resolution and control display"
  - "controls [Windows Forms], anchoring"
  - "forms [Windows Forms], resizing"
  - "Windows Forms, resizing"
  - "controls [Windows Forms], positioning"
  - "controls [Windows Forms], docking"
  - "Explorer-style applications [Windows Forms], creating"
  - "Windows Forms controls, filling client area"
---
# How to dock and anchor controls (Windows Forms .NET)

If you're designing a form that the user can resize at run time, the controls on your form should resize and reposition properly. Controls have two properties that help with automatic placement and sizing, when the form changes size.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

- <xref:System.Windows.Forms.Control.Dock%2A?displayProperty=nameWithType>

  Controls that are docked fill the edges of the control's container, either the form or a container control. For example, Windows Explorer docks its <xref:System.Windows.Forms.TreeView> control to the left side of the window and its <xref:System.Windows.Forms.ListView> control to the right side of the window. The docking mode can be any side of the control's container, or set to fill the remaining space of the container.

  :::image type="content" source="./media/how-to-dock-and-anchor/dock-modes.png" alt-text="A windows form demonstrating the different dock modes for a control":::

  Controls are docked in reverse z-order and the <xref:System.Windows.Forms.Control.Dock%2A> property interacts with the <xref:System.Windows.Forms.Control.AutoSize%2A> property. For more information, see [Automatic sizing](layout.md#automatic-sizing).

- <xref:System.Windows.Forms.Control.Anchor%2A?displayProperty=nameWithType>

  When an anchored control's form is resized, the control maintains the distance between the control and the anchor positions. For example, if you have a <xref:System.Windows.Forms.TextBox> control that is anchored to the left, right, and bottom edges of the form, as the form is resized, the <xref:System.Windows.Forms.TextBox> control resizes horizontally so that it maintains the same distance from the right and left sides of the form. The control also positions itself vertically so that its location is always the same distance from the bottom edge of the form. If a control isn't anchored and the form is resized, the position of the control relative to the edges of the form is changed.

  :::image type="content" source="./media/how-to-dock-and-anchor/anchor-resize.gif" alt-text="A Windows form demonstrating the different anchor modes for a control":::

For more information, see [Position and layout of controls](layout.md).

## Dock a control

A control is docked by setting its <xref:System.Windows.Forms.Control.Dock%2A> property.

> [!NOTE]
> Inherited controls must be `Protected` to be able to be docked. To change the access level of a control, set its **Modifier** property in the **Properties** window.

### Use the designer

Use the Visual Studio designer **Properties** window to set the docking mode of a control.

01. Select the control in the designer.

01. In the **Properties** window, select the arrow to the right of the **Dock** property.

    :::image type="content" source="media/how-to-dock-and-anchor/vs-dock-property.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Dock property shown.":::

01. Select the button that represents the edge of the container where you want to dock the control. To fill the contents of the control's form or container control, press the center box. Press **(none)** to disable docking.

    :::image type="content" source="media/how-to-dock-and-anchor/vs-dock-property-expanded.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Dock property expanded.":::

   The control is automatically resized to fit the boundaries of the docked edge.

### Set Dock programmatically

01. Set the `Dock` property on a control. In this example, a button is docked to the right side of its container:

    ```csharp
    button1.Dock = DockStyle.Right;
    ```

    ```vb
    button1.Dock = DockStyle.Right
    ```

## Anchor a control

A control is anchored to an edge by setting its <xref:System.Windows.Forms.Control.Anchor%2A> property to one or more values.

> [!NOTE]
> Certain controls, such as the <xref:System.Windows.Forms.ComboBox> control, have a limit to their height. Anchoring the control to the bottom of its form or container cannot force the control to exceed its height limit.
>
> Inherited controls must be `Protected` to be able to be anchored. To change the access level of a control, set its `Modifiers` property in the **Properties** window.

### Use the designer

Use the Visual Studio designer **Properties** window to set the anchored edges of a control.

01. Select the control in the designer.

01. In the **Properties** window, select the arrow to the right of the **Anchor** property.

    :::image type="content" source="media/how-to-dock-and-anchor/vs-anchor-property.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Anchor property shown.":::

01. To set or unset an anchor, select the top, left, right, or bottom arm of the cross.

    :::image type="content" source="media/how-to-dock-and-anchor/vs-anchor-property-expanded.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Anchor property expanded.":::

### Set Anchor programmatically

01. Set the `Anchor` property on a control. In this example, a button is anchored to the right and bottom sides of its container:

    ```csharp
    button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ```

    ```vb
    button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
    ```

## See also

- [Position and layout of controls](layout.md).
- <xref:System.Windows.Forms.Control.Anchor%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.Dock%2A?displayProperty=fullName>
