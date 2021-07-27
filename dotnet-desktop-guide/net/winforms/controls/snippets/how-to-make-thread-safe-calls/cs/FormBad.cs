using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormBad : Form
    {
        public FormBad()
        {
            InitializeComponent();
        }

        //<Bad>
        private void button1_Click(object sender, EventArgs e)
        {
            var thread2 = new System.Threading.Thread(WriteTextUnsafe);
            thread2.Start();
        }

        private void WriteTextUnsafe() =>
            textBox1.Text = "This text was set unsafely.";
        //</Bad>
    }
}
