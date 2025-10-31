---
title: "How to retrieve Data from the Clipboard"
description: Learn how to use the methods provided by the System.Windows.Forms.Clipboard class to interact with the Windows operating system Clipboard feature.
ms.date: 10/31/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "pasting Clipboard data"
  - "Clipboard [Windows Forms], retrieving data"
ms.assetid: 99612537-2c8a-449f-aab5-2b3b28d656e7
ai-usage: ai-assisted
zone_pivot_groups: desktop-version
---
# How to retrieve data from the Clipboard

The <xref:System.Windows.Forms.Clipboard> class provides methods that you can use to interact with the Windows operating system Clipboard feature. Many applications use the Clipboard as a temporary repository for data. For example, word processors use the Clipboard during cut-and-paste operations. The Clipboard is also useful for transferring information from one application to another.

Some applications store data on the Clipboard in multiple formats to increase the number of other applications that can potentially use the data. A Clipboard format is a string that identifies the format. An application that uses the identified format can retrieve the associated data on the Clipboard. The <xref:System.Windows.Forms.DataFormats> class provides predefined format names for your use. You can also use your own format names or use an object's type as its format. For information about adding data to the Clipboard, see [How to add data to the Clipboard](how-to-add-data-to-the-clipboard.md).

::: zone pivot="dotnet"

To determine whether the Clipboard contains data in a particular format, use one of the `Contains`*Format* methods. To retrieve data from the Clipboard, use one of the `Get`*Format* methods or the <xref:System.Windows.Forms.Clipboard.TryGetData%2A> method for custom formats.

> [!NOTE]
> In .NET Framework, you use the <xref:System.Windows.Forms.Clipboard.GetData%2A> method instead of `TryGetData`, and the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A> method is commonly used for multiple format scenarios.

::: zone-end

::: zone pivot="dotnetframework"

To determine whether the Clipboard contains data in a particular format, use one of the `Contains`*Format* methods. To retrieve data from the Clipboard, use one of the `Get`*Format* methods or the <xref:System.Windows.Forms.Clipboard.GetData%2A> method for custom formats.

You can also use the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A?displayProperty=nameWithType> method and call the methods of the returned <xref:System.Windows.Forms.IDataObject>. To determine whether a particular format is available in the returned object, for example, call the <xref:System.Windows.Forms.IDataObject.GetDataPresent%2A> method.

::: zone-end

> [!NOTE]
> All Windows-based applications share the system Clipboard. Therefore, the contents are subject to change when you switch to another application.
>
> The <xref:System.Windows.Forms.Clipboard> class can only be used in threads set to single thread apartment (STA) mode. To use this class, ensure that your `Main` method is marked with the <xref:System.STAThreadAttribute> attribute.

### To retrieve data from the Clipboard in a single, common format

::: zone pivot="dotnet"

1. Use the <xref:System.Windows.Forms.Clipboard.GetAudioStream%2A>, <xref:System.Windows.Forms.Clipboard.GetFileDropList%2A>, <xref:System.Windows.Forms.Clipboard.GetImage%2A>, or <xref:System.Windows.Forms.Clipboard.GetText%2A> method. Optionally, use the corresponding `Contains`*Format* methods first to determine whether data is available in a particular format.

   For custom data formats, use the `TryGetData` method instead of the obsoleted `GetData` method. The `GetData` method returns data successfully in most cases, but when `BinaryFormatter` is required for deserialization and isn't enabled, it returns a <xref:System.NotSupportedException> instance that indicates `BinaryFormatter` is needed. For custom data formats, it's recommended to use the JSON-based methods (`SetDataAsJson<T>()` and `TryGetData<T>()`) for better type safety and to avoid `BinaryFormatter` dependencies.

> [!NOTE]
> In .NET Framework, these same `Get`*Format* methods are available, but you use `GetData` instead of `TryGetData` for custom formats.

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/csharp/MainForm.cs" id="RetrieveCommonFormat":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/vb/MainForm.vb" id="RetrieveCommonFormat":::

::: zone-end

::: zone pivot="dotnetframework"

1. Use the <xref:System.Windows.Forms.Clipboard.GetAudioStream%2A>, <xref:System.Windows.Forms.Clipboard.GetFileDropList%2A>, <xref:System.Windows.Forms.Clipboard.GetImage%2A>, or <xref:System.Windows.Forms.Clipboard.GetText%2A> method. Optionally, use the corresponding `Contains`*Format* methods first to determine whether data is available in a particular format.

> [!NOTE]
> In .NET (non-Framework), the `GetData` method is obsoleted in favor of `TryGetData` for custom data formats. `GetData` returns data successfully in most cases, but when `BinaryFormatter` is required for deserialization and isn't enabled, it returns a <xref:System.NotSupportedException> instance that indicates `BinaryFormatter` is needed.

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/csharp/form1.cs" id="RetrieveCommonFormat":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/vb/form1.vb" id="RetrieveCommonFormat":::

::: zone-end

### To retrieve data from the Clipboard in a custom format

::: zone pivot="dotnet"

1. Use the <xref:System.Windows.Forms.Clipboard.TryGetData%2A> method with a custom format name. This method replaces the obsoleted `GetData` method in modern .NET versions.

   You can also use predefined format names with this method. For more information, see <xref:System.Windows.Forms.DataFormats>.

> [!IMPORTANT]
> In .NET 10 and later, `SetData` no longer works with types that require `BinaryFormatter` for serialization. The `GetData` method returns data successfully in most cases, but when `BinaryFormatter` is required for deserialization and isn't enabled, it returns a <xref:System.NotSupportedException> instance that indicates `BinaryFormatter` is needed. The examples below show how to retrieve data that may have been set by other applications or earlier .NET versions.

> [!NOTE]
> In .NET Framework, you use the <xref:System.Windows.Forms.Clipboard.GetData%2A> method instead of `TryGetData`, and object serialization through `SetData` is fully supported.

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/csharp/MainForm.cs" id="RetrieveCustomFormat":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/vb/MainForm.vb" id="RetrieveCustomFormat":::

The `Customer` class used in the previous snippet:

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/csharp/MainForm.cs" id="HelperMethods":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/vb/MainForm.vb" id="HelperMethods":::

::: zone-end

::: zone pivot="dotnetframework"

1. Use the <xref:System.Windows.Forms.Clipboard.GetData%2A> method with a custom format name.

   You can also use predefined format names with the <xref:System.Windows.Forms.Clipboard.SetData%2A> method. For more information, see <xref:System.Windows.Forms.DataFormats>.

> [!NOTE]
> In .NET (non-Framework), the `GetData` method is obsoleted in favor of `TryGetData`. `GetData` returns data successfully in most cases, but when `BinaryFormatter` is required for deserialization and isn't enabled, it returns a <xref:System.NotSupportedException> instance that indicates `BinaryFormatter` is needed.

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/csharp/form1.cs" id="RetrieveCustomFormat":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/vb/form1.vb" id="RetrieveCustomFormat":::
:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/csharp/form1.cs" id="HelperMethods":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/vb/form1.vb" id="HelperMethods":::

::: zone-end

### To retrieve data from the Clipboard in multiple formats

::: zone pivot="dotnet"

1. Use the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A> method to get an <xref:System.Windows.Forms.IDataObject>, then use <xref:System.Windows.Forms.Clipboard.TryGetData%2A> to retrieve data in specific formats.

   This approach is recommended for modern .NET applications as it uses the newer, safer APIs.

> [!NOTE]
> In .NET Framework, you typically use the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A> method and work directly with the returned <xref:System.Windows.Forms.IDataObject>, using its methods like <xref:System.Windows.Forms.IDataObject.GetData%2A> instead of the newer `TryGetData` approach.

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/csharp/MainForm.cs" id="RetrieveMultipleFormats":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/vb/MainForm.vb" id="RetrieveMultipleFormats":::
:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/csharp/MainForm.cs" id="HelperMethods":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/net/vb/MainForm.vb" id="HelperMethods":::

::: zone-end

::: zone pivot="dotnetframework"

1. Use the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A> method.

> [!NOTE]
> In .NET (non-Framework), you typically combine `GetDataObject` with the newer `TryGetData` method rather than working directly with the <xref:System.Windows.Forms.IDataObject> methods.

:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/csharp/form1.cs" id="RetrieveMultipleFormats":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/vb/form1.vb" id="RetrieveMultipleFormats":::
:::code language="csharp" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/csharp/form1.cs" id="HelperMethods":::
:::code language="vb" source="./snippets/how-to-retrieve-data-from-the-clipboard/framework/vb/form1.vb" id="HelperMethods":::

::: zone-end

## See also

- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)
- [How to add data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [Windows Forms clipboard and DataObject changes in .NET 10](../migration/clipboard-dataobject-net10.md)
