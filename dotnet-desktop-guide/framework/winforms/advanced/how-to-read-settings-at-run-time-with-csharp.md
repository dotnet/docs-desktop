---
title: "How To: Read Settings at Run Time With C#"
description: Learn how to read both Application-scoped and User-scoped settings at run time with C# via the Properties object.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application settings [Windows Forms], reading"
  - "application settings [Windows Forms], run time"
  - "application settings [Windows Forms], C#"
ms.assetid: dbe8bf09-5e1c-49da-9192-154033d7240b
---
# How To: Read Settings at Run Time With C\#

You can read both Application-scoped and User-scoped settings at run time via the Properties object. The Properties object exposes all of the default settings for the project via the Properties.Settings.Default member in the default namespace of the project they are defined in.  
  
## To Read Settings at Run Time with C\#
  
Access the appropriate setting via the Properties.Settings.Default member. The following example shows how to assign a setting named `myColor` to a BackColor property. It requires you to have previously created a Settings file containing a setting named `myColor` of type `System.Drawing.Color`. For information about creating a Settings file, see [How To: Create a New Setting at Design Time](how-to-create-a-new-setting-at-design-time.md).  
  
```csharp
this.BackColor = Properties.Settings.Default.myColor;  
```  
  
## See also

- [Using Application Settings and User Settings](using-application-settings-and-user-settings.md)
- [How To: Write User Settings at Run Time with C#](how-to-write-user-settings-at-run-time-with-csharp.md)
- [Application Settings Overview](application-settings-overview.md)
