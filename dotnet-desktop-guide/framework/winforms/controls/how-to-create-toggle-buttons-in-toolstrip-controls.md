---
title: "How to: Create Toggle Buttons in ToolStrip Controls"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "toggle buttons [Windows Forms], creating"
  - "examples [Windows Forms], toolbars"
  - "ToolStrip control [Windows Forms], creating toggle buttons"
ms.assetid: d9c197df-4c65-43f2-beee-b68b52b2befc
---
# How to: Create Toggle Buttons in ToolStrip Controls

When a user clicks a toggle button, it appears sunken and retains the sunken appearance until the user clicks the button again.

## To create a toggling ToolStripButton

- Use code such as the following code example. This code assumes that your form contains a <xref:System.Windows.Forms.ToolStrip> control, and that its <xref:System.Windows.Forms.ToolStrip.Items%2A> collection contains a <xref:System.Windows.Forms.ToolStripButton> called `toolStripButton1`. It also assumes that you have an event handler called `toolStripButton1_CheckedChanged`.

    ```vb
    toolStripButton1.CheckOnClick = True
    toolStripButton1.CheckedChanged AddressOf _
    EventHandler(toolStripButton1_CheckedChanged);
    ```

    ```csharp
    toolStripButton1.CheckOnClick = true;
    toolStripButton1.CheckedChanged += new _
    EventHandler(toolStripButton1_CheckedChanged);
    ```

## See also

- <xref:System.Windows.Forms.ToolStripButton>
- [ToolStrip Control Overview](toolstrip-control-overview-windows-forms.md)
