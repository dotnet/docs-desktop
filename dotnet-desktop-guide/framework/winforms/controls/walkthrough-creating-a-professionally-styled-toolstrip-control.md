---
title: "Walkthrough: Creating a Professionally Styled ToolStrip Control"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "ToolStripProfessionalRenderer class [Windows Forms]"
  - "ToolStripRenderer class [Windows Forms]"
  - "toolbars [Windows Forms], walkthroughs"
  - "ToolStrip control [Windows Forms], creating professionally styled controls"
ms.assetid: b52339ae-f1d3-494e-996e-eb455614098a
---
# Walkthrough: Creating a Professionally Styled ToolStrip Control

You can give your application’s <xref:System.Windows.Forms.ToolStrip> controls a professional appearance and behavior by writing your own class derived from the <xref:System.Windows.Forms.ToolStripProfessionalRenderer> type.

This walkthrough demonstrates how to use <xref:System.Windows.Forms.ToolStrip> controls to create a composite control that resembles the **Navigation Pane** provided by Microsoft® Outlook®. The following tasks are illustrated in this walkthrough:

- Creating a Windows Control Library project.

- Designing the StackView Control.

- Implementing a Custom Renderer.

When you are finished, you will have a reusable custom client control with the professional appearance of a Microsoft Office® XP control.

To copy the code in this topic as a single listing, see [How to: Create a Professionally Styled ToolStrip Control](how-to-create-a-professionally-styled-toolstrip-control.md).

## Prerequisites

You'll need Visual Studio to complete this walkthrough.

## Create the control library project

1. In Visual Studio, create a new Windows Control Library project named `StackViewLibrary`.

2. In **Solution Explorer**, delete the project's default control by deleting the source file named "UserControl1.cs" or "UserControl1.vb", depending on your language of choice.

     For more information, see [How to: Remove, Delete, and Exclude Items](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/0ebzhwsk(v=vs.100)).

3. Add a new <xref:System.Windows.Forms.UserControl> item to the **StackViewLibrary** project. Give the new source file a base name of `StackView`.

## Design the StackView control

The `StackView` control is a composite control with one child <xref:System.Windows.Forms.ToolStrip> control. For more information about composite controls, see [Varieties of Custom Controls](varieties-of-custom-controls.md).

1. From the **Toolbox**, drag a <xref:System.Windows.Forms.ToolStrip> control to the design surface.

2. In the **Properties** window, set the <xref:System.Windows.Forms.ToolStrip> control's properties according to the following table.

    |Property|Value|
    |--------------|-----------|
    |Name|`stackStrip`|
    |CanOverflow|`false`|
    |Dock|<xref:System.Windows.Forms.DockStyle.Bottom>|
    |Font|`Tahoma, 10pt, style=Bold`|
    |GripStyle|<xref:System.Windows.Forms.ToolStripGripStyle.Hidden>|
    |LayoutStyle|<xref:System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow>|
    |Padding|`0, 7, 0, 0`|
    |RenderMode|<xref:System.Windows.Forms.ToolStripRenderMode.Professional>|

3. In the Windows Forms Designer, click the <xref:System.Windows.Forms.ToolStrip> control's **Add** button and add a <xref:System.Windows.Forms.ToolStripButton> to the `stackStrip` control.

4. In the **Properties** window, set the <xref:System.Windows.Forms.ToolStripButton> control's properties according to the following table.

    |Property|Value|
    |--------------|-----------|
    |Name|`mailStackButton`|
    |CheckOnClick|true|
    |CheckState|<xref:System.Windows.Forms.CheckState.Checked>|
    |DisplayStyle|<xref:System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText>|
    |ImageAlign|<xref:System.Drawing.ContentAlignment.MiddleLeft>|
    |ImageScaling|<xref:System.Windows.Forms.ToolStripItemImageScaling.None>|
    |ImageTransparentColor|`238, 238, 238`|
    |Margin|`0, 0, 0, 0`|
    |Padding|`3, 3, 3, 3`|
    |Text|**Mail**|
    |TextAlign|<xref:System.Drawing.ContentAlignment.MiddleLeft>|

5. Repeat step 7 for three more <xref:System.Windows.Forms.ToolStripButton> controls.

     Name the controls `calendarStackButton`, `contactsStackButton`, and `tasksStackButton`. Set the value of the <xref:System.Windows.Forms.Control.Text%2A> property to **Calendar**, **Contacts**, and **Tasks**, respectively.

## Handle events

Two events are important to make the `StackView` control behave correctly. Handle the <xref:System.Windows.Forms.UserControl.Load> event to position the control correctly. Handle the <xref:System.Windows.Forms.ToolStripItem.Click> event for each <xref:System.Windows.Forms.ToolStripButton> to give the `StackView` control state behavior similar to the <xref:System.Windows.Forms.RadioButton> control.

1. In the Windows Forms Designer, select the `StackView` control.

2. In the **Properties** window, click **Events**.

3. Double-click the Load event to generate the `StackView_Load` event handler.

4. In the `StackView_Load` event handler, copy and paste the following code.

     [!code-csharp[System.Windows.Forms.ToolStrip.StackView#3](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#3)]
     [!code-vb[System.Windows.Forms.ToolStrip.StackView#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#3)]

5. In the Windows Forms Designer, select the `mailStackButton` control.

6. In the **Properties** window, click **Events**.

7. Double-click the Click event.

     The Windows Forms Designer generates the `mailStackButton_Click` event handler.

8. Rename the `mailStackButton_Click` event handler to `stackButton_Click`.

     For more information, see [Rename a code symbol refactoring](/visualstudio/ide/reference/rename).

9. Insert the following code into the `stackButton_Click` event handler.

     [!code-csharp[System.Windows.Forms.ToolStrip.StackView#4](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#4)]
     [!code-vb[System.Windows.Forms.ToolStrip.StackView#4](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#4)]

10. In the Windows Forms Designer, select the `calendarStackButton` control.

11. In the **Properties** window, set the Click event to the `stackButton_Click` event handler.

12. Repeat steps 10 and 11 for the `contactsStackButton` and `tasksStackButton` controls.

## Define icons

Each `StackView` button has an associated icon. For convenience, each icon is represented as a Base64-encoded string, which is deserialized before a <xref:System.Drawing.Bitmap> is created from it. In a production environment, you store bitmap data as a resource, and your icons appear in the Windows Forms Designer. For more information, see [How to: Add Background Images to Windows Forms](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/dff9f95f(v=vs.100)).

1. In the Code Editor, insert the following code into the `StackView` class definition. This code initializes the bitmaps for the <xref:System.Windows.Forms.ToolStripButton> icons.

     [!code-csharp[System.Windows.Forms.ToolStrip.StackView#2](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#2)]
     [!code-vb[System.Windows.Forms.ToolStrip.StackView#2](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#2)]

2. Add a call to the `InitializeImages` method in the `StackView` class constructor.

     [!code-csharp[System.Windows.Forms.ToolStrip.StackView#5](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#5)]
     [!code-vb[System.Windows.Forms.ToolStrip.StackView#5](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#5)]

## Implement a custom renderer

You can customize most elements of the `StackView` control my implementing a class that derives from the <xref:System.Windows.Forms.ToolStripRenderer> class. In this procedure, you will implement a <xref:System.Windows.Forms.ToolStripProfessionalRenderer> class that customizes the grip and draws gradient backgrounds for the <xref:System.Windows.Forms.ToolStripButton> controls.

1. Insert the following code into the `StackView` control definition.

     This is the definition for the `StackRenderer` class, which overrides the <xref:System.Windows.Forms.ToolStripRenderer.RenderGrip>, <xref:System.Windows.Forms.ToolStripRenderer.RenderToolStripBorder>, and <xref:System.Windows.Forms.ToolStripRenderer.RenderButtonBackground> methods to produce a custom appearance.

     [!code-csharp[System.Windows.Forms.ToolStrip.StackView#10](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#10)]
     [!code-vb[System.Windows.Forms.ToolStrip.StackView#10](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#10)]

2. In the `StackView` control's constructor, create a new instance of the `StackRenderer` class and assign this instance to the `stackStrip` control's <xref:System.Windows.Forms.ToolStrip.Renderer%2A> property.

     [!code-csharp[System.Windows.Forms.ToolStrip.StackView#5](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#5)]
     [!code-vb[System.Windows.Forms.ToolStrip.StackView#5](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#5)]

## Test the StackView control

The `StackView` control derives from the <xref:System.Windows.Forms.UserControl> class. Therefore, you can test the control with the **UserControl Test Container**. For more information, see [How to: Test the Run-Time Behavior of a UserControl](how-to-test-the-run-time-behavior-of-a-usercontrol.md).

1. Press **F5** to build the project and start the **UserControl Test Container**.

2. Move the pointer over the buttons of the `StackView` control, and then click a button to see the appearance of its selected state.

## Next steps

In this walkthrough, you have created a reusable custom client control with the professional appearance of an Office XP control. You can use the <xref:System.Windows.Forms.ToolStrip> family of controls for many other purposes:

- Create shortcut menus for your controls with <xref:System.Windows.Forms.ContextMenuStrip>. For more information, see [ContextMenu Component Overview](contextmenu-component-overview-windows-forms.md).

- Create a form with an automatically populated standard menu. For more information, see [Walkthrough: Providing Standard Menu Items to a Form](walkthrough-providing-standard-menu-items-to-a-form.md).

- Create a multiple document interface (MDI) form with docking <xref:System.Windows.Forms.ToolStrip> controls. For more information, see [How to: Create an MDI Form with Menu Merging and ToolStrip Controls](how-to-create-an-mdi-form-with-menu-merging-and-toolstrip-controls.md).

## See also

- <xref:System.Windows.Forms.MenuStrip>
- <xref:System.Windows.Forms.ToolStrip>
- <xref:System.Windows.Forms.StatusStrip>
- [ToolStrip Control](toolstrip-control-windows-forms.md)
- [How to: Provide Standard Menu Items to a Form](how-to-provide-standard-menu-items-to-a-form.md)
