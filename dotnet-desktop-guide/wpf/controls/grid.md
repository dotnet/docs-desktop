---
title: "Grid"
description: Learn about the Grid control, which is a layout control that enables flexible positioning of child elements in rows and columns.
ms.date: 01/22/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "layout [WPF], Grid control"
  - "controls [WPF], Grid"
  - "Grid control [WPF]"
ai-usage: ai-assisted
---
# Grid

<xref:System.Windows.Controls.Grid> is a layout control that enables flexible positioning of child elements in rows and columns.

## Common tasks

The following table shows common tasks you can accomplish with the Grid control.

| Title | Description |
|-------|-------------|
| [Build a Standard UI Dialog Box by Using Grid](how-to-build-a-standard-ui-dialog-box-by-using-grid.md) | Learn how to create a standard dialog box layout using Grid. |
| [Create a Complex Grid](how-to-create-a-complex-grid.md) | Learn how to build sophisticated Grid layouts with multiple rows and columns. |
| [Create a Grid Element](how-to-create-a-grid-element.md) | Learn how to create and configure a Grid control. |
| [Create and Use a GridLengthConverter Object](how-to-create-and-use-a-gridlengthconverter-object.md) | Learn how to work with GridLengthConverter for dynamic sizing. |
| [Manipulate Columns and Rows by Using ColumnDefinitionsCollections and RowDefinitionsCollections](manipulate-columns-and-rows-by-using-columndefinitionscollections.md) | Learn how to programmatically manipulate grid structure. |
| [Position the Child Elements of a Grid](how-to-position-the-child-elements-of-a-grid.md) | Learn how to position and align elements within grid cells. |
| [Share Sizing Properties Between Grids](how-to-share-sizing-properties-between-grids.md) | Learn how to synchronize sizing between multiple Grid controls. |

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information about modifying a control's template, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The Grid control does not define a content property. It's a panel control that hosts child elements positioned using the <xref:System.Windows.Controls.Grid.Row>, <xref:System.Windows.Controls.Grid.Column>, <xref:System.Windows.Controls.Grid.RowSpan>, and <xref:System.Windows.Controls.Grid.ColumnSpan> attached properties.

## See also

- <xref:System.Windows.Controls.Panel>
- <xref:System.Windows.Controls.Canvas>
- <xref:System.Windows.Controls.DockPanel>
- <xref:System.Windows.Controls.Grid>
- <xref:System.Windows.Controls.StackPanel>
- <xref:System.Windows.Controls.VirtualizingStackPanel>
- <xref:System.Windows.Controls.WrapPanel>
- [Layout](../advanced/layout.md)
- [ScrollViewer Overview](scrollviewer-overview.md)
- [Walkthrough: My first WPF desktop application](../get-started/walkthrough-my-first-wpf-desktop-application.md)
