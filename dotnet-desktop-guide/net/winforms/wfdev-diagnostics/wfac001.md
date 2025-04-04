---
title: WFAC001 error
description: Learn about the Windows Forms code that generate compile-time error WFAC001.
ms.date: 04/02/2025
f1_keywords:
  - "WFAC001"
helpviewer_keywords:
  - "WFAC001"
# NOTE: This error/warning is part of the old diagnostic identifiers. It's not being maintained.
---
# Compiler Warning WFAC001

**Version introduced:** .NET 6

> Only projects with `OutputType=WindowsApplication` supported.

Library projects can't call the Windows Forms bootstrap code. Only projects with `OutputType` set to `Exe` or `WinExe` are supported, because only application projects define an application entry point, where the application bootstrap code must reside.

> [!IMPORTANT]
> Starting with .NET 9, this warning has changed to [WFO0001](../compiler-messages/wfo0001.md).

## How to fix

Remove the call to `ApplicationConfiguration.Initialize` or change the project type to an executable.
