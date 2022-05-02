using System.Drawing.Printing;

namespace Sample_print_winform_print_preview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //<string_declaration>
        // Declare a string to hold the entire document contents.
        private string DocumentContents="";

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string StringToPrint="";
        //</string_declaration>

        //<print_file_using_event_handler>
        void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(StringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(StringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            StringToPrint = StringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (StringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                StringToPrint = DocumentContents;
        }
        //</print_file_using_event_handler>

        //<read_document_and_show_print_preview_dialog>
        private void Button1_Click(object sender, EventArgs e)
        {
            //<open_and_read_document_contents_the_string>
            string docName = "testPage.txt";
            string docPath = @"C:\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new (docPath + docName, FileMode.Open))
            using (StreamReader reader = new (stream))
            {
                DocumentContents = reader.ReadToEnd();
            }
            StringToPrint = DocumentContents;
            //</open_and_read_document_contents_the_string>

            //<set_the_document_property>
            printPreviewDialog1.Document = printDocument1;
            //</set_the_document_property>

            //<set_property_of_dialog>
            printPreviewDialog1.ShowDialog();
            //<set_property_of_dialog>
        }
        //</read_document_and_show_print_preview_dialog>

    }
}