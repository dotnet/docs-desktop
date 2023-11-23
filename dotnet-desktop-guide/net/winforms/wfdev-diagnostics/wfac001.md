---
title: WFAC001 error
description: Learn about the Windows Forms code that generate compile-time error WFAC001.
ms.date: 11/22/2023
---
# WFAC001: Only projects with 'OutputType=WindowsApplication' supported

Only projects with `OutputType` set to `Exe` or `WinExe` are supported, because only application projects define an application entry point, where the application bootstrap code must reside.

## How to fix

Remove the call to `ApplicationConfiguration.Initialize` or change the project type to an executable.
