---
title: What's new in WPF for .NET 9
description: Learn about what's new in Windows Presentation Foundation (WPF) for .NET 9. New versions of WPF are released yearly with .NET.
ms.topic: whats-new
ms.date: 11/08/2024

#customer intent: As a developer, I want to know what's changed so that I can remain up-to-date.

---

# What's new in WPF for .NET 9

This article describes what's new in Windows Presentation Foundation (WPF) for .NET 9. The main area of focus for WPF this year was improving the visual capabilities of WPF and providing a new theme based on the Fluent design principles for Windows 11.

You can preview the new theme by downloading the **WPF Gallery** app from the [Microsoft Store](https://www.microsoft.com/store/productId/9NDLX60WX4KQ).

## Fluent theme

A new theme is included with WPF that delivers a fresh, modern Windows 11 aesthetic for WPF apps. It includes integrated light and dark modes, and a system accent color support.

- Fluent theme in light mode:

  :::image type="content" source="./media/net90/wpf-light.png" lightbox="./media/net90/wpf-light.png" alt-text="A screenshot of the WPF Gallery app, demonstrating the fluent theme in light mode.":::

- Fluent theme in dark mode:

  :::image type="content" source="./media/net90/wpf-dark.png" lightbox="./media/net90/wpf-dark.png" alt-text="A screenshot of the WPF Gallery app, demonstrating the fluent theme in dark mode":::

### Apply the theme

You can apply the Fluent theme in two ways. First, you can apply the theme by setting the `ThemeMode` property. For more information, see the [ThemeMode](#thememode) section. Secondly, you can apply the theme by loading the resource dictionary that contains the theme.

The Fluent theme resource dictionary is available at the following pack URI: `/PresentationFramework.Fluent;component/Themes/Fluent.xaml`. To apply the resource at the application-level, load the resource into your app's resources:

```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/PresentationFramework.Fluent;component/Themes/Fluent.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## ThemeMode

A new styling API has been added to WPF, which is controlled through the `ThemeMode` property. By using this property, you can load the Fluent style without having to apply a styling resource dictionary directly.

Valid values are:

- `Light`&mdash;Applies the light Fluent theme.
- `Dark`&mdash;Applies the dark Fluent theme.
- `System`&mdash;Applies either the light or dark Fluent theme, based on the current system choice.
- `None`&mdash;(default) Uses the Aero2 theme.

To apply a theme mode for the whole application, set the `ThemeMode` property on the `Application` type. To apply it to a single window, set `ThemeMode` on the `Window` type.

For example, style the entire application based on the current light or dark theme set by Windows:

:::code language="csharp" source=".\snippets\net90\csharp\App.xaml" range="1-6" highlight="6":::

Here's an example of forcing the light theme, regardless of the theme set by Windows:

:::code language="csharp" source=".\snippets\net90\csharp\LightWindow.xaml" range="1-6" highlight="6":::

If the `ThemeMode` is set to any value other than `None` at the application-level, `None` can no longer be applied at the window-level.

`ThemeMode` is designed to respect the settings set by a Fluent Dictionary, allowing you to customize the Fluent theme.

### Set in code

Support for changing setting the `ThemeMode` in code is currently an experimental feature. Accessing the `ThemeMode` property by code generates error **WPF0001**, preventing access to the API. Suppress the error to access to the API.

> [!WARNING]
> This API is experimental and subject to change.

First, add the following `PropertyGroup` element to your project file to suppress the error:

:::code language="xml" source=".\snippets\net90\csharp\MyWpfProject.csproj" id="NoWarn":::

> [!TIP]
> You can use the `#pragma warning disable WPF0001` directive to suppress the error where it occurs instead of disabling it for the entire project.

Next, set either the `ThemeMode` property at the application-level or window-level:

:::code language="csharp" source=".\snippets\net90\csharp\MainWindow.xaml.cs" id="ThemeMode":::

## Support for Windows accent color

Windows 10 introduced a user-selectable accent color that's used in providing a personal touch or calling out a specific visual element. WPF now supports the user-selected accent color.

The visual color is available as a `System.Windows.Media.Color`, `System.Windows.Media.SolidColorBrush`, or `System.Windows.ResourceKey`. Along with the color itself,  light and dark shades of the accent color are available. These are accessed through `System.Windows.SystemColors`:

- Colors
  - `AccentColor`
  - `AccentColorLight1`
  - `AccentColorLight2`
  - `AccentColorLight3`
  - `AccentColorDark1`
  - `AccentColorDark2`
  - `AccentColorDark3`
- Brushes
  - `AccentColorBrush`
  - `AccentColorLight1Brush`
  - `AccentColorLight2Brush`
  - `AccentColorLight3Brush`
  - `AccentColorDark1Brush`
  - `AccentColorDark2Brush`
  - `AccentColorDark3Brush`
- Resource keys
  - `AccentColorKey`
  - `AccentColorLight1Key`
  - `AccentColorLight2Key`
  - `AccentColorLight3Key`
  - `AccentColorDark1Key`
  - `AccentColorDark2Key`
  - `AccentColorDark3Key`

> [!IMPORTANT]
> Accent colors are available with or without the Fluent theme.

When creating a UI that uses the accent color, wrap the resource key in a dynamic resource. When a user changes the accent color while the app is opened, the color is updated automatically in the app. For example, here's a `TextBlock` with the foreground color set to the user's chosen accent color:

:::code language="xaml" source=".\snippets\net90\csharp\MainWindow.xaml" id="DynamicAccent":::

## Hyphen based ligature support

WPF has never supported hyphen-based ligatures in UI controls such as the `TextBlock`. This long-standing community ask was added in .NET 9.

Here's an image of the ligatures not being applied to the glyphs in .NET 8:

:::image type="content" source="./media/net90/ligature-8.png" alt-text="A screenshot of a simple WPF app that has a text block showing how glyphs aren't combined into ligatures.":::

And now, that same text as rendered in .NET 9:

:::image type="content" source="./media/net90/ligature-9.png" alt-text="A screenshot of a simple WPF app that has a text block showing how glyphs aren't combined into ligatures.":::
