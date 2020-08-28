---
title: "Walkthrough: Providing Standard Menu Items to a Form"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "menu items [Windows Forms], standard"
  - "toolbars [Windows Forms], walkthroughs"
  - "StatusStrip control [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
ms.assetid: dac37d98-589e-4d6d-9673-6437e8943122
---
# Walkthrough: Providing Standard Menu Items to a Form

You can provide a standard menu for your forms with the <xref:System.Windows.Forms.MenuStrip> control.

This walkthrough demonstrates how to use a <xref:System.Windows.Forms.MenuStrip> control to create a standard menu. The form also responds when a user selects a menu item. The following tasks are illustrated in this walkthrough:

- Creating a Windows Forms project.

- Creating a standard menu.

- Creating a <xref:System.Windows.Forms.StatusStrip> control.

- Handling menu item selection.

When you are finished, you will have a form with a standard menu that displays menu item selections in a <xref:System.Windows.Forms.StatusStrip> control.

To copy the code in this topic as a single listing, see [How to: Provide Standard Menu Items to a Form](how-to-provide-standard-menu-items-to-a-form.md).

## Prerequisites

You'll need Visual Studio to complete this walkthrough.

## Create the project

1. In Visual Studio, create a Windows application project called **StandardMenuForm** (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **Windows Forms Application**).

2. In the Windows Forms Designer, select the form.

## Create a standard menu

The Windows Forms Designer can automatically populate a <xref:System.Windows.Forms.MenuStrip> control with standard menu items.

1. From the **Toolbox**, drag a <xref:System.Windows.Forms.MenuStrip> control onto your form.

2. Click the <xref:System.Windows.Forms.MenuStrip> control's designer actions glyph (![Small black arrow](./media/designer-actions-glyph.gif)) and select **Insert Standard Items**.

     The <xref:System.Windows.Forms.MenuStrip> control is populated with the standard menu items.

3. Click the **File** menu item to see its default menu items and corresponding icons.

## Create a StatusStrip control

Use the <xref:System.Windows.Forms.StatusStrip> control to display status for your Windows Forms applications. In the current example, menu items selected by the user are displayed in a <xref:System.Windows.Forms.StatusStrip> control.

1. From the **Toolbox**, drag a <xref:System.Windows.Forms.StatusStrip> control onto your form.

     The <xref:System.Windows.Forms.StatusStrip> control automatically docks to the bottom of the form.

2. Click the <xref:System.Windows.Forms.StatusStrip> control's drop-down button and select **StatusLabel** to add a <xref:System.Windows.Forms.ToolStripStatusLabel> control to the <xref:System.Windows.Forms.StatusStrip> control.

## Handle item selection

Handle the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked> event to respond when the user selects a menu item.

1. Click the **File** menu item that you created in the Creating a Standard Menu section.

2. In the **Properties** window, click **Events**.

3. Double-click the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked> event.

     The Windows Forms Designer generates an event handler for the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked> event.

4. Insert the following code into the event handler.

     [!code-csharp[System.Windows.Forms.ToolStrip.StandardMenu#3](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.ToolStrip.StandardMenu#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/VB/Form1.vb#3)]

5. Insert the `UpdateStatus` utility method definition into the form.

     [!code-csharp[System.Windows.Forms.ToolStrip.StandardMenu#2](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.ToolStrip.StandardMenu#2](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/VB/Form1.vb#2)]

## Checkpoint -test your form

1. Press **F5** to compile and run your form.

2. Click the **File** menu item to open the menu.

3. On the **File** menu, click one of the items to select it.

     The <xref:System.Windows.Forms.StatusStrip> control displays the selected item.

## Next steps

In this walkthrough, you have created a form with a standard menu. You can use the <xref:System.Windows.Forms.ToolStrip> family of controls for many other purposes:

- Create shortcut menus for your controls with <xref:System.Windows.Forms.ContextMenuStrip>. For more information, see [ContextMenu Component Overview](contextmenu-component-overview-windows-forms.md).

- Create a multiple document interface (MDI) form with docking <xref:System.Windows.Forms.ToolStrip> controls. For more information, see [Walkthrough: Creating an MDI Form with Menu Merging and ToolStrip Controls](walkthrough-creating-an-mdi-form-with-menu-merging-and-toolstrip-controls.md).

- Give your <xref:System.Windows.Forms.ToolStrip> controls a professional appearance. For more information, see [How to: Set the ToolStrip Renderer for an Application](how-to-set-the-toolstrip-renderer-for-an-application.md).

## See also

- <xref:System.Windows.Forms.MenuStrip>
- <xref:System.Windows.Forms.ToolStrip>
- <xref:System.Windows.Forms.StatusStrip>
- [MenuStrip Control](menustrip-control-windows-forms.md)
