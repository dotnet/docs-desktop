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

To understand the context and implications of these changes you shuold understand the folowing:

- Familiarity with how `BinaryFormatter` was used in clipboard and drag-and-drop scenarios before .NET 9.
- The security vulnerabilities that led to `BinaryFormatter` removal.
- Knowledge of `System.Text.Json` serialization patterns and limitations.

For more information, see:

- [BinaryFormatter security guide](/dotnet/standard/serialization/binaryformatter-security-guide).
- [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

## Summary of the changes

<!-- Write a quick summary of the changes. Be conscise. Tell the reader that SetData on custom types no longer works, that GetData is obsolete, and that the TrySetData and TryGetData are the modern replacements that roundtrips custom objects to JSON. Then end with a paragraph about how the following sections describe all of this in more detail. -->

## Breaking changes from BinaryFormatter removal

The removal of `BinaryFormatter` from .NET 9 fundamentally changes how Windows Forms handles clipboard and drag-and-drop operations with custom types. These changes affect existing code patterns and require careful migration to maintain functionality.

### Custom types no longer serialize automatically

Previously, you could place any serializable custom object on the clipboard using `SetData()`, and `BinaryFormatter` would handle serialization automatically. This pattern no longer works stating with .NET 9, but importantly, it fails silently without throwing exceptions.

The following code doesn't work:

```csharp
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// This worked in .NET 8 and earlier but silently fails starting with .NET 9
Person person = new Person { Name = "John", Age = 30 };
Clipboard.SetData("MyApp.Person", person);  // No data is stored

// Later attempts to retrieve the data returns null
object data = Clipboard.GetData("MyApp.Person");
```

#### Behavior you encounter

- `SetData()` completes without throwing an exception but doesn't actually store the data.
- The clipboard operation appears to succeed from your application's perspective.
- Later attempts to retrieve the data with `GetData()` return `null`.

#### Migration strategy

Use the new `SetDataAsJson<T>()` method or serialize manually to `string` or `byte[]`. See [Working with custom types](#working-with-custom-types) section for detailed guidance.

### GetData() is obsolete - use TryGetData\<T>() instead

The legacy `GetData()` method is obsolete in .NET 10. Even for scenarios where it might still return data, migrate to the new type-safe `TryGetData<T>()` methods that provide better error handling and type safety.

**Obsolete code that should be avoided:**

```csharp
// DON'T USE - GetData() is obsolete in .NET 10
object data = Clipboard.GetData("MyApp.Person");  // Obsolete method

// Always returns null on a custom object type
if (data != null)
{
    Person person = (Person)data;  // Unsafe casting
    ProcessPerson(person);
}
```

**Modern approach using TryGetData\<T>():**

```csharp
// USE THIS - Type-safe approach with TryGetData<T>()
if (Clipboard.TryGetData("MyApp.Person", out Person person))
{
    ProcessPerson(person);  // person is guaranteed to be the correct type
}
else
{
    // Handle the case where data isn't available or is wrong type
    ShowError("Unable to retrieve person data from clipboard");
}
```

#### Benefits of TryGetData\<T>():

- **Type safety**: No need for casting - the method returns the exact type you request.
- **Clear error handling**: Returns boolean success indicator instead of null/exception patterns.
- **Future-proof**: Designed to work with new serialization methods and legacy data support.

#### How to identify affected code

Look for:

- Any `GetData()` calls - the entire method is obsolete regardless of data type.
- `DataObject.GetData()` and `IDataObject.GetData()` usage in drag-and-drop operations.

#### Migration strategy

Replace all `GetData()` usage with type-safe `TryGetData<T>()` methods. See [New type-safe APIs](#new-type-safe-apis) section for comprehensive examples of all overloads.

## New type-safe APIs

.NET 10 introduces three new API families that provide type safety, better error handling, and JSON serialization support for clipboard and drag-and-drop operations.

### TryGetData\<T>() methods

The `TryGetData<T>()` family replaces the obsolete `GetData()` method with type-safe retrieval and clear success/failure indication.

#### Basic type-safe retrieval

```csharp
// Simple retrieval with standard formats
if (Clipboard.TryGetData(DataFormats.Text, out string textData))
{
    ProcessTextData(textData);
}

// Works with any supported type using custom formats
if (Clipboard.TryGetData("NumberData", out int numberData))
{
    ProcessNumber(numberData);
}

// Using standard formats for common data types
if (Clipboard.TryGetData(DataFormats.UnicodeText, out string unicodeText))
{
    ProcessUnicodeText(unicodeText);
}

// Control OLE data conversion
if (Clipboard.TryGetData(DataFormats.Text, autoConvert: false, out string rawText))
{
    ProcessRawText(rawText);
}

// Working with file drops using standard format
if (Clipboard.TryGetData(DataFormats.FileDrop, out string[] files))
{
    ProcessFiles(files);
}
```

#### Custom JSON types

```csharp
// Retrieve custom types stored with SetDataAsJson<T>()
if (Clipboard.TryGetData("Person", out Person person))
{
    ProcessPerson(person);
}

// Handle application-specific data formats
if (Clipboard.TryGetData("MyApp.Settings", out AppSettings settings))
{
    ApplySettings(settings);
}

// Work with complex custom objects
if (Clipboard.TryGetData("DocumentData", out DocumentInfo doc))
{
    LoadDocument(doc);
}
```

#### Type resolver for legacy binary data (requires BinaryFormatter - not recommended)

> [!WARNING]
> Type resolvers only work when BinaryFormatter support is enabled, which is **not recommended** due to security risks. See [Enabling BinaryFormatter support](#enabling-binaryformatter-support-not-recommended) for more information.

Type resolvers allow you to handle legacy binary data by mapping type names to actual types during deserialization:

```csharp
// Create a type resolver that maps old type names to current types
Func<TypeName, Type> resolver = typeName =>
{
    // Only allow specific known safe types
    return typeName.FullName switch
    {
        "MyApp.Person" => typeof(Person),
        "MyApp.Settings" => typeof(AppSettings),
        "System.String" => typeof(string),
        "System.Int32" => typeof(int),
        _ => throw new InvalidOperationException($"Type not allowed: {typeName.FullName}")
    };
};

// Use resolver with legacy binary data
if (Clipboard.TryGetData("LegacyFormat", resolver, out Person person))
{
    ProcessPerson(person);
}

// Combined resolver with conversion control
if (Clipboard.TryGetData("OldCustomData", resolver, autoConvert: true, out MyType data))
{
    ProcessCustomData(data);
}
```

**Important security considerations for type resolvers:**

- Always use an explicit allow-list of permitted types
- Never allow dynamic type loading or assembly resolution
- Validate type names before mapping to actual types
- Throw exceptions for any unauthorized or unknown types
- Consider this a temporary bridge during migration only

### SetDataAsJson\<T>() methods

These methods provide automatic JSON serialization using `System.Text.Json` with type-safe storage.

#### Automatic format inference

```csharp
var person = new Person { Name = "Alice", Age = 25 };

// Format automatically inferred from type name
Clipboard.SetDataAsJson(person);  // Uses "Person" as format

// Later retrieval
if (Clipboard.TryGetData("Person", out Person retrievedPerson))
{
    Console.WriteLine($"Retrieved: {retrievedPerson.Name}");
}
```

#### Custom format specification

```csharp
var settings = new AppSettings { Theme = "Dark", AutoSave = true };

// Custom format for better organization
Clipboard.SetDataAsJson("MyApp.Settings", settings);

// Multiple formats for the same data
Clipboard.SetDataAsJson("Config.V1", settings);
Clipboard.SetDataAsJson("AppConfig", settings);
```

### ITypedDataObject interface

This interface enables type-safe drag-and-drop operations by extending `IDataObject` with typed methods.

#### Implementation in custom DataObject

```csharp
public class TypedDataObject : DataObject, ITypedDataObject
{
    public bool TryGetData<T>(string format, out T data)
    {
        // Implementation uses new type-safe logic
        return base.TryGetData(format, out data);
    }

    // This overload requires BinaryFormatter support (not recommended)
    public bool TryGetData<T>(string format, Func<TypeName, Type> resolver, out T data)
    {
        return base.TryGetData(format, resolver, out data);
    }
}

#### Usage in drag-and-drop scenarios

```csharp
private void OnDragDrop(object sender, DragEventArgs e)
{
    if (e.Data is ITypedDataObject typedData)
    {
        // Type-safe retrieval from drag data using standard formats
        if (typedData.TryGetData(DataFormats.FileDrop, out string[] files))
        {
            ProcessDroppedFiles(files);
        }
        
        // Using standard text formats
        if (typedData.TryGetData(DataFormats.Text, out string text))
        {
            ProcessDroppedText(text);
        }
        
        // Custom formats for application-specific data
        if (typedData.TryGetData("CustomItem", out MyItem item))
        {
            ProcessCustomItem(item);
        }
    }
}
```

## Types that don't require JSON serialization

Many built-in .NET types continue to work with clipboard operations without requiring JSON serialization or `BinaryFormatter` support. These types are automatically serialized into the .NET Remoting Binary Format (NRBF), which provides efficient storage while maintaining type safety.

These types use the .NET Remoting Binary Format (NRBF) for serialization, the same efficient binary format used by the legacy `BinaryFormatter`. Key characteristics of NRBF serialization:

- **Compact binary representation** for efficient storage and transfer.
- **Built-in type information** preserves exact .NET types during round-trip operations.
- **Cross-process compatibility** works between different .NET applications.
- **No custom serialization required** - types serialize automatically.

For detailed technical information about NRBF, see the [.NET Remoting Binary Format specification](https://learn.microsoft.com/openspecs/windows_protocols/ms-nrbf/75b9fe09-be15-475f-85b8-ae7b7558cfe5).

Classes that support working with NRBF-encoded data are implemented in the <xref:System.Formats.Nrbf?displayProperty=fullName> namespace.

### Type safety guarantees

Windows Forms provides several safety mechanisms for these built-in types:

- **Exact type matching**: `TryGetData<T>()` ensures only the requested type is returned.
- **Automatic validation**: WinForms validates type compatibility during deserialization.
- **No arbitrary code execution**: Unlike custom types with BinaryFormatter, these types can't execute malicious code.
- **Content validation required**: Developers must still validate data content and ranges for their application logic.
- **No size constraints**: Large arrays or bitmaps are not automatically limited (monitor memory usage).

### Supported primitive types

The following primitive types work seamlessly with clipboard and `DataObject` operations without requiring any custom serialization or configuration. These built-in .NET types are automatically handled by the clipboard system:

- `bool`, `byte`, `char`, `decimal`, `double`, `short`, `int`, `long`
- `sbyte`, `ushort`, `uint`, `ulong`, `float`, `string`
- `TimeSpan` and `DateTime`

The following examples show how these primitive types work directly with `SetData()` and `TryGetData<T>()` methods:

```csharp
// Numeric types
Clipboard.SetData("MyInt", 42);
Clipboard.SetData("MyDouble", 3.14159);
Clipboard.SetData("MyDecimal", 123.45m);

// Text and character types
Clipboard.SetData("MyString", "Hello World");
Clipboard.SetData("MyChar", 'A');

// Boolean and date/time types
Clipboard.SetData("MyBool", true);
Clipboard.SetData("MyDateTime", DateTime.Now);
Clipboard.SetData("MyTimeSpan", TimeSpan.FromMinutes(30));

// Later retrieval with type safety
if (Clipboard.TryGetData("MyInt", out int value))
{
    ProcessInteger(value);
}
```

### Collections of primitive types

Arrays and generic lists of supported primitive types work without additional configuration, but there are some important limitations to be aware of:

- All array and list elements must be of supported primitive types.
- Avoid `string[]` and `List<string>` due to null value handling complexity in NRBF format.
- Use individual string storage or JSON serialization for string collections instead.

The following exmaples show how arrays and lists can be set on the clipboard:

```csharp
// Arrays of primitive types
int[] numbers = { 1, 2, 3, 4, 5 };
Clipboard.SetData("NumberArray", numbers);

double[] coordinates = { 1.0, 2.5, 3.7 };
Clipboard.SetData("Coordinates", coordinates);

// Generic lists
List<int> intList = new List<int> { 10, 20, 30 };
Clipboard.SetData("IntList", intList);

// Retrieval maintains type safety
if (Clipboard.TryGetData("NumberArray", out int[] retrievedNumbers))
{
    ProcessNumbers(retrievedNumbers);
}
```

### System.Drawing types

Common graphics types from the `System.Drawing` namespace work seamlessly with clipboard and `DataObject` operations. These types are particularly useful for applications that work with visual elements and need to transfer drawing-related data between components or applications. However, when using `Bitmap` objects, be mindful of memory usage for large images. The following types are supported:

- `Point`, `PointF`, `Rectangle`, `RectangleF`
- `Size`, `SizeF`, `Color`
- `Bitmap` (consider memory usage for large images)

The following examples show how these graphics types can be used with clipboard operations:

```csharp
// Geometric types
Point location = new Point(100, 200);
Rectangle bounds = new Rectangle(0, 0, 500, 300);
Size dimensions = new Size(800, 600);

Clipboard.SetData("Location", location);
Clipboard.SetData("Bounds", bounds);
Clipboard.SetData("Size", dimensions);

// Color information
Color backgroundColor = Color.FromArgb(255, 128, 64, 192);
Clipboard.SetData("BackColor", backgroundColor);

// Bitmap data (use with caution for large images)
Bitmap smallIcon = new Bitmap(16, 16);
Clipboard.SetData("Icon", smallIcon);
```

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
