---
title: Troubleshoot 32-bit problems
description: Describes how Visual Studio and Windows Forms may have problems with 32-bit components. Learn how to enable the out-of-process designer, which may help.
ms.date: 03/27/2024
ms.topic: troubleshooting 
#customer intent: As a developer I want to understand why 32-bit references are a problem so that I can fix my problems or upgrade Visual Studio
---

# Troubleshoot 32-bit problems (Windows Forms .NET)

After upgrading to Visual Studio 2022, you might run into a problem where the design-time experience of your app stops working. This could be related to referencing a 32-bit component. Visual Studio 2022 is a 64-bit process and can't load 32-bit components, regardless of the underlying technology, such as .NET Framework, .NET, or COM\ActiveX. You might not realize you have references to 32-bit components until you try to upgrade Visual Studio. References that compile to 64-bit or target `AnyCPU` continue to work. You'll also run into the same problem if a component you're referencing compiles to `AnyCPU` but happens to reference something 32-bit.

## What's the problem

Windows Forms code runs in two modes: design-time and run-time. At run-time, you're running in whatever mode you compiled for: 32-bit or 64-bit; .NET Framework or .NET. At design-time, your code is run inside Visual Studio, which is a 64-bit .NET Framework process. If your project code doesn't match that environment, it can't run in the designer. For example, if your project is targeting 32-bit .NET Framework or 64-bit .NET, it doesn't match Visual Studio's 64-bit .NET Framework process. And that's the problem: the Windows Forms designer in Visual Studio can't instantiate 32-bit components or .NET components directly, it can only instantiate 64-bit .NET Framework components. To fix these integration issues, the Windows Forms team created the **out-of-process designer** for Visual Studio that acts like a translation layer for the Windows Forms designer. The out-of-process designer communicates with the Visual Studio 64-bit .NET Framework designer on behalf of your code so that you can use the designer with .NET projects.

Previous versions of Visual Studio targeted 32-bit, and your project probably compiled to `AnyCPU`, which would pick 32-bit while in design mode to match Visual Studio. 32-bit specific references worked, but if you had a 64-bit specific reference, you might have run into a problem with the designer. With Visual Studio 2022, the problem reversed. Visual Studio 2022 is only available in 64-bit. Components and libraries that were compiled as `AnyCPU` work in both 32-bit and 64-bit and don't have an issue running in Visual Studio 2022 64-bit. But, after upgrading to Visual Studio 2022, your projects might fail to run at design-time if the project relies on a 32-bit specific component. This is even the case when your referenced component is compiled for `AnyCPU`, but happens to reference a 32-bit component or 32-bit COM\ActiveX library directly.

To summarize, 32-bit components can't be used by the Windows Forms designer in Visual Studio 2022, which is a 64-bit app. The **out-of-process designer** was created to help Windows Forms for .NET apps during design-time for both 32-bit and 64-bit. This designer now helps with loading 32-bit and 64-bit .NET Framework components.

## What can you do

There are a few design changes you should consider, which might help your project.

- Upgrade from .NET Framework to .NET 8+.

  .NET uses the out-of-process designer, which helps with 32-bit designer problems.

- With .NET Framework, set your app to target `AnyCPU`.

  If you target `AnyCPU` and enable `Prefer 32-bit`, your app runs under 64-bit when in Visual Studio design-time, but compiles to 32-bit for run-time.

- Recompile the 32-bit component for `AnyCPU` or 64-bit.

  If you have access to the source code for the 32-bit component, try compiling it for `AnyCPU` or 64-bit and reference that new version.

- Find a 64-bit alternative component.

  If you're using a component owned by someone else, check to see if they offer a 64-bit version, and reference that.

- Try the out-of-process designer.

  Your final option would be to enable the out-of-process designer for .NET Framework.

## Out-of-process designer

If your project targets .NET, you're already using the out-of-process designer. However, if you're still using .NET Framework, you need to enable the out-of-process designer.

> [!WARNING]
> The updated out-of-process 32-Bit .NET Framework Designer doesn't achieve full parity with the old in-process .NET Framework Designer due to the same architectural differences. Highly customized control designers aren't compatible. If you use custom control libraries from 3rd parties, check if they offer versions that support the out-of-process .NET Framework Designer.

The **out-of-process designer**, with some limitations, handles 32-bit issues with Visual Studio 2022:

- .NET Framework benefits from improved type resolution.
- ActiveX and COM references are supported in both .NET Framework and .NET.
- The in-process designer in Visual Studio detects 32-bit assembly load failures and can suggest enabling the out-of-process designer.

### Use the out-of-process designer

Support for 32-bit references requires **Visual Studio 17.9 or later**. Enable it by adding the following `<PropertyGroup>` setting to your project file:

```xml
<PropertyGroup>
    <UseWinFormsOutOfProcDesigner>True</UseWinFormsOutOfProcDesigner>
</PropertyGroup>
```

After modifying the project file, reload the project.

### 32-bit issue detection

Currently, when Visual Studio detects that a 32-bit reference fails to load, it prompts you to enable the Windows Forms out-of-process designer. If you agree to enable it, the project is updated for you and then reloaded.

:::image type="content" source="./media/troubleshoot-32bit/designer-prompt.png" alt-text="The image of a window from Visual Studio prompting the user to enable the out-of-process designer.":::

This detection feature is controlled in the Visual Studio menu, under **Tools** > **Options** > **Preview Features**.

## See also

- [.NET Blog – WinForms Designer Selection for 32-bit .NET Framework Projects](https://devblogs.microsoft.com/visualstudio/winforms-designer-selection-for-32-bit-net-framework-projects/)
