---
title: "Windows Forms clipboard and DataObject changes in .NET 10"
description: "Learn about the major clipboard and drag-and-drop changes in .NET 10, including new type-safe APIs, JSON serialization, and migration from BinaryFormatter."
author: adegeo
ms.author: adegeo
ms.service: dotnet-desktop
ms.topic: concept-article
ms.date: 09/26/2025
ms.custom:
  - copilot-scenario-highlight
ai-usage: ai-assisted

#customer intent: As a Windows Forms developer, I want to understand the clipboard and DataObject changes in .NET 10 so that I can upgrade my applications and use the new type-safe APIs.

---

# Windows Forms clipboard and DataObject changes in .NET 10

This article shows you how to upgrade your Windows Forms clipboard and drag-and-drop operations to the new type-safe APIs in .NET 10. You'll learn how to use the new `TryGetData<T>()` and `SetDataAsJson<T>()` methods, understand which built-in types work without changes, and discover strategies for handling custom types and legacy data after the removal of `BinaryFormatter`.

`BinaryFormatter` was removed from the runtime in .NET 9 because of security vulnerabilities. This change broke clipboard and drag-and-drop operations with custom objects. .NET 10 introduces new APIs that use JSON serialization and type-safe methods to restore this functionality, improve security, and provide better error handling and cross-process compatibility.

One significant change is that `SetData()` no longer works with custom types. It silently fails without storing data on the clipboard. `GetData()` is obsolete in .NET 10 and shouldn't be used, even for built-in types. Use the new `TryGetData<T>()` and `SetDataAsJson<T>()` methods for type-safe operations and JSON serialization of custom objects.

The following sections provide detailed migration guidance, explain which types work without changes, and show how to handle both new development and legacy data scenarios.

## Prerequisites

Before you continue, review these concepts:

- How applications used `BinaryFormatter` in clipboard and drag-and-drop scenarios before .NET 9.
- The security vulnerabilities that led to the removal of `BinaryFormatter`.
- How to work with `System.Text.Json` serialization patterns and their limitations.

For more information, see these articles:

- [BinaryFormatter security guide](/dotnet/standard/serialization/binaryformatter-security-guide).
- [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

## Breaking changes from BinaryFormatter removal

Removing `BinaryFormatter` in .NET 9 fundamentally changes how Windows Forms handles clipboard and drag-and-drop operations with custom types. These changes affect existing code patterns and require careful migration to maintain functionality.

### Custom types no longer serialize automatically

In .NET 8 and earlier, you could place any serializable custom object on the clipboard by calling `SetData()`. The `BinaryFormatter` handled serialization automatically. Starting with .NET 9, this pattern no longer works. The `SetData()` method silently fails for custom types and doesn't store data on the clipboard.

The following code no longer works:

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

// Later attempts to retrieve the data return null
object data = Clipboard.GetData("MyApp.Person");
```

#### What you might see

- The `SetData()` method completes without throwing an exception but doesn't store the data.
- The clipboard operation appears to succeed from your application's perspective.
- Later attempts to retrieve the data with `GetData()` return `null`.

#### Migration guidance

Use the new `SetDataAsJson<T>()` method or manually serialize to a `string` or `byte[]`. For details, see the [Working with custom types](#working-with-custom-types) section.

### GetData() is obsolete - use TryGetData\<T>() instead

The legacy `GetData()` method is obsolete in .NET 10. Even if it sometimes returns data, you should migrate to the new type-safe `TryGetData<T>()` methods for better error handling and type safety.

**Obsolete code to avoid:**

```csharp
// Don't use - GetData() is obsolete in .NET 10
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
// Use this - type-safe approach with TryGetData<T>()
if (Clipboard.TryGetData("MyApp.Person", out Person person))
{
    ProcessPerson(person);  // person is guaranteed to be the correct type
}
else
{
    // Handle the case where data isn't available or is the wrong type
    ShowError("Unable to retrieve person data from clipboard");
}
```

#### Benefits of TryGetData\<T>()

- Type safety: No need for casting—the method returns the exact type you request.
- Clear error handling: Returns a Boolean success indicator instead of using null or exception patterns.
- Future-proof: Designed to work with new serialization methods and legacy data support.

#### How to identify affected code

Look for:

- Any `GetData()` calls, as the entire method is obsolete regardless of data type.
- `DataObject.GetData()` and `IDataObject.GetData()` usage in drag-and-drop operations.

#### Migration guidance

Replace all `GetData()` usage with type-safe `TryGetData<T>()` methods. For comprehensive examples of all overloads, see the [New type-safe APIs](#new-type-safe-apis) section.

## New type-safe APIs

.NET 10 introduces three new API families that provide type safety, better error handling, and JSON serialization support for clipboard and drag-and-drop operations:

- `TryGetData<T>()` methods for retrieving data
- `SetDataAsJson<T>()` methods for storing data
- `ITypedDataObject` interface for drag-and-drop operations

### TryGetData\<T>() methods

The `TryGetData<T>()` family replaces the obsolete `GetData()` method. It provides type-safe retrieval and clear success or failure indication for your clipboard operations.

#### Basic type-safe retrieval

```csharp
// Retrieve text data using a standard format
if (Clipboard.TryGetData(DataFormats.Text, out string textData))
{
    ProcessTextData(textData);
}

// Retrieve an integer using a custom format
if (Clipboard.TryGetData("NumberData", out int numberData))
{
    ProcessNumber(numberData);
}

// Retrieve Unicode text using a standard format
if (Clipboard.TryGetData(DataFormats.UnicodeText, out string unicodeText))
{
    ProcessUnicodeText(unicodeText);
}

// Retrieve raw text data with OLE conversion control
if (Clipboard.TryGetData(DataFormats.Text, autoConvert: false, out string rawText))
{
    ProcessRawText(rawText);
}

// Retrieve file drops using a standard format
if (Clipboard.TryGetData(DataFormats.FileDrop, out string[] files))
{
    ProcessFiles(files);
}
```

#### Custom JSON types

```csharp
// Retrieve a custom type stored with SetDataAsJson<T>()
if (Clipboard.TryGetData("Person", out Person person))
{
    ProcessPerson(person);
}

// Retrieve application-specific data formats
if (Clipboard.TryGetData("MyApp.Settings", out AppSettings settings))
{
    ApplySettings(settings);
}

// Retrieve complex custom objects
if (Clipboard.TryGetData("DocumentData", out DocumentInfo doc))
{
    LoadDocument(doc);
}
```

#### Use a type resolver for legacy binary data (requires BinaryFormatter; not recommended)

> [!WARNING]
> Type resolvers only work when BinaryFormatter support is enabled, which isn't recommended due to security risks. For more information, see [Enable BinaryFormatter support (not recommended)](#enable-binaryformatter-support-not-recommended).

Type resolvers let you handle legacy binary data by mapping type names to actual types during deserialization.

```csharp
// Create a type resolver that maps old type names to current types
Func<TypeName, Type> resolver = typeName =>
{
    // Only allow specific, known, safe types
    return typeName.FullName switch
    {
        "MyApp.Person" => typeof(Person),
        "MyApp.Settings" => typeof(AppSettings),
        "System.String" => typeof(string),
        "System.Int32" => typeof(int),
        _ => throw new InvalidOperationException($"Type not allowed: {typeName.FullName}")
    };
};

// Use the resolver with legacy binary data
if (Clipboard.TryGetData("LegacyFormat", resolver, out Person person))
{
    ProcessPerson(person);
}

// Use a resolver with conversion control
if (Clipboard.TryGetData("OldCustomData", resolver, autoConvert: true, out MyType data))
{
    ProcessCustomData(data);
}
```

**Important security considerations for type resolvers:**

- Always use an explicit allowlist of permitted types.
- Never allow dynamic type loading or assembly resolution.
- Validate type names before mapping to actual types.
- Throw exceptions for any unauthorized or unknown types.
- Use this approach only as a temporary bridge during migration.

### SetDataAsJson\<T>() methods

These methods provide automatic JSON serialization using `System.Text.Json` with type-safe storage.

#### Automatic format inference

```csharp
var person = new Person { Name = "Alice", Age = 25 };

// The format is automatically inferred from the type name
Clipboard.SetDataAsJson(person)  // Uses "Person" as the format

// Retrieve the data later
if (Clipboard.TryGetData("Person", out Person retrievedPerson))
{
    Console.WriteLine($"Retrieved: {retrievedPerson.Name}");
}
```

#### Specify a custom format

```csharp
var settings = new AppSettings { Theme = "Dark", AutoSave = true };

// Use a custom format for better organization
Clipboard.SetDataAsJson("MyApp.Settings", settings)

// Store the same data in multiple formats
Clipboard.SetDataAsJson("Config.V1", settings)
Clipboard.SetDataAsJson("AppConfig", settings)
```

### ITypedDataObject interface

The `ITypedDataObject` interface enables type-safe drag-and-drop operations by extending `IDataObject` with typed methods.

#### Implement ITypedDataObject in a custom DataObject

```csharp
public class TypedDataObject : DataObject, ITypedDataObject
{
    public bool TryGetData<T>(string format, out T data)
    {
        // Use new type-safe logic
        return base.TryGetData(format, out data);
    }

    // This overload requires BinaryFormatter support (not recommended)
    public bool TryGetData<T>(string format, Func<TypeName, Type> resolver, out T data)
    {
        return base.TryGetData(format, resolver, out data);
    }
}
```

#### Use ITypedDataObject in drag-and-drop scenarios

```csharp
private void OnDragDrop(object sender, DragEventArgs e)
{
    if (e.Data is ITypedDataObject typedData)
    {
        // Retrieve files from drag data using a standard format
        if (typedData.TryGetData(DataFormats.FileDrop, out string[] files))
        {
            ProcessDroppedFiles(files);
        }

        // Retrieve text using a standard format
        if (typedData.TryGetData(DataFormats.Text, out string text))
        {
            ProcessDroppedText(text);
        }

        // Retrieve custom items using an application-specific format
        if (typedData.TryGetData("CustomItem", out MyItem item))
        {
            ProcessCustomItem(item);
        }
    }
}
```

## Types that don't require JSON serialization

Many built-in .NET types work with clipboard operations without requiring JSON serialization or `BinaryFormatter` support. These types automatically serialize into the .NET Remoting Binary Format (NRBF), which provides efficient storage and maintains type safety.

These types use NRBF, the same efficient binary format used by the legacy `BinaryFormatter`. NRBF serialization provides these key benefits:

- **Compact binary representation**: Enables efficient storage and transfer.
- **Built-in type information**: Preserves exact .NET types during round-trip operations.
- **Cross-process compatibility**: Works between different .NET applications.
- **Automatic serialization**: Types serialize without custom code.

For technical details, see the [.NET Remoting Binary Format specification](https://learn.microsoft.com/openspecs/windows_protocols/ms-nrbf/75b9fe09-be15-475f-85b8-ae7b7558cfe5).

Classes that support NRBF-encoded data are implemented in the <xref:System.Formats.Nrbf?displayProperty=fullName> namespace.

### Type safety guarantees

Windows Forms provides several safety mechanisms for these built-in types:

- **Exact type matching**. `TryGetData<T>()` returns only the requested type.
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

Arrays and generic lists of supported primitive types work without extra configuration. However, keep these limitations in mind:

- All array and list elements must be supported primitive types.
- Avoid `string[]` and `List<string>` because NRBF format has complexity handling null values in string collections.
- Store strings individually or use JSON serialization for string collections.

The following examples show how arrays and lists can be set on the clipboard:

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

Common graphics types from the `System.Drawing` namespace work seamlessly with clipboard and `DataObject` operations. These types are useful for applications that work with visual elements and need to transfer drawing-related data between components or applications. Be aware that serializing a `Bitmap` can consume a large amount of memory, especially for large images. The following types are supported:

- `Point`, `PointF`, `Rectangle`, `RectangleF`.
- `Size`, `SizeF`, `Color`.
- `Bitmap` (can consume significant memory when serialized).

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

## Work with custom types

When you use `SetDataAsJson<T>()` and `TryGetData<T>()` with custom types, `System.Text.Json` handles serialization automatically. Many types work without any special configuration—records, simple classes, and structs with public properties serialize seamlessly.

### Simple types that work without attributes

Most straightforward custom types don't require special configuration:

```csharp
// Records work without any attributes.
public record PersonInfo(string Name, int Age, string Email);

// Simple classes serialize all public properties automatically.
public class DocumentMetadata
{
    public string Title { get; set; }
    public DateTime Created { get; set; }
    public string Author { get; set; }
}

// Structs with public properties work seamlessly.
public struct Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
```

### Use JSON attributes for advanced control

Use `System.Text.Json` attributes only when you need to customize serialization behavior. For comprehensive guidance on `System.Text.Json` serialization, attributes, and advanced configuration options, see [JSON serialization and deserialization in .NET](/dotnet/standard/serialization/system-text-json/).

The following example shows how you can use JSON attributes to control serialization:

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

### Example: Clipboard operations with custom types

```csharp
var data = new ClipboardFriendlyType 
{ 
    Name = "Sample", 
    DisplayText = "Sample Display Text",
    InternalId = "internal-123" // This property isn't serialized due to [JsonIgnore]
};

Clipboard.SetDataAsJson("MyAppData", data);

if (Clipboard.TryGetData("MyAppData", out ClipboardFriendlyType retrieved))
{
    Console.WriteLine($"Retrieved: {retrieved.Name}");
    // retrieved.InternalId is null because of [JsonIgnore]
}
```

## Enable BinaryFormatter support (not recommended)

> [!CAUTION]
> `BinaryFormatter` support is **not recommended**. Use it only as a temporary migration bridge for legacy applications that can't immediately migrate to the new type-safe APIs.

If you must continue using `BinaryFormatter` for clipboard operations in .NET 10, enable limited support through explicit configuration. This approach carries significant security risks and requires several steps.

For complete migration guidance, see the [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide/).

### Security warnings and risks

`BinaryFormatter` is inherently insecure and deprecated for these reasons:

- **Arbitrary code execution vulnerabilities**: Attackers can execute malicious code during deserialization, exposing your application to remote attacks.
- **Denial of service attacks**: Malicious clipboard data can consume excessive memory or CPU resources, causing crashes or instability.
- **Information disclosure risks**: Attackers might extract sensitive data from memory.
- **No security boundaries**: The format is fundamentally unsafe, and configuration settings can't secure it.

Only enable this support as a temporary bridge while you update your application to use the new type-safe APIs.

### Complete configuration requirements

Follow these steps to enable `BinaryFormatter` support for clipboard operations:

1. Install the compatibility package.

   Add the unsupported `BinaryFormatter` compatibility package to your project:

   ```xml
   <ItemGroup>
     <PackageReference Include="System.Runtime.Serialization.Formatters" Version="9.0.0" />
   </ItemGroup>
   ```

1. Enable unsafe serialization in your project file.

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

   Without this switch, clipboard operations won't fall back to `BinaryFormatter` even if general serialization support is enabled.

### Implement security-focused type resolvers

Even with `BinaryFormatter` enabled, you must implement type resolvers to restrict deserialization to explicitly approved types. Follow these guidelines:

- **Use explicit allow-lists.** Reject any type not explicitly approved.
- **Validate type names.** Ensure type names exactly match expected values.
- **Limit to essential types.** Include only types required for your clipboard functionality.
- **Throw exceptions for unknown types.** Clearly reject unauthorized types.
- **Review regularly.** Audit and update the allowed list as needed.

The following example shows a secure type resolver implementation:

```csharp
// Create a security-focused type resolver
private static Type SecureTypeResolver(TypeName typeName)
{
    // Explicit allow-list of permitted types—add only what you need
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

- [How to: Add Data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)
