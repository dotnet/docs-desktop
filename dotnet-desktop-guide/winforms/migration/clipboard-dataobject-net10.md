---
title: "Windows Forms clipboard and DataObject changes in .NET 10"
description: "Learn about the major clipboard and drag-and-drop changes in .NET 10, including new type-safe APIs, JSON serialization, and migration from BinaryFormatter."
author: [your GitHub alias]
ms.author: [your Microsoft alias or a team alias]
ms.service: dotnet-desktop
ms.topic: concept-article
ms.date: 09/25/2025
ms.custom:
- copilot-scenario-highlight
ai-usage: ai-assisted

#customer intent: As a Windows Forms developer, I want to understand the clipboard and DataObject changes in .NET 10 so that I can upgrade my applications and use the new type-safe APIs.

---

# Windows Forms clipboard and DataObject changes in .NET 10

This article explains how to upgrade Windows Forms clipboard and drag-and-drop operations to .NET 10's new type-safe APIs. You'll learn to use the new `TryGetData<T>()` and `SetDataAsJson<T>()` methods, understand which built-in types work without modification, and discover strategies for handling custom types and legacy data affected by `BinaryFormatter` removal.

`BinaryFormatter` was removed from the .NET runtime in .NET 9 due to security vulnerabilities, breaking existing clipboard and drag-and-drop operations with custom objects. .NET 10 introduces new APIs that use JSON serialization and provide type-safe methods to restore this functionality while maintaining security and improving error handling and cross-process compatibility.

One signifigant change is that `SetData()` no longer works with custom types, and it silently fails without storing data on the clipboard. `GetData()` is obsolete in .NET 10 and should no longer be used, even for built-in types. The modern replacements are `TryGetData<T>()` and `SetDataAsJson<T>()`, which provide type-safe operations and use JSON serialization to round-trip custom objects.

The following sections provide detailed migration guidance, explain which types work without modification, and show how to handle both new development and legacy data scenarios.

## Prerequisites

To understand the context and implications of these changes you should understand the following:

- Familiarity with how `BinaryFormatter` was used in clipboard and drag-and-drop scenarios before .NET 9.
- The security vulnerabilities that led to `BinaryFormatter` removal.
- Knowledge of `System.Text.Json` serialization patterns and limitations.

For more information, see:

- [BinaryFormatter security guide](/dotnet/standard/serialization/binaryformatter-security-guide).
- [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

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

When using `SetDataAsJson<T>()` and `TryGetData<T>()` with custom types, `System.Text.Json` handles serialization automatically. Many types work perfectly without any special configuration - records, simple classes, and structs with public properties serialize seamlessly.

### Simple types that work without attributes

Most straightforward custom types require no special configuration:

```csharp
// Records work perfectly without any attributes
public record PersonInfo(string Name, int Age, string Email);

// Simple classes serialize all public properties automatically
public class DocumentMetadata
{
    public string Title { get; set; }
    public DateTime Created { get; set; }
    public string Author { get; set; }
}

// Structs with public properties work seamlessly
public struct Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
```

### JSON attributes for advanced control

Use `System.Text.Json` attributes only when you need to customize serialization behavior. For comprehensive guidance on `System.Text.Json` serialization, attributes, and advanced configuration options, see [JSON serialization and deserialization in .NET](/dotnet/standard/serialization/system-text-json/).

The following snippet demonstrates using JSON attributes to control serialization:

```csharp
public class ClipboardFriendlyType
{
    // Include a field that normally isn't serialized
    [JsonInclude]
    private int _privateData;

    // Public properties are always serialized
    public string Name { get; set; }
    
    // Exclude sensitive or non-essential data
    [JsonIgnore]
    public string InternalId { get; set; }
    
    // Handle property name differences for compatibility
    [JsonPropertyName("display_text")]
    public string DisplayText { get; set; }
    
    // Control null value handling
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string OptionalField { get; set; }
}
```

### Usage with clipboard operations

```csharp
var data = new ClipboardFriendlyType 
{ 
    Name = "Sample", 
    DisplayText = "Sample Display Text",
    InternalId = "internal-123" // This won't be serialized due to [JsonIgnore]
};

Clipboard.SetDataAsJson("MyAppData", data);

if (Clipboard.TryGetData("MyAppData", out ClipboardFriendlyType retrieved))
{
    Console.WriteLine($"Retrieved: {retrieved.Name}");
    // retrieved.InternalId will be null due to [JsonIgnore]
}
```

## Enable BinaryFormatter support (not recommended)

> [!CAUTION]
> `BinaryFormatter` support is **not recommended** and should only be used as a temporary migration bridge. This section is provided for legacy applications that cannot immediately migrate to the new type-safe APIs.

If your application absolutely must continue using `BinaryFormatter` for clipboard operations during migration to .NET 10, you can enable limited support through explicit configuration. However, this approach carries significant security risks and requires multiple configuration steps.

For comprehensive guidance on migrating _away_ from `BinaryFormatter`, see the [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

### Security warnings and risks

`BinaryFormatter` is inherently insecure and has been deprecated across the entire .NET ecosystem for the following critical security reasons:

**Arbitrary code execution vulnerabilities**: `BinaryFormatter` can execute arbitrary code during deserialization, making applications vulnerable to remote code execution attacks when processing untrusted data from the clipboard.

**Denial of service attacks**: Malicious clipboard data can cause applications to consume excessive memory or CPU resources, leading to application crashes or system instability.

**Information disclosure risks**: Attackers can potentially extract sensitive information from application memory through carefully crafted serialized payloads.

**No security boundaries**: `BinaryFormatter` cannot be made secure through configuration alone - the format itself is fundamentally unsafe for untrusted data.

`BinaryFormatter` support should only be enabled as a temporary migration bridge while you update your application to use the new type-safe APIs. Plan to remove this dependency as quickly as possible.

### Complete configuration requirements

Enabling `BinaryFormatter` support for clipboard operations requires multiple configuration steps. All steps must be completed for the functionality to work. Follow these instructions in order:

1. Install the compatibility package.

   Add the unsupported `BinaryFormatter` compatibility package to your project:

   ```xml
   <ItemGroup>
     <PackageReference Include="System.Runtime.Serialization.Formatters" Version="9.0.0" />
   </ItemGroup>
   ```

1. Enable unsafe serialization in the project.

   Set the `EnableUnsafeBinaryFormatterSerialization` property to `true` in your project file:

   ```xml
   <PropertyGroup>
     <TargetFramework>net10.0</TargetFramework>
     <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
   </PropertyGroup>
   ```

1. Configure the Windows Forms runtime switch.

   Create or update your application's `runtimeconfig.json` file to enable the Windows Forms-specific clipboard switch:

   ```json
   {
     "runtimeOptions": {
       "configProperties": {
         "Windows.ClipboardDragDrop.EnableUnsafeBinaryFormatterSerialization": true
       }
     }
   }
   ```

   Without this Windows Forms-specific switch, clipboard operations will not fall back to `BinaryFormatter` even if the general serialization support is enabled.

### Implement security-focused type resolvers

Even with `BinaryFormatter` enabled, you must implement type resolvers to control which types can be deserialized. This provides a crucial security boundary by allowing only explicitly permitted types.

When implementing type resolvers, follow these critical security guidelines to protect your application from malicious clipboard data:

- **Use explicit allow-lists**: Never allow dynamic type resolution or accept any type not explicitly approved.
- **Validate type names**: Ensure type names exactly match expected values without wildcards or partial matches.
- **Limit to essential types**: Only include types that are absolutely necessary for your application's clipboard functionality.
- **Throw exceptions for unknown types**: Always reject unauthorized types with clear error messages.
- **Review regularly**: Audit and update the allowed types list as part of your security review process.

The following example demonstrates a secure type resolver implementation that follows all these guidelines. Notice how it uses an explicit dictionary of allowed types, validates exact matches, and throws exceptions for any unauthorized types:

```csharp
// Create a security-focused type resolver
private static Type SecureTypeResolver(TypeName typeName)
{
    // Explicit allow-list of permitted types - only add types you specifically need
    var allowedTypes = new Dictionary<string, Type>
    {
        ["MyApp.Person"] = typeof(Person),
        ["MyApp.Settings"] = typeof(AppSettings),
        ["System.String"] = typeof(string),
        ["System.Int32"] = typeof(int),
        // Add only the specific types your application requires
    };

    // Only allow explicitly listed types - exact string match required
    if (allowedTypes.TryGetValue(typeName.FullName, out Type allowedType))
    {
        return allowedType;
    }

    // Reject any type not in the allow-list with clear error message
    throw new InvalidOperationException(
        $"Type '{typeName.FullName}' is not permitted for clipboard deserialization");
}

// Use the resolver with clipboard operations
if (Clipboard.TryGetData("LegacyData", SecureTypeResolver, out MyCustomType data))
{
    ProcessLegacyData(data);
}
```

## Use AI to migrate clipboard code

Migrating clipboard operations from .NET 8 to .NET 10 involves systematic code changes across multiple files and classes. AI tools like Copilot can significantly accelerate this migration process by identifying legacy patterns, generating modern replacements, and creating comprehensive test scenarios. Rather than manually searching through your codebase and converting each clipboard operation individually, you can leverage Copilot to handle the repetitive aspects while you focus on validating the results and handling edge cases.

The following sections demonstrate specific prompt strategies for different aspects of clipboard migration, from identifying problematic code patterns to creating robust JSON-serializable types and comprehensive test suites.

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

- [How to: Add Data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)
