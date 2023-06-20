---
title: User control overview
description: Learn about what a user control is in Windows Forms. A user control is a composite control that displays other controls as a group, and is interacted with as a single control.
ms.date: 06/01/2023
ms.topic: overview
no-loc: ["UserControl", "UserControl1", "UserControlProject", "Label", "Button", "Form", "TextBox"]
f1_keywords: 
  - "UserControl"
helpviewer_keywords: 
  - "controls [Windows Forms], user controls"
  - "controls [Windows Forms], types of"
  - "composite controls [Windows Forms]"
  - "extended controls [Windows Forms]"
  - "controls [Windows Forms], extended"
  - "user controls [Windows Forms]"
  - "custom controls [Windows Forms]"
  - "controls [Windows Forms], composite"
---

# User control overview (Windows Forms .NET)

A user control is a collection of Windows Forms controls encapsulated in a common container. This kind of control is referred to as a _composite control_. The contained controls are called _constituent controls_. User controls derive from the <xref:System.Windows.Forms.UserControl> class.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

User controls are designed like Forms, with a visual designer. You create, arrange, and modify, the constituent controls through the visual designer. The control events and logic are written exactly the same way as when you're designing a Form. The user control is placed on a Form just like any other control.

User controls are usable by the project in which they're created, or in other projects that have reference to the user control's library.

## Constituent controls

The constituent controls are available to the user control, and the app user can interact with them all individually at runtime, but the properties and methods declared by the constituent controls aren't exposed to the consumer. For example, if you place a `TextBox` and `Button` control on the user control, the button's `Click` event is handled internally by the user control, but not by the Form where the user control is placed.

## Add a user control to a project

After creating a new project, use the Visual Studio templates to create a user control. The following steps demonstrate how to add a user control to your project:

01. In Visual Studio, find the **Project Explorer** pane. Right-click on the project and choose **Add** > **User Control (Windows Forms)**.

    :::image type="content" source="media/usercontrol-overview/right-click.png" alt-text="Right-click the Visual Studio solution explorer to add a user control to a Windows Forms project":::

01. In the **Name** box, type a name for your user control. Visual Studio provides a default and unique name that you may use. Next, press **Add**.

    :::image type="content" source="media/usercontrol-overview/new-usercontrol-dialog.png" alt-text="Add item dialog in Visual Studio for Windows Forms":::

After the user control is created, Visual Studio opens the designer:

:::image type="content" source="media/usercontrol-overview/designer.png" alt-text="The user control designer in Visual Studio for Windows Forms":::

For an example of a working user control, see [How to create a user control](how-to-create-usercontrol.md).
