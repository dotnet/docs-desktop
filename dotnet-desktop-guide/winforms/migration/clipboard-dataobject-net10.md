---
title: "Clipboard and DataObject changes in .NET 10"
description: "Learn about the major clipboard and drag-and-drop changes in .NET 10, including new type-safe APIs, JSON serialization, and migration from BinaryFormatter."
author: adegeo
ms.author: adegeo
ms.service: dotnet-desktop
ms.topic: concept-article
ms.date: 09/26/2025
dev_langs:
  - "csharp"
  - "vb"
ms.custom:
  - copilot-scenario-highlight
ai-usage: ai-assisted

#customer intent: As a Windows Forms developer, I want to understand the clipboard and DataObject changes in .NET 10 so that I can upgrade my applications and use the new type-safe APIs.

---

# Windows Forms clipboard and DataObject changes in .NET 10

This article shows you how to upgrade your Windows Forms clipboard and drag-and-drop operations to the new type-safe APIs in .NET 10. You'll learn how to use the new <xref:System.Windows.Forms.Clipboard.TryGetData*?displayProperty=nameWithType> and <xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)?displayProperty=nameWithType> methods, understand which built-in types work without changes, and discover strategies for handling custom types and legacy data after the removal of `BinaryFormatter`.

`BinaryFormatter` was removed from the runtime in .NET 9 because of security vulnerabilities. This change broke clipboard and drag-and-drop operations with custom objects. .NET 10 introduces new APIs that use JSON serialization and type-safe methods to restore this functionality, improve security, and provide better error handling and cross-process compatibility.

<xref:System.Windows.Clipboard.SetData(System.String,System.Object)?displayProperty=nameWithType> no longer works with custom types. While this method has always performed a copy operation that serializes data (by default), that serialization now fails for custom types because `BinaryFormatter` has been removed. <xref:System.Windows.Forms.Clipboard.GetData(System.String)?displayProperty=nameWithType> is obsolete in .NET&nbsp;10. When data requires serialization but the format isn't supported, `GetData()` returns a <xref:System.NotSupportedException> instance rather than the actual data. Use the new <xref:System.Windows.Forms.Clipboard.TryGetData*?displayProperty=nameWithType> and <xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)?displayProperty=nameWithType> methods for type-safe operations and JSON serialization of custom objects.

The following sections provide detailed migration guidance, explain which types work without changes, and show how to handle both new development and legacy data scenarios.

## Prerequisites

Before you continue, review these concepts:

- How applications used `BinaryFormatter` in clipboard and drag-and-drop scenarios before .NET&nbsp;9.
- The security vulnerabilities that led to the removal of `BinaryFormatter`.
- How to work with `System.Text.Json` serialization patterns and their limitations.

For more information, see these articles:

- [Deserialization risks in use of BinaryFormatter and related types](/dotnet/standard/serialization/binaryformatter-security-guide).
- [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

## Breaking changes from BinaryFormatter removal

Removing `BinaryFormatter` in .NET 9 fundamentally changes how Windows Forms handles clipboard and drag-and-drop operations with custom types. These changes affect existing code patterns and require careful migration to maintain functionality.

### Custom types no longer serialize automatically

In .NET 8 and earlier, you could place any serializable custom object on the clipboard by calling `SetData()`. The `BinaryFormatter` handled serialization automatically. Starting with .NET 9, `SetData()` still performs a copy operation that attempts to serialize the data, but this serialization fails for custom types because `BinaryFormatter` has been removed.

The following code no longer works:

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/ObsoletePatterns.cs" id="ObsoleteCustomType":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/ObsoletePatterns.vb" id="ObsoleteCustomType":::

#### What you might see

- The `SetData()` method completes without throwing an exception.
- The data is placed on the clipboard, but can't be properly serialized for cross-process use.
- Later attempts to retrieve the data with `GetData()` return a <xref:System.NotSupportedException> instance instead of the actual data, indicating the serialization format isn't supported.

#### Migration guidance

Use the new [`SetDataAsJson<T>()`](xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)) method or manually serialize to a `string` or `byte[]`. For details, see the [Work with custom types](#work-with-custom-types) section.

### GetData() is obsolete - use TryGetData\<T>() instead

The legacy `GetData()` method is obsolete in .NET 10. When data requires serialization but the format isn't supported, `GetData()` returns a <xref:System.NotSupportedException> instance instead of the actual data. When data doesn't require serialization (set with `copy: false`), `GetData()` returns the data, but only within the same process. You should migrate to the new type-safe [`TryGetData<T>()`](xref:System.Windows.Forms.Clipboard.TryGetData*) methods for better error handling and type safety.

**Obsolete code to avoid:**

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/ObsoletePatterns.cs" id="ObsoleteGetData":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/ObsoletePatterns.vb" id="ObsoleteGetData":::

**Modern approach using TryGetData\<T>():**

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/ModernApproach.cs" id="ModernTryGetData":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/ModernApproach.vb" id="ModernTryGetData":::

#### Benefits of TryGetData\<T>()

- Type safety: No need for casting—the method returns the exact type you request.
- Clear error handling: Returns a Boolean success indicator instead of using null or exception patterns.
- Future-proof: Designed to work with new serialization methods and legacy data support.

#### How to identify affected code

Look for:

- Any `GetData()` calls, as the entire method is obsolete regardless of data type.
- `DataObject.GetData()` and `IDataObject.GetData()` usage in drag-and-drop operations.

#### Migration guidance

Replace all `GetData()` usage with type-safe [`TryGetData<T>()`](xref:System.Windows.Forms.Clipboard.TryGetData*) methods. For comprehensive examples of all overloads, see the [New type-safe APIs](#new-type-safe-apis) section.

## New type-safe APIs

.NET 10 introduces three new API families that provide type safety, better error handling, and JSON serialization support for clipboard and drag-and-drop operations:

- <xref:System.Windows.Forms.Clipboard.TryGetData*> methods for retrieving data
- <xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)> methods for storing data
- <xref:System.Windows.Forms.ITypedDataObject> interface for drag-and-drop operations

### TryGetData\<T>() methods

The `TryGetData<T>()` family replaces the obsolete `GetData()` method. It provides type-safe retrieval and clear success or failure indication for your clipboard operations.

#### Basic type-safe retrieval

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/TypeSafeRetrieval.cs" id="BasicTypeSafeRetrieval":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/TypeSafeRetrieval.vb" id="BasicTypeSafeRetrieval":::

#### Custom JSON types

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/TypeSafeRetrieval.cs" id="CustomJsonTypes":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/TypeSafeRetrieval.vb" id="CustomJsonTypes":::

#### Use a type resolver for legacy binary data (requires BinaryFormatter; not recommended)

> [!WARNING]
> Type resolvers only work when BinaryFormatter support is enabled, which isn't recommended due to security risks. For more information, see [Enable BinaryFormatter clipboard support (not recommended)](../advanced/how-to-enable-binaryformatter-clipboard-support.md).

Type resolvers let you handle legacy binary data by mapping type names to actual types during deserialization.

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/TypeResolver.cs" id="TypeResolverExample":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/TypeResolver.vb" id="TypeResolverExample":::

**Important security considerations for type resolvers:**

- Always use an explicit allowlist of permitted types.
- Never allow dynamic type loading or assembly resolution.
- Validate type names before mapping to actual types.
- Throw exceptions for any unauthorized or unknown types.
- Use this approach only as a temporary bridge during migration.

### SetDataAsJson\<T>() methods

These methods provide automatic JSON serialization using `System.Text.Json` with type-safe storage.

#### Automatic format inference

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/SetDataAsJsonExamples.cs" id="AutomaticFormatInference":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/SetDataAsJsonExamples.vb" id="AutomaticFormatInference":::

#### Specify a custom format

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/SetDataAsJsonExamples.cs" id="CustomFormat":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/SetDataAsJsonExamples.vb" id="CustomFormat":::

### ITypedDataObject interface

The <xref:System.Windows.Forms.ITypedDataObject> interface enables type-safe drag-and-drop operations by extending <xref:System.Windows.Forms.IDataObject> with typed methods.

Starting with .NET 10, <xref:System.Windows.Forms.DataObject> (a common type in drag-and-drop scenarios) implements `ITypedDataObject`.

#### Use ITypedDataObject in drag-and-drop scenarios

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/ITypedDataObjectExamples.cs" id="DragDropUsage":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/ITypedDataObjectExamples.vb" id="DragDropUsage":::

## Types that don't require JSON serialization

Many built-in .NET types work with clipboard operations without requiring JSON serialization or `BinaryFormatter` support. These types automatically serialize into the .NET Remoting Binary Format (NRBF), which provides efficient storage and maintains type safety.

These types use NRBF, the same efficient binary format used by the legacy `BinaryFormatter`. NRBF serialization provides these key benefits:

- **Compact binary representation**: Enables efficient storage and transfer.
- **Built-in type information**: Preserves exact .NET types during round-trip operations.
- **Cross-process compatibility**: Works between different .NET applications when data is serialized during the copy operation.
- **Automatic serialization**: Types serialize without custom code.

> [!NOTE]
> Methods like `SetData()` perform a copy operation that serializes data for cross-process clipboard use. If you use the <xref:System.Windows.Forms.DataObject> type directly with `SetDataObject(dataObject, copy)`, you can control serialization by setting the `copy` parameter to `false`, which skips serialization and limits clipboard access to the current process only.

For technical details, see the [.NET Remoting Binary Format specification](/openspecs/windows_protocols/ms-nrbf/75b9fe09-be15-475f-85b8-ae7b7558cfe5).

Classes that support NRBF-encoded data are implemented in the <xref:System.Formats.Nrbf?displayProperty=fullName> namespace.

### Type safety guarantees

Windows Forms provides several safety mechanisms for these built-in types:

- **Exact type matching**. <xref:System.Windows.Forms.Clipboard.TryGetData*> returns only the requested type.
- **Automatic validation**. Windows Forms validates type compatibility during deserialization.
- **No arbitrary code execution**. Unlike custom types with BinaryFormatter, these types can't execute malicious code.
- **Content validation required**. You must still validate data content and ranges for your application logic.
- **No size constraints**. Large arrays or bitmaps aren't automatically limited. Monitor memory usage.

### Supported primitive types

The following primitive types work seamlessly with clipboard and `DataObject` operations. You don't need custom serialization or configuration. The clipboard system automatically handles these built-in .NET types:

- `bool`, `byte`, `char`, `decimal`, `double`, `short`, `int`, and `long`.
- `sbyte`, `ushort`, `uint`, `ulong`, `float`, and `string`.
- `TimeSpan` and `DateTime`.

The following examples show how these primitive types work directly with `SetData()` and `TryGetData<T>()` methods:

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/PrimitiveTypesExamples.cs" id="PrimitiveTypesExample":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/PrimitiveTypesExamples.vb" id="PrimitiveTypesExample":::

### Collections of primitive types

Arrays and generic lists of supported primitive types work without extra configuration. However, keep these limitations in mind:

- All array and list elements must be supported primitive types.
- Avoid `string[]` and `List<string>` because NRBF format has complexity handling null values in string collections.
- Store strings individually or use JSON serialization for string collections.

The following examples show how arrays and lists can be set on the clipboard:

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/PrimitiveTypesExamples.cs" id="CollectionsExample":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/PrimitiveTypesExamples.vb" id="CollectionsExample":::

### System.Drawing types

Common graphics types from the `System.Drawing` namespace work seamlessly with clipboard and `DataObject` operations. These types are useful for applications that work with visual elements and need to transfer drawing-related data between components or applications. Be aware that serializing a `Bitmap` can consume a large amount of memory, especially for large images. The following types are supported:

- `Point`, `PointF`, `Rectangle`, `RectangleF`.
- `Size`, `SizeF`, `Color`.
- `Bitmap` (can consume significant memory when serialized).

The following examples show how these graphics types can be used with clipboard operations:

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/SystemDrawingTypesExamples.cs" id="SystemDrawingTypes":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/SystemDrawingTypesExamples.vb" id="SystemDrawingTypes":::

## Work with custom types

When you use <xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)> and <xref:System.Windows.Forms.Clipboard.TryGetData*> with custom types, `System.Text.Json` handles serialization automatically. Many types work without any special configuration—records, simple classes, and structs with public properties serialize seamlessly.

### Simple types that work without attributes

Most straightforward custom types don't require special configuration:

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/CustomTypesExamples.cs" id="SimpleCustomTypes":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/CustomTypesExamples.vb" id="SimpleCustomTypes":::

### Use JSON attributes for advanced control

Use `System.Text.Json` attributes only when you need to customize serialization behavior. For comprehensive guidance on `System.Text.Json` serialization, attributes, and advanced configuration options, see [JSON serialization and deserialization in .NET](/dotnet/standard/serialization/system-text-json/overview).

The following example shows how you can use JSON attributes to control serialization:

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/CustomTypesExamples.cs" id="JsonAttributesExample":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/CustomTypesExamples.vb" id="JsonAttributesExample":::

### Example: Clipboard operations with custom types

:::code language="csharp" source="./snippets/clipboard-dataobject-net10/net/csharp/CustomTypesExamples.cs" id="CustomTypesClipboardOperations":::
:::code language="vb" source="./snippets/clipboard-dataobject-net10/net/vb/CustomTypesExamples.vb" id="CustomTypesClipboardOperations":::

## Enable BinaryFormatter support (not recommended)

> [!CAUTION]
> `BinaryFormatter` support is **not recommended**. Use it only as a temporary migration bridge for legacy applications that can't immediately migrate to the new type-safe APIs.

If you must continue using `BinaryFormatter` for clipboard operations in .NET 10, enable limited support through explicit configuration. This approach carries significant security risks and requires several steps.

For complete step-by-step instructions, see [Enable BinaryFormatter clipboard support (not recommended)](../advanced/how-to-enable-binaryformatter-clipboard-support.md). For general migration guidance, see the [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

### Security warnings and risks

`BinaryFormatter` is inherently insecure and deprecated for these reasons:

- **Arbitrary code execution vulnerabilities**: Attackers can execute malicious code during deserialization, exposing your application to remote attacks.
- **Denial of service attacks**: Malicious clipboard data can consume excessive memory or CPU resources, causing crashes or instability.
- **Information disclosure risks**: Attackers might extract sensitive data from memory.
- **No security boundaries**: The format is fundamentally unsafe, and configuration settings can't secure it.

Only enable this support as a temporary bridge while you update your application to use the new type-safe APIs.

For detailed security guidelines and configuration steps, see [Security warnings and risks](../advanced/how-to-enable-binaryformatter-clipboard-support.md#security-warnings-and-risks) in the how-to guide.

### Implement security-focused type resolvers

Even with `BinaryFormatter` enabled, you must implement type resolvers to restrict deserialization to explicitly approved types. Follow these guidelines:

- **Use explicit allow-lists.** Reject any type not explicitly approved.
- **Validate type names.** Ensure type names exactly match expected values.
- **Limit to essential types.** Include only types required for your clipboard functionality.
- **Throw exceptions for unknown types.** Clearly reject unauthorized types.
- **Review regularly.** Audit and update the allowed list as needed.

For complete implementation examples and code samples, see [Implement security-focused type resolvers](../advanced/how-to-enable-binaryformatter-clipboard-support.md#implement-security-focused-type-resolvers) in the how-to guide.

## Use AI to migrate clipboard code

Migrating clipboard operations from .NET 8 to .NET 10 involves systematic code changes across multiple files and classes. AI tools like GitHub Copilot can help accelerate your migration by identifying legacy patterns, suggesting modern replacements, and creating test scenarios. Instead of manually searching through your codebase and converting each clipboard operation individually, you can use AI to handle repetitive tasks while you focus on validating results and handling edge cases.

The following sections show specific prompt strategies for different aspects of clipboard migration, from finding problematic code patterns to creating robust JSON-serializable types and comprehensive test suites.

### Use AI to identify legacy clipboard patterns

Use Copilot to scan your codebase and locate clipboard operations that need migration. This helps you understand the scope of changes required before starting the actual migration work.

```copilot-prompt
Find all clipboard operations in my codebase that use GetData(), SetData() with custom objects, DataObject.GetData(), or IDataObject.GetData(). Show me the file paths and line numbers where these patterns occur.
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

### Use AI to convert GetData() to TryGetData\<T>()

Use Copilot to convert obsolete `GetData()` calls to the new type-safe `TryGetData<T>()` pattern. This conversion includes proper error handling and eliminates unsafe casting.

```copilot-prompt
Convert this GetData() clipboard code to use the new TryGetData<T>() method with proper error handling:

[paste your existing GetData() code here]

Make sure to eliminate casting and add appropriate error handling for when the data isn't available.
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

### Use AI to migrate SetData() to SetDataAsJson\<T>()

Use Copilot to convert custom object storage from the obsolete `SetData()` method to the new `SetDataAsJson<T>()` approach. This ensures your custom objects are properly serialized to the clipboard.

```copilot-prompt
Take this SetData() clipboard code that stores custom objects:

[paste your existing SetData() code here]

Convert it to use SetDataAsJson<T>() and make the custom types JSON-serializable. Add any necessary System.Text.Json attributes if the types have complex properties.
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

### Use AI to create JSON-serializable data models

Use Copilot to design custom types that work seamlessly with `SetDataAsJson<T>()` and `TryGetData<T>()`. This includes adding appropriate attributes for properties that need special handling.

```copilot-prompt
Create a JSON-serializable version of this class for clipboard operations:

[paste your existing class definition here]

Make it work with System.Text.Json, add JsonIgnore for sensitive properties, JsonInclude for private fields that should serialize, and JsonPropertyName for any properties that need different names in JSON.
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

### Use AI to generate type-safe wrapper methods

Use Copilot to create wrapper methods that encapsulate the new clipboard APIs and provide clean interfaces for your application's specific data types.

```copilot-prompt
Create a type-safe clipboard wrapper class that provides methods for storing and retrieving these custom types:

[list your custom types here]

Use SetDataAsJson<T>() and TryGetData<T>() internally, include proper error handling, and add methods like SavePersonToClipboard() and TryGetPersonFromClipboard().
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

### Use AI to create comprehensive tests

Use Copilot to generate test suites that verify your clipboard migration works correctly, including round-trip serialization tests and error handling scenarios.

```copilot-prompt
Generate comprehensive unit tests for this clipboard code:

[paste your migrated clipboard code here]

Include tests for successful round-trip serialization, handling of null values, error cases when data isn't available, and verification that the migrated code produces the same results as the original for valid scenarios.
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

### Use AI to validate migration results

Use Copilot to review your migrated code and identify potential issues or areas where the migration might not be complete.

```copilot-prompt
Review this migrated clipboard code for potential issues:

[paste your migrated code here]

Check for: missing error handling, types that might not serialize properly to JSON, performance concerns with large objects, security issues, and any remaining uses of obsolete methods.
```

[!INCLUDE [copilot-disclaimer](../../includes/copilot-disclaimer.md)]

## Related content

- [How to add data to the Clipboard](../advanced/how-to-add-data-to-the-clipboard.md)
- [How to retrieve data from the Clipboard](../advanced/how-to-retrieve-data-from-the-clipboard.md)
- [Drag-and-Drop Operations and Clipboard Support](../advanced/drag-and-drop-operations-and-clipboard-support.md)
- <xref:System.Windows.Forms.Clipboard.SetDataAsJson``1(System.String,``0)?displayProperty=fullName>
- <xref:System.Windows.Forms.Clipboard.TryGetData*?displayProperty=fullName>
