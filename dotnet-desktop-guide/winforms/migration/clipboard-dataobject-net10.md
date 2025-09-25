---
title: "Windows Forms clipboard and DataObject changes in .NET 10"
description: "Learn about the major clipboard and drag-and-drop changes in .NET 10, including new type-safe APIs, JSON serialization, and migration from BinaryFormatter."
author: [your GitHub alias]
ms.author: [your Microsoft alias or a team alias]
ms.service: dotnet-desktop
ms.topic: concept-article
ms.date: 09/25/2025
ai-usage: ai-generated

#customer intent: As a Windows Forms developer, I want to understand the clipboard and DataObject changes in .NET 10 so that I can migrate my applications and use the new type-safe APIs.

---

# Windows Forms clipboard and DataObject changes in .NET 10

[Introduce and explain the purpose of the article - overview of .NET 10 clipboard changes and why they matter to developers.]

## Prerequisites

[Prerequisites for understanding and applying these changes - .NET knowledge, Windows Forms experience, etc.]

## Breaking changes from BinaryFormatter removal

- **Custom types no longer serialize automatically** - Objects that previously worked with `SetData()` now require explicit handling
- **`GetData()` behavior changes** - Legacy method may not retrieve data as expected
- **Legacy binary data handling** - Existing clipboard data may not be accessible without special handling
- **Common patterns that need updating**:
  - Direct `SetData()` calls with custom objects
  - `GetData()` retrieval without type checking
  - Cross-process data sharing with complex types

## New type-safe APIs

- **`TryGetData<T>()` family of methods**:
  - Multiple overloads for different scenarios
  - Returns boolean success indicator instead of throwing exceptions
  - Type-safe retrieval with explicit type specification
  - Optional resolver parameter for legacy data handling
  - `autoConvert` parameter for OLE data conversion control

- **`SetDataAsJson<T>()` methods**:
  - JSON serialization using System.Text.Json
  - Automatic format inference from type name
  - Custom format specification support
  - Cross-process and cross-framework compatibility

- **`ITypedDataObject` interface**:
  - Enables typed data retrieval for drag-and-drop scenarios
  - Must be implemented by custom data objects
  - Provides compile-time type safety guarantees

## Recommended built-in types

- **Primitive types** that work without BinaryFormatter:
  - `bool`, `byte`, `char`, `decimal`, `double`, `short`, `int`, `long`
  - `sbyte`, `ushort`, `uint`, `ulong`, `float`, `string`
  - `TimeSpan` and `DateTime`

- **Collections** of primitive types:
  - Arrays of any supported primitive type
  - `List<T>` where T is a supported primitive type
  - Avoid `string[]` and `List<string>` due to null handling complexity

- **System.Drawing types**:
  - `Bitmap`, `Point`, `PointF`, `Rectangle`, `RectangleF`
  - `Size`, `SizeF`, `Color`

- **Type safety guarantees**:
  - WinForms ensures only requested types are created
  - Data content validation remains developer responsibility
  - No size constraints on deserialized data

## Working with custom types

- **JSON serialization best practices**:
  - Design simple, serializable types for clipboard use
  - Use System.Text.Json compatible attributes
  - Avoid complex object hierarchies and circular references
  - Consider serialization size and performance impact

- **Alternative serialization strategies**:
  - Manual string serialization for simple data
  - Custom byte array handling for binary data
  - Format-specific serialization (XML, custom protocols)
  - Direct conversion to supported built-in types when possible

- **Cross-process compatibility considerations**:
  - JSON provides better cross-framework compatibility
  - Consider version compatibility when designing types
  - Test data exchange between different application versions

## Legacy data support

- **Reading legacy NRBF data** without BinaryFormatter:
  - Use `NrbfDecoder` for safe binary data access
  - Work with `SerializationRecord` objects instead of direct deserialization
  - Extract data manually without automatic type creation

- **Cross-version data exchange strategies**:
  - Design fallback mechanisms for mixed .NET environments
  - Implement version detection and compatibility layers
  - Consider maintaining dual serialization approaches during migration

- **Safe legacy data handling**:
  - Always validate data structure before processing
  - Implement type checking and bounds verification
  - Use allow-lists for acceptable data types and values

## Migration strategies

- **Assessment and planning**:
  - Inventory existing clipboard and drag-drop functionality
  - Identify custom types used in data transfer operations
  - Prioritize migration based on security and functionality impact

- **Common migration patterns**:
  - Replace `GetData()` calls with `TryGetData<T>()`
  - Convert custom types to use `SetDataAsJson<T>()`
  - Update drag-drop implementations to use `ITypedDataObject`

- **Phased migration approach**:
  - Start with new development using type-safe APIs
  - Update critical security-sensitive operations first
  - Gradually migrate legacy functionality
  - Maintain compatibility layers during transition

- **Testing and validation strategies**:
  - Test cross-process data exchange scenarios
  - Validate data integrity after serialization changes
  - Performance test with realistic data sizes

## Enabling BinaryFormatter support (not recommended)

- **Security warnings and risks**:
  - BinaryFormatter is inherently insecure and deprecated
  - Enables arbitrary code execution through deserialization attacks
  - Should only be used as temporary migration bridge
  - Requires explicit opt-in through multiple configuration steps

- **Complete configuration requirements**:
  - Reference `System.Runtime.Serialization.Formatters` package
  - Set `EnableUnsafeBinaryFormatterSerialization` project property to `true`
  - Configure `Windows.ClipboardDragDrop.EnableUnsafeBinaryFormatterSerialization` runtime switch
  - Implement security-focused type resolvers for safe operation

- **Type resolver implementation patterns**:
  - Use explicit allow-lists of permitted types
  - Verify assembly names and versions
  - Throw exceptions for any unauthorized types
  - Never allow implicit type loading or resolution

- **Gradual migration approach**:
  - Enable BinaryFormatter support only during transition period
  - Migrate high-risk operations to new APIs first
  - Plan complete removal of BinaryFormatter dependency
  - Monitor and log all binary deserialization operations

## Use Copilot to update types

[Explain and give some example of using copilot to data objects.]

## Related content

- [How to: Add Data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)
