namespace Sample_Print_Application
{
    public partial class Form1 : Form
    {
        //<add_string_ to_your_form>
        private string stringToPrint;
        //</add_string_ to_your_form>

        public Form1()
        {
            InitializeComponent();
        }
        private void ReadFile()
        {
            //<set_DocumentName_then_open_and_read_document_to_the_string>
            string docName = "testPage.txt";
            string docPath = @"C:\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                stringToPrint = reader.ReadToEnd();
            }
            //</set_DocumentName_then_open_and_read_document_to_the_string>
        }

        //<print_contents_of_the_file_using_event_handler>
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }
        //</print_contents_of_the_file_using_event_handler>
        
        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
            //<call_print_method_to_print_file>
            printDocument1.Print();
            //</call_print_method_to_print_file>
        }
    }
}