using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace RetrieveClipboardData;

public class MainForm : Form
{
    //<HelperMethods>
    [Serializable]
    public class Customer
    {
        private string nameValue = string.Empty;
        public Customer(string name)
        {
            nameValue = name;
        }
        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }
    }
    //</HelperMethods>

    public MainForm()
    {
        Clipboard.Clear();
    }

    //<RetrieveCustomFormat>
    // Demonstrates TryGetData using a custom format name and a business object.
    // Note: In .NET 10, SetData for objects is no longer supported,
    // so this example shows how to retrieve data that might have been
    // set by other applications or earlier .NET versions.
    public Customer? TestCustomFormat
    {
        get
        {
            // For demonstration, we'll use string data instead of objects
            // since SetData for objects is no longer supported in .NET 10
            if (Clipboard.TryGetData("CustomerFormat", out object? data))
            {
                return data as Customer;
            }
            return null;
        }
    }
    //</RetrieveCustomFormat>

    //<RetrieveMultipleFormats>
    // Demonstrates how to retrieve data from the Clipboard in multiple formats
    // using TryGetData instead of the obsoleted GetData method.
    public void TestClipboardMultipleFormats()
    {
        IDataObject? dataObject = Clipboard.GetDataObject();
        
        if (dataObject != null)
        {
            // Check for custom format
            if (dataObject.GetDataPresent("CustomFormat"))
            {
                if (Clipboard.TryGetData("CustomFormat", out object? customData))
                {
                    if (customData is ListViewItem item)
                    {
                        MessageBox.Show(item.Text);
                    }
                    else if (customData is string stringData)
                    {
                        MessageBox.Show(stringData);
                    }
                }
            }

            // Check for Customer type - note that object serialization
            // through SetData is no longer supported in .NET 10
            if (dataObject.GetDataPresent(typeof(Customer)))
            {
                if (Clipboard.TryGetData(typeof(Customer).FullName!, out object? customerData))
                {
                    if (customerData is Customer customer)
                    {
                        MessageBox.Show(customer.Name);
                    }
                }
            }

            // For modern .NET 10 applications, prefer using standard formats
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                MessageBox.Show($"Text data: {text}");
            }
        }
    }
    //</RetrieveMultipleFormats>

    //<RetrieveCommonFormat>
    // Demonstrates TryGetData methods for common formats.
    // These methods are preferred over the older Get* methods.
    public Stream? SwapClipboardAudio(Stream replacementAudioStream)
    {
        Stream? returnAudioStream = null;
        if (Clipboard.ContainsAudio())
        {
            returnAudioStream = Clipboard.GetAudioStream();
            Clipboard.SetAudio(replacementAudioStream);
        }
        return returnAudioStream;
    }

    // Demonstrates TryGetData for file drop lists
    public StringCollection? SwapClipboardFileDropList(StringCollection replacementList)
    {
        StringCollection? returnList = null;
        if (Clipboard.ContainsFileDropList())
        {
            returnList = Clipboard.GetFileDropList();
            Clipboard.SetFileDropList(replacementList);
        }
        return returnList;
    }

    // Demonstrates TryGetData for images
    public Image? SwapClipboardImage(Image replacementImage)
    {
        Image? returnImage = null;
        if (Clipboard.ContainsImage())
        {
            returnImage = Clipboard.GetImage();
            Clipboard.SetImage(replacementImage);
        }
        return returnImage;
    }

    // Demonstrates TryGetData for text in HTML format
    public string? SwapClipboardHtmlText(string replacementHtmlText)
    {
        string? returnHtmlText = null;
        if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html);
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html);
        }
        return returnHtmlText;
    }

    // Example of using TryGetData for custom string-based data
    public string? GetCustomStringData(string format)
    {
        if (Clipboard.TryGetData(format, out object? data))
        {
            return data as string;
        }
        return null;
    }
    //</RetrieveCommonFormat>
}