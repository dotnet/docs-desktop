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
    public partial class FormThread : Form
    {
        public FormThread()
        {
            InitializeComponent();
        }

        //<Good>
        private void button1_Click(object sender, EventArgs e)
        {
            var threadParameters = new System.Threading.ThreadStart(delegate { WriteTextSafe("This text was set safely."); });
            var thread2 = new System.Threading.Thread(threadParameters);
            thread2.Start();
        }

        public void WriteTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { WriteTextSafe($"{text} (THREAD2)"); };
                textBox1.Invoke(safeWrite);
            }
            else
                textBox1.Text = text;
        }
        //</Good>

        private void textBox1_Enter(object sender, System.EventArgs e)
        {
            //if (!String.IsNullOrEmpty(textBox1.Text))
            //{
            //    textBox1.SelectionStart = 0;
            //    textBox1.SelectionLength = textBox1.Text.Length;
            //}
        }
    }
}
