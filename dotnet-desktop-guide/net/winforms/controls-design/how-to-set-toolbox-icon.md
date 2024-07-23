---
title: How to set the toolbox icon
description: Learn how to assign your control's icon. The icon appears in the Visual Studio Toolbox.
ms.date: 07/20/2023
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Toolbox [Windows Forms], adding bitmaps for custom controls"
  - "custom controls [Windows Forms], Toolbox bitmaps"
  - "bitmaps [Windows Forms], custom controls"
---

# Set the icon of a control in the Toolbox (Windows Forms .NET)

Controls that you create always receive a generic icon for the **Toolbox** window in Visual Studio. However, when you change the icon, it adds a sense of professionalism to your control, and makes it stand out in the toolbox. This article teaches you how to set the icon for your control.

## Bitmap icon

Icons for the **Toolbox** window in Visual Studio must conform to certain standards, otherwise they're ignored or are displayed incorrectly.

- **Size**: Icons for a control must be a 16x16 bitmap image.
- **File type**: The icon can be either a Bitmap (_.bmp_) or a Windows Icon (_.ico_) file.
- **Transparency**: The magenta color (RGB: `255,0,255`, Hex: `0xFF00FF`) is rendered transparent.
- **Themes**: Visual Studio has multiple themes, but each theme is considered either dark or light. Your icon should be designed for the light theme. When Visual Studio uses a dark theme, the dark and light colors in the icon are automatically inverted.

## How to assign an icon

Icons are assigned to a control with the <xref:System.Drawing.ToolboxBitmapAttribute> attribute. For more information about attributes, see [Attributes (C#)](/dotnet/csharp/programming-guide/concepts/attributes/index) or [Attributes overview (Visual Basic)](/dotnet/visual-basic/programming-guide/concepts/attributes/index).

> [!TIP]
> You can download a sample icon from [GitHub](https://github.com/dotnet/docs-desktop/blob/main/dotnet-desktop-guide/net/winforms/controls-design/media/how-to-set-toolbox-icon/CompassRose.bmp).

The attribute is set on the control's class, and has three different constructors:

- <xref:System.Drawing.ToolboxBitmapAttribute.%23ctor(System.Type)>&mdash;This constructor takes a single type reference, and from that type, tries to find an embedded resource to use as the icon.

  The type's <xref:System.Type.FullName> is used to look up an [embedded resource][embedded] in the assembly of that type, using the following format: `{project-name}.{namespace-path}.{type-name}{.bmp|.ico}`. For example, if the type `MyProject.MyNamespace.CompassRose` is referenced, the attribute looks for an embedded resource named `MyProject.MyNamespace.CompassRose.bmp` or `MyProject.MyNamespace.CompassRose.ico`.

  ```csharp
  // Looks for a CompassRose.bmp or CompassRose.ico embedded resource in the
  // same namespace as the CompassRose type.
  [ToolboxBitmap(typeof(CompassRose))]
  public partial class CompassRose : UserControl
  {
      // Code for the control
  }
  ```

  ```vb
  ' Looks for a CompassRose.bmp or CompassRose.ico embedded resource in the
  ' same namespace as the CompassRose type.
  <ToolboxBitmap(GetType(CompassRose))>
  Public Class CompassRose
      ' Code for the control
  End Class
  ```

- <xref:System.Drawing.ToolboxBitmapAttribute.%23ctor(System.Type,System.String)>&mdash;This constructor takes two parameters. The first parameter is a type, and the second is the namespace and name of the [embedded resource][embedded] in the assembly of that type.

  ```csharp
  // Loads the icon from the WinFormsApp1.Resources.CompassRose.bmp resource
  // in the assembly containing the type CompassRose
  [ToolboxBitmap(typeof(CompassRose), "WinFormsApp1.Resources.CompassRose.bmp")]
  public partial class CompassRose : UserControl
  {
      // Code for the control
  }
  ```

  ```vb
  ' Loads the icon from the WinFormsApp1.Resources.CompassRose.bmp resource
  ' in the assembly containing the type CompassRose
  <ToolboxBitmap(GetType(CompassRose), "WinFormsApp1.Resources.CompassRose.bmp")>
  Public Class CompassRose
      ' Code for the control
  End Class
  ```

- <xref:System.Drawing.ToolboxBitmapAttribute.%23ctor(System.String)>&mdash;This constructor takes a single string parameter, the absolute path to the icon file.

  ```csharp
  // Loads the icon from a file on disk
  [ToolboxBitmap(@"C:\Files\Resources\MyIcon.bmp")]
  public partial class CompassRose : UserControl
  {
      // Code for the control
  }
  ```

  ```vb
  ' Loads the icon from a file on disk
  <ToolboxBitmap("C:\Files\Resources\MyIcon.bmp")>
  Public Class CompassRose
      ' Code for the control
  End Class
  ```

[embedded]: /visualstudio/ide/build-actions
