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
        private string documentContents="";

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint="";
        //</string_declaration>

        //<print_file_using_event_handler>
        void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }
        //</print_file_using_event_handler>

        //<read_document_and_show_print_preview_dialog>
        private void Button1_Click(object sender, EventArgs e)
        {
            //<open_and_read_document_contents_to_the_string>
            string docName = "testPage.txt";
            string docPath = @"C:\";
            string fullPath = System.IO.Path.Combine(docPath, docName);
            printDocument1.DocumentName = docName;
            stringToPrint = System.IO.File.ReadAllText(fullPath);
            //</open_and_read_document_contents_to_the_string>

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
