using System.Collections.Specialized;

namespace ClipboardExample;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        //<ClipboardClear>
        Clipboard.Clear();
        //</ClipboardClear>
    }

    //<CustomerClass>
    // Customer class used in custom clipboard format examples.
    public class Customer
    {
        public string Name { get; set; }
        
        public Customer(string name)
        {
            Name = name;
        }
    }
    //</CustomerClass>

    //<SetTextExample>
    // Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    public Stream SwapClipboardAudio(Stream replacementAudioStream)
    {
        Stream? returnAudioStream = null;

        if (Clipboard.ContainsAudio())
        {
            returnAudioStream = Clipboard.GetAudioStream();
            Clipboard.SetAudio(replacementAudioStream);
        }
        return returnAudioStream;
    }

    // Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    public StringCollection SwapClipboardFileDropList(StringCollection replacementList)
    {
        StringCollection? returnList = null;

        if (Clipboard.ContainsFileDropList())
        {
            returnList = Clipboard.GetFileDropList();
            Clipboard.SetFileDropList(replacementList);
        }
        return returnList;
    }

    // Demonstrates SetImage, ContainsImage, and GetImage.
    public Image SwapClipboardImage(Image replacementImage)
    {
        Image? returnImage = null;

        if (Clipboard.ContainsImage())
        {
            returnImage = Clipboard.GetImage();
            Clipboard.SetImage(replacementImage);
        }
        return returnImage;
    }

    // Demonstrates SetText, ContainsText, and GetText.
    public string SwapClipboardHtmlText(string replacementHtmlText)
    {
        string? returnHtmlText = null;

        if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html);
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html);
        }
        return returnHtmlText;
    }
    //</SetTextExample>

    //<CustomFormatExample>
    // Demonstrates SetDataAsJson, ContainsData, and GetData
    // using a custom format name and a business object.
    public Customer TestCustomFormat
    {
        get
        {
            Clipboard.SetDataAsJson("CustomerFormat", new Customer("Customer Name"));
            if (Clipboard.ContainsData("CustomerFormat"))
            {
                if (Clipboard.TryGetData("CustomerFormat", out Customer customerData))
                    return customerData;
            }

            return null;
        }
    }
    //</CustomFormatExample>

    //<MultipleFormatsExample>
    // Demonstrates how to use a DataObject to add
    // data to the Clipboard in multiple formats.
    public void TestClipboardMultipleFormats()
    {
        DataObject data = new();

        Customer customer = new("Customer #2112");
        ListViewItem listViewItem = new($"Customer as ListViewItem {customer.Name}");

        // Add a Customer object using the type as the format.
        data.SetDataAsJson(customer);

        // Add a ListViewItem object using a custom format name.
        data.SetDataAsJson("ListViewItemFormat", listViewItem.Text);

        Clipboard.SetDataObject(data);

        // Retrieve the data from the Clipboard.
        DataObject retrievedData = (DataObject)Clipboard.GetDataObject()!;

        if (retrievedData.GetDataPresent("ListViewItemFormat"))
        {
            if (retrievedData.TryGetData("ListViewItemFormat", out String item))
            {
                ListViewItem recreatedListViewItem = new(item);
                MessageBox.Show($"Data contains ListViewItem with text of {recreatedListViewItem.Text}");
            }
        }

        if (retrievedData.GetDataPresent(typeof(Customer)))
        {
            if (retrievedData.TryGetData(out Customer newCustomer))
            {
                MessageBox.Show($"Data contains Customer with name of {newCustomer.Name}");
            }
        }
    }
    //</MultipleFormatsExample>
}
