using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

//const string OutputFile = ".openpublishing.redirection.json";
const string RedirectsFileName = ".openpublishing.redirection.json";
const string DefinitionFile = "definitions.json";

// .openpublishing.redirection.winforms.json
// definitions.winforms.json
JsonSerializerOptions options = new JsonSerializerOptions
{
    Converters = { new JsonStringEnumConverter() },
    ReadCommentHandling = JsonCommentHandling.Skip,
    WriteIndented = true
};

// File names
string srcRedirectFilePath = string.Empty;
string definitionsFilePath = string.Empty;

// If a .openpublishing.redirection.json path is provided, use it. Otherwise, use the default
srcRedirectFilePath = args.Length == 1 ? args[0] : RedirectsFileName;

if (!Path.IsPathFullyQualified(srcRedirectFilePath))
    srcRedirectFilePath = Path.GetFullPath(srcRedirectFilePath, Environment.CurrentDirectory);

// Load the redirect and figure out which definition file to use
if (!File.Exists(srcRedirectFilePath))
{
    if (args.Length == 1)
        Console.WriteLine($"ERROR: The redirects file doesn't exist: '{srcRedirectFilePath}'");
    else
        Console.WriteLine($"ERROR: The redirects file (usually named '{RedirectsFileName}') doesn't exist. Either pass the path to one as the first parameter, or copy one into this folder.");
    Environment.Exit(-1);
}

if (!Path.GetFileNameWithoutExtension(srcRedirectFilePath).StartsWith(Path.GetFileNameWithoutExtension(RedirectsFileName), StringComparison.OrdinalIgnoreCase) ||
    !Path.GetExtension(srcRedirectFilePath).Equals(Path.GetExtension(RedirectsFileName), StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine($"ERROR: The file name provided must be in the format of {Path.GetFileNameWithoutExtension(RedirectsFileName)}[.*].{Path.GetExtension(RedirectsFileName)}");
    Environment.Exit(-2);
}

// Check for standard
if (Path.GetFileName(srcRedirectFilePath).Equals(RedirectsFileName, StringComparison.OrdinalIgnoreCase))
    definitionsFilePath = DefinitionFile;

else
    // Should construct "definitions.*.json" according to what is in the srcRedirectFilePath variable.
    definitionsFilePath = $"{Path.GetFileNameWithoutExtension(DefinitionFile)}{Path.GetFileName(srcRedirectFilePath).Replace(Path.GetFileNameWithoutExtension(RedirectsFileName), "")}";

// Load the definitions
if (!File.Exists(definitionsFilePath))
{
    Console.WriteLine($"ERROR: Definitions file is missing: '{definitionsFilePath}'");
    Environment.Exit(-3);
}

Console.WriteLine($"Loading definitions from '{definitionsFilePath}'");
Document document = JsonSerializer.Deserialize<Document>(System.IO.File.ReadAllText(definitionsFilePath), options);

// Load the source redirects file
RedirectsFile redirects = JsonSerializer.Deserialize<RedirectsFile>(System.IO.File.ReadAllText(srcRedirectFilePath), options);

Counters.LoadedRedirects = redirects.redirections.Length;

// Make sure there are entries
if (document.Entries.Length == 0)
{
    Console.WriteLine("No entries found in definition file");
    Environment.Exit(0);
}

Console.WriteLine("Reading all entries");
foreach (Entry item in document.Entries)
{
    if (item.Redirect == RedirectType.Normal)
    {
        if (item.SourceUrls == null)
            CreateNormalEntry(item.SourceUrl, item.TargetUrl, false);
        else
        {
            foreach (var sourceUrl in item.SourceUrls)
                CreateNormalEntry(sourceUrl, item.TargetUrl, false);
        }
    }

    else if (item.Redirect == RedirectType.NormalDocId)
        CreateNormalEntry(item.SourceUrl, item.TargetUrl, true);
      
    else
    {
        string sourceMoniker = item.SourceUrl.Contains(document.Moniker1, StringComparison.OrdinalIgnoreCase) ? document.Moniker1 : document.Moniker2;
        string targetMoniker = sourceMoniker == document.Moniker1 ? document.Moniker2 : document.Moniker1;

        if (item.Redirect == RedirectType.TwoWay)
        {
            CreateEntry(sourceMoniker, item.SourceUrl, item.TargetUrl);
            CreateEntry(targetMoniker, item.TargetUrl, item.SourceUrl);
        }
        else
        {
            CreateEntry(sourceMoniker, item.SourceUrl, item.TargetUrl);
        }
    }
}

Console.WriteLine($"Redirects file has {Counters.LoadedRedirects} existing entries.");

// After creating or updating all of the redirection entries, check to see if there were any changes
if (Counters.ModifiedRedirects == 0 && Counters.NewRedirects == 0)
{
    Console.WriteLine($"No changes to redirection file required.");
    Environment.Exit(0);
}

Console.WriteLine();
Console.WriteLine($"New entries: {Counters.NewRedirects}");
Console.WriteLine($"Updated entries: {Counters.ModifiedRedirects}");
Console.WriteLine();


// There were changes, save them.
Console.WriteLine($"Erasing '{srcRedirectFilePath}'");
System.IO.File.Delete(srcRedirectFilePath);


Console.WriteLine($"Writing '{srcRedirectFilePath}'");

// Format new json content.
string formattedJson = JsonSerializer.Serialize(redirects, options);
formattedJson = formattedJson.Replace("  ", "    ");    // match existing indent.
formattedJson += "\r\n";    // add newline at end.

// Save new content to source path.
File.WriteAllText(srcRedirectFilePath, formattedJson);



// ===================================================
// Supporting methods and types
// ===================================================

void CreateEntry(string sourceMoniker, string sourceUrl, string targetUrl)
{
    // Opposite repo paths are used here according to moniker
    string sourceFile = NormalizeMarkdownIndex(document.MonikerToMarkdown(sourceUrl, sourceMoniker, document.Moniker1 == sourceMoniker ? document.RepoPath2 : document.RepoPath1));
    redirects.AddRedirect(sourceFile, targetUrl, false);
}

void CreateNormalEntry(string sourceUrl, string targetUrl, bool redirectDocId)
{
    if (sourceUrl.Contains(document.Moniker1, StringComparison.OrdinalIgnoreCase))
        sourceUrl = document.MonikerToMarkdown(sourceUrl, document.Moniker1, document.RepoPath1);

    else if (sourceUrl.Contains(document.Moniker2, StringComparison.OrdinalIgnoreCase))
        sourceUrl = document.MonikerToMarkdown(sourceUrl, document.Moniker2, document.RepoPath2);
    
    redirects.AddRedirect(sourceUrl, targetUrl, redirectDocId);
}

string NormalizeMarkdownIndex(string path) =>
    path.EndsWith("/.md", StringComparison.OrdinalIgnoreCase) ? path.Replace("/.md", "/index.md", StringComparison.OrdinalIgnoreCase) : path;

Environment.Exit(0);

enum RedirectType
{
    OneWay,
    TwoWay,
    Normal,
    NormalDocId
}

class Document
{
    public string PublishRoot {get;set;}
    public string Moniker1 { get; set; }
    public string RepoPath1 { get; set; }

    public string Moniker2 { get; set; }
    public string RepoPath2 { get; set; }
    public Entry[] Entries { get; set; }

    public string MonikerToMarkdown(string input, string moniker, string repoPath) =>
        input.Replace($"?view={moniker}", "", StringComparison.OrdinalIgnoreCase)
             .Replace(PublishRoot, repoPath, StringComparison.OrdinalIgnoreCase) + ".md";
}

static class Counters
{
    public static int LoadedRedirects = 0;
    public static int NewRedirects = 0;
    public static int ModifiedRedirects = 0;
}

class Entry
{
    public RedirectType Redirect { get; set; }
    public string SourceUrl { get; set; }
    public string TargetUrl { get; set; }
    public string[] SourceUrls { get; set; }
}

class RedirectsFile
{
    private List<RedirectEntry> _redirects = new List<RedirectEntry>();

    public RedirectEntry[] redirections { get => _redirects.ToArray(); set => _redirects = new List<RedirectEntry>(value); }

    public void AddRedirect(string source, string targetUrl, bool redirectDocId)
    {
        source = source.Trim();
        targetUrl = targetUrl.Trim();

        foreach (var item in _redirects)
        {
            // Exisint redirect found in publishing redirection file, update it
            if (string.Equals(item.source_path, source, StringComparison.OrdinalIgnoreCase))
            {
                // Entry exists and doesn't need to be modified
                if (item.redirect_url != targetUrl || item.redirect_document_id != redirectDocId)
                {
                    item.redirect_url = targetUrl;
                    item.redirect_document_id = redirectDocId;
                    Counters.ModifiedRedirects++;
                }
                return;
            }
        }
        _redirects.Add(new(source, targetUrl, redirectDocId));
        Counters.NewRedirects++;
    }
}

class RedirectEntry
{
    public string source_path { get; set; }
    public string redirect_url { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool redirect_document_id { get; set; }

    public RedirectEntry() { }

    public RedirectEntry(string source, string targetUrl) =>
        (source_path, redirect_url, redirect_document_id) = (source, targetUrl, false);
    
    public RedirectEntry(string source, string targetUrl, bool redirectId) =>
        (source_path, redirect_url, redirect_document_id) = (source, targetUrl, redirectId ? true : default);
}


/*
EXAMPLE DEFINITIONS.JSON

{
    "Moniker1": "netframeworkdesktop-4.8",
    "RepoPath1": "dotnet-desktop-guide/framework/",
    "Moniker2": "netdesktop-5.0",
    "RepoPath2": "dotnet-desktop-guide/net/",
    "PublishRoot": "/dotnet/desktop/",
    "Entries": [

    // ========
    // WinForms
    // ========
        {
            "Redirect": "TwoWay",
            "SourceUrl": "/dotnet/desktop/winforms/how-to-create-a-windows-forms-application-from-the-command-line?view=netframeworkdesktop-4.8",
            "TargetUrl": "/dotnet/desktop/winforms/get-started/create-app-visual-studio?view=netdesktop-5.0"
        },
        {
            "Redirect": "OneWay",
            "SourceUrl": "/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms?view=netframeworkdesktop-4.8",
            "TargetUrl": "/dotnet/desktop/winforms/forms/events?view=netdesktop-5.0"
        }
}

*/
