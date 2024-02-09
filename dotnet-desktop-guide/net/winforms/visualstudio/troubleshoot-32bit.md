---
title: X
description: X.
ms.date: 06/01/2023
ms.topic: overview
---

# 32-bit problems in a 64-bit world (Windows Forms .NET)

Visual Studio 2022 is a 64-bit process, and cannot reference 32-bit .NET Framework, 32-bit .NET, or 32-bit COM\ActiveX libraries. This situation can prevent you from upgrading from previous versions of Visual Studio. You may not realize you have refernces to 32-bit components until you try to upgrade. References that compile to 64-bit or target `AnyCPU` work. However, if the component you're using references something 32-bit, the same problems arise.

As Windows Forms support was added to .NET, Visual Studio was unable to support it because Visual Studio runs on .NET Framework, not .NET. You can't use .NET references from a .NET Framework process. Visual Studio can't invoke the designer to design .NET Windows Forms, forms. To address this issue, the Windows Forms team created the **out-of-process designer** for Visual Studio and .NET, as a translation layer that communicates between the .NET project and the in-process Visual Studio designer based on .NET Framework.

The **out-of-process designer** has been improved, with some limitations, to handle 32-bit issues with Visual Studio 2022:

- .NET Frameworks benefit from improved type resolution.
- ActiveX and COM references are supported in both .NET Framework and .NET.
- The in-process designer detects 32-bit assembly load failures and can suggest enabling the out-of-process designer.

Support for 32-bit references requires **Visual Studio 17.9 Preview 2 or later**. This is a preview feature and feedback is welcome. [TODO: LINK TO FEEDBACK]().

## Use the out-of-process designer

Support for 32-bit references requires **Visual Studio 17.9 Preview 2 or later**. Enable it by adding the following `<PropertyGroup>` setting to your project file:

```xml
<PropertyGroup>
    <UseWinFormsOutOfProcDesigner>True</UseWinFormsOutOfProcDesigner>
</PropertyGroup>
```

After modifying the project file, you'll need to reload the project.

## 32-bit issue detection

Currently, when Visual Studio detects when a 32-bit reference fails to load, it prompts you to enable the Windows Forms Out-of-process Designer. If you agree to enable it, the project is updated for you and then reloaded.

## The types of errors you may encounter

...
