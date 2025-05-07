using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //<ClickCheckbox>
        private void button1_Click(object sender, EventArgs e)
        {
            InvokeOnClick(checkBox1, EventArgs.Empty);
        }
        //</ClickCheckbox>

        private void SimulateButtonClick()
        {
            //<PerformClick>
            button1.PerformClick();
            //</PerformClick>
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
