This tool uses the _definitions.json_ file to generate a _.openpublishing.redirection_ file. If a _.openpublishing.redirection_ file exists in the folder, it's copied to the output folder and updated and appended to there.

Pass in the file path of a _.openpublishing.redirection_ file, and it'll be  updated in-place. e.g. redirs.exe "c:\repos\dotnet\docs-desktop\.openpublishing.redirection.json"

The definitions generate two-way redirects between versioned content. The definition file is a json file that has some config at the start:

```json
{
    "Moniker1": "netframeworkdesktop-4.8",
    "RepoPath1": "dotnet-desktop-guide/framework/",
    "Moniker2": "netdesktop-7.0",
    "RepoPath2": "dotnet-desktop-guide/net/",
    "PublishRoot": "/dotnet/desktop/",
    ...
}
```

There are three settings:

- `Moniker`

  A moniker represents the `?view=` query string value.

- `RepoPath`

  The repo path represents the folder path to this content in the repo for the Moniker.

- `PublishRoot`

  This is the root on ms.docs where the content is published to.

`Moniker1` and `RepoPath1` work together to define a repo path and version. `Moniker2` and `RepoPath2` work together to define another repo path and version. Redirects between monikers require that the path of article `Moniker1` be rewritten in the path as if it exists in the repo where `Moniker2` is.

When you use the version switcher to move from moniker `netdesktop-7.0` to `netframeworkdesktop-4.8`, it replaces the `?view=` query string, but keeps the same URL file path:

| Moniker | URL |
| - | - |
| `Moniker1` | `https://learn.microsoft.com/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms?view=netframeworkdesktop-4.8` |
| `Moniker2` | `https://learn.microsoft.com/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms?view=netdesktop-7.0` |

Based on the publishing path and repo paths of the monikers registered with the build system, you can reverse engineer the path to the source file by continually transforming the URL:

01. Remove the website:

    ```
    /dotnet/desktop/winforms/creating-event-handlers-in-windows-forms?view=netframeworkdesktop-4.8
    ```

01. Remove the `PublishRoot`:

    ```
    winforms/creating-event-handlers-in-windows-forms?view=netframeworkdesktop-4.8
    ```

01. Remove the moniker and append `.md`

    ```
    winforms/creating-event-handlers-in-windows-forms.md
    ```

01. Add the RepoPath for both monikers to come up with where the file should exist in the repo:

    | Moniker | URL |
    | - | - |
    | `RepoPath1` | `dotnet-desktop-guide/framework/winforms/creating-event-handlers-in-windows-forms.md` |
    | `RepoPath2` | `dotnet-desktop-guide/net/winforms/creating-event-handlers-in-windows-forms.md` |

If a file exists in both versioned areas of a repo, redirects happen automatically. If a file doesn't exist in one of the versioned folders, say 5.0, you must create a redirect for where the 4.8 version of the file would exist in the 5.0 area. If you then want to be able to redirect in the opposite direction, back from 5.0 to 4.8, you must create another redirect for that scenario too.

There are more examples in the next section.

## Entries

The final part of the config file are all the entries for redirection. A redirect entry looks like the following:

```json
{
    "Redirect": "OneWay",
    "SourceUrl": "/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms?view=netframeworkdesktop-4.8",
    "TargetUrl": "/dotnet/desktop/winforms/forms/events?view=netdesktop-7.0"
},
```

The `Redirect` field represents the type of redirect and can be one of the following:

- `OneWay`

  This generates a redirect from the `SourceUrl` to the `TargetUrl`. The `SourceUrl` is regenerated based moniker and opposite-moniker's url. For example, if the `SourceUrl` contained `Moniker1` (`netframeworkdesktop-4.8`), then the URL has `?view=netframeworkdesktop-4.8` stripped from it and it's rewritten in the #2 repo path, `RepoPath2`:

  ```json
  {
    "source_path": "dotnet-desktop-guide/net/winforms/creating-event-handlers-in-windows-forms.md",
    "redirect_url": "/dotnet/desktop/winforms/forms/events?view=netdesktop-7.0"
  },
  ```

- `TwoWay`

  This mode works the same as `OneWay` except it creates a redirect, then it swaps the `SourceUrl` and `TargetUrl` paths and creates another redirect. This effectively maps two URLs to each other.

  ```json
  {
    "source_path": "dotnet-desktop-guide/net/winforms/creating-event-handlers-in-windows-forms.md",
    "redirect_url": "/dotnet/desktop/winforms/forms/events?view=netdesktop-7.0"
  },
  {
    "source_path": "dotnet-desktop-guide/framework/forms/events.md",
    "redirect_url": "/dotnet/desktop/winforms/winforms/creating-event-handlers-in-windows-forms?view=netdesktop-7.0"
  },
  ```

- `Normal`

  This is similar to `OneWay` but it doesn't use any reverse-moniker logic processing. As a convenience, this **will** translate the source url into the source markdown file for you so you don't need to figure out what it is. This is mostly processed just like a normal redirect you create in the redirection file.

- `NormalDocId`

  This is the same as `Normal` but it adds the `redirect_document_id: true` entry to the redirect.
