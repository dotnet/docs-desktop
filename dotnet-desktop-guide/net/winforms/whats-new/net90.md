---
title: What's new in WinForms for .NET 9
description: Learn about what's new in Windows Forms for .NET 9. New versions of Windows Forms are released yearly with .NET.
ms.topic: whats-new
ms.date: 11/11/2024
#customer intent: As a developer, I want to know what's changed so that I can remain up-to-date.
---

# What's new in Windows Forms for .NET 9

This article describes what's new in Windows Forms for .NET 9.

## Async forms

> [!IMPORTANT]
> This feature set is experimental, except for `Control.InvokeAsync`.

Modern apps require asynchronous communication models. As Windows Forms has grown on .NET, more components require marshaling to an `async` method to run on the UI-thread. For example, controls like [WebView2](/microsoft-edge/webview2/), native Windows 10 and Windows 11 APIs, or modern asynchronous libraries like [Semantic Kernel](/semantic-kernel/overview/). Another scenario would be where you're sharing MVVM ViewModels built around `async` with Windows Forms from other UI stacks such as WPF, WinUI, or .NET MAUI.

The following a list of new methods added to support asynchronous scenarios:

- [System.Windows.Forms.Form.ShowAsync](xref:System.Windows.Forms.Form.ShowAsync(System.Windows.Forms.IWin32Window)?displayProperty=nameWithType)
- <xref:System.Windows.Forms.Form.ShowDialogAsync*?displayProperty=nameWithType>
- <xref:System.Windows.Forms.TaskDialog.ShowDialogAsync*?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.InvokeAsync*?displayProperty=nameWithType> **(This API isn't experimental.)**

This API is guarded behind a compiler error because it's experimental. To suppress the error and enable access to the API, add the following `PropertyGroup` to your project file:

:::code language="xml" source=".\snippets\net90\csharp\MyExampleProject.csproj" id="experimental_async":::

> [!TIP]
> For more information about how to suppress this rule, see [Compiler Error WFO5002](../compiler-messages/wfo5002.md#to-correct-this-error).

## BinaryFormatter no longer supported

`BinaryFormatter` is considered unsafe because it's vulnerable to deserialization attacks, which can lead to denial of service (DoS), information disclosure, or remote code execution. It was implemented before deserialization vulnerabilities were well understood, and its design doesn't follow modern security best practices.

Starting with .NET 9, its implementation has been removed to prevent these security risks. When `BinaryFormatter` is used, the `PlatformNotSupportedException` exception is thrown.

Windows Forms used `BinaryFormatter` in many scenarios, such as when serializing data for clipboard and drag-and-drop operations, and most importantly, the Windows Forms Designer. Internally, Windows Forms continues to use a safer subset of `BinaryFormatter` to handle specific use cases with a known set of types.

Windows Forms for .NET 9 is shipping with analyzers that help you identify times you unknowingly participate in binary serialization.

For more information about `BinaryFormatter`, see [Windows Forms migration guide for BinaryFormatter](/dotnet/standard/serialization/binaryformatter-migration-guide/winforms-applications).

## Dark mode

> [!IMPORTANT]
> This feature set is experimental.

Preliminary support for dark mode has been added to Windows Forms, with the goal of finalizing support in .NET 10. When the color mode changes, the <xref:System.Drawing.SystemColors> are changed to match. The color mode for the app can be set to one of the following values:

- `SystemColorMode.Classic`&mdash;(default) Light mode, the same as previous versions of Windows Forms.
- `SystemColorMode.System`&mdash;Respect the light or dark mode set by Windows.
- `SystemColorMode.Dark`&mdash;Use dark mode.

To apply a color mode, call <xref:System.Windows.Forms.Application.SetColorMode(System.Windows.Forms.SystemColorMode)?displayProperty=nameWithType> in the program startup code:

:::code language="csharp" source=".\snippets\net90\csharp\Program.cs" highlight="14":::
:::code language="vb" source=".\snippets\net90\vb\Program.vb" highlight="8":::

This API is guarded behind a compiler error because it's experimental. To suppress the error and enable access to the API, add the following `PropertyGroup` to your project file:

:::code language="xml" source=".\snippets\net90\csharp\MyExampleProject.csproj" id="experimental_darkmode":::

> [!TIP]
> For more information about how to suppress this rule, see [Compiler Error WFO5001](../compiler-messages/wfo5001.md#to-correct-this-error).

## FolderBrowserDialog enhancements

`FolderBrowserDialog` now supports selecting multiple folders, which are stored in the <xref:System.Windows.Forms.FolderBrowserDialog.SelectedPaths> array. To enable multiple folders, set <xref:System.Windows.Forms.FolderBrowserDialog.Multiselect> to `true`.

## System.Drawing new features and enhancements

The **System.Drawing** library has had many improvements, including wrapping GDI+ effects, support for `ReadOnlySpan`, and better interop code generation.

### System.Drawing supports GDI+ effects

The **System.Drawing** library now supports GDI+ bitmap effects, such as blur and tint. Effects have been a part of GDI+, but weren't exposed through **System.Drawing** until now.

Effects are applied to a <xref:System.Drawing.Bitmap> by calling the <xref:System.Drawing.Bitmap.ApplyEffect(System.Drawing.Imaging.Effects.Effect,System.Drawing.Rectangle)?displayProperty=nameWithType> method. Provide the effect and an optional `Rectangle` for the area to apply the effect on. Use <xref:System.Drawing.Rectangle.Empty?displayProperty=nameWithType> to process the entire image.

The <xref:System.Drawing.Imaging.Effects> namespace contains the effects you can apply:

- <xref:System.Drawing.Imaging.Effects.BlackSaturationCurveEffect>
- <xref:System.Drawing.Imaging.Effects.BlurEffect>
- <xref:System.Drawing.Imaging.Effects.BrightnessContrastEffect>
- <xref:System.Drawing.Imaging.Effects.ColorBalanceEffect>
- <xref:System.Drawing.Imaging.Effects.ColorCurveEffect>
- <xref:System.Drawing.Imaging.Effects.ColorLookupTableEffect>
- <xref:System.Drawing.Imaging.Effects.ColorMatrixEffect>
- <xref:System.Drawing.Imaging.Effects.ContrastCurveEffect>
- <xref:System.Drawing.Imaging.Effects.CurveChannel>
- <xref:System.Drawing.Imaging.Effects.DensityCurveEffect>
- <xref:System.Drawing.Imaging.Effects.ExposureCurveEffect>
- <xref:System.Drawing.Imaging.Effects.GrayScaleEffect>
- <xref:System.Drawing.Imaging.Effects.HighlightCurveEffect>
- <xref:System.Drawing.Imaging.Effects.InvertEffect>
- <xref:System.Drawing.Imaging.Effects.LevelsEffect>
- <xref:System.Drawing.Imaging.Effects.MidtoneCurveEffect>
- <xref:System.Drawing.Imaging.Effects.ShadowCurveEffect>
- <xref:System.Drawing.Imaging.Effects.SharpenEffect>
- <xref:System.Drawing.Imaging.Effects.TintEffect>
- <xref:System.Drawing.Imaging.Effects.VividEffect>
- <xref:System.Drawing.Imaging.Effects.WhiteSaturationCurveEffect>

### System.Drawing supports Span

Many methods that accepted arrays have been enhanced to also accept `ReadOnlySpan`. For example, methods such as <xref:System.Drawing.Drawing2D.GraphicsPath.AddLines(System.ReadOnlySpan{System.Drawing.Point})?displayProperty=nameWithType>, <xref:System.Drawing.Graphics.DrawLines(System.Drawing.Pen,System.ReadOnlySpan{System.Drawing.Point})?displayProperty=nameWithType>, and <xref:System.Drawing.Graphics.DrawPolygon(System.Drawing.Pen,System.ReadOnlySpan{System.Drawing.Point})>, accept an array or `ReadOnlySpan`.

### Use CsWin32 for interop

All interop code has been replaced by [CsWin32](https://github.com/microsoft/CsWin32), a C# P/Invoke source generator.

## ToolStrip

The following improvements have been added to the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.ToolStripItem> controls.

- A new property was added to `ToolStrip`, <xref:System.Windows.Forms.ToolStrip.AllowClickThrough>.

  When set to `true`, the control can be interacted with while the form is unfocused.

Back when .NET Core 3.1 was released, all `Menu`-related controls, such as `MainMenu` and `MenuItem`, were removed. `ToolStrip` and `ToolStripMenuItem` should be used instead. However, `ToolStripItem`, the base class for `ToolStripMenuItem`, didn't have a replacement for the `MenuItem.Select` event. This event was raised when the mouse or keyboard is used to highlight the item.

.NET 9 has added <xref:System.Windows.Forms.ToolStripItem.SelectedChanged?displayProperty=nameWithType>, which can be used to detect when a menu item is highlighted.
