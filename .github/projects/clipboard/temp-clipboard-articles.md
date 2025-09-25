# Clipboard-Related Articles in Windows Forms Documentation

This document lists all articles in the Windows Forms documentation that reference clipboard functionality. This is intended as a reference for updating documentation about new clipboard features.

## Core Clipboard Documentation

### Main Articles

1. **Drag-and-Drop Operations and Clipboard Support**
   - **Path:** `dotnet-desktop-guide\winforms\advanced\drag-and-drop-operations-and-clipboard-support.md`
   - **Description:** Overview article covering both drag-and-drop and clipboard functionality
   - **Content:** Main hub for clipboard operations

1. **How to: Add Data to the Clipboard**
   - **Path:** `dotnet-desktop-guide\winforms\advanced\how-to-add-data-to-the-clipboard.md`
   - **Description:** Step-by-step guide for adding data to the clipboard
   - **Content:** Covers `Clipboard.SetText()`, `SetData()`, and `SetDataObject()` methods

1. **How to: Retrieve Data from the Clipboard**
   - **Path:** `dotnet-desktop-guide\winforms\advanced\how-to-retrieve-data-from-the-clipboard.md`
   - **Description:** Guide for retrieving data from the clipboard
   - **Content:** Covers `Clipboard.GetText()`, `GetData()`, and `ContainsData()` methods

### Security and Permissions

1. **Additional Security Considerations in Windows Forms**
   - **Path:** `dotnet-desktop-guide\winforms\additional-security-considerations-in-windows-forms.md`
   - **Description:** Contains a dedicated "Clipboard Access" section discussing security permissions
   - **Content:** Security implications and permission requirements for clipboard access

1. **Windows Forms and Unmanaged Applications**
   - **Path:** `dotnet-desktop-guide\winforms\advanced\windows-forms-and-unmanaged-applications.md`
   - **Description:** Discusses clipboard access in the context of COM interop scenarios
   - **Content:** References clipboard in COM interoperability context

### Control-Specific Articles

1. **How to: Create a Read-Only Text Box (Windows Forms)**
   - **Path:** `dotnet-desktop-guide\winforms\controls\how-to-create-a-read-only-text-box-windows-forms.md`
   - **Description:** Mentions clipboard shortcuts (Ctrl+C, Ctrl+V) work in read-only text boxes
   - **Content:** Brief reference to clipboard functionality preservation

1. **How to: Put Quotation Marks in a String (Windows Forms)**
   - **Path:** `dotnet-desktop-guide\winforms\controls\how-to-put-quotation-marks-in-a-string-windows-forms.md`
   - **Description:** Example includes copying text to clipboard
   - **Content:** Code example using `Clipboard.SetText()`

1. **How to: Select Text in the Windows Forms TextBox Control**
   - **Path:** `dotnet-desktop-guide\winforms\controls\how-to-select-text-in-the-windows-forms-textbox-control.md`
   - **Description:** Mentions clipboard operations (copy/cut/paste) work with selected text
   - **Content:** References standard clipboard keyboard shortcuts

## Code Snippets and Examples

### Snippet Locations

- **Path:** `dotnet-desktop-guide\samples\snippets\winforms\*`
- **Files Found:**
  - Various code examples demonstrating clipboard operations.
  - Both C# and VB.NET implementations.
  - Examples of text, image, and custom data formats.

## Navigation and TOC References

### Table of Contents

- **Path:** `dotnet-desktop-guide\winforms\advanced\toc.yml`
- **Content:** Contains navigation entries for clipboard-related articles

## Summary

This repository contains comprehensive documentation covering:

- **3 primary clipboard articles** (overview, adding data, retrieving data).
- **Multiple supporting articles** that reference clipboard functionality.
- **Security considerations** for clipboard access.
- **Control-specific guidance** on clipboard behavior.
- **Code examples** in both C# and VB.NET.

## Notes for Updates

When adding new clipboard features:

1. Update the main overview article first.
1. Consider if new how-to guides are needed.
1. Update security considerations if permissions change.
1. Add code snippets for new functionality.
1. Update control-specific articles if behavior changes.

---

*Generated on September 25, 2025 as a reference for clipboard feature documentation updates.*
