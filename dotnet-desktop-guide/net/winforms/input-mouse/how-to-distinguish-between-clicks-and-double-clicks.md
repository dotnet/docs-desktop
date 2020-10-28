---
title: "How to distinguish between single and double clicks"
description: Describes different ways to detect the difference between a single or double click with a control or form for Windows Forms for .NET.
ms.date: 10/26/2020
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "mouse [Windows Forms], click"
  - "mouse [Windows Forms], double-click"
  - "mouse clicks [Windows Forms], single versus double"
---
# How to distinguish between clicks and double-clicks (Windows Forms .NET)

Typically, a single *click* initiates a user interface action and a *double-click* extends the action. For example, one click usually selects an item, and a double-click edits the selected item. However, the Windows Forms click events do not easily accommodate a scenario where a click and a double-click perform incompatible actions, because an action tied to the <xref:System.Windows.Forms.Control.Click> or <xref:System.Windows.Forms.Control.MouseClick> event is performed before the action tied to the <xref:System.Windows.Forms.Control.DoubleClick> or <xref:System.Windows.Forms.Control.MouseDoubleClick> event. This topic demonstrates two solutions to this problem.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

One solution is to handle the double-click event and roll back the actions in the handling of the click event. In rare situations you may need to simulate click and double-click behavior by handling the <xref:System.Windows.Forms.Control.MouseDown> event and by using the <xref:System.Windows.Forms.SystemInformation.DoubleClickTime%2A> and <xref:System.Windows.Forms.SystemInformation.DoubleClickSize%2A> properties of the <xref:System.Windows.Forms.SystemInformation> class. You measure the time between clicks and if a second click occurs before the value of <xref:System.Windows.Forms.SystemInformation.DoubleClickTime%2A> is reached and the click is within a rectangle defined by <xref:System.Windows.Forms.SystemInformation.DoubleClickSize%2A>, perform the double-click action; otherwise, perform the click action.

## To roll back a click action

Ensure that the control you are working with has standard double-click behavior. If not, enable the control with the <xref:System.Windows.Forms.Control.SetStyle%2A> method. Handle the double-click event and roll back the click action as well as the double-click action. The following code example demonstrates a how to create a custom button with double-click enabled, as well as how to roll back the click action in the double-click event handling code.

This code example uses a new button control that enables double-clicks:

:::code language="csharp" source="snippets/how-to-distinguish-between-clicks-and-double-clicks/csharp/DoubleClickButton.cs" id="DoubleClickButton":::
:::code language="vb" source="snippets/how-to-distinguish-between-clicks-and-double-clicks/vb/DoubleClickButton.vb" id="DoubleClickButton":::

The following code demonstrates how a form changes the style of border based on a click or double-click of the new button control:

:::code language="csharp" source="snippets/how-to-distinguish-between-clicks-and-double-clicks/csharp/Form1.cs" id="RollbackForm":::
:::code language="vb" source="snippets/how-to-distinguish-between-clicks-and-double-clicks/vb/Form1.vb" id="RollbackForm":::

## To distinguish between clicks

Handle the <xref:System.Windows.Forms.Control.MouseDown> event and determine the location and time span between clicks using the <xref:System.Windows.Forms.SystemInformation> property and a <xref:System.Windows.Forms.Timer> component. Perform the appropriate action depending on whether a click or double-click takes place. The following code example demonstrates how this can be done.

:::code language="csharp" source="snippets/how-to-distinguish-between-clicks-and-double-clicks/csharp/Form2.cs":::
:::code language="vb" source="snippets/how-to-distinguish-between-clicks-and-double-clicks/vb/Form2.vb":::

## See also

- [Overview of using the mouse (Windows Forms .NET)](overview.md)
- [Using mouse events (Windows Forms .NET)](events.md)
- [Manage mouse pointers (Windows Forms .NET)](how-to-manage-cursor-pointer.md)
- [How to simulate mouse events (Windows Forms .NET)](how-to-simulate-events.md)
- <xref:System.Windows.Forms.Control.Click?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.MouseDown?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.SetStyle%2A?displayProperty=nameWithType>
