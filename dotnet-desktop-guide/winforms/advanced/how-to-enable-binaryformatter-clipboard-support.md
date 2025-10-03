---
title: "Enable BinaryFormatter clipboard support (not recommended)"
description: "Learn how to configure legacy BinaryFormatter support for Windows Forms clipboard operations in .NET 10, including security considerations and type resolver implementation."
author: adegeo
ms.author: adegeo
ms.service: dotnet-desktop
ms.topic: how-to
ms.date: 10/02/2025
dev_langs:
  - "csharp"
  - "vb"
ai-usage: ai-assisted

#customer intent: As a Windows Forms developer, I want to enable BinaryFormatter clipboard support for legacy applications so that I can maintain compatibility while migrating to new type-safe APIs.

---

# Enable BinaryFormatter clipboard support (not recommended)

> [!CAUTION]
> `BinaryFormatter` support isn't recommended. Use it only as a temporary migration bridge for legacy applications that can't immediately migrate to the new type-safe APIs. This approach carries significant security risks.

This article shows how to configure limited `BinaryFormatter` support for Windows Forms clipboard operations in .NET 10. While `BinaryFormatter` was removed from the runtime in .NET 9 due to security vulnerabilities, restore limited functionality through explicit configuration for legacy applications that need time to migrate.

For complete migration guidance to the new type-safe APIs, see [Windows Forms clipboard and DataObject changes in .NET 10](../migration/clipboard-dataobject-net10.md).

> [!WARNING]
> Use this approach only as a temporary bridge while updating your application to use the new type-safe clipboard APIs introduced in .NET 10.

## Prerequisites

Before continuing, review these concepts:

- How your application currently uses `BinaryFormatter` in clipboard operations.
- The security vulnerabilities that led to the removal of `BinaryFormatter`.
- Your migration timeline to the new type-safe clipboard APIs.

For more information, see these articles:

- [Deserialization risks in use of BinaryFormatter and related types](/dotnet/standard/serialization/binaryformatter-security-guide)
- [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide)

## Security warnings and risks

`BinaryFormatter` is inherently insecure and deprecated for these reasons:

- **Arbitrary code execution vulnerabilities**: Attackers can execute malicious code during deserialization, exposing your application to remote attacks.
- **Denial of service attacks**: Malicious clipboard data can consume excessive memory or CPU resources, causing crashes or instability.
- **Information disclosure risks**: Attackers might extract sensitive data from memory.
- **No security boundaries**: The format is fundamentally unsafe, and configuration settings can't secure it.

Enable this support only as a temporary bridge while you update your application to use the new type-safe APIs.

## Install the compatibility package

Add the unsupported `BinaryFormatter` compatibility package to your project. This package provides the necessary runtime support for `BinaryFormatter` operations:

:::code language="xml" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/csharp/how-to-enable-binaryformatter-clipboard-support.csproj" id="PackageReference":::

> [!NOTE]
> This package is marked as unsupported and deprecated. Use it only for temporary compatibility during migration.

## Enable unsafe serialization in your project

Set the `EnableUnsafeBinaryFormatterSerialization` property to `true` in your project file. This property tells the compiler to allow `BinaryFormatter` usage:

```xml
<PropertyGroup>
  <TargetFramework>net10.0</TargetFramework>
  <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
</PropertyGroup>
```

Without this setting, your application generates compilation errors when it attempts to use `BinaryFormatter` APIs.

## Configure the Windows Forms runtime switch

Create or update your application's `runtimeconfig.json` file to enable the Windows Forms-specific clipboard switch. This configuration allows clipboard operations to fall back to `BinaryFormatter` when necessary:

:::code language="json" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/csharp/runtimeconfig.json":::

> [!IMPORTANT]
> Without this specific runtime switch, clipboard operations won't fall back to `BinaryFormatter` even if general serialization support is enabled. This switch is required specifically for Windows Forms clipboard functionality.

## Implement security-focused type resolvers

Even with `BinaryFormatter` enabled, implement type resolvers to restrict deserialization to explicitly approved types. Type resolvers provide your only defense against malicious payload attacks.

### Create a secure type resolver

:::code language="csharp" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/csharp/SecureTypeResolver.cs" id="SecureTypeResolver":::
:::code language="vb" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/vb/SecureTypeResolver.vb" id="SecureTypeResolver":::

### Use the type resolver with clipboard operations

:::code language="csharp" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/csharp/ClipboardUsage.cs" id="ClipboardUsage":::
:::code language="vb" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/vb/ClipboardUsage.vb" id="ClipboardUsage":::

## Security guidelines for type resolvers

Follow these essential security guidelines when implementing type resolvers:

### Use explicit allowlists

- **Reject by default**: Allow only explicitly listed types.
- **No wildcards**: Avoid pattern matching or namespace-based permissions.
- **Exact matching**: Require exact string matches for type names.

### Validate all inputs

- **Type name validation**: Ensure type names match expected formats.
- **Assembly restrictions**: Limit types to known, trusted assemblies.
- **Version checking**: Consider version-specific type restrictions.

### Handle unknown types securely

- **Throw exceptions**: Always throw for unauthorized types.
- **Log attempts**: Consider logging unauthorized access attempts.
- **Clear error messages**: Provide specific rejection reasons for debugging.

### Regular maintenance

- **Audit regularly**: Review and update the allowed type list.
- **Remove unused types**: Eliminate permissions for types no longer needed.
- **Document decisions**: Maintain clear documentation of why each type is permitted.

## Test your configuration

After configuring `BinaryFormatter` support, test your application to ensure it works correctly:

1. **Verify clipboard operations**: Test both storing and retrieving data with your custom types.
1. **Test type resolver**: Confirm that unauthorized types are properly rejected.
1. **Monitor security**: Watch for any unexpected type resolution attempts.
1. **Performance testing**: Ensure the type resolver doesn't significantly impact performance.

:::code language="csharp" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/csharp/TestConfiguration.cs" id="TestConfiguration":::
:::code language="vb" source="./snippets/how-to-enable-binaryformatter-clipboard-support/net/vb/TestConfiguration.vb" id="TestConfiguration":::

## Plan your migration strategy

While `BinaryFormatter` support provides temporary compatibility, develop a migration plan to move to the new type-safe APIs:

1. **Identify usage**: Catalog all clipboard operations using custom types.
1. **Prioritize migration**: Focus on the most security-sensitive operations first.
1. **Update incrementally**: Migrate one operation at a time to reduce risk.
1. **Test thoroughly**: Ensure new implementations provide equivalent functionality.
1. **Remove BinaryFormatter**: Disable support once migration is complete.

## Clean up resources

Once you've migrated to the new type-safe clipboard APIs, remove the `BinaryFormatter` configuration to improve security:

1. Remove the `System.Runtime.Serialization.Formatters` package reference.
1. Remove the `EnableUnsafeBinaryFormatterSerialization` property from your project file.
1. Remove the `Windows.ClipboardDragDrop.EnableUnsafeBinaryFormatterSerialization` setting from your `runtimeconfig.json`.
1. Delete type resolver implementations that are no longer needed.

## Related content

- [Clipboard and DataObject changes in .NET 10](../migration/clipboard-dataobject-net10.md)
- [How to add data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [How to retrieve data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [BinaryFormatter migration guide](/dotnet/standard/serialization/binaryformatter-migration-guide)
- [Deserialization risks in use of BinaryFormatter and related types](/dotnet/standard/serialization/binaryformatter-security-guide)
