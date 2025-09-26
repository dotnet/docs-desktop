---
title: "Drag-and-Drop Operations and Clipboard Support"
description: Learn how to enable user drag-and-drop operations and clipboard support within Windows Forms applications, including the new type-safe APIs introduced in .NET 10.
ms.date: "09/26/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "drag and drop [Windows Forms]"
  - "drag and drop [Windows Forms], Windows Forms"
  - "Clipboard [Windows Forms], Windows Forms"
  - "TryGetData [Windows Forms]"
  - "SetDataAsJson [Windows Forms]"
  - "BinaryFormatter removal [Windows Forms]"
ms.assetid: 7cce79b6-5835-46fd-b690-73f12ad368b2
ai-usage: ai-assisted
---
# Drag-and-Drop Operations and Clipboard Support

You can enable user drag-and-drop operations within a Windows-based application by handling a series of events, most notably the <xref:System.Windows.Forms.Control.DragEnter>, <xref:System.Windows.Forms.Control.DragLeave>, and <xref:System.Windows.Forms.Control.DragDrop> events.

You can also implement user cut/copy/paste support and user data transfer to the Clipboard within your Windows-based applications by using simple method calls.

## .NET 10 Compatibility

Starting with .NET 9, `BinaryFormatter` was removed from the runtime due to security vulnerabilities. This removal broke clipboard and drag-and-drop operations for custom objects, creating a functionality gap for Windows Forms applications.

.NET 10 addresses this issue by introducing new APIs that restore clipboard and drag-and-drop functionality while improving security, error handling, and cross-process compatibility. These APIs use JSON serialization and provide type-safe methods for data operations.

Key improvements in .NET 10 include:

- **Type-safe data retrieval** with `TryGetData<T>()` methods that provide better error handling.
- **JSON serialization** for custom types using `SetDataAsJson<T>()` methods.
- **Built-in support** for common data types without requiring binary serialization.

For comprehensive guidance on updating your applications, see [Clipboard and drag-and-drop changes in .NET 10](../migration/clipboard-dataobject-net10.md).

## In This Section

[Walkthrough: Performing a Drag-and-Drop Operation in Windows Forms](walkthrough-performing-a-drag-and-drop-operation-in-windows-forms.md)\
Explains how to start a drag-and-drop operation.

[How to: Perform Drag-and-Drop Operations Between Applications](how-to-perform-drag-and-drop-operations-between-applications.md)\
Illustrates how to accomplish drag-and-drop operations across applications.

[How to: Add Data to the Clipboard](how-to-add-data-to-the-clipboard.md)\
Describes how to programmatically insert information on the Clipboard, including the new type-safe APIs available in .NET 10.

[How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)\
Describes how to access data stored on the Clipboard using both legacy methods and the new type-safe `TryGetData<T>()` methods.

[Clipboard and drag-and-drop changes in .NET 10](../migration/clipboard-dataobject-net10.md)\
Comprehensive guide for migrating clipboard and drag-and-drop code to the new .NET 10 APIs and understanding the removal of `BinaryFormatter`.

## Related Sections

[Drag-and-Drop Functionality in Windows Forms](../input-mouse/drag-and-drop.md)\
Describes the methods, events, and classes used to implement drag-and-drop behavior.

<xref:System.Windows.Forms.Control.QueryContinueDrag>
Describes the intricacies of the event that asks permission to continue the drag operation.

<xref:System.Windows.Forms.Control.DoDragDrop%2A>
Describes the intricacies of the method that's central to beginning a drag operation.

<xref:System.Windows.Forms.Clipboard>
Also see [How to: Send Data to the Active MDI Child](how-to-send-data-to-the-active-mdi-child.md).
