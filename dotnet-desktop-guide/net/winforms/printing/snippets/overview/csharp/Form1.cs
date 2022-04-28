namespace Sample_Print_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            printDocument1.DocumentName = "SamplePrintApp";
            //<show_dialog>
            // display show dialog and if user selects "Ok" document is printed
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
            //</show_dialog>
        }


        //<specify_the_material_to_be_printed>
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) =>
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(100, 100, 100, 100));
        //</specify_the_material_to_be_printed>

        //<message_box_indicating_document_has_finished_printing>
        private void PrintDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e) =>
            MessageBox.Show(printDocument1.DocumentName + " has finished printing.");
        //</message_box_indicating_document_has_finished_printing>

    }
}
