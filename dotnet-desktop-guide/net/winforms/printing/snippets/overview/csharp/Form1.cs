using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_print_app
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
            //<show-dialog>
            // display show dialog and if user selects "Ok" document is printed
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            //</show-dialog>
        }

        //<specify-the-material-to-be-printed>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red,new Rectangle(100, 100, 100, 100));
        }
        //</specify-the-material-to-be-printed>

        //<message-box-indicating-document-has-finished-printing>
        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MessageBox.Show(printDocument1.DocumentName + " has finished printing.");
        }
        //</message-box-indicating-document-has-finished-printing>

    }
}
