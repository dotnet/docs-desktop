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

[Describe the main breaking changes and immediate impact on existing code.]

## New type-safe APIs

[Explain the new TryGetData\<T> and SetDataAsJson\<T> methods and their benefits.]

## Recommended built-in types

[Detail the types that work without custom serialization - primitives, arrays, System.Drawing types.]

## Working with custom types

[Explain JSON serialization approach and best practices for custom types.]

## Legacy data support

[How to handle existing binary data using NrbfDecoder and SerializationRecord.]

## Migration strategies

[Practical approaches for updating existing applications.]

## Enabling BinaryFormatter support (not recommended)

[Complete guide for legacy applications that need temporary BinaryFormatter support.]

## Use Copilot to update types

[Explain and give some example of using copilot to data objects.]

## Related content

- [How to: Add Data to the Clipboard](how-to-add-data-to-the-clipboard.md)
- [How to: Retrieve Data from the Clipboard](how-to-retrieve-data-from-the-clipboard.md)
- [Drag-and-Drop Operations and Clipboard Support](drag-and-drop-operations-and-clipboard-support.md)