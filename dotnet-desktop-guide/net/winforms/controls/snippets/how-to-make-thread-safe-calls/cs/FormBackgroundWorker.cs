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
    public partial class FormBackgroundWorker : Form
    {
        public FormBackgroundWorker()
        {
            InitializeComponent();
        }

        //<Background>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            int max = 10;

            while (counter <= max)
            {
                backgroundWorker1.ReportProgress(0, counter.ToString());
                System.Threading.Thread.Sleep(1000);
                counter++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) =>
            textBox1.Text = (string)e.UserState;
        //</Background>
    }
}
