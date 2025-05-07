namespace Sample_Print_Application
{
    public partial class Form1 : Form
    {
        //<add_string_to_your_form>
        private string stringToPrint="";
        //</add_string_to_your_form>

        public Form1()
        {
            InitializeComponent();
        }
        
        //<print_contents_using_event_handler>
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
        //</print_contents_using_event_handler>
        
        //<set_DocumentName_and_string>
        private void button1_Click(object sender, EventArgs e)
        {
            string docName = "testPage.txt";
            string docPath = @"C:\";
            string fullPath = System.IO.Path.Combine(docPath, docName);

            printDocument1.DocumentName = docName;

            stringToPrint = System.IO.File.ReadAllText(fullPath);
            
            //<call_print_method_to_print_file>
            printDocument1.Print();
            //</call_print_method_to_print_file>
        }
        //</set_DocumentName_and_string>
    }
}
