---
title: Create a Multipane User Interface
description: Describes how to layout Windows Forms controls to mimic a Microsoft Outlook email application.
ms.date: 01/21/2022
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "SplitContainer control [Windows Forms], examples"
  - "ListView control [Windows Forms], examples"
  - "RichTextBox control [Windows Forms], examples"
  - "Panel control [Windows Forms], examples"
  - "TreeView control [Windows Forms], examples"
  - "Splitter control [Windows Forms], examples"
ms.assetid: e79f6bcc-3740-4d1e-b46a-c5594d9b7327
---
# How to: Create a Multipane User Interface with Windows Forms

By arranging controls on a form, you can create a multi-pane user interface that's similar to the one used in Microsoft Outlook, with a **Folder** list, a **Messages** pane, and a **Preview** pane. This arrangement is achieved chiefly through docking controls with the form.

When you dock a control, you determine which edge of the parent container a control is fastened to. If you set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Right>, the right edge of the control will be docked to the right edge of its parent control. Additionally, the docked edge of the control is resized to match that of its container control. For more information about how the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property works, see [How to: Dock Controls on Windows Forms](how-to-dock-controls-on-windows-forms.md).

This procedure focuses on arranging the <xref:System.Windows.Forms.SplitContainer> and the other controls on the form, not on adding functionality to make the application mimic Microsoft Outlook.

:::image type="content" source="media/how-to-create-a-multipane-user-interface-with-windows-forms/form.png" alt-text="A form that's designed to look like an Outlook mail window.":::

To create this user interface, you place all the controls within a <xref:System.Windows.Forms.SplitContainer> control. The `SplitContainer` contains a <xref:System.Windows.Forms.TreeView> control in the left-hand panel and another `SplitContainer` on the right-hand panel. The second `SplitContainer` contains a <xref:System.Windows.Forms.ListView> control on top and a <xref:System.Windows.Forms.RichTextBox> control on the bottom.

These <xref:System.Windows.Forms.SplitContainer> controls enable independent resizing of the other controls on the form. You can adapt the techniques in this procedure to craft custom user interfaces of your own.

## Control layout

The following table describes how the controls are configured to mimic Microsoft Outlook:

| Control        | Property         | Value                                            |
|----------------|------------------|--------------------------------------------------|
| SplitContainer | Name             | `splitContainer1`                                |
|                | Dock             | `Fill`                                           |
|                | TabIndex         | `4`                                              |
|                | SplitterWidth    | `4`                                              |
|                | SplitterDistance | `100`                                            |
|                | Panel1.Controls  | Add the `treeView1` control to this panel.       |
|                | Panel2.Controls  | Add the `splitContainer2` control to this panel. |
| TreeView       | Name             | `treeView1`                                      |
|                | Dock             | `Fill`                                           |
|                | TabIndex         | `0`                                              |
|                | Nodes            | Add a new node named `Node0`                     |
| SplitContainer | Name             | `splitContainer2`                                |
|                | Dock             | `Fill`                                           |
|                | TabIndex         | `1`                                              |
|                | SplitterWidth    | `4`                                              |
|                | SplitterDistance | `150`                                            |
|                | Orientation      | `Horizontal`                                     |
|                | Panel1.Controls  | Add the `listView1` control to this panel.       |
|                | Panel2.Controls  | Add the `richTextBox1` control to this panel.    |
| ListView       | Name             | `listView1`                                      |
|                | Dock             | `Fill`                                           |
|                | TabIndex         | `2`                                              |
|                | Items            | Add a new item and set the text to `item1`.      |
| RichTextBox    | Name             | `richTextBox1`                                   |
|                | Dock             | `Fill`                                           |
|                | TabIndex         | `3`                                              |
|                | Text             | `richTextBox1`                                   |

## See also

- <xref:System.Windows.Forms.SplitContainer>
- [SplitContainer Control](splitcontainer-control-windows-forms.md)
- [How to: Create a Multipane User Interface with Windows Forms Using the Designer](create-a-multipane-user-interface-with-wf-using-the-designer.md)
