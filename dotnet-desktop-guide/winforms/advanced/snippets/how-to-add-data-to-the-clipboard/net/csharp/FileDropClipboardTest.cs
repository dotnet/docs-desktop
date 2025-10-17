using System.Collections.Specialized;

namespace ClipboardExample;

public partial class FileDropClipboardTest : Form
{
    public FileDropClipboardTest()
    {
        InitializeComponent();
    }

    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
        // Check for Ctrl+V key combination
        if (e.Control && e.KeyCode == Keys.V)
        {
            // Prevent the default paste behavior
            e.Handled = true;
            
            // Handle the clipboard file drop list
            HandleClipboardFileDropList();
        }
    }

    private void HandleClipboardFileDropList()
    {
        try
        {
            // Check if clipboard contains file drop list
            if (Clipboard.ContainsFileDropList())
            {
                // Get the file drop list from clipboard
                StringCollection files = Clipboard.GetFileDropList();
                
                if (files != null && files.Count > 0)
                {
                    // Clear existing text and add file names
                    textBox.Clear();
                    textBox.AppendText("Files from clipboard:" + Environment.NewLine);
                    textBox.AppendText(new string('-', 30) + Environment.NewLine);
                    
                    foreach (string file in files)
                    {
                        textBox.AppendText(file + Environment.NewLine);
                    }
                    
                    textBox.AppendText(Environment.NewLine + $"Total files: {files.Count}");
                }
                else
                {
                    textBox.Text = "Clipboard contains file drop list but no files found.";
                }
            }
            else
            {
                // Check what other data formats are available
                textBox.Clear();
                textBox.AppendText("No file drop list found in clipboard." + Environment.NewLine);
                textBox.AppendText("Available clipboard formats:" + Environment.NewLine);
                textBox.AppendText(new string('-', 30) + Environment.NewLine);
                
                IDataObject dataObject = Clipboard.GetDataObject();
                if (dataObject != null)
                {
                    string[] formats = dataObject.GetFormats();
                    foreach (string format in formats)
                    {
                        textBox.AppendText($"- {format}" + Environment.NewLine);
                    }
                }
                else
                {
                    textBox.AppendText("Clipboard is empty or inaccessible.");
                }
            }
        }
        catch (Exception ex)
        {
            textBox.Text = $"Error accessing clipboard: {ex.Message}";
        }
    }
}
