---
name: Redirect an article
agent: agent
description: "Deletes an article and creates a redirect entry to point to a different article."
---

You have to delete a markdown article in and create a redirect entry from the deleted article to a different article. The redirect entry should be placed alphabetically in the JSON file.

Artilces related to WPF go in the `.openpublishing.redirection.wpf.json` file, and articles related to Windows Forms go in the `.openpublishing.redirection.winforms.json` file.

For example, if you are deleting the article gridsplitter-how-to-topics.md and want to redirect it to gridsplitter.md, you would:

1. Delete the file `dotnet-desktop-guide/wpf/controls/gridsplitter-how-to-topics.md`.
2. Add the following entry to the `.openpublishing.redirection.wpf.json` file, where `source_path` is the location of the file in the repository and `destination` is the URL path of the article to redirect to:

```json
{
  "source_path": "dotnet-desktop-guide/wpf/controls/gridsplitter-how-to-topics.md",
  "destination": "/dotnet/desktop/wpf/controls/gridsplitter",
}
```

3. Search the repository for any links to the old article and update them to point to the new article.
