using System.Collections.Specialized;

namespace ClipboardExample;

public partial class ClipboardMultipleFormatsTest : Form
{
    public ClipboardMultipleFormatsTest()
    {
        InitializeComponent();
    }

    // Customer class used in custom clipboard format examples.
    public class Customer
    {
        public string Name { get; set; }
        
        public Customer(string name)
        {
            Name = name;
        }
    }

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

    private void btnTestMultipleFormats_Click(object sender, EventArgs e)
    {
        try
        {
            TestClipboardMultipleFormats();
            lblStatus.Text = "Multiple formats test completed successfully!";
            lblStatus.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
            lblStatus.ForeColor = Color.Red;
        }
    }

    private void btnClearClipboard_Click(object sender, EventArgs e)
    {
        try
        {
            Clipboard.Clear();
            lblStatus.Text = "Clipboard cleared.";
            lblStatus.ForeColor = Color.Blue;
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error clearing clipboard: {ex.Message}";
            lblStatus.ForeColor = Color.Red;
        }
    }

    private void btnCheckClipboard_Click(object sender, EventArgs e)
    {
        try
        {
            var dataObject = Clipboard.GetDataObject();
            if (dataObject != null)
            {
                var formats = dataObject.GetFormats();
                if (formats.Length > 0)
                {
                    txtClipboardInfo.Text = "Available formats in clipboard:\r\n" + string.Join("\r\n", formats);
                    lblStatus.Text = $"Found {formats.Length} format(s) in clipboard.";
                    lblStatus.ForeColor = Color.Blue;
                }
                else
                {
                    txtClipboardInfo.Text = "No data formats found in clipboard.";
                    lblStatus.Text = "Clipboard is empty.";
                    lblStatus.ForeColor = Color.Gray;
                }
            }
            else
            {
                txtClipboardInfo.Text = "Clipboard data object is null.";
                lblStatus.Text = "Clipboard is empty.";
                lblStatus.ForeColor = Color.Gray;
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error checking clipboard: {ex.Message}";
            lblStatus.ForeColor = Color.Red;
        }
    }
}
