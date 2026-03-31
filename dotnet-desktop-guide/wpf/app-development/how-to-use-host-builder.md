---
title: "Use the .NET Generic Host in a WPF app"
description: "Learn how to integrate the .NET Generic Host with a WPF application for dependency injection, configuration, and logging."
ms.date: 03/30/2026
ms.topic: how-to
ms.service: dotnet-desktop
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
#customer intent: As a WPF developer, I want to use the .NET Generic Host in my WPF application so that I can leverage dependency injection, configuration, and logging.
---

# Use the .NET Generic Host in a WPF app

The .NET Generic Host provides a standardized way to configure and run applications with built-in support for dependency injection (DI), configuration, and logging. WPF applications don't include Host Builder integration by default, but you can add it. This article shows how to set up the Generic Host in a WPF app so you can inject services into your windows and use the full .NET hosting infrastructure.

## Prerequisites

- .NET 10 SDK
- The `Microsoft.Extensions.Hosting` NuGet package

## Set up the Generic Host

To integrate the Generic Host with your WPF app:

1. Remove `StartupUri` from `App.xaml` and use the `Startup` event instead.
1. Build the host in the startup handler.
1. Register services in the DI container.
1. Stop the host when the application exits.

First, update the application XAML file to remove `StartupUri` and wire up the `Startup` and `Exit` event handlers:

:::code language="xaml" source="snippets/how-to-use-host-builder/csharp/App.xaml":::

> [!NOTE]
> In Visual Basic, this file is named `Application.xaml` instead of `App.xaml`.

:::code language="xaml" source="snippets/how-to-use-host-builder/vb/Application.xaml":::

Next, configure the host in the code-behind. The `Application_Startup` method builds the host, registers services, starts the host, and shows the main window:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/App.xaml.cs" id="CreateHost":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/Application.xaml.vb" id="CreateHost":::

The key parts of the host setup are:

- <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> sets up configuration (including `appsettings.json`), logging, and the DI container.
- <xref:Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices%2A> registers your services and windows with the DI container.
- The host starts asynchronously, then resolves and shows `MainWindow`.

When the application exits, stop and dispose of the host to clean up resources:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/App.xaml.cs" id="StopHost":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/Application.xaml.vb" id="StopHost":::

## Register and consume services

Once the host runs, you can register custom services and inject them into your windows. To create and register a service:

1. Define a service interface.
1. Create a class that implements the interface.
1. Register the interface and implementation in the `ConfigureServices` callback.

The following code defines an `IGreetingService` interface:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/IGreetingService.cs" id="IGreetingService":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/IGreetingService.vb" id="IGreetingService":::

Next, create a class that implements the interface. The `GreetingService` class injects <xref:Microsoft.Extensions.Configuration.IConfiguration> to read values from `appsettings.json`:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/GreetingService.cs" id="GreetingService":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/GreetingService.vb" id="GreetingService":::

Register the service and the main window in the `ConfigureServices` callback:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/App.xaml.cs" id="RegisterServices":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/Application.xaml.vb" id="RegisterServices":::

## Run a hosted service

The Generic Host can also run background services that participate in the application's lifecycle. An <xref:Microsoft.Extensions.Hosting.IHostedService> implementation receives callbacks when the host starts and stops. To add a hosted service:

1. Create a class that implements <xref:Microsoft.Extensions.Hosting.IHostedService>.
1. Write startup logic in `StartAsync` and cleanup logic in `StopAsync`.
1. Register the service with `AddHostedService` in the `ConfigureServices` callback.

The following class writes to the debug output when the host starts and stops:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/SampleLifecycleService.cs" id="SampleLifecycleService":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/SampleLifecycleService.vb" id="SampleLifecycleService":::

The host calls `StartAsync` during <xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A> and `StopAsync` during <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>, so the debug output appears in the **Output** window in Visual Studio.

## Inject services into a window

Windows registered in the DI container receive their dependencies through constructor injection. To consume services in a window:

1. Add constructor parameters for each service the window needs.
1. Store the injected services in private fields.
1. Use the services in event handlers or other methods.

The following code shows `MainWindow` accepting `ILogger<MainWindow>` and `IGreetingService` through its constructor:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/MainWindow.xaml.cs" id="MainWindowCodeBehind":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/MainWindow.xaml.vb" id="MainWindowCodeBehind":::

## Add configuration

<xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> automatically loads `appsettings.json` when the file is in the output directory. To add a configuration file to your project:

1. Create an `appsettings.json` file in the project root.
1. Set `CopyToOutputDirectory` to `PreserveNewest` in the project file so the file copies to the output directory.

The following example provides a `GreetingMessage` value that `GreetingService` reads:

:::code language="json" source="snippets/how-to-use-host-builder/csharp/appsettings.json":::

Update the project file to copy the configuration file to the output directory:

:::code language="xml" source="snippets/how-to-use-host-builder/csharp/HostBuilderApp.csproj":::

## Related content

- [Dependency injection in .NET](/dotnet/core/extensions/dependency-injection)
- [.NET Generic Host](/dotnet/core/extensions/generic-host)
- [Logging in .NET](/dotnet/core/extensions/logging)
- [Configuration in .NET](/dotnet/core/extensions/configuration)
