using System;
using System.Windows.Forms;

namespace ClipboardExample
{
    public partial class ClipboardTextTest : Form
    {
        public ClipboardTextTest()
        {
            InitializeComponent();
        }

        private void btnSetText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtText.Text))
            {
                Clipboard.SetText(txtText.Text, TextDataFormat.Text);
            }
        }

        private void btnSetUnicodeText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUnicodeText.Text))
            {
                Clipboard.SetText(txtUnicodeText.Text, TextDataFormat.UnicodeText);
            }
        }

        private void btnSetRtf_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRtf.Text))
            {
                Clipboard.SetText(txtRtf.Text, TextDataFormat.Rtf);
            }
        }

        private void btnSetHtml_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHtml.Text))
            {
                Clipboard.SetText(txtHtml.Text, TextDataFormat.Html);
            }
        }

        private void btnSetCommaSeparatedValue_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCommaSeparatedValue.Text))
            {
                Clipboard.SetText(txtCommaSeparatedValue.Text, TextDataFormat.CommaSeparatedValue);
            }
        }

        private void btnGetClipboard_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            
            // Check if RTF is available first and display it formatted
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                string rtfData = Clipboard.GetText(TextDataFormat.Rtf);
                txtOutput.AppendText("RTF (formatted): ");
                
                // Store current selection position
                int selectionStart = txtOutput.TextLength;
                txtOutput.AppendText("\n");
                
                // Insert the RTF content with formatting
                int rtfStart = txtOutput.TextLength;
                txtOutput.SelectedRtf = rtfData;
                txtOutput.AppendText("\n\nRTF (raw): " + rtfData + "\n\n");
            }
            
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                txtOutput.AppendText("Text: " + Clipboard.GetText(TextDataFormat.Text) + "\n");
            }
            
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                txtOutput.AppendText("UnicodeText: " + Clipboard.GetText(TextDataFormat.UnicodeText) + "\n");
            }
            
            if (Clipboard.ContainsText(TextDataFormat.Html))
            {
                txtOutput.AppendText("Html: " + Clipboard.GetText(TextDataFormat.Html) + "\n");
            }
            
            if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
            {
                txtOutput.AppendText("CommaSeparatedValue: " + Clipboard.GetText(TextDataFormat.CommaSeparatedValue) + "\n");
            }
            
            if (txtOutput.Text.Length == 0)
            {
                txtOutput.Text = "No text data found in clipboard.";
            }
        }

        private void btnClearClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            txtOutput.Text = "Clipboard cleared.";
        }
    }
}
