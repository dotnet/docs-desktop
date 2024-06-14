---
title: "How to: Persist and Restore Application-Scope Properties Across Application Sessions"
description: Learn how to persist and restore application-scope properties across application sessions via included code examples in XAML, C#, and Visual Basic.
ms.date: 06/13/2024
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application-scope properties [WPF], persisting"
  - "persisting application-scope properties [WPF]"
  - "properties [WPF], persisting"
  - "restoring application-scope properties [WPF]"
  - "properties [WPF], restoring"
  - "application-scope properties [WPF], restoring"
ms.assetid: 55d5904a-f444-4eb5-abd3-6bc74dd14226
---
# How to: Persist and Restore Application-Scope Properties Across Application Sessions

This example shows how to persist application-scope properties when an application shuts down, and how to restore application-scope properties when an application is next launched.

## Example

The application persists application-scope properties to, and restores them from, isolated storage. Isolated storage is a protected storage area that can safely be used by applications without file access permission. The *App.xaml* file defines the `App_Startup` method as the handler for the <xref:System.Windows.Application.Startup?displayProperty=nameWithType> event, and the `App_Exit` method as the handler for the <xref:System.Windows.Application.Exit?displayProperty=nameWithType> event, as shown in the highlighted lines of the following XAML:

> [!NOTE]
> The following XAML is written for CSharp. The Visual Basic version omits the class declaration.

:::code language="xaml" source="./snippets/persist-and-restore-application-scope-properties/csharp/App.xaml" highlight="5,6":::

This next example shows the Application code-behind, which contains the event handlers for the XAML. The `App_Startup` method restores application-scope properties, and the `App_Exit` method saves application-scope properties.

:::code language="csharp" source="./snippets/persist-and-restore-application-scope-properties/csharp/App.xaml.cs":::

:::code language="vb" source="./snippets/persist-and-restore-application-scope-properties/vb/Application.xaml.vb":::
