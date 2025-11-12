---
title: "Automatic scaling in Windows Forms"
description: "Learn how Windows Forms handles DPI scaling and high-DPI support for modern .NET applications."
ms.date: 10/26/2020
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: overview
ai-usage: ai-assisted
helpviewer_keywords:
  - "scalability [Windows Forms], automatic in Windows Forms"
  - "Windows Forms, automatic scaling"
  - "high DPI support"
  - "DPI awareness"
---

# Automatic scaling in Windows Forms

Windows Forms automatically scales your forms and controls to display correctly across different monitors with varying DPI settings. This feature ensures your application maintains a consistent appearance whether it runs on a standard monitor or a high-DPI display.

## How DPI scaling works

Modern displays use varying pixel densities, measured in dots per inch (DPI). Standard displays use 96 DPI (100% scaling), but high-resolution displays can use 120 DPI (125%), 144 DPI (150%), 192 DPI (200%), or higher. Without proper DPI scaling, your application might appear too small on high-DPI displays or too large on standard displays.

Windows Forms handles DPI scaling automatically when you configure DPI awareness for your application. The framework adjusts the size and position of forms and controls based on the DPI of the monitor where they're displayed.

## Configure DPI awareness

For modern .NET applications (.NET 6 and later), configure DPI awareness in your project file using the `ApplicationHighDpiMode` property. This is the recommended approach because Visual Studio's designer uses these settings when you design forms.

Add the following property to your project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net9.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    
    <ApplicationHighDpiMode>PerMonitorV2</ApplicationHighDpiMode>
  </PropertyGroup>

</Project>
```

Alternatively, you can set DPI awareness in code by calling <xref:System.Windows.Forms.Application.SetHighDpiMode%2A> before calling `Application.Run`:

```csharp
[STAThread]
static void Main()
{
    ApplicationConfiguration.Initialize();
    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
    Application.Run(new Form1());
}
```

> [!TIP]
> Use the project file approach when possible. This method ensures Visual Studio's designer reflects the DPI settings you've configured.

## DPI awareness modes

The <xref:System.Windows.Forms.HighDpiMode> enumeration defines several DPI awareness modes:

- **PerMonitorV2** (recommended): The application scales dynamically based on the DPI of each monitor. When you move a window between monitors with different DPI settings, Windows Forms automatically rescales the window and its contents. This mode provides the best user experience on systems with multiple monitors.

- **SystemAware**: The application queries the DPI of the primary monitor once at startup and uses that value for all monitors. This mode is simpler but doesn't handle multiple monitors with different DPI settings as well as PerMonitorV2.

- **PerMonitor**: Similar to PerMonitorV2 but with fewer features. Use PerMonitorV2 instead.

- **DpiUnaware**: The application doesn't scale for DPI and always assumes 100% scaling (96 DPI). Windows might apply bitmap scaling, which can make the application appear blurry.

- **DpiUnawareGdiScaled**: Similar to DpiUnaware but improves the quality of GDI/GDI+ content through enhanced bitmap scaling.

> [!NOTE]
> PerMonitorV2 mode is available on Windows 10 Creators Update (version 1703) and later. On earlier Windows versions, the mode falls back to PerMonitor.

## Handle DPI changes at runtime

When your application runs in PerMonitorV2 mode, Windows Forms automatically handles DPI changes when you move windows between monitors. However, you can respond to DPI changes programmatically using these events:

- <xref:System.Windows.Forms.Form.DpiChanged>: Raised when the DPI of the monitor displaying the form changes.
- <xref:System.Windows.Forms.Control.DpiChangedBeforeParent>: Raised before a parent control or form handles a DPI change.
- <xref:System.Windows.Forms.Control.DpiChangedAfterParent>: Raised after a parent control or form handles a DPI change.

Use these events when you need to perform custom scaling logic or update resources based on the new DPI setting.

## Legacy AutoScaleMode

> [!IMPORTANT]
> For modern .NET applications, use the `ApplicationHighDpiMode` setting instead of `AutoScaleMode`. The information in this section applies primarily to .NET Framework applications or when maintaining compatibility with legacy code.

The <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> property provides font-based scaling for .NET Framework applications. This approach is less common in modern .NET applications because DPI-based scaling (using `HighDpiMode`) provides better results.

When using AutoScaleMode:

1. At design time, each <xref:System.Windows.Forms.ContainerControl> records the scaling mode and current resolution in <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>.

1. At runtime, the actual resolution is stored in <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A>. The <xref:System.Windows.Forms.ContainerControl.AutoScaleFactor%2A> property calculates the ratio between runtime and design-time scaling resolution.

1. When the form loads, if <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> differ, <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> scales the control and its children.

## Customize scaling behavior

You can customize how controls scale by overriding these members:

- <xref:System.Windows.Forms.Control.ScaleChildren%2A>: Determines whether child controls should be scaled.
- <xref:System.Windows.Forms.Control.GetScaledBounds%2A>: Adjusts the bounds that the control scales to, but not the scaling logic.
- <xref:System.Windows.Forms.Control.ScaleControl%2A>: Changes the scaling logic for the current control.

## Troubleshooting

If you experience scaling issues:

- Verify the `ApplicationHighDpiMode` setting in your project file.
- Ensure you're not mixing DPI awareness modes (for example, setting different modes for base and derived forms).
- Check that you haven't disabled scaling in application manifests or configuration files.
- For font-related scaling issues, see [How to: Respond to Font Scheme Changes in a Windows Forms Application](../how-to-respond-to-font-scheme-changes-in-a-windows-forms-application.md).

## See also

- <xref:System.Windows.Forms.Application.SetHighDpiMode%2A>
- <xref:System.Windows.Forms.HighDpiMode>
- [High DPI support in Windows Forms](../high-dpi-support-in-windows-forms.md)
- [What's new in Windows Forms for .NET 6](../whats-new/net60.md#project-level-application-settings)
- [Rendering Controls with Visual Styles](../controls/rendering-controls-with-visual-styles.md)
