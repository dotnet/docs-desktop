---
title: WFAC002 error
description: Learn about the Windows Forms code that generate compile-time error WFAC002.
ms.date: 11/22/2023
---
# WFAC002: Unsupported property value

The related application configuration values defined in the project file are invalid. The following snippet demonstrates valid values:

```xml
<PropertyGroup>

  <ApplicationVisualStyles>true</ApplicationVisualStyles>
  <ApplicationUseCompatibleTextRendering>false</ApplicationUseCompatibleTextRendering>
  <ApplicationHighDpiMode>SystemAware</ApplicationHighDpiMode>
  <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>

</PropertyGroup>
```

## How to fix

Change the invalid setting to a valid value.
