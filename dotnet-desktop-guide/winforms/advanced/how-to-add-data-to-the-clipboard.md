---
title: "How to: Add Data to the Clipboard"
ms.date: 10/02/2025
ms.service: dotnet-framework
ms.update-cycle: 1825-days
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Clipboard [Windows Forms], copying data to"
  - "data [Windows Forms], copying to Clipboard"
ms.assetid: 25152454-0e78-40a9-8a9e-a2a5a274e517
description: Learn how to add data to the clipboard within many applications and transfer that data from one application to another.
---
# How to: Add Data to the Clipboard

The <xref:System.Windows.Forms.Clipboard> class provides methods that you can use to interact with the Windows operating system Clipboard feature. Many applications use the Clipboard as a temporary repository for data. For example, word processors use the Clipboard during cut-and-paste operations. The Clipboard is also useful for transferring data from one application to another.

When you add data to the Clipboard, you can indicate the data format so that other applications can recognize the data if they can use that format. You can also add data to the Clipboard in multiple different formats to increase the number of other applications that can potentially use the data.

A Clipboard format is a string that identifies the format so that an application that uses that format can retrieve the associated data. The <xref:System.Windows.Forms.DataFormats> class provides predefined format names for your use. You can also use your own format names or use the type of an object as its format.

> [!NOTE]
> All Windows-based applications share the Clipboard. Therefore, the contents are subject to change when you switch to another application.
>
> The <xref:System.Windows.Forms.Clipboard> class can only be used in threads set to single thread apartment (STA) mode. To use this class, ensure that your `Main` method is marked with the <xref:System.STAThreadAttribute> attribute.

To add data to the Clipboard in one or multiple formats, use the <xref:System.Windows.Forms.Clipboard.SetDataObject%2A> method. You can pass any object to this method, but to add data in multiple formats, you must first add the data to a separate object designed to work with multiple formats. Typically, you will add your data to a <xref:System.Windows.Forms.DataObject>, but you can use any type that implements the <xref:System.Windows.Forms.IDataObject> interface.

To add data to the Clipboard in a single, common format, use the specific method for that format, such as <xref:System.Windows.Forms.Clipboard.SetText%2A> for text.

::: zone pivot="dotnet"

> [!IMPORTANT]
> Custom objects must be serializable to JSON for them to be put on the Clipboard. Use the new type-safe methods like <xref:System.Windows.Forms.Clipboard.SetDataAsJson%2A> which automatically handle JSON serialization. The legacy `SetData()` method no longer works with custom objects starting with .NET 9 due to the removal of `BinaryFormatter`.

::: zone-end

::: zone pivot="dotnetframework"

> [!IMPORTANT]
> An object must be serializable for it to be put on the Clipboard. To make a type serializable, mark it with the <xref:System.SerializableAttribute> attribute. If you pass a non-serializable object to a Clipboard method, the method will fail without throwing an exception. For more information about serialization, see <xref:System.Runtime.Serialization>.

::: zone-end

### To add data to the Clipboard in a single, common format

1. Use the <xref:System.Windows.Forms.Clipboard.SetAudio%2A>, <xref:System.Windows.Forms.Clipboard.SetFileDropList%2A>, <xref:System.Windows.Forms.Clipboard.SetImage%2A>, or <xref:System.Windows.Forms.Clipboard.SetText%2A> method.

::: zone pivot="dotnet"

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/net/csharp/Form1.cs" id="SetTextExample":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/net/vb/Form1.vb" id="SetTextExample":::

::: zone-end

::: zone pivot="dotnetframework"

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/framework/csharp/ClipboardOperations.cs" id="SetTextExample":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/framework/vb/ClipboardOperations.vb" id="SetTextExample":::

::: zone-end

### To add data to the Clipboard in a custom format

::: zone pivot="dotnet"

1. Use the <xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)?displayProperty=nameWithType> method with a custom format name and your object.

    The `SetDataAsJson<T>()` method automatically serializes your custom objects using `System.Text.Json`. This is the recommended approach in .NET 10 and later for storing custom types on the clipboard, as it provides type safety and security advantages over the legacy `SetData()` method.

    > [!IMPORTANT]
    > The legacy <xref:System.Windows.Forms.Clipboard.SetData%2A> method no longer works with custom objects in .NET 9 and later due to the removal of `BinaryFormatter`. Use `SetDataAsJson<T>()` instead for custom types.

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/net/csharp/Form1.cs" id="CustomFormatExample":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/net/vb/Form1.vb" id="CustomFormatExample":::

The `Customer` class used in the previous snippet:

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/net/csharp/Form1.cs" id="CustomerClass":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/net/vb/Form1.vb" id="CustomerClass":::

::: zone-end

::: zone pivot="dotnetframework"

1. Use the <xref:System.Windows.Forms.Clipboard.SetData%2A> method with a custom format name.

    You can also use predefined format names with the <xref:System.Windows.Forms.Clipboard.SetData%2A> method. For more information, see <xref:System.Windows.Forms.DataFormats>.

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/framework/csharp/ClipboardOperations.cs" id="CustomFormatExample":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/framework/vb/ClipboardOperations.vb" id="CustomFormatExample":::

The `Customer` class used in the previous snippet:

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/framework/csharp/ClipboardOperations.cs" id="CustomerClass":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/framework/vb/ClipboardOperations.vb" id="CustomerClass":::

::: zone-end

### To add data to the Clipboard in multiple formats

1. Use the <xref:System.Windows.Forms.Clipboard.SetDataObject%2A?displayProperty=nameWithType> method and pass in a <xref:System.Windows.Forms.DataObject> that contains your data.

::: zone pivot="dotnet"

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/net/csharp/Form1.cs" id="MultipleFormatsExample":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/net/vb/Form1.vb" id="MultipleFormatsExample":::

The `Customer` class used in the previous snippet:

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/net/csharp/Form1.cs" id="CustomerClass":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/net/vb/Form1.vb" id="CustomerClass":::

::: zone-end

::: zone pivot="dotnetframework"

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/framework/csharp/ClipboardOperations.cs" id="MultipleFormatsExample":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/framework/vb/ClipboardOperations.vb" id="MultipleFormatsExample":::

The `Customer` class used in the previous snippet:

:::code language="csharp" source="./snippets/how-to-add-data-to-the-clipboard/framework/csharp/ClipboardOperations.cs" id="CustomerClass":::
:::code language="vb" source="./snippets/how-to-add-data-to-the-clipboard/framework/vb/ClipboardOperations.vb" id="CustomerClass":::

::: zone-end

## See also

- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)
- [How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [Windows Forms clipboard and DataObject changes in .NET 10](../../migration/clipboard-dataobject-net10.md)
