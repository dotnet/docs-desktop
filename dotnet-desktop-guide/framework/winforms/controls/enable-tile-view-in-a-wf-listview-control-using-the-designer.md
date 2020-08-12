---
title: Enable Tile View in ListView Control Using the Designer
ms.date: "03/30/2017"
helpviewer_keywords:
  - "tile view feature"
  - "ListView control [Windows Forms], tile view"
  - "tiling [Windows Forms], Windows Forms, controls"
ms.assetid: 12f0816a-52b8-41ee-a6d9-ded3a8a5817a
---
# How to: Enable Tile View in a Windows Forms ListView Control Using the Designer
The tile view feature of the <xref:System.Windows.Forms.ListView> control enables you to provide a visual balance between graphical and textual information. The textual information displayed for an item in tile view is the same as the column information defined for details view. Tile view functions in combination with either the grouping or insertion mark features in the <xref:System.Windows.Forms.ListView> control.

 The tile view uses a 32 x 32 icon and several lines of text, as shown in the following image.

 ![Tile View in a ListView Control](./media/enable-tile-view-in-a-wf-listview-control-using-the-designer/tile-view-in-listview-control.gif "Tile view icons and text")

 Tile view properties and methods enable you to specify which column fields to display for each item, and to collectively control the size and appearance of all items within a tile view window. For clarity, the first line of text in a tile is always the item's name; it cannot be changed.

 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ListView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

## To set tile view in the designer

1. In Visual Studio, select the <xref:System.Windows.Forms.ListView> control on your form.

2. In the **Properties** window, select the <xref:System.Windows.Forms.ListView.View%2A> property and choose **Tile**.

## See also

- <xref:System.Windows.Forms.ListView.TileSize%2A>
- [ListView Control Overview](listview-control-overview-windows-forms.md)
