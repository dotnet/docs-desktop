---
title: "Windows Forms clipboard and DataObject changes in .NET 10"
description: "Learn about the major clipboard and drag-and-drop changes in .NET 10, including new type-safe APIs, JSON serialization, and migration from BinaryFormatter."
author: [your GitHub alias]
ms.author: [your Microsoft alias or a team alias]
ms.service: dotnet-desktop
ms.topic: concept-article
ms.date: 09/25/2025
ai-usage: ai-generated

#customer intent: As a Windows Forms developer, I want to understand the clipboard and DataObject changes in .NET 10 so that I can upgrade my applications and use the new type-safe APIs.

---

# Windows Forms clipboard and DataObject changes in .NET 10

This article explains how to upgrade Windows Forms clipboard and drag-and-drop operations to .NET 10's new type-safe APIs. You'll learn to use the new `TryGetData<T>()` and `SetDataAsJson<T>()` methods, understand which built-in types work without modification, and discover strategies for handling custom types and legacy data affected by `BinaryFormatter` removal.

`BinaryFormatter` was removed from the .NET runtime in .NET 9 due to security vulnerabilities, breaking existing clipboard and drag-and-drop operations with custom objects. .NET 10 introduces new APIs that use JSON serialization and provide type-safe methods to restore this functionality while maintaining security and improving error handling and cross-process compatibility.

## Prerequisites

To understand the context and implications of these changes:

- Familiarity with how `BinaryFormatter` was used in clipboard and drag-and-drop scenarios before .NET 9.
- Understanding of the security vulnerabilities that led to `BinaryFormatter` removal (see [BinaryFormatter security guide](/dotnet/standard/serialization/binaryformatter-security-guide)).
- Knowledge of `System.Text.Json` serialization patterns and limitations.

For background on the breaking changes, see [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

## Breaking changes from BinaryFormatter removal

<!-- 
EXPAND THIS OUTLINE: Transform these bullet points into comprehensive documentation that:
- Explains each breaking change with detailed context
- Provides before/after code examples showing what breaks
- Shows specific error messages or behaviors developers will encounter
- Includes guidance on identifying affected code in existing applications
- Links to migration strategies and solutions in later sections
- Uses clear, actionable language with second person voice
-->

- **Custom types no longer serialize automatically** - Objects that previously worked with `SetData()` now require explicit handling
- **`GetData()` behavior changes** - Legacy method may not retrieve data as expected
- **Legacy binary data handling** - Existing clipboard data may not be accessible without special handling
- **Common patterns that need updating**:
  - Direct `SetData()` calls with custom objects
  - `GetData()` retrieval without type checking
  - Cross-process data sharing with complex types

## New type-safe APIs

<!-- 
EXPAND THIS OUTLINE: Create comprehensive documentation for the new APIs that:
- Explains each API family with detailed method signatures and overloads
- Provides practical code examples for each method showing real-world usage
- Demonstrates the benefits of type safety and error handling
- Shows how these APIs replace legacy methods
- Includes both C# and VB.NET examples where appropriate
- Covers performance and security advantages
- Uses proper xref links to API documentation
-->

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

<!-- 
EXPAND THIS OUTLINE: Create detailed documentation that:
- Explains why these types work without BinaryFormatter (built-in NRBF serialization)
- Provides comprehensive examples of using each type category
- Shows practical scenarios where each type is useful
- Explains the limitations and considerations for each type
- Includes performance and compatibility notes
- Demonstrates array and collection usage patterns
- Covers null handling and edge cases
-->

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

<!-- 
EXPAND THIS OUTLINE: Provide comprehensive guidance that:
- Shows step-by-step examples of designing clipboard-friendly custom types
- Demonstrates SetDataAsJson<T> usage with real-world scenarios
- Covers System.Text.Json attributes and configuration options
- Explains serialization performance considerations and optimization
- Provides alternative approaches for complex scenarios (manual serialization)
- Shows cross-process compatibility testing strategies
- Includes troubleshooting common serialization issues
-->

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

<!-- 
EXPAND THIS OUTLINE: Create detailed documentation that:
- Explains the NrbfDecoder and SerializationRecord approach with code examples
- Shows how to safely extract data from legacy binary formats
- Provides patterns for handling mixed-version environments
- Demonstrates fallback strategies when legacy data can't be read
- Includes security considerations for processing legacy data
- Shows validation and error handling best practices
- Covers performance implications of legacy data processing
-->

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

<!-- 
EXPAND THIS OUTLINE: Provide actionable migration guidance that:
- Creates a step-by-step assessment checklist for existing applications
- Shows concrete before/after code examples for common migration patterns
- Provides a phased migration approach with clear priorities
- Demonstrates testing strategies for validating migrations
- Includes performance impact analysis and optimization tips
- Covers rollback strategies and risk mitigation
- Shows integration with existing development workflows
-->

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

<!-- 
EXPAND THIS OUTLINE: Create comprehensive documentation with strong security warnings that:
- Leads with prominent security warnings and explains the risks clearly
- Provides complete, step-by-step configuration instructions
- Shows detailed type resolver implementation examples with security focus
- Explains the temporary nature of this approach and migration timeline
- Demonstrates monitoring and logging for security auditing
- Includes troubleshooting for configuration issues
- Emphasizes this is only for legacy bridge scenarios
-->

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

<!-- 
EXPAND THIS SECTION: Create practical guidance for using AI assistance that:
- Shows how GitHub Copilot can help identify clipboard-related code patterns
- Demonstrates prompting strategies for converting legacy code to new APIs
- Provides examples of AI-assisted refactoring for SetData/GetData migrations
- Shows how to use Copilot for generating type-safe wrapper methods
- Includes tips for validating AI-generated migration code
- Covers using Copilot for creating JSON-serializable data models
- Demonstrates AI-assisted testing scenarios for clipboard functionality
-->

[Explain and give some example of using copilot to data objects.]

## Related content

- [How to: Add Data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)
