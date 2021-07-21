---
title: Control layout options
description: Learn about the different settings on a control that affect layout and positioning in Windows Forms for .NET. Learn about the different types of control containers that affect layout.
ms.date: 07/19/2021
ms.topic: overview
helpviewer_keywords: 
  - "forms [Windows Forms], aligning controls"
  - "Windows Forms, aligning controls"
  - "controls [Windows Forms], positioning"
  - "controls [Windows Forms], aligning"
  - "TabControl control [Windows Forms], about TabControl control"
  - "SplitContainer control [Windows Forms], about SplitContainer control"
  - "Panel control [Windows Forms], about Panel control"
  - "GroupBox control [Windows Forms], about GroupBox control"
  - "FlowLayoutPanel control [Windows Forms], about FlowLayoutPanel control"
  - "TableLayoutPanel control [Windows Forms], about TableLayoutPanel control"
  - "sizing [Windows Forms], automatic"
  - "layout [Windows Forms], AutoSize"
  - "automatic sizing"
  - "AutoSizeMode property"
---

# Position and layout of controls (Windows Forms .NET)

Control placement in Windows Forms is determined not only by the control, but also by the parent of the control. This article describes the different settings provided by controls and the different types of parent containers that affect layout.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Fixed position and size

The position a control appears on a parent is determined by the value of the <xref:System.Windows.Forms.Control.Location> property relative to the top-left of the parent surface. The top-left position coordinate in the parent is `(x0,y0)`. The size of the control is determined by the <xref:System.Windows.Forms.Control.Size> property and represents the width and height of the control.

:::image type="content" source="media/layout/location+container.png" alt-text="Location of the control relative to the container":::

When a control is added to a parent that enforces automatic placement, the position and size of the control is changed. In this case, the position and size of the control may not be manually adjusted, depending on the type of parent.

The <xref:System.Windows.Forms.Control.MaximumSize%2A> and <xref:System.Windows.Forms.Control.MinimumSize%2A> properties help set the minimum and maximum space a control can use.

## Margin and Padding

There are two control properties that help with precise placement of controls: <xref:System.Windows.Forms.Control.Margin%2A> and <xref:System.Windows.Forms.Control.Padding%2A>.

The <xref:System.Windows.Forms.Control.Margin%2A> property defines the space around the control that keeps other controls a specified distance from the control's borders.

The <xref:System.Windows.Forms.Control.Padding%2A> property defines the space in the interior of a control that keeps the control's content (for example, the value of its <xref:System.Windows.Forms.Control.Text%2A> property) a specified distance from the control's borders.

The following figure shows the <xref:System.Windows.Forms.Control.Margin%2A> and <xref:System.Windows.Forms.Control.Padding%2A> properties on a control.

:::image type="content" source="media/layout/margin-padding.png" alt-text="Padding and Margin properties for Windows Forms Controls":::

The Visual Studio Designer will respect these properties when you're positioning and resizing controls. Snaplines appear as guides to help you remain outside the specified margin of a control. For example, Visual Studio displays the snapline when you drag a control next to another control:

:::image type="content" source="media/layout/margins.gif" alt-text="Animated image demonstrating the snaplines with margin properties for Windows Forms .NET in Visual Studio":::

## Automatic placement and size

Controls can be automatically placed within their parent. Some parent containers force placement while others respect control settings that guide placement. There are two properties on a control that help automatic placement and size within a parent: <xref:System.Windows.Forms.Control.Dock%2A> and <xref:System.Windows.Forms.Control.Anchor>.

Drawing order can affect automatic placement. The order in which a control is drawn determined by the control's index in the parent's <xref:System.Windows.Forms.Control.Controls> collection. This index is known as the **:::no-loc text="Z-order":::**. Each control is drawn in the reverse order they appear in the collection. Meaning, the collection is a first-in-last-drawn and last-in-first-drawn collection.

The <xref:System.Windows.Forms.Control.MinimumSize%2A> and <xref:System.Windows.Forms.Control.MaximumSize%2A> properties help set the minimum and maximum space a control can use.

### Dock

The `Dock` property sets which border of the control is aligned to the corresponding side of the parent, and how the control is resized within the parent.

:::image type="content" source="media/layout/dock-modes.png" alt-text="Windows form with buttons with dock settings.":::

When a control is docked, the container determines the space it should occupy and resizes and places the control. The width and height of the control are still respected based on the docking style. For example, if the control is docked to the top, the <xref:System.Windows.Forms.Control.Height> of the control is respected but the <xref:System.Windows.Forms.Control.Width> is automatically adjusted. If a control is docked to the left, the <xref:System.Windows.Forms.Control.Width> of the control is respected but the <xref:System.Windows.Forms.Control.Height> is automatically adjusted.

The <xref:System.Windows.Forms.Control.Location> of the control can't be manually set as docking a control automatically controls its position.

The **:::no-loc text="Z-order":::** of the control does affect docking. As docked controls are laid out, they use what space is available to them. For example, if a control is drawn first and docked to the top, it will take up the entire width of the container. If a next control is docked to the left, it has less vertical space available to it.

:::image type="content" source="media/layout/dock-top-then-left.png" alt-text="Windows form with buttons docked to the left and top with top being bigger.":::

If the control's **:::no-loc text="Z-order":::** is reversed, the control that is docked to the left now has more initial space available. The control uses the entire height of the container. The control that is docked to the top has less horizontal space available to it.

:::image type="content" source="media/layout/dock-left-then-top.png" alt-text="Windows form with buttons docked to the left and top with left being bigger.":::

As the container grows and shrinks, the controls docked to the container are repositioned and resized to maintain their applicable positions and sizes.

:::image type="content" source="media/layout/dock-resize.gif" alt-text="Animation showing how A Windows Form with buttons docked in all positions is resized.":::

If multiple controls are docked to the same side of the container, they're stacked according to their **:::no-loc text="Z-order":::**.

:::image type="content" source="media/layout/dock-left-left.png" alt-text="Windows form with two buttons docked to the left.":::

### Anchor

Anchoring a control allows you to tie the control to one or more sides of the parent container. As the container changes in size, any child control will maintain its distance to the anchored side.

A control can be anchored to one or more sides, without restriction. The anchor is set with the <xref:System.Windows.Forms.Control.Anchor> property.

:::image type="content" source="media/layout/anchor-resize.gif" alt-text="Animation showing how A Windows Form with buttons anchored in all positions is resized.":::

### Automatic sizing

The <xref:System.Windows.Forms.Control.AutoSize> property enables a control to change its size, if necessary, to fit the size specified by the <xref:System.Windows.Forms.Control.PreferredSize> property. You adjust the sizing behavior for specific controls by setting the `AutoSizeMode` property.

Only some controls support the <xref:System.Windows.Forms.Control.AutoSize%2A> property. In addition, some controls that support the <xref:System.Windows.Forms.Control.AutoSize%2A> property also supports the `AutoSizeMode` property.

| Always true behavior | Description |
|--|--|
| Automatic sizing is a run-time feature. | This means it never grows or shrinks a control and then has no further effect. |
| If a control changes size, the value of its <xref:System.Windows.Forms.Control.Location%2A> property always remains constant. | When a control's contents cause it to grow, the control grows toward the right and downward. Controls do not grow to the left. |
| The <xref:System.Windows.Forms.Control.Dock%2A> and <xref:System.Windows.Forms.Control.Anchor%2A> properties are honored when <xref:System.Windows.Forms.Control.AutoSize%2A> is `true`. | The value of the control's <xref:System.Windows.Forms.Control.Location%2A> property is adjusted to the correct value.<br /><br /> The <xref:System.Windows.Forms.Label> control is the exception to this rule. When you set the value of a docked <xref:System.Windows.Forms.Label> control's <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`, the <xref:System.Windows.Forms.Label> control will not stretch. |
| A control's <xref:System.Windows.Forms.Control.MaximumSize%2A> and <xref:System.Windows.Forms.Control.MinimumSize%2A> properties are always honored, regardless of the value of its <xref:System.Windows.Forms.Control.AutoSize%2A> property. | The <xref:System.Windows.Forms.Control.MaximumSize%2A> and <xref:System.Windows.Forms.Control.MinimumSize%2A> properties are not affected by the <xref:System.Windows.Forms.Control.AutoSize%2A> property. |
| There is no minimum size set by default. | This means that if a control is set to shrink under <xref:System.Windows.Forms.Control.AutoSize%2A> and it has no contents, the value of its <xref:System.Windows.Forms.Control.Size%2A> property is `(0x,0y)`. In this case, your control will shrink to a point, and it will not be readily visible. |
| If a control does not implement the <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method, the <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method returns last value assigned to the <xref:System.Windows.Forms.Control.Size%2A> property. | This means that setting <xref:System.Windows.Forms.Control.AutoSize%2A> to `true` will have no effect. |
| A control in a <xref:System.Windows.Forms.TableLayoutPanel> cell always shrinks to fit in the cell until its <xref:System.Windows.Forms.Control.MinimumSize%2A> is reached. | This size is enforced as a maximum size. This is not the case when the cell is part of an <xref:System.Windows.Forms.SizeType.AutoSize> row or column. |

#### AutoSizeMode property

The <xref:System.Windows.Forms.AutoSizeMode> property provides more fine-grained control over the default <xref:System.Windows.Forms.Control.AutoSize%2A> behavior. The `AutoSizeMode` property specifies how a control sizes itself to its content. The content, for example, could be the text for a <xref:System.Windows.Forms.Button> control or the child controls for a container.

The following list shows the `AutoSizeMode` values and its behavior.

- <xref:System.Windows.Forms.AutoSizeMode.GrowAndShrink?displayProperty=nameWithType>

  The control grows or shrinks to encompass its contents.

  The <xref:System.Windows.Forms.Control.MinimumSize%2A> and <xref:System.Windows.Forms.Control.MaximumSize%2A> values are honored, but the current value of the <xref:System.Windows.Forms.Control.Size%2A> property is ignored.

  This is the same behavior as controls with the <xref:System.Windows.Forms.Control.AutoSize%2A> property and no `AutoSizeMode` property.

- <xref:System.Windows.Forms.AutoSizeMode.GrowOnly?displayProperty=nameWithType>

  The control grows as much as necessary to encompass its contents, but it will not shrink smaller than the value specified by its <xref:System.Windows.Forms.Control.Size%2A> property.

  This is the default value for `AutoSizeMode`.

#### Controls that support the AutoSize property

The following table describes the level of auto sizing support by control:

| Control                                      | `AutoSize` supported | `AutoSizeMode` supported |
|----------------------------------------------|----------------------|--------------------------|
| <xref:System.Windows.Forms.Button>           | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.CheckedListBox>   | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.FlowLayoutPanel>  | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.Form>             | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.GroupBox>         | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.Panel>            | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.TableLayoutPanel> | ✔️                  | ✔️                       |
| <xref:System.Windows.Forms.CheckBox>         | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.DomainUpDown>     | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.Label>            | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.LinkLabel>        | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.MaskedTextBox>    | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.NumericUpDown>    | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.RadioButton>      | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.TextBox>          | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.TrackBar>         | ✔️                  | ❌                        |
| <xref:System.Windows.Forms.CheckedListBox>   | ❌                   | ❌                        |
| <xref:System.Windows.Forms.ComboBox>         | ❌                   | ❌                        |
| <xref:System.Windows.Forms.DataGridView>     | ❌                   | ❌                        |
| <xref:System.Windows.Forms.DateTimePicker>   | ❌                   | ❌                        |
| <xref:System.Windows.Forms.ListBox>          | ❌                   | ❌                        |
| <xref:System.Windows.Forms.ListView>         | ❌                   | ❌                        |
| <xref:System.Windows.Forms.MaskedTextBox>    | ❌                   | ❌                        |
| <xref:System.Windows.Forms.MonthCalendar>    | ❌                   | ❌                        |
| <xref:System.Windows.Forms.ProgressBar>      | ❌                   | ❌                        |
| <xref:System.Windows.Forms.PropertyGrid>     | ❌                   | ❌                        |
| <xref:System.Windows.Forms.RichTextBox>      | ❌                   | ❌                        |
| <xref:System.Windows.Forms.SplitContainer>   | ❌                   | ❌                        |
| <xref:System.Windows.Forms.TabControl>       | ❌                   | ❌                        |
| <xref:System.Windows.Forms.TabPage>          | ❌                   | ❌                        |
| <xref:System.Windows.Forms.TreeView>         | ❌                   | ❌                        |
| <xref:System.Windows.Forms.WebBrowser>       | ❌                   | ❌                        |
| <xref:System.Windows.Forms.ScrollBar>        | ❌                   | ❌                        |

#### AutoSize in the design environment

The following table describes the sizing behavior of a control at design time, based on the value of its <xref:System.Windows.Forms.Control.AutoSize%2A> and `AutoSizeMode` properties.

Override the <xref:System.Windows.Forms.Design.ControlDesigner.SelectionRules%2A> property to determine whether a given control is in a user-resizable state. In the following table, "can't resize" means <xref:System.Windows.Forms.Design.SelectionRules.Moveable> only, "can resize" means <xref:System.Windows.Forms.Design.SelectionRules.AllSizeable> and <xref:System.Windows.Forms.Design.SelectionRules.Moveable>.

| `AutoSize` setting | `AutoSizeMode` setting                                 | Behavior |
|--------------------|--------------------------------------------------------|----------|
| `true`             | Property not available.                                | The user can't resize the control at design time, except for the following controls:<br /><br /> -   <xref:System.Windows.Forms.TextBox><br />-   <xref:System.Windows.Forms.MaskedTextBox><br />-   <xref:System.Windows.Forms.RichTextBox><br />-   <xref:System.Windows.Forms.TrackBar> |
| `true`             | <xref:System.Windows.Forms.AutoSizeMode.GrowAndShrink> | The user can't resize the control at design time.                                                                                                                                                                                                                                          |
| `true`             | <xref:System.Windows.Forms.AutoSizeMode.GrowOnly>      | The user can resize the control at design time. When the <xref:System.Windows.Forms.Control.Size%2A> property is set, the user can only increase the size of the control.                                                                                                                   |
| `false` or `AutoSize` is hidden | Not applicable.                           | User can resize the control at design time.                                                                                                                                                                                                                                                 |

> [!NOTE]
> To maximize productivity, the Windows Forms Designer in Visual Studio shadows the <xref:System.Windows.Forms.Control.AutoSize%2A> property for the <xref:System.Windows.Forms.Form> class. At design time, the form behaves as though the <xref:System.Windows.Forms.Control.AutoSize%2A> property is set to `false`, regardless of its actual setting. At runtime, no special accommodation is made, and the <xref:System.Windows.Forms.Control.AutoSize%2A> property is applied as specified by the property setting.

## Container: Form

The <xref:System.Windows.Forms.Form> is the main object of Windows Forms. A Windows Forms application will usually have a form displayed at all times. Forms contain controls and respect  the <xref:System.Windows.Forms.Control.Location> and <xref:System.Windows.Forms.Control.Size> properties of the control for manual placement. Forms also respond to the [Dock](#dock) property for automatic placement.

Most of the time a form will have grips on the edges that allow the user to resize the form. The <xref:System.Windows.Forms.Control.Anchor> property of a control will let the control grow and shrink as the form is resized.

## Container: Panel

The <xref:System.Windows.Forms.Panel> control is similar to a form in that it simply groups controls together. It supports the same manual and automatic placement styles that a form does. For more information, see the [Container: Form](#container-form) section.

A panel blends in seamlessly with the parent, and it does cut off any area of a control that falls out of bounds of the panel. If a control falls outside the bounds of the panel and <xref:System.Windows.Forms.Form.AutoScroll> is set to `true`, scroll bars appear and the user can scroll the panel.

Unlike the [group box](#container-group-box) control, a panel doesn't have a caption and border.

:::image type="content" source="media/layout/panel-groupbox.png" alt-text="A Windows Form with a panel and group box.":::

The image above has a panel with the <xref:System.Windows.Forms.Panel.BorderStyle%2A> property set to demonstrate the bounds of the panel.

## Container: Group box

The <xref:System.Windows.Forms.GroupBox> control provides an identifiable grouping for other controls. Typically, you use a group box to subdivide a form by function. For example, you may have a form representing personal information and the fields related to an address would be grouped together. At design time, it's easy to move the group box around along with its contained controls.

The group box supports the same manual and automatic placement styles that a form does. For more information, see the [Container: Form](#container-form) section. A group box also cuts off any portion of a control that falls out of bounds of the panel.

Unlike the [panel](#container-panel) control, a group box doesn't have the capability to scroll content and display scroll bars.

:::image type="content" source="media/layout/panel-groupbox.png" alt-text="A Windows Form with a panel and group box.":::

## Container: Flow Layout

The <xref:System.Windows.Forms.FlowLayoutPanel> control arranges its contents in a horizontal or vertical flow direction. You can wrap the control's contents from one row to the next, or from one column to the next. Alternately, you can clip instead of wrap its contents.  
  
You can specify the flow direction by setting the value of the <xref:System.Windows.Forms.FlowLayoutPanel.FlowDirection%2A> property. The <xref:System.Windows.Forms.FlowLayoutPanel> control correctly reverses its flow direction in Right-to-Left (RTL) layouts. You can also specify whether the <xref:System.Windows.Forms.FlowLayoutPanel> control's contents are wrapped or clipped by setting the value of the <xref:System.Windows.Forms.FlowLayoutPanel.WrapContents%2A> property.  

The <xref:System.Windows.Forms.FlowLayoutPanel> control automatically sizes to its contents when you set the <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`. It also provides a `FlowBreak` property to its child controls. Setting the value of the `FlowBreak` property to `true` causes the <xref:System.Windows.Forms.FlowLayoutPanel> control to stop laying out controls in the current flow direction and wrap to the next row or column.  

:::image type="content" source="media/layout/flow.png" alt-text="A Windows Form with two flow panel controls.":::

The image above has two `FlowLayoutPanel` controls with the <xref:System.Windows.Forms.Panel.BorderStyle> property set to demonstrate the bounds of the control.

## Container: Table layout

The <xref:System.Windows.Forms.TableLayoutPanel> control arranges its contents in a grid. Because the layout is done both at design time and run time, it can change dynamically as the application environment changes. This gives the controls in the panel the ability to resize proportionally, so they can respond to changes such as the parent control resizing or text length changing because of localization.

Any Windows Forms control can be a child of the <xref:System.Windows.Forms.TableLayoutPanel> control, including other instances of <xref:System.Windows.Forms.TableLayoutPanel>. This allows you to construct sophisticated layouts that adapt to changes at run time.

You can also control the direction of expansion (horizontal or vertical) after the <xref:System.Windows.Forms.TableLayoutPanel> control is full of child controls. By default, the <xref:System.Windows.Forms.TableLayoutPanel> control expands downward by adding rows.

You can control the size and style of the rows and columns by using the <xref:System.Windows.Forms.TableLayoutPanel.RowStyles%2A> and <xref:System.Windows.Forms.TableLayoutPanel.ColumnStyles%2A> properties. You can set the properties of rows or columns individually.

The <xref:System.Windows.Forms.TableLayoutPanel> control adds the following properties to its child controls: `Cell`, `Column`, `Row`, `ColumnSpan`, and `RowSpan`.

:::image type="content" source="media/layout/table.png" alt-text="A Windows Form with table layout control.":::

The image above has a table with the <xref:System.Windows.Forms.TableLayoutPanel.CellBorderStyle> property set to demonstrate the bounds of each cell.

## Container: Split container

The Windows Forms <xref:System.Windows.Forms.SplitContainer> control can be thought of as a composite control; it's two panels separated by a movable bar. When the mouse pointer is over the bar, the pointer changes shape to show that the bar is movable.  

With the <xref:System.Windows.Forms.SplitContainer> control, you can create complex user interfaces; often, a selection in one panel determines what objects are shown in the other panel. This arrangement is effective for displaying and browsing information. Having two panels lets you aggregate information in areas, and the bar, or "splitter," makes it easy for users to resize the panels.

:::image type="content" source="media/layout/splitcontainer.png" alt-text="A Windows Form with a nested split container.":::

The image above has a split container to create a left and right pane. The right pane contains a second split container with the <xref:System.Windows.Forms.SplitContainer.Orientation> set to <xref:System.Windows.Forms.Orientation.Vertical>. The <xref:System.Windows.Forms.SplitContainer.BorderStyle> property is set to demonstrate the bounds of each panel.

## Container: Tab control

The <xref:System.Windows.Forms.TabControl> displays multiple tabs, like dividers in a notebook or labels in a set of folders in a filing cabinet. The tabs can contain pictures and other controls. Use the tab control to produce the kind of multiple-page dialog box that appears many places in the Windows operating system, such as the Control Panel and Display Properties. Additionally, the <xref:System.Windows.Forms.TabControl> can be used to create property pages, which are used to set a group of related properties.

The most important property of the <xref:System.Windows.Forms.TabControl> is <xref:System.Windows.Forms.TabControl.TabPages%2A>, which contains the individual tabs. Each individual tab is a <xref:System.Windows.Forms.TabPage> object.

:::image type="content" source="media/layout/tabcontrol.png" alt-text="A Windows Form with a tab control with two tab pages.":::
