---
title: "How to: Create a Windows Explorer–Style Interface on a Windows Form"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Explorer [Windows Forms], creating with Windows Forms"
  - "SplitContainer control [Windows Forms], Explorer-style interface"
  - "forms [Windows Forms], Windows Explorer type"
ms.assetid: 9a3d5f4f-5dda-4350-9ad5-57ce5976dc47
---
# How to: Create a Windows Explorer–Style Interface on a Windows Form
Windows Explorer is a common user-interface choice for applications because of its ready familiarity.

 Windows Explorer is, essentially, a <xref:System.Windows.Forms.TreeView> control and a <xref:System.Windows.Forms.ListView> control on separate panels. The panels are made resizable by a splitter. This arrangement of controls is very effective for displaying and browsing information.

 The following steps show how to arrange controls in a Windows Explorer-like form. They do not show how to add the file-browsing functionality of the Windows Explorer application.

## To create a Windows Explorer-style Windows Form

1. Create a new Windows Application project (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **Windows Forms Application**).

2. From the **Toolbox**:

    1. Drag a <xref:System.Windows.Forms.SplitContainer> control onto your form.

    2. Drag a <xref:System.Windows.Forms.TreeView> control into **SplitterPanel1** (the panel of the <xref:System.Windows.Forms.SplitContainer> control marked **Panel1**).

    3. Drag a <xref:System.Windows.Forms.ListView> control into **SplitterPanel2** (the panel of the <xref:System.Windows.Forms.SplitContainer> control marked **Panel2**).

3. Select all three controls by pressing the CTRL key and clicking them in turn. When you select the <xref:System.Windows.Forms.SplitContainer> control, click the splitter bar, rather than the panels.

    > [!NOTE]
    > Do not use the **Select All** command on the **Edit** menu. If you do so, the property needed in the next step will not appear in the **Properties** window.

4. In the **Properties** window, set the <xref:System.Windows.Forms.SplitContainer.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.

5. Press F5 to run the application.

     The form displays a two-part user interface, similar to that of the Windows Explorer.

    > [!NOTE]
    > When you drag the splitter, the panels resize themselves.

## See also

- <xref:System.Windows.Forms.SplitContainer>
- [How to: Create a Multipane User Interface with Windows Forms](how-to-create-a-multipane-user-interface-with-windows-forms.md)
- [How to: Define Resize and Positioning Behavior in a Split Window](how-to-define-resize-and-positioning-behavior-in-a-split-window.md)
- [How to: Split a Window Horizontally](how-to-split-a-window-horizontally.md)
- [SplitContainer Control](splitcontainer-control-windows-forms.md)
