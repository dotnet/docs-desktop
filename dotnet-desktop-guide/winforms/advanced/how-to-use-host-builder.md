---
title: "Use the .NET Generic Host in a Windows Forms app"
description: "Learn how to integrate the .NET Generic Host with a Windows Forms application for dependency injection, configuration, and logging."
ms.date: 03/30/2026
ms.topic: how-to
ms.service: dotnet-desktop
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
#customer intent: As a Windows Forms developer, I want to use the .NET Generic Host in my Windows Forms application so that I can leverage dependency injection, configuration, and logging.
---

# Use the .NET Generic Host in a Windows Forms app

The .NET Generic Host provides a standardized way to configure and run applications with built-in support for dependency injection (DI), configuration, and logging. Windows Forms apps don't include Generic Host integration by default, but you can add it. This article shows how to set up the Generic Host in a Windows Forms app to inject services into your forms.

## Prerequisites

- The [`Microsoft.Extensions.Hosting`](https://www.nuget.org/packages/Microsoft.Extensions.Hosting/) NuGet package.

## Set up the Generic Host

The setup differs slightly between C# and Visual Basic. In C#, configure the host directly in `Program.cs`. In Visual Basic, use the Application Framework's startup and shutdown events in `ApplicationEvents.vb`.

# [C#](#tab/csharp)

Configure the host in `Program.cs` alongside `ApplicationConfiguration.Initialize()`:

1. Call `ApplicationConfiguration.Initialize()` to configure WinForms defaults, including visual styles, high DPI mode, and default fonts.
1. Build the host with <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder*> and register services.
1. Start the host and resolve the main form from DI.
1. Pass the form to <xref:System.Windows.Forms.Application.Run*>.
1. Stop and dispose of the host after the form closes.

The following code shows the complete `Program.cs`:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/Program.cs":::

# [Visual Basic](#tab/vb)

Configure the host through the Application Framework's `Startup` and `Shutdown` events in `ApplicationEvents.vb`:

1. Remove the **Startup form** setting from the Application Framework project properties.

   The `<MainForm>` setting is in the `Application.myapp` file.

   > [!NOTE]
   > Removing this setting prevents the designer from generating an `OnCreateMainForm` override that bypasses DI.

1. Handle the `Startup` event to build and start the host.
1. Handle the `Shutdown` event to stop and dispose of the host.
1. Override `OnCreateMainForm` to resolve the main form from the DI container.
1. Expose the host through a shared property so that forms can resolve services.

The following code shows the complete `ApplicationEvents.vb`:

:::code language="vb" source="snippets/how-to-use-host-builder/vb/ApplicationEvents.vb":::

<!-- markdownlint-disable MD001 -->
### Visual Basic without the Application Framework
<!-- markdownlint-enable MD001 -->

If you're not using the Application Framework, configure the host directly in the `Main` method of your startup class:

:::code language="vb" source="snippets/how-to-use-host-builder/vb/AlternativeProgram.vb" id="ProgramVersion":::

---

## Register and consume services

With the host configured, register custom services and inject them into your forms. To create and register a service:

1. Define a service interface:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/IGreetingService.cs" id="IGreetingService":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/IGreetingService.vb" id="IGreetingService":::

1. Create a class that implements the interface. The `GreetingService` class injects <xref:Microsoft.Extensions.Configuration.IConfiguration> to read the greeting message from `appsettings.json`:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/GreetingService.cs" id="GreetingService":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/GreetingService.vb" id="GreetingService":::

1. Register the interface and implementation on the builder's `Services` property, as shown in the [Set up the Generic Host](#set-up-the-generic-host) section.

## Run a hosted service

The Generic Host can also run background services that participate in the application lifecycle. Implement <xref:Microsoft.Extensions.Hosting.IHostedService> to receive callbacks when the host starts and stops. To add a hosted service:

1. Create a class that implements <xref:Microsoft.Extensions.Hosting.IHostedService>. The following class writes to the debug output when the host starts and stops:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/SampleLifecycleService.cs" id="SampleLifecycleService":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/SampleLifecycleService.vb" id="SampleLifecycleService":::

1. Register the service with `AddHostedService` on the builder's `Services` property, as shown in the [Set up the Generic Host](#set-up-the-generic-host) section.

The host calls `StartAsync` on startup and `StopAsync` on shutdown, so the debug output appears in the **Output** window in Visual Studio.

## Consume services in a form

Because `Form1` is resolved from the DI container, constructor injection works directly:

1. Add constructor parameters for each service the form needs.
1. Store the injected services in private fields.
1. Use the services in event handlers or other methods.

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/Form1.cs" id="Form1":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/Form1.vb" id="Form1":::

## Add configuration

<xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder*> automatically loads `appsettings.json` from the output directory. To add a configuration file:

1. Create an `appsettings.json` file in the project root with your configuration values:

   :::code language="json" source="snippets/how-to-use-host-builder/csharp/appsettings.json":::

1. Set `CopyToOutputDirectory` to `PreserveNewest` in the project file so `appsettings.json` is copied to the output directory:

   :::code language="xml" source="snippets/how-to-use-host-builder/csharp/HostBuilderApp.csproj" highlight="11-15":::

## Related content

- [Dependency injection in .NET](/dotnet/core/extensions/dependency-injection)
- [.NET Generic Host](/dotnet/core/extensions/generic-host)
- [Logging in .NET](/dotnet/core/extensions/logging)
- [Configuration in .NET](/dotnet/core/extensions/configuration)
