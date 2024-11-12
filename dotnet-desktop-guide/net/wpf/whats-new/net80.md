---
title: What's new in WPF for .NET 8
description: Learn about what's new in Windows Presentation Foundation (WPF) for .NET 8. .NET 8 was released November 2023.
ms.date: 10/24/2024
ms.topic: conceptual
---

# What's new in WPF for .NET 8

WPF adds hardware acceleration and a new control for browsing and selecting folders in .NET 8.

## Hardware acceleration

Previously, all WPF applications that were accessed remotely had to use software rendering, even if the system had hardware rendering capabilities. .NET 8 adds an option that lets you opt into hardware acceleration for Remote Desktop Protocol (RDP).

Hardware acceleration refers to the use of a computer's graphics processing unit (GPU) to speed up the rendering of graphics and visual effects in an application. This can result in improved performance and more seamless, responsive graphics. In contrast, software rendering relies solely on the computer's central processing unit (CPU) to render graphics, which can be slower and less effective.

To opt in, set the `Switch.System.Windows.Media.EnableHardwareAccelerationInRdp` configuration property to `true` in a *runtimeconfig.json* file. For more information, see [Hardware acceleration in RDP](/dotnet/core/runtime-config/wpf#hardware-acceleration-in-rdp).

## OpenFolderDialog

WPF includes a new dialog box control called <xref:Microsoft.Win32.OpenFolderDialog>. This control lets app users browse and select folders. Previously, app developers relied on third-party software to achieve this functionality.

```csharp
var openFolderDialog = new OpenFolderDialog()
{
    Title = "Select folder to open ...",
    InitialDirectory = Environment.GetFolderPath(
        Environment.SpecialFolder.ProgramFiles)
};

string folderName = "";
if (openFolderDialog.ShowDialog())
{
    folderName = openFolderDialog.FolderName;
}
```

For more information, see [WPF File Dialog Improvements in .NET 8 (.NET blog)](https://devblogs.microsoft.com/dotnet/wpf-file-dialog-improvements-in-dotnet-8/).
