---
title: Designers changes from .NET Framework
description: Learn about the Windows Forms designer changes from .NET Framework to .NET.
ms.date: 06/01/2023
ms.topic: overview
no-loc: ["UserControl", "UserControl1", "UserControlProject", "Label", "Button", "Form", "TextBox"]
dev_langs:
- "csharp"
- "vb"
---

# The designer changes since .NET Framework (Windows Forms .NET)

The Visual Designer for Windows Forms for .NET has had some improvements and changes since .NET Framework. These changes largely affect custom control designers. This article describes the key differences from .NET Framework.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

Visual Studio is a .NET Framework-based application, and as such, the Visual Designer you see for Windows Forms is also based on .NET Framework. With a .NET Framework project, both the Visual Studio environment and the Windows Forms app being designed, run within the same process: **devenv.exe**. This poses a problem when you're working with a Windows Forms .NET (not .NET Framework) app. Both .NET and .NET Framework code can't work within the same process. As a result, Windows Forms .NET uses a different designer, the "out-of-process" designer.

## Out-of-process designer

The out-of-process designer is a process called **DesignToolsServer.exe**, and is run along-side Visual Studio's **devenv.exe** process. The **DesignToolsServer.exe** process runs on the same version and platform of .NET that your app has been set up to target, such as .NET 7 and x64.

In the Visual Studio designer, .NET Framework proxy objects are created for each component and control on the designer, which communicate with the real .NET objects from your project in the **DesignToolsServer.exe** designer.

## Control designers

For .NET, control designers need to be coded with the `Microsoft.WinForms.Designer.SDK` API, available on [NuGet](https://www.nuget.org/packages/Microsoft.WinForms.Designer.SDK). This library is a refactoring of the .NET Framework designers for .NET. All of the designer types have moved to different namespaces but the type names are mostly the same. To update your .NET Framework designers for .NET, you must adjust the namespaces a bit.

- Designer classes and other related types, such as `ControlDesigner` and `ComponentTray`, have moved from the `System.Windows.Forms.Design` namespace to the `Microsoft.DotNet.DesignTools.Designers` namespace.
- Action list-related types in the `System.ComponentModel.Design` namespace have moved to the `Microsoft.DotNet.DesignTools.Designers.Actions` namespace.
- Behavior-related types, such as adorners and snaplines, in the `System.Windows.Forms.Design.Behavior` namespace have moved to the `Microsoft.DotNet.DesignTools.Designers.Behaviors` namespace.

## Custom type editors

Custom type editors are more complicated than the control designers. Because the Visual Studio process is .NET Framework-based, any UI shown within the context of Visual Studio must be .NET Framework-based too. This design poses a problem, for example, when you're creating a .NET control that shows a custom type editor invoked by clicking on the `…` button in the property grid. The dialog can't be shown within the context of Visual Studio.

The out-of-process designer handles most of the control designer features, such as adorners, built-in type editors, and custom painting. Anytime you need to show a custom modal dialog, such as displaying new type editor, you need to replicate that proxy-object client-server communication that the out-of-process designer provides. This creates a lot more overhead than the old .NET Framework system.

If your custom control properties are using type editors provided by Windows Forms, you can use the <xref:System.ComponentModel.EditorAttribute> to mark your properties with the corresponding .NET Framework editor you want Visual Studio to use. By using the built-in editors, you avoid the requirement of replicating the proxy-object client-server communication provided by the out-of-process designer.

```csharp
[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public string? Filename { get; set; }
```

```vb
<Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
Public Property Filename As String
```

### Create a type editor

To create custom designers that provide type editors, you'll need a variety of projects, as described in the following list:

- `Control`: This project is your custom control library that contains the code for your controls. This is the library a user would reference when they want to use your controls.
- `Control.Client`: A Windows Forms for .NET Framework project that contains your custom designer UI dialogs.
- `Control.Server`: A Windows Forms for .NET project that contains the custom designer code for your controls.
- `Control.Protocol`: A .NET Standard project that contains the communication classes used both by the `Control.Client` and `Control.Server` projects.
- `Control.Package`: A NuGet package project that contains all of the other projects. This package is formatted in a way that lets the Visual Studio Windows Forms for .NET tooling host and use your control library and designers.

Even if your type editor derives from an existing editor, such as <xref:System.Drawing.Design.ColorEditor> or <xref:System.Windows.Forms.Design.FileNameEditor>, you still have to create that proxy-object client-server communication because you've provided a new UI class type that you want to display in the context of Visual Studio. However, the code to implement that type editor into Visual Studio is much simpler.

> [!IMPORTANT]
> Documentation that describes this scenario in detail is in progress. Until that documentation is published, use the following blog post and sample to guide you in creating, publishing, and using this project structure:
>
> - [Blog: Custom Controls for WinForm’s Out-Of-Process Designer](https://devblogs.microsoft.com/dotnet/custom-controls-for-winforms-out-of-process-designer/)
> - [TileRepeater control example](https://github.com/microsoft/winforms-designer-extensibility/tree/main/Samples/TypeEditor/Dotnet/TileRepeater_Medium)
