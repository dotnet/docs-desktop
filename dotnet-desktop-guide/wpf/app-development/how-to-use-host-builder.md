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
#customer intent: As a WPF developer, I want to use the .NET Generic Host in my WPF application so that I can use dependency injection, configuration, and logging.
---

# Use the .NET Generic Host in a WPF app

The .NET Generic Host provides a standardized way to configure and run applications with built-in support for dependency injection (DI), configuration, and logging. WPF applications don't include Host Builder integration by default, but you can add it. This article shows how to set up the Generic Host in a WPF app to inject services into your windows and use the full .NET hosting infrastructure.

## Prerequisites

- The `Microsoft.Extensions.Hosting` NuGet package.

## Set up the Generic Host

To integrate the Generic Host with your WPF app:

1. Remove `StartupUri` from the application XAML file and wire up the `Startup` and `Exit` event handlers:

   :::code language="xaml" source="snippets/how-to-use-host-builder/csharp/App.xaml" highlight="4,5":::

1. Build the host in the code-behind.

   The `Application_Startup` method creates the host with <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder%2A>, registers services on the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder.Services%2A> property, starts the host, and shows the main window:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/App.xaml.cs" id="CreateHost":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/Application.xaml.vb" id="CreateHost":::

1. Stop and dispose of the host when the application exits to clean up resources:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/App.xaml.cs" id="StopHost":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/Application.xaml.vb" id="StopHost":::

## Create a service

The `Services` property in the previous section registers services with the DI container. To create a custom service:

1. Define a service interface:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/IGreetingService.cs" id="IGreetingService":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/IGreetingService.vb" id="IGreetingService":::

1. Create a class that implements the interface. The `GreetingService` class accepts <xref:Microsoft.Extensions.Configuration.IConfiguration> through constructor injection to read values from `appsettings.json`:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/GreetingService.cs" id="GreetingService":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/GreetingService.vb" id="GreetingService":::

## Run a hosted service

The Generic Host can also run background services that participate in the application's lifecycle. The host calls an <xref:Microsoft.Extensions.Hosting.IHostedService> implementation when it starts and stops. To add a hosted service:

1. Create a class that implements <xref:Microsoft.Extensions.Hosting.IHostedService>. The following class writes to the debug output when the host starts and stops:

   :::code language="csharp" source="snippets/how-to-use-host-builder/csharp/SampleLifecycleService.cs" id="SampleLifecycleService":::
   :::code language="vb" source="snippets/how-to-use-host-builder/vb/SampleLifecycleService.vb" id="SampleLifecycleService":::

1. Register the service with `AddHostedService` on the builder's `Services` property, as shown in the `Application_Startup` method in the [Set up the Generic Host](#set-up-the-generic-host) section.

The host calls `StartAsync` when starting and `StopAsync` when stopping, so the debug output appears in the **Output** window in Visual Studio.

## Inject services into a window

The DI container injects dependencies into registered windows through constructor injection. To consume services in a window:

1. Add constructor parameters for each service the window needs.
1. Store the injected services in private fields.
1. Use the services in event handlers or other methods.

The following code shows `MainWindow` accepting `ILogger<MainWindow>` and `IGreetingService` through its constructor:

:::code language="csharp" source="snippets/how-to-use-host-builder/csharp/MainWindow.xaml.cs" id="MainWindowCodeBehind":::
:::code language="vb" source="snippets/how-to-use-host-builder/vb/MainWindow.xaml.vb" id="MainWindowCodeBehind":::

## Add configuration

<xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder%2A> automatically loads `appsettings.json` when the file is in the output directory. To add a configuration file to your project:

1. Create an `appsettings.json` file in the project root with your configuration values:

   :::code language="json" source="snippets/how-to-use-host-builder/csharp/appsettings.json":::

1. Set `CopyToOutputDirectory` to `PreserveNewest` in the project file so the file copies to the output directory:

   :::code language="xml" source="snippets/how-to-use-host-builder/csharp/HostBuilderApp.csproj" highlight="17-19":::

## Related content

- [Dependency injection in .NET](/dotnet/core/extensions/dependency-injection)
- [.NET Generic Host](/dotnet/core/extensions/generic-host)
- [Logging in .NET](/dotnet/core/extensions/logging)
- [Configuration in .NET](/dotnet/core/extensions/configuration)
