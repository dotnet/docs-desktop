using System;
using System.Windows.Forms;

public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    //<CustomerClass>
    [Serializable]
    public class Customer
    {
        private string nameValue = string.Empty;
        public Customer(String name)
        {
            nameValue = name;
        }
        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }
    }
    //</CustomerClass>

    public Form1()
    {
        //<ClipboardClear>
        Clipboard.Clear();
        //</ClipboardClear>
    }

    //<CustomFormatExample>
    // Demonstrates SetData, ContainsData, and GetData
    // using a custom format name and a business object.
    public Customer TestCustomFormat
    {
        get
        {
            Clipboard.SetData("CustomerFormat", new Customer("Customer Name"));
            if (Clipboard.ContainsData("CustomerFormat"))
            {
                return Clipboard.GetData("CustomerFormat") as Customer;
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
        DataObject data = new DataObject();

        // Add a Customer object using the type as the format.
        data.SetData(new Customer("Customer as Customer object"));

        // Add a ListViewItem object using a custom format name.
        data.SetData("CustomFormat",
            new ListViewItem("Customer as ListViewItem"));

        Clipboard.SetDataObject(data);
        DataObject retrievedData = (DataObject)Clipboard.GetDataObject();

        if (retrievedData.GetDataPresent("CustomFormat"))
        {
            ListViewItem item =
                retrievedData.GetData("CustomFormat") as ListViewItem;
            if (item != null)
            {
                MessageBox.Show(item.Text);
            }
        }

        if (retrievedData.GetDataPresent(typeof(Customer)))
        {
            Customer customer =
                retrievedData.GetData(typeof(Customer)) as Customer;
            if (customer != null)
            {
                MessageBox.Show(customer.Name);
            }
        }
    }
    //</MultipleFormatsExample>

    //<GenericSetDataExample>
    // Demonstrates SetData, ContainsData, and GetData.
    public Object SwapClipboardFormattedData(String format, Object data)
    {
        Object returnObject = null;
        if (Clipboard.ContainsData(format))
        {
            returnObject = Clipboard.GetData(format);
            Clipboard.SetData(format, data);
        }
        return returnObject;
    }
    //</GenericSetDataExample>

    //<SetTextExample>
    //<SetAudioExample>
    // Demonstrates SetAudio, ContainsAudio, and GetAudioStream.
    public System.IO.Stream SwapClipboardAudio(
        System.IO.Stream replacementAudioStream)
    {
        System.IO.Stream returnAudioStream = null;
        if (Clipboard.ContainsAudio())
        {
            returnAudioStream = Clipboard.GetAudioStream();
            Clipboard.SetAudio(replacementAudioStream);
        }
        return returnAudioStream;
    }
    //</SetAudioExample>

    //<SetFileDropListExample>
    // Demonstrates SetFileDropList, ContainsFileDroList, and GetFileDropList
    public System.Collections.Specialized.StringCollection
        SwapClipboardFileDropList(
        System.Collections.Specialized.StringCollection replacementList)
    {
        System.Collections.Specialized.StringCollection returnList = null;
        if (Clipboard.ContainsFileDropList())
        {
            returnList = Clipboard.GetFileDropList();
            Clipboard.SetFileDropList(replacementList);
        }
        return returnList;
    }
    //</SetFileDropListExample>

    //<SetImageExample>
    // Demonstrates SetImage, ContainsImage, and GetImage.
    public System.Drawing.Image SwapClipboardImage(
        System.Drawing.Image replacementImage)
    {
        System.Drawing.Image returnImage = null;
        if (Clipboard.ContainsImage())
        {
            returnImage = Clipboard.GetImage();
            Clipboard.SetImage(replacementImage);
        }
        return returnImage;
    }
    //</SetImageExample>

    //<SetHtmlTextExample>
    // Demonstrates SetText, ContainsText, and GetText.
    public String SwapClipboardHtmlText(String replacementHtmlText)
    {
        String returnHtmlText = null;
        if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            returnHtmlText = Clipboard.GetText(TextDataFormat.Html);
            Clipboard.SetText(replacementHtmlText, TextDataFormat.Html);
        }
        return returnHtmlText;
    }
    //</SetHtmlTextExample>
    //</SetTextExample>
}