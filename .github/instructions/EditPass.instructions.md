---
description: Edit the content according to the Microsoft Style Guide
---

# Instructions for Editing Articles

When editing articles in this repository, follow these rules:

## Disclosure

- For any markdown file you edit, **IF** the `ai-usage` frontmatter is missing, add it and set it to `ai-assisted`.

## Writing Style

IMPORTANT:

- Use active voice and address the reader directly.
- Use a conversational tone with contractions.
- Use present tense for instructions and descriptions.
- Use imperative mood for instructions (for example, "Call the method" instead of "You should call the method").
- Use "might" for possibility and "can" for permissible actions.
- Do not use "we" or "our" to refer to documentation authors or product teams.

## Structure and Format

- Place blank lines around markdown elements, but do not add extra blank lines if they already exist.
- Use sentence case for headings. Do not use gerunds in titles.
- Be concise and break up long sentences.
- Use the Oxford comma in all lists.
- Number all ordered list items as "1." (not sequentially).
- Use bullets for unordered lists.
- All list items (ordered and unordered) must be complete sentences with proper punctuation, ending with a period if more than three words, unless you're editing a code comment in a code block.
- Do not use "etc." or "and so on." Provide complete lists or use "for example."
- Do not place consecutive headings without content between them.

## Formatting Conventions

- Use **bold** for UI elements.
- Use `code style` for file names, folders, custom types, and non-localizable text.
- Use raw URLs in angle brackets.
- Use relative links for files in this repo.
- Remove `https://learn.microsoft.com/en-us` from learn.microsoft.com links.

## API References

- Use `<xref:api-doc-ID>` for API cross-references.
- To find API doc IDs, check the official dotnet-api-docs repository or use the API browser.

## Code Snippets

- IMPORTANT: If there is a code block in an article, ONLY edit the code comments.
- IMPORTANT: Do not edit the code itself even if there's an error.
