---
description: The plan for updating the Clipboard content
---

# Plan to Update WinForms Clipboard Documentation for .NET 10

## LLM instructions
If you're creating article files, use the [templates](/.github/projects/article-templates/) folder to find a suitable article template.

IMPORTANT! Add the following files as context:
- [Migration guide for Clipboard in .NET 10](/dotnet-desktop-guide/winforms/migration/clipboard-dataobject-net10.md)
- [Engineer's overview on the changes in .NET 10 for Clipboard](/.github/projects/clipboard/clipboard-dataobject-net10-changes.md)
- [BinaryFormatter migration guide](https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-migration-guide/)

## Executive Summary

The .NET 10 release introduces significant changes to the Windows Forms clipboard and drag-and-drop functionality, primarily driven by the removal of `BinaryFormatter` from the runtime. This requires updating existing documentation and creating new articles to cover the new type-safe APIs, JSON serialization, and migration guidance.

## Current Documentation Inventory

### Existing Articles to Update:

1. **`drag-and-drop-operations-and-clipboard-support.md`** - Main overview article
2. **`how-to-add-data-to-the-clipboard.md`** - Adding data guide
3. **`how-to-retrieve-data-from-the-clipboard.md`** - Retrieving data guide  

## Detailed Update Plan

### Phase 1: Create New Comprehensive Overview Article ✅

**New Article: `clipboard-dataobject-net10.md`** (COMPLETED)

- **Location**: dontnet-desktop-guide/winforms/migration/clipboard-dataobject-net10.md
- **Priority**: High (COMPLETED)
- **Content Focus**:
  - Overview of .NET 10 changes and BinaryFormatter removal
  - Comparison table: old vs new APIs
  - Best practices for type-safe clipboard operations
  - Migration guide from legacy methods
  - Security improvements and implications
- **Target Audience**: Developers migrating existing applications
- **Estimated Length**: 2,000-2,500 words
- **Status**: Completed 

### Phase 2: Update Existing Core Articles ✅

#### 2.1 Update Main Overview (`drag-and-drop-operations-and-clipboard-support.md`) ✅

- **Changes Needed**:
  - Add .NET 10 compatibility section
  - Update introduction to mention new type-safe APIs
  - Add links to new migration guide
  - Update "In This Section" with new articles
- **Priority**: High
- **Status**: Completed

#### 2.2 Comprehensive Rewrite (`how-to-add-data-to-the-clipboard.md`) ✅

- **Major Changes**:
  - Add new section on `SetDataAsJson<T>()` method
  - Update best practices to recommend new APIs first
  - Add warning about BinaryFormatter deprecation
  - Show examples of recommended built-in types
  - Add migration examples from old to new methods
- **New Sections**:
  - "Adding Custom Types with JSON Serialization"
  - "Working with Recommended Built-in Types"
  - "Migrating from Legacy SetData Methods"
- **Priority**: High
- **Status**: Completed

#### 2.3 Comprehensive Rewrite (`how-to-retrieve-data-from-the-clipboard.md`) ✅

- **Major Changes**:
  - Replace `GetData()` examples with `TryGetData<T>()` methods
  - Add type-safe retrieval examples
  - Cover resolver patterns for legacy data
  - Add error handling best practices
- **New Sections**:
  - "Type-Safe Data Retrieval with `TryGetData<T>`"
  - "Handling Legacy Binary Data"
  - "Working with Custom JSON Types"
- **Priority**: High
- **Status**: Completed

### Phase 3: Create New Specialized Articles

#### 3.1 New Article: `how-to-use-typed-clipboard-apis.md`

- **Template**: How-to article
- **Content Focus**:
  - Detailed guide on `TryGetData<T>()` methods
  - Examples of all overloads
  - Type resolver implementation patterns
  - Error handling strategies
- **Priority**: High

#### 3.2 New Article: `clipboard-json-serialization.md`

- **Content Focus**:
  - Using `SetDataAsJson<T>()` effectively
  - System.Text.Json considerations
  - Custom type design for clipboard
  - Cross-process/cross-framework compatibility
- **Priority**: Medium

#### 3.3 New Article: `how-to-enable-binaryformatter-clipboard-support.md` ✅

- **Template**: How-to article (COMPLETED)
- **Content Focus**:
  - Complete guide for legacy application migration
  - Runtime configuration steps
  - Security considerations and risks
  - Type resolver implementation examples
- **Priority**: Medium (for legacy support)
- **Status**: Completed

### Phase 4: Navigation and Discoverability Updates

#### 4.1 Update Table of Contents (`toc.yml`)

- Add new articles to the drag-and-drop section
- Reorganize clipboard articles for better flow
- Add migration guide as featured content

#### 4.2 Update Cross-References

- Add xref links between related articles
- Update "See also" sections across all clipboard articles
- Link to BinaryFormatter migration guidance

## Implementation Timeline

### Week 1-2: Foundation ✅

- [x] Create comprehensive migration overview article
- [x] Update main overview article with .NET 10 references
- [x] Set up new code snippet structure

### Week 3-4: Core Rewrites ✅

- [x] Rewrite "How to: Add Data" article
- [x] Rewrite "How to: Retrieve Data" article
- [x] Create new typed APIs guide

### Week 5-6: Specialized Content

- [ ] Create JSON serialization guide
- [ ] Create BinaryFormatter legacy support guide
- [ ] Update security considerations

### Week 7: Polish and Integration

- [ ] Update all code snippets
- [ ] Update navigation and cross-references
- [ ] Review and test all examples

## Quality Assurance Checklist

### Content Standards

- [ ] All articles include `ai-usage: ai-generated` frontmatter
- [ ] Follow Microsoft Writing Style Guide
- [ ] Use Oxford commas in all lists
- [ ] Number ordered lists as "1." (not sequential)
- [ ] Use complete sentences in lists with proper punctuation
- [ ] Active voice and second person throughout

### Technical Standards

- [ ] All code examples compile and run
- [ ] Both C# and VB.NET examples where appropriate
- [ ] API references use proper xref format
- [ ] Version compatibility clearly documented
- [ ] Security warnings appropriately placed

### Documentation Architecture

- [ ] Logical information hierarchy
- [ ] Clear navigation between related topics
- [ ] Appropriate use of includes for shared content
- [ ] SEO-friendly titles and descriptions

## Success Metrics

1. **Coverage**: All major .NET 10 clipboard APIs documented
2. **Migration Support**: Clear upgrade path from legacy APIs
3. **Developer Experience**: Easy-to-find, actionable guidance
4. **Code Quality**: All examples follow best practices
5. **Discoverability**: Proper navigation and cross-linking

## Risk Mitigation

### Technical Risks

- **API Changes**: Monitor .NET 10 development for any last-minute API changes
- **Backward Compatibility**: Ensure legacy guidance remains accurate

### Content Risks  

- **Information Overload**: Balance comprehensive coverage with readability
- **Fragmentation**: Maintain consistent messaging across all articles

This plan ensures comprehensive coverage of the .NET 10 clipboard changes while maintaining the existing documentation structure and providing clear migration guidance for developers.
