---
title: Visual Studio Design-time overview
description: Learn about what capabilities are available in Visual Studio for Windows Forms designer support with your custom controls.
ms.date: 06/01/2023
ms.topic: overview
no-loc: ["UserControl", "UserControl1", "UserControlProject", "Label", "Button", "Form", "TextBox"]
dev_langs:
- "csharp"
- "vb"
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

# Overview about Visual Studio design-time support for custom controls (Windows Forms .NET)

As you've noticed when interacting with the Windows Forms designer, there are many different design-time features offered by the Windows Forms controls. Some of the features offered by the Visual Studio Designer include snap lines, action items, and the property grid. All of these features offer you an easier way to interact and customize a control during design-time. This article is an overview about what kind of support you can add to your custom controls, to make the design-time experience better for the consumers of your controls.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## What's different from .NET Framework

Many basic design elements of custom controls have remained the same from .NET Framework. However, if you use more advanced designer customization features, such as action lists, type converters, custom dialogs, you have some unique scenarios to handle.

Visual Studio is a .NET Framework-based application, and as such, the Visual Designer you see for Windows Forms is also based on .NET Framework. With a .NET Framework project, both the Visual Studio environment and the Windows Forms app being designed run within the same process, **devenv.exe**. This poses a problem when you're working with a Windows Forms .NET (not .NET Framework) app. Both .NET and .NET Framework can't work within the same process. As a result, Windows Forms .NET uses a different designer, the "out-of-process" designer.

The out-of-process designer is a process called **DesignToolsServer.exe**, and is run along-side Visual Studio's **devenv.exe** process. The **DesignToolsServer.exe** process runs in the same version and platform, such as .NET 7 and x64, of .NET that your app is targeting. When your custom control needs to display UI in the **devenv.exe** your custom control must implement a client-server architecture to facilitate the communication to and from **devenv.exe**. For more information, see [The designer changes since .NET Framework (Windows Forms .NET)](designer-differences-framework.md).

## Property window

The Visual Studio **Properties** window displays the properties and events for the selected control or form. This is usually the first point of customization you perform on a custom control or component.

The following image shows a `Button` control selected in the Visual Designer, and the properties grid showing the button's properties:

:::image type="content" source="media/designer-overview/properties.png" alt-text="The Windows Forms designer in Visual Studio showing a button and the properties window":::

You can control some aspects of how information about your custom control appears in the properties grid. Attributes are applied either to the custom control class or class properties.

### Attributes for classes

The following table shows the attributes you can apply to specify the behavior of your custom controls and components at design time.

| Attribute                                               | Description                                                                 |
|---------------------------------------------------------|-----------------------------------------------------------------------------|
| <xref:System.ComponentModel.DefaultEventAttribute>      | Specifies the default event for a component.                                |
| <xref:System.ComponentModel.DefaultPropertyAttribute>   | Specifies the default property for a component.                             |
| <xref:System.ComponentModel.DesignerAttribute>          | Specifies the class used to implement design-time services for a component. |
| <xref:System.ComponentModel.DesignerCategoryAttribute>  | Specifies that the designer for a class belongs to a certain category.      |
| <xref:System.ComponentModel.ToolboxItemAttribute>       | Represents an attribute of a toolbox item.                                  |
| <xref:System.ComponentModel.ToolboxItemFilterAttribute> | Specifies the filter string and filter type to use for a Toolbox item.      |

### Attributes for properties

The following table shows the attributes you can apply to properties or other members of your custom controls and components.

| Attribute                                                  | Description                                                                                                                        |
|------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| <xref:System.ComponentModel.AmbientValueAttribute>         | Specifies the value to pass to a property to cause the property to get its value from another source. This is known as *ambience*. |
| <xref:System.ComponentModel.BrowsableAttribute>            | Specifies whether a property or event should be displayed in a **Properties** window.                                              |
| <xref:System.ComponentModel.CategoryAttribute>             | Specifies the name of the category in which to group the property or event when displayed in a <xref:System.Windows.Forms.PropertyGrid> control set to <xref:System.Windows.Forms.PropertySort.Categorized> mode. |
| <xref:System.ComponentModel.DefaultValueAttribute>         | Specifies the default value for a property.                   |
| <xref:System.ComponentModel.DescriptionAttribute>          | Specifies a description for a property or event.              |
| <xref:System.ComponentModel.DisplayNameAttribute>          | Specifies the display name for a property, event, or a public method that doesn't return a value and takes no arguments.                                 |
| <xref:System.ComponentModel.EditorAttribute>               | Specifies the editor to use to change a property.             |
| <xref:System.ComponentModel.EditorBrowsableAttribute>      | Specifies that a property or method is viewable in an editor. |
| <xref:System.ComponentModel.Design.HelpKeywordAttribute>   | Specifies the context keyword for a class or member.          |
| <xref:System.ComponentModel.LocalizableAttribute>          | Specifies whether a property should be localized.             |
| <xref:System.ComponentModel.PasswordPropertyTextAttribute> | Indicates that an object's text representation is hidden by characters such as asterisks.                                        |
| <xref:System.ComponentModel.ReadOnlyAttribute>             | Specifies whether the property this attribute is bound to is read-only or read/write at design time.                               |
| <xref:System.ComponentModel.RefreshPropertiesAttribute>    | Indicates that the property grid should refresh when the associated property value changes.                                        |
| <xref:System.ComponentModel.TypeConverterAttribute>        | Specifies what type to use as a converter for the object this attribute is bound to.                                               |

<!--
### Type editors
-->

## Custom control designers

The design-time experience for custom controls can be enhanced by authoring an associated custom designer. By default, your custom control is displayed on the host's design surface, and it looks the same as it does during run-time. With a custom designer you can enhance the design-time view of the control, add action items, snap lines, and other items, which can assist the user in determining how to lay out and configure the control. For example, at design-time the <xref:System.Windows.Forms.ToolStrip> designer adds extra controls for the user to add, remove, and configure the individual items, as demonstrated in the following image:

:::image type="content" source="media/designer-overview/custom-designer.png" alt-text="A Windows Forms designer in Visual Studio showing a split container's design-time view.":::

You can create your own custom designers by performing the following steps:

01. Adding reference to the [Microsoft.WinForms.Designer.SDK NuGet package](https://www.nuget.org/packages/Microsoft.WinForms.Designer.SDK).
01. Create a type inherits from the `Microsoft.DotNet.DesignTools.Designers.ControlDesigner` class.
01. In your user control class, mark the class with the <xref:System.ComponentModel.DesignerAttribute?displayProperty=fullName> class attribute, passing the type you created in the previous step.

For more information, see the [What's different from .NET Framework](#whats-different-from-net-framework) section.

## Action items

Designer actions are context-sensitive menus that allow the user to perform common tasks quickly. For example, if you add a <xref:System.Windows.Forms.TabControl> to a form, you're going to add and remove tabs to and from the control. Tabs are managed in the **Properties** window, through the <xref:System.Windows.Forms.TabControl.TabPages%2A> property, which displays a tab collection editor. Instead of forcing the user to always sift through the **Properties** list looking for the `TabPages` property, the `TabControl` provides a smart tag button that's only visible when the control is selected, as shown in the following images:

:::image type="content" source="media/designer-overview/action-collapsed.png" alt-text="The Windows Forms designer in Visual Studio showing a tab control's smart tag button.":::

When the smart tag is selected, the action list is displayed:

:::image type="content" source="media/designer-overview/action-expanded.png" alt-text="The Windows Forms designer in Visual Studio showing a tab control's smart tag button pressed, which displayed a list of actions.":::

By adding the **Add Tab** and **Remove Tab** actions, the control's designer makes it so that you can quickly add or remove a tab.

### Creating an action item list

Action item lists are provided by the `ControlDesigner` type you create. The following steps are a basic guide to creating your own action list:

01. Adding reference to the [Microsoft.WinForms.Designer.SDK NuGet package](https://www.nuget.org/packages/Microsoft.WinForms.Designer.SDK).
01. Create a new action list class that inherits from `Microsoft.DotNet.DesignTools.Designers.Actions.DesignerActionList`.
01. Add the properties to the action list you want the user to access. For example, adding a `bool` or `Boolean` (in Visual Basic) property to the class creates a <xref:System.Windows.Forms.CheckBox> control in the action list.
01. Follow the steps in the [Custom control designers](#custom-control-designers) section to create a new designer.
01. In the designer class, override the `ActionLists` property, which returns a `Microsoft.DotNet.DesignTools.Designers.Actions.DesignerActionListCollection` type.
01. Add your action list to a `DesignerActionListCollection` instance, and return it.

For an example of an action list, see the [Windows Forms Designer Extensibility Documents & Samples GitHub repository](https://github.com/microsoft/winforms-designer-extensibility), specifically the [`TileRepeater.Designer.Server/ControlDesigner`](https://github.com/microsoft/winforms-designer-extensibility/tree/main/Samples/TypeEditor/Dotnet/TileRepeater_Medium/TileRepeater.Designer.Server/ControlDesigner) folder.

<!--
## Drop-down type editors

In the **Properties** window, most properties are easily edited in the grid, such as when the property's backing type is an enumeration, boolean, or number.
-->

## Modal dialog type editors

In the **Properties** window, most properties are easily edited in the grid, such as when the property's backing type is an enumeration, boolean, or number.

:::image type="content" source="media/designer-overview/property-simple.png" alt-text="The Visual Studio Properties window for a Windows Forms app, showing the alignment property.":::

Sometimes, a property is more complex and requires a custom dialog that the user can use to change the property. For example, the <xref:System.Windows.Forms.Control.Font%2A> property is a [System.Drawing.Font](xref:System.Drawing.Font) type, which contains many properties that alter what the font looks like. This isn't easily presentable in the **Properties** window, so this property uses a custom dialog to edit the font:

:::image type="content" source="media/designer-overview/property-dialog.png" alt-text="The Visual Studio Font dialog for a Windows Forms app.":::

If your custom control properties are using the built-in type editors provided by Windows Forms, you can use the <xref:System.ComponentModel.EditorAttribute> to mark your properties with the corresponding .NET Framework editor you want Visual Studio to use. By using the built-in editors, you avoid the requirement of replicating the proxy-object client-server communication provided by the out-of-process designer.

When referencing a built-in type editor, use the .NET Framework type, not the .NET type:

```csharp
[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public string? Filename { get; set; }
```

```vb
<Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
Public Property Filename As String
```

<!--
## Designer-snap lines
-->
