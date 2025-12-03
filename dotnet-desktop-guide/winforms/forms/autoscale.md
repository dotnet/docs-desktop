---
title: "Automatic scaling in Windows Forms"
description: "Learn how Windows Forms handles DPI scaling and high-DPI support for modern .NET applications."
ms.date: 11/19/2025
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

- **PerMonitorV2** (recommended): The application scales dynamically based on the DPI of each monitor. When you move a window between monitors with different DPI settings, Windows Forms automatically rescales the window and its contents. This mode provides the best user experience on systems with multiple monitors. PerMonitorV2 also scales non-client areas (title bar, borders, menus) and provides the most comprehensive DPI support.

- **SystemAware**: The application queries the DPI of the primary monitor once at startup and uses that value for all monitors. If you move the window to a monitor with different DPI, the operating system applies bitmap scaling, which can make the application appear blurry or incorrectly sized on secondary displays.

- **PerMonitor**: An earlier version of per-monitor DPI awareness with fewer features than PerMonitorV2. Use PerMonitorV2 instead for new applications.

- **DpiUnaware**: The application doesn't scale for DPI and always renders at 96 DPI (100% scaling). Windows applies bitmap scaling, which makes the application appear blurry on high-DPI displays.

- **DpiUnawareGdiScaled**: Similar to DpiUnaware but improves the quality of GDI/GDI+ content through enhanced bitmap scaling.

> [!NOTE]
> PerMonitorV2 mode is available on Windows 10 Creators Update (version 1703) and later. On earlier Windows versions, the mode automatically falls back to PerMonitor. This fallback is handled by the operating system and requires no code changes.

## Handle DPI changes at runtime

When your application runs in PerMonitorV2 mode, Windows Forms automatically handles DPI changes when you move windows between monitors. However, you can respond to DPI changes programmatically using these events:

- <xref:System.Windows.Forms.Form.DpiChanged>: Raised when the DPI of the monitor displaying the form changes. The <xref:System.Windows.Forms.DpiChangedEventArgs> provides the old and new DPI values and a suggested rectangle for the form's new bounds.
- <xref:System.Windows.Forms.Control.DpiChangedBeforeParent>: Raised before a parent control or form handles a DPI change. Use this to prepare custom controls for scaling.
- <xref:System.Windows.Forms.Control.DpiChangedAfterParent>: Raised after a parent control or form handles a DPI change. Use this to adjust custom layout after automatic scaling.

Use these events when you need to:

- Load different image resources based on DPI
- Perform custom drawing that needs DPI-specific calculations
- Adjust layout beyond what automatic scaling provides
- Update cached dimensions or measurements

The framework automatically rescales control sizes, positions, and fonts. You typically only need to handle these events for custom resources or drawing logic.

## Understanding AutoScaleMode

> [!IMPORTANT]
> Modern .NET applications use the `ApplicationHighDpiMode` setting in combination with `AutoScaleMode`. Both settings work together to provide comprehensive DPI scaling.

The <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> property determines how Windows Forms calculates scaling factors. Even with `HighDpiMode` set, AutoScaleMode affects how controls scale:

- **Font** (default and recommended): Scales controls based on the system font size. As DPI increases, the default system font also increases, and controls scale proportionally. This mode is recommended for most business applications because it accounts for user font preferences and accessibility settings.

- **Dpi**: Scales controls based directly on pixel density (DPI). Use this mode for graphics-heavy applications where you want explicit control over scaling based on pixel density, independent of font settings.

- **None**: Disables automatic scaling. Only use this if you're implementing completely custom scaling logic.

- **Inherit**: Child controls inherit their parent container's scaling mode. This ensures consistent scaling throughout a control hierarchy.

### How AutoScaleMode works

1. At design time, each <xref:System.Windows.Forms.ContainerControl> records the scaling mode and current resolution in <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>.

1. At runtime, the actual resolution is stored in <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A>. The <xref:System.Windows.Forms.ContainerControl.AutoScaleFactor%2A> property calculates the ratio between runtime and design-time scaling resolution.

1. When the form loads, if <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> differ, <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> scales the control and its children.

> [!TIP]
> Use one consistent AutoScaleMode across all forms and container controls. Mixing Font mode on some forms and Dpi mode on others can lead to inconsistent scaling behavior.

## Customize scaling behavior

You can customize how controls scale by overriding these members:

- <xref:System.Windows.Forms.Control.ScaleChildren%2A>: Determines whether child controls should be scaled.
- <xref:System.Windows.Forms.Control.GetScaledBounds%2A>: Adjusts the bounds that the control scales to, but not the scaling logic.
- <xref:System.Windows.Forms.Control.ScaleControl%2A>: Changes the scaling logic for the current control.

## Common issues and solutions

### List control anchoring issues

Certain list controls (<xref:System.Windows.Forms.ListBox>, <xref:System.Windows.Forms.ListView>, <xref:System.Windows.Forms.CheckedListBox>) with bottom anchoring can have rounding issues during DPI changes, leading to gaps or overlaps.

**Solution**: Place the list control inside a <xref:System.Windows.Forms.Panel> and dock-fill it, rather than directly anchoring it to the form's bottom:

```csharp
var panel = new Panel { Dock = DockStyle.Fill };
var listBox = new ListBox { Dock = DockStyle.Fill };
panel.Controls.Add(listBox);
this.Controls.Add(panel);
```

The panel handles resizing correctly, avoiding the rounding issues.

### Hard-coded pixel dimensions

Using fixed pixel sizes breaks DPI scaling. At 200% scaling, a 300-pixel-wide control is only half the intended physical width.

**Solution**: Use relative positioning with anchoring, docking, or layout containers. If you must specify dimensions in code, use <xref:System.Windows.Forms.Control.LogicalToDeviceUnits%2A>:

```csharp
// Instead of: button.Width = 100;
button.Width = LogicalToDeviceUnits(100);
```

### Blurry images

Bitmap images appear pixelated or blurry at high DPI when automatically scaled.

**Solution**: Provide multiple image resolutions and load the appropriate one based on DPI (see the "Work with images and assets" section above). Consider using vector graphics or drawing with GDI+ methods for scalable graphics.

### Mixed DPI awareness modes

Setting different `HighDpiMode` values for different forms can cause inconsistent behavior.

**Solution**: Use one DPI mode for the entire application. Set `ApplicationHighDpiMode` in your project file, which applies to all forms.

### Dynamically created controls not scaling

Controls added at runtime after the form loads might not scale correctly.

**Solution**: Call <xref:System.Windows.Forms.Control.PerformLayout> on the parent container after adding controls:

```csharp
var newLabel = new Label { Text = "New Label", AutoSize = true };
this.Controls.Add(newLabel);
this.PerformLayout();
```

For container controls, they automatically handle layout when new children are added.

### Font-based scaling not working

If you override the form's font, font-based scaling might not work as expected.

**Solution**: Let forms use the default system font unless you have a specific reason to change it. If using a custom font, ensure <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> remains set to `Font`.

## Test your application

Thoroughly test DPI scaling:

- **Test at multiple scaling levels**: Use Windows display settings to test at 100%, 125%, 150%, and 200% scaling.
- **Test multi-monitor scenarios**: Move windows between monitors with different DPI settings.
- **Check for clipped text**: Ensure labels and buttons show complete text at all scaling levels.
- **Verify image quality**: Confirm images remain sharp at high DPI.
- **Test dynamic content**: Ensure controls added at runtime scale correctly.

You can verify DPI awareness in Task Manager (it shows a DPI Awareness column) or by checking the <xref:System.Windows.Forms.Form.DeviceDpi> property at runtime.

## Troubleshooting

If you experience scaling issues:

- Verify the `ApplicationHighDpiMode` setting in your project file.
- Ensure you're not mixing DPI awareness modes (for example, setting different modes for base and derived forms).
- Check that you haven't disabled scaling in application manifests or configuration files.
- Use <xref:System.Windows.Forms.Form.DeviceDpi> to verify the current DPI at runtime.
- Check the Task Manager's DPI Awareness column to confirm your application's DPI mode.
- For font-related scaling issues, see [How to: Respond to Font Scheme Changes in a Windows Forms Application](../how-to-respond-to-font-scheme-changes-in-a-windows-forms-application.md).

## See also

- <xref:System.Windows.Forms.Application.SetHighDpiMode%2A>
- <xref:System.Windows.Forms.HighDpiMode>
- [High DPI support in Windows Forms](../high-dpi-support-in-windows-forms.md)
- [What's new in Windows Forms for .NET 6](../whats-new/net60.md#project-level-application-settings)
- [Rendering Controls with Visual Styles](../controls/rendering-controls-with-visual-styles.md)
