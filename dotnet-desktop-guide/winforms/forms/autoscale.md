---
title: "Automatic form scaling"
description: "Learn how Windows Forms for .NET handles scaling the UI with DPI awareness and automatic scaling modes."
ms.date: 01/21/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: overview
ai-usage: ai-assisted
helpviewer_keywords:
  - "scalability [Windows Forms], automatic in Windows Forms"
  - "Windows Forms, automatic scaling"
  - "DPI awareness"
  - "high DPI support"
---

# Automatic scaling

Automatic scaling lets a form and its controls, designed on one machine with a certain display resolution or font, display appropriately on another machine with a different display resolution or font. Forms and controls intelligently resize to stay consistent with native windows and other applications on both users' and other developers' machines. Automatic scaling and visual styles help Windows Forms applications maintain a consistent look when compared to native Windows applications on each user's machine.

For the most part, automatic scaling works as expected in Windows Forms. However, font scheme changes can be problematic. For an example of how to resolve this issue, see [How to: Respond to Font Scheme Changes in a Windows Forms Application](../how-to-respond-to-font-scheme-changes-in-a-windows-forms-application.md).

## DPI awareness in modern .NET

Modern .NET (6.0+) handles DPI scaling differently than .NET Framework. In .NET 6 and later versions, DPI awareness is configured through the project file using the `ApplicationHighDpiMode` property, which is set to `SystemAware` by default. This configuration works with the application bootstrap system to automatically configure DPI handling when your application starts.

The recommended DPI mode for modern Windows Forms applications is `PerMonitorV2`, which provides the best scaling experience across multiple monitors with different DPI settings. With `PerMonitorV2`, your application dynamically adjusts when moved between monitors with different scaling settings.

Configure DPI mode in your project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <ApplicationHighDpiMode>PerMonitorV2</ApplicationHighDpiMode>
  </PropertyGroup>
</Project>
```

> [!NOTE]
> While the recommended approach is to configure DPI through the project file, you can still use an application manifest file (*app.manifest*) to override these settings. However, using the manifest is discouraged because it can cause conflicts with the application configuration. For more information, see [Compiler Warning WFO0003](../compiler-messages/wfo0003.md).

### Visual Studio designer considerations

When designing forms in Visual Studio, you might need to configure the designer's DPI awareness separately from your application. Starting with Visual Studio 2022 version 17.8, you can set the `ForceDesignerDPIUnaware` property in your project file to make the Windows Forms designer run in DPI-unaware mode. This setting helps avoid rendering issues when designing forms on high-DPI monitors:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <ForceDesignerDPIUnaware>true</ForceDesignerDPIUnaware>
  </PropertyGroup>
</Project>
```

This property only affects the Visual Studio designer and doesn't change how your application runs. For more information, see [Disable DPI-awareness to address scaling issues](/visualstudio/designers/disable-dpi-awareness).

Available DPI modes include:

- `SystemAware`—The application queries for the DPI once at startup and uses this value for the lifetime of the app.
- `PerMonitor`—The application checks for DPI changes on a per-monitor basis and rescales when DPI changes.
- `PerMonitorV2`—Similar to `PerMonitor`, but enables child window DPI change notifications and improved scaling behavior.
- `DpiUnaware`—The application doesn't scale for DPI changes, and Windows handles the scaling.
- `DpiUnawareGdiScaled`—Similar to `DpiUnaware` but provides better quality for GDI-based content.

For more information about configuring DPI settings, see [What's new in Windows Forms for .NET 6](../whats-new/net60.md#project-level-application-settings).

## Need for automatic scaling

Without automatic scaling, an application designed for one display resolution or font appears too small or too large when that resolution or font changes. For example, if you design an application using Tahoma 9 point as a baseline, without adjustment it appears too small when run on a machine where the system font is Tahoma 12 point. Text elements, such as titles, menus, and text box contents, render smaller than other applications. Furthermore, the size of user interface (UI) elements that contain text, such as the title bar, menus, and many controls, depend on the font used. In this example, these elements also appear relatively smaller.

An analogous situation occurs when you design an application for a certain display resolution. The most common display resolution is 96 dots per inch (DPI), which equals 100% display scaling, but higher resolution displays supporting 125%, 150%, 200% (which respectively equal 120, 144, and 192 DPI) and above are becoming more common. Without adjustment, an application, especially a graphics-based one, designed for one resolution appears either too large or too small when run at another resolution.

Automatic scaling addresses these problems by automatically resizing the form and its child controls according to the relative font size or display resolution. The Windows operating system supports automatic scaling of dialog boxes using a relative unit of measurement called dialog units. A dialog unit is based on the system font, and its relationship to pixels can be determined through the Win32 SDK function `GetDialogBaseUnits`. When a user changes the theme used by Windows, all dialog boxes automatically adjust accordingly. Windows Forms supports automatic scaling either according to the default system font or the display resolution. Optionally, you can disable automatic scaling in an application.

> [!CAUTION]
> Arbitrary mixtures of DPI and font scaling modes aren't supported. Although you can scale a user control using one mode (for example, DPI) and place it on a form using another mode (Font) with no issues, mixing a base form in one mode and a derived form in another can lead to unexpected results.

## Automatic scaling in action

Windows Forms uses the following logic to automatically scale forms and their contents:

1. At design time, each <xref:System.Windows.Forms.ContainerControl> records the scaling mode and its current resolution in the <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> properties, respectively.

1. At run time, the actual resolution is stored in the <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> property. The <xref:System.Windows.Forms.ContainerControl.AutoScaleFactor%2A> property dynamically calculates the ratio between the run-time and design-time scaling resolution.

1. When the form loads, if the values of <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> differ, then the <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> method is called to scale the control and its children. This method suspends layout and calls the <xref:System.Windows.Forms.Control.Scale%2A> method to perform the actual scaling. Afterward, the value of <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> is updated to avoid progressive scaling.

1. <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> is also automatically invoked in the following situations:

    - In response to the <xref:System.Windows.Forms.Control.OnFontChanged%2A> event if the scaling mode is <xref:System.Windows.Forms.AutoScaleMode.Font>.

    - When the layout of the container control resumes and a change is detected in the <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> or <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> properties.

    - When a parent <xref:System.Windows.Forms.ContainerControl> is being scaled. Each container control is responsible for scaling its children using its own scaling factors and not the one from its parent container.

1. Child controls can modify their scaling behavior through several means:

    - Override the <xref:System.Windows.Forms.Control.ScaleChildren%2A> property to determine if their child controls should be scaled.

    - Override the <xref:System.Windows.Forms.Control.GetScaledBounds%2A> method to adjust the bounds that the control is scaled to, but not the scaling logic.

    - Override the <xref:System.Windows.Forms.Control.ScaleControl%2A> method to change the scaling logic for the current control.

## High DPI improvements

Modern .NET includes significant improvements to high DPI rendering, especially with `PerMonitorV2` mode:

- **Per-monitor DPI awareness**—Applications dynamically adjust when moved between monitors with different DPI settings.
- **Improved scaling behavior**—Controls scale correctly when DPI changes, including nested controls and container controls (.NET 6+).
- **Form size scaling**—<xref:System.Windows.Forms.Form.MaximumSize%2A> and <xref:System.Windows.Forms.Form.MinimumSize%2A> properties scale based on the current monitor DPI settings (.NET 7+, enabled by default in .NET 8+).
- **DPI change events**—New events let you programmatically handle dynamic DPI changes:
  - <xref:System.Windows.Forms.Form.DpiChanged>—Fires when the DPI setting changes on the display device where the form is currently displayed.
  - <xref:System.Windows.Forms.Control.DpiChangedBeforeParent>—Fires when the DPI setting for a control changes programmatically before a DPI change event for its parent control or form occurs.
  - <xref:System.Windows.Forms.Control.DpiChangedAfterParent>—Fires when the DPI setting for a control changes programmatically after a DPI change event for its parent control or form occurs.

For more information about high DPI improvements, see [What's new in Windows Forms for .NET 6](../whats-new/net60.md#high-dpi-improvements-for-permonitorv2), [What's new in Windows Forms for .NET 7](../whats-new/net70.md#high-dpi-improvements), and [What's new in Windows Forms for .NET 8](../whats-new/net80.md#high-dpi-improvements).

## .NET Framework differences

.NET Framework handles DPI awareness differently than modern .NET:

- In .NET Framework, configure DPI awareness through an *app.config* file with the `<System.Windows.Forms.ApplicationConfigurationSection>` element.
- In modern .NET, configure DPI awareness through the project file with the `ApplicationHighDpiMode` property.
- .NET Framework uses manifest files for DPI configuration, which is no longer recommended.
- Modern .NET provides better scaling behavior and more reliable DPI change handling.

For information about .NET Framework DPI configuration, see [High DPI support in Windows Forms](../high-dpi-support-in-windows-forms.md).

## See also

- <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A>
- <xref:System.Windows.Forms.Control.Scale%2A>
- <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A>
- <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>
- [Rendering Controls with Visual Styles](../controls/rendering-controls-with-visual-styles.md)
