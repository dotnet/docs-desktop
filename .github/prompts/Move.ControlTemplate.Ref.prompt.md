---
mode: agent
description: "Move control template information from type-styles-and-templates.md files into the main control markdown file."
---

Most control articles don't have any templating information, or they do, but it's in a different file named in the following pattern `type-styles-and-templates.md`. I want to move the content of that file into the main control file, so all information about the control is in one place.

Using the button control as an example, the main control file is `dotnet-desktop-guide/wpf/controls/button.md` and the styles and templates file is `dotnet-desktop-guide/wpf/controls/button-styles-and-templates.md`.

The content and headings from the styles and templates file should be moved into the main control file under a new heading named `Styles and templates`. The content should be appended to the end of the main control file, after any existing content, but before any reference or link section.

After that, add an entry to the `.openpublishing.redirection.wpf.json` file to redirect from the old styles and templates file to the main control file.

The structure of the edits should look like the following:

```
## Styles and templates

<instruction>Introduction about styles and templates for the control, include an xref link of the control. Finish with this clause: For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).</instruction>

### Parts

<instruction>List and describe the named parts of the control template, if any exist.</instruction>

### Visual states

<instruction>List and describe the visual states of the control, if any exist.</instruction>
```