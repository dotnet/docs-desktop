---
model: GPT-4o (copilot)
mode: agent
description: "Updates link text to match target content headings"
---

# Refresh Links Prompt

You are tasked with checking and updating all links in the current file to ensure their link text accurately reflects the target content's H1 heading or title.

## Link Types and Processing Rules

### 1. Relative Links (e.g., `./folder/file.md`, `../folder/file.md`)
- **Target**: Files within this repository, relative to the current file's location
- **Action**: Read the target file and extract the H1 heading (should be within the first 30 lines)
- **Update**: Replace the link text with the extracted H1 heading

### 2. Root-Relative Links (e.g., `/dotnet-desktop-guide/wpf/overview`)
- **Target**: Published pages on https://learn.microsoft.com/
- **Action**: Fetch the page from `https://learn.microsoft.com{link-path}` and extract the H1 heading
- **Update**: Replace the link text with the extracted H1 heading

### 3. Repository Root Links (e.g., `~/dotnet-desktop-guide/winforms/overview.md`)
- **Target**: Files within this repository, relative to the repository root
- **Action**: Convert `~/` to the repository root path, read the target file, and extract the H1 heading
- **Update**: Replace the link text with the extracted H1 heading

### 4. Full URLs (e.g., `https://example.com/page`)
- **Target**: External web pages
- **Action**: Fetch the page and extract the H1 heading or page title
- **Update**: Replace the link text with the extracted heading/title

### 5. XREF links (e.g., `[link text](xref:api-doc-id)`)
- **Target**: API documentation links
- **Action**: Do not change the link text, ignore this type of item.

## Processing Instructions

1. **Scan the file**: Identify all markdown links in the format `[link text](url)`

2. **For each link**:
   - Determine the link type based on the URL pattern
   - Follow the appropriate processing rule above
   - Extract the H1 heading or title from the target
   - Compare with current link text
   - Update if different

3. **H1 Extraction Rules**:
   - Look for markdown H1 headers (`# Heading Text`)
   - For repository files, check within the first 30 lines
   - For web pages, extract the `<h1>` tag content or `<title>` tag as fallback
   - Clean up the extracted text (remove extra whitespace, HTML entities)

4. **Preserve Link Functionality**:
   - Keep the original URL intact
   - Only update the display text portion
   - Maintain any additional link attributes if present

5. **Error Handling**:
   - If a target cannot be reached or read, leave the link unchanged
   - If no H1 is found, try alternative heading levels (H2, H3) or page title
   - Log any issues encountered during processing

## Example Transformations

```markdown
Before: [Old Link Text](../wpf/overview.md)
After:  [WPF Overview](../wpf/overview.md)

Before: [Click here](/dotnet-desktop-guide/winforms/getting-started)
After:  [Getting Started with Windows Forms](/dotnet-desktop-guide/winforms/getting-started)

Before: [Link](~/dotnet-desktop-guide/wpf/controls/button.md)
After:  [Button Control](~/dotnet-desktop-guide/wpf/controls/button.md)

Before: [External](https://example.com/some-page)
After:  [Example Page](https://example.com/some-page)
```

## Output

Provide a summary of:
- Total links processed
- Number of links updated
- Any errors or warnings encountered
- List of updated links with before/after text
