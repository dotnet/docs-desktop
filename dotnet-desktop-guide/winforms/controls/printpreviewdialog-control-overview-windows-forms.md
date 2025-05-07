---
title: "PrintPreviewDialog Control Overview"
description: This article provides an overview of the PrintPreviewDialog control in Windows Forms, which is a preconfigured dialog box.
ms.date: 04/07/2025
ms.service: dotnet-framework
f1_keywords:
  - "PrintPreviewDialog"
helpviewer_keywords:
  - "PrintPreviewDialog control (using designer), about PrintPreviewDialog"
ms.assetid: efd4ee8d-6edd-47ec-88e4-4a4759bd2384
---
# PrintPreviewDialog control overview (Windows Forms)

The Windows Forms <xref:System.Windows.Forms.PrintPreviewDialog> control is a preconfigured dialog box used to display how a [PrintDocument](printdocument-component-windows-forms.md) appears when printed. Use it within your Windows-based application as a simple solution instead of configuring your own dialog box. The control contains buttons for printing, zooming in, displaying one or multiple pages, and closing the dialog box.

## Key properties and methods

The control's key property is <xref:System.Windows.Forms.PrintPreviewDialog.Document%2A>, which sets the document to be previewed. The document must be a <xref:System.Drawing.Printing.PrintDocument> object. In order to display the dialog box, you must call its <xref:System.Windows.Forms.Form.ShowDialog%2A> method. Anti-aliasing can make the text appear smoother, but it can also make the display slower; to use it, set the <xref:System.Windows.Forms.PrintPreviewDialog.UseAntiAlias%2A> property to `true`.

Certain properties are available through the <xref:System.Windows.Forms.PrintPreviewControl> that the <xref:System.Windows.Forms.PrintPreviewDialog> contains. (You don't have to add <xref:System.Windows.Forms.PrintPreviewControl> to the form; it's automatically contained within the <xref:System.Windows.Forms.PrintPreviewDialog> when you add the dialog to your form.) Examples of properties available through the <xref:System.Windows.Forms.PrintPreviewControl> are the <xref:System.Windows.Forms.PrintPreviewControl.Columns%2A> and <xref:System.Windows.Forms.PrintPreviewControl.Rows%2A> properties, which determine the number of pages displayed horizontally and vertically on the control. You can access the <xref:System.Windows.Forms.PrintPreviewControl.Columns%2A> property as `PrintPreviewDialog1.PrintPreviewControl.Columns` in Visual Basic, `printPreviewDialog1.PrintPreviewControl.Columns` in Visual C#, or `printPreviewDialog1->PrintPreviewControl->Columns` in Visual C++.

## PrintPreviewDialog performance

Under the following conditions, the <xref:System.Windows.Forms.PrintPreviewDialog> control initializes slowly:

- A network printer is used.
- User preferences for this printer, such as duplex settings, are modified.

The optimization isn't applied if you use the <xref:System.Drawing.Printing.PrintDocument.QueryPageSettings> event to modify page settings.

To apply the optimization, set the `Switch.System.Drawing.Printing.OptimizePrintPreview` runtime config option to `true`.

# [.NET](#tab/dotnet)

The option can be set in the _runtimeconfig.json_ configuration file or the project file of an app:

- **Configure a default in project file.**

  To apply the setting in the project file, enable runtime config generation by setting `<GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>` to in a `<PropertyGroup>`. Then, add the `<RuntimeHostConfigurationOption>` setting to an `<ItemGroup>`:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk">

    <!-- Other project settings ... -->

    <PropertyGroup>
      <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
    </PropertyGroup>

    <ItemGroup>
      <RuntimeHostConfigurationOption Include="Switch.System.Drawing.Printing.OptimizePrintPreview" Value="true" />
    </ItemGroup>

  </Project>
  ```

- **Configure a default in the _runtimeconfig.template.json_ source file.**

  To configure the default setting for your app, apply the setting in the _runtimeconfig.template.json_ source file. When the app is compiled or published, the template file is used to generate a runtime config file.

  ```json
  {
    "configProperties": {
      "Switch.System.Drawing.Printing.OptimizePrintPreview": true
    }
  }
  ```

  For more information about runtime config, see [.NET runtime configuration settings](/dotnet/core/runtime-config/).

- **Configure a published app with the _{appname}.runtimeconfig.json_ output file.**

  To configure the published app, apply the setting in the _{appname}.runtimeconfig.json_ file's `runtimeOptions/configProperties` section.

  ```json
  {
    "runtimeOptions": {
      "configProperties": {
        "Switch.System.Drawing.Printing.OptimizePrintPreview": true,
      }
    }
  }
  ```

  For more information about runtime config, see [.NET runtime configuration settings](/dotnet/core/runtime-config/).

# [.NET Framework](#tab/dotnetframework)

Add the following switch to the [`<AppContextSwitchOverrides>`](/dotnet/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element) element in the [`<runtime>`](/dotnet/framework/configure-apps/file-schema/runtime/index) section of the app config file:

```xml
<runtime >
   <!-- AppContextSwitchOverrides values are in the form of "key1=true|false;key2=true|false" -->
   <AppContextSwitchOverrides value="Switch.System.Drawing.Printing.OptimizePrintPreview=true" />
</runtime >
```

> [!TIP]
> If .NET Framework 4.5.2 (no longer supported) is installed, enable the optimization by adding the following key to the `<appSettings>` section of your configuration file to improve the performance of <xref:System.Windows.Forms.PrintPreviewDialog> control initialization:
>
> ```xml
> <appSettings>
>    <add key="EnablePrintPreviewOptimization" value="true" />
> </appSettings>
> ```

---

## See also

- <xref:System.Windows.Forms.PrintPreviewDialog>
- [PrintPreviewControl Control Overview](printpreviewcontrol-control-overview-windows-forms.md)
- [PrintPreviewDialog Control](printpreviewdialog-control-windows-forms.md)
- [Dialog-Box Controls and Components](dialog-box-controls-and-components-windows-forms.md)
