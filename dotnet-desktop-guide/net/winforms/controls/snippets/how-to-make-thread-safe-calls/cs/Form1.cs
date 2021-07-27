using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //var thread2 = new Thread(new ThreadStart(WriteTextUnsafe));
            //thread2.Start();
            await Task.Factory.StartNew(WriteTextUnsafe, new CancellationToken(false), TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            await Task.Delay(6000);
            Action de = delegate { WriteTextSafe(); };
            textBox1.Invoke(de);
        }

        private async void WriteTextUnsafe()
        {
            textBox1.Text = "This text was set unsafely.";
            await Task.Delay(4000);
            textBox1.Text = "This text was set unsafely twice!";
        }

        private void WriteTextSafe()
        {
            textBox1.Text = "This text was set safely.";
        }
    }
}
