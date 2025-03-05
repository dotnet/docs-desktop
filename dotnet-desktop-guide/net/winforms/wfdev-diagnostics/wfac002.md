---
title: WFAC002 error
description: Learn about the Windows Forms code that generate compile-time error WFAC002.
ms.date: 03/05/2025
f1_keywords:
  - "WFAC002"
helpviewer_keywords:
  - "WFAC002"
# NOTE: This error/warning is part of the old diagnostic identifiers. It's not being maintained.
---
# Compiler Warning WFAC002

**Version introduced:** .NET 6

> Unsupported property value.

> [!IMPORTANT]
> Starting with .NET 9, this error has changed to [WFO0002](../compiler-messages/wfo0002.md).

Error WFAC002 is generated when one of the following project properties is set to an invalid value in the project file:

```xml
<PropertyGroup>

  <ApplicationVisualStyles>true</ApplicationVisualStyles>
  <ApplicationUseCompatibleTextRendering>false</ApplicationUseCompatibleTextRendering>
  <ApplicationHighDpiMode>SystemAware</ApplicationHighDpiMode>
  <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>

</PropertyGroup>
```

These properties must be set to valid values because they're used in code generation. If these properties are invalid, the method `ApplicationConfiguration.Initialize` may not be generated or may contain invalid code.

## To correct this error

Change the invalid setting to a valid value. For more information, see [Application Bootstrap](../whats-new/net60.md#new-application-bootstrap).

## Suppress an error

> [!IMPORTANT]
> It's not recommended that you suppress this error.

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFAC002.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFAC002</NoWarn>
  </PropertyGroup>
  ```

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).
