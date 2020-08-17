---
title: Create a Multipane User Interface Using the Designer
ms.date: "03/30/2017"
helpviewer_keywords:
  - "user interface [Windows Forms], multipane"
  - "SplitContainer control [Windows Forms], using the designer"
  - "multipane user interface"
ms.assetid: c3f9294d-a26c-4198-9242-f237f55f7573
---
# How to: Create a Multipane User Interface with Windows Forms Using the Designer
In the following procedure, you will create a multipane user interface that is similar to the one used in Microsoft Outlook, with a **Folder** list, a **Messages** pane, and a **Preview** pane. This arrangement is achieved chiefly through docking controls with the form.

 When you dock a control, you determine which edge of the parent container a control is fastened to. Thus, if you set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Right>, the right edge of the control will be docked to the right edge of its parent control. Additionally, the docked edge of the control is resized to match that of its container control. For more information about how the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property works, see [How to: Dock Controls on Windows Forms](how-to-dock-controls-on-windows-forms.md).

 This procedure focuses on arranging the <xref:System.Windows.Forms.SplitContainer> and the other controls on the form, not on adding functionality to make the application mimic Microsoft Outlook.

 To create this user interface, you place all the controls within a <xref:System.Windows.Forms.SplitContainer> control, which contains a <xref:System.Windows.Forms.TreeView> control in the left-hand panel. The right-hand panel of the <xref:System.Windows.Forms.SplitContainer> control contains a second <xref:System.Windows.Forms.SplitContainer> control with a <xref:System.Windows.Forms.ListView> control above a <xref:System.Windows.Forms.RichTextBox> control. These <xref:System.Windows.Forms.SplitContainer> controls enable independent resizing of the other controls on the form. You can adapt the techniques in this procedure to craft custom user interfaces of your own.

## To create an Outlook-style user interface at design time

1. Create a new Windows Application project (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **Windows Forms Application**).

2. Drag a <xref:System.Windows.Forms.SplitContainer> control from the **Toolbox** to the form. In the **Properties** window, set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.

3. Drag a <xref:System.Windows.Forms.TreeView> control from the **Toolbox** to the left-hand panel of the <xref:System.Windows.Forms.SplitContainer> control. In the **Properties** window, set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Left> by clicking the left hand panel in the value editor shown when the down arrow is clicked.

4. Drag another <xref:System.Windows.Forms.SplitContainer> control from the **Toolbox**; place it in the right-hand panel of the <xref:System.Windows.Forms.SplitContainer> control you added to your form. In the **Properties** window, set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill> and the <xref:System.Windows.Forms.SplitContainer.Orientation%2A> property to <xref:System.Windows.Forms.Orientation.Horizontal>.

5. Drag a <xref:System.Windows.Forms.ListView> control from the **Toolbox** to the upper panel of the second <xref:System.Windows.Forms.SplitContainer> control you added to your form. Set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property of the <xref:System.Windows.Forms.ListView> control to <xref:System.Windows.Forms.DockStyle.Fill>.

6. Drag a <xref:System.Windows.Forms.RichTextBox> control from the **Toolbox** to the lower panel of the second <xref:System.Windows.Forms.SplitContainer> control. Set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property of the <xref:System.Windows.Forms.RichTextBox> control to <xref:System.Windows.Forms.DockStyle.Fill>.

     At this point, if you press F5 to run the application, the form displays a three-part user interface, similar to that of Microsoft Outlook.

    > [!NOTE]
    > When you put the mouse pointer over either of the splitters within the <xref:System.Windows.Forms.SplitContainer> controls, you can resize the internal dimensions.

At this point in application development, you have crafted a sophisticated user interface. The next step is proceeding with the programming of the application itself, perhaps by connecting the <xref:System.Windows.Forms.TreeView> control and <xref:System.Windows.Forms.ListView> controls to some kind of data source. For more information about connecting controls to data, see [Data Binding and Windows Forms](../data-binding-and-windows-forms.md).

## See also

- <xref:System.Windows.Forms.SplitContainer>
- [SplitContainer Control](splitcontainer-control-windows-forms.md)
