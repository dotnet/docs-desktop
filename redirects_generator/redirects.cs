using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

const string OutputFile = ".openpublishing.redirection.json";

JsonSerializerOptions options = new JsonSerializerOptions
{
    Converters = { new JsonStringEnumConverter() },
    ReadCommentHandling = JsonCommentHandling.Skip,
    WriteIndented = true
};

// If a .openpublishing.redirection.json path is provided,
// then copy that file to the output folder.
if (args.Length == 1)
{
    if (!File.Exists(args[0]))
    {
        Console.WriteLine("ERROR: The file provided doesn't exist");
        return;
    }

    // Get passed in .openpublishing.redirection.json path.
    string srcRedirectFilePath = args[0];

    // Copy .openpublishing.redirection.json to output folder.
    File.Copy(srcRedirectFilePath, OutputFile, overwrite: true);
}

// Load the definitions
Console.WriteLine("Loading 'definitions.json'");
Document document = JsonSerializer.Deserialize<Document>(System.IO.File.ReadAllText("definitions.json"), options);
RedirectsFile redirects = new RedirectsFile();

Console.WriteLine($"Checking for existing '{OutputFile}'");
if (System.IO.File.Exists(OutputFile))
    redirects = JsonSerializer.Deserialize<RedirectsFile>(System.IO.File.ReadAllText(OutputFile), options);

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

if (System.IO.File.Exists(OutputFile))
{
    Console.WriteLine($"Erasing '{OutputFile}'");
    System.IO.File.Delete(OutputFile);
}

Console.WriteLine($"Writing '{OutputFile}'");
System.IO.File.WriteAllText(OutputFile, JsonSerializer.Serialize(redirects));

// If a .openpublishing.redirection.json path is provided,
// then overwrite it with the formatted new content.
if (args.Length == 1 && File.Exists(args[0]))
{
    // Get passed in .openpublishing.redirection.json path.
    string srcRedirectFilePath = args[0];

    // Format new json content.
    string formattedJson = JsonSerializer.Serialize(redirects, options);
    formattedJson = formattedJson.Replace("  ", "    ");    // match existing indent.
    formattedJson += "\r\n";    // add newline at end.

    // Save new content to source path.
    File.WriteAllText(srcRedirectFilePath, formattedJson);
}

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
            if (string.Equals(item.source_path, source, StringComparison.OrdinalIgnoreCase))
            {
                item.redirect_url = targetUrl;
                item.redirect_document_id = redirectDocId;
                return;
            }
        }
        _redirects.Add(new(source, targetUrl, redirectDocId));
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