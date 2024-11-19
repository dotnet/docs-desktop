---
title: WFAC010 warning
description: Learn about the Windows Forms DPI settings that generate compile-time warning WFAC010.
ms.date: 11/15/2023
---
# WFAC010: Unsupported high DPI configuration.

Windows Forms applications should specify application DPI-awareness via the [application configuration](../whats-new/net60.md#new-application-bootstrap) or with the <xref:System.Windows.Forms.Application.SetHighDpiMode%2A?displayProperty=nameWithType> API.

> [!IMPORTANT]
> Starting with .NET 9, this warning has changed to [WFO0003](../compiler-messages/wfo0003.md).

## Workarounds

### Using C\#

Use the [new bootstrap API](../whats-new/net60.md#new-application-bootstrap) by calling the `ApplicationConfiguration.Initialize` method before <xref:System.Windows.Application.Run?displayProperty=nameWithType>.

```csharp
class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
```

The `ApplicationConfiguration.Initialize` method is generated when your app compiles, based on the settings in the app's project file. For example, look at the following `<Application*>` settings:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>

    <ApplicationVisualStyles>true</ApplicationVisualStyles>
    <ApplicationUseCompatibleTextRendering>false</ApplicationUseCompatibleTextRendering>
    <ApplicationHighDpiMode>SystemAware</ApplicationHighDpiMode>
    <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>

  </PropertyGroup>

</Project>
```

These settings generate the following method:

```csharp
[CompilerGenerated]
internal static partial class ApplicationConfiguration
{
    public static void Initialize()
    {
        global::System.Windows.Forms.Application.EnableVisualStyles();
        global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        global::System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        global::System.Windows.Forms.Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, (FontStyle)0, (GraphicsUnit)3));
    }
}
```

### Using Visual Basic

Visual Basic operates a little differently than C# at the moment. The project file settings are required for Visual Studio to detect the application settings, but you must also configure the settings in the project's property page **Application** > **Application Framework** (which affects the _My Project\\Application.myapp_ file) or in the application startup events.

> [!IMPORTANT]
> Font isn't settable in the project properties.

The following code example demonstrates handling the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.ApplyApplicationDefaults> event to configure the default font and HighDPI mode:

```vb
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
            e.Font = New Font("Microsoft Sans Serif", 8.25)
            e.HighDpiMode = HighDpiMode.SystemAware
        End Sub
    End Class
End Namespace
```

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable WFAC010

// Code that uses the API.
// ...

// Re-enable the warning.
#pragma warning restore WFAC010
```

To suppress all the `WFAC010` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);WFAC010</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
