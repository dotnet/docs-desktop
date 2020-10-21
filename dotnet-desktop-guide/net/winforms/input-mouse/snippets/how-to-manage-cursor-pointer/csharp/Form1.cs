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

        private void Form1_Load(object sender, EventArgs e)
        {
            //<SetControlCursor>
            button2.Cursor = System.Windows.Forms.Cursors.Hand;
            //</SetControlCursor>
        }

        //<MoveCursor>
        private void button1_Click(object sender, EventArgs e) =>
            Cursor.Position = PointToScreen(button2.Location);

        private void button2_Click(object sender, EventArgs e) =>
            Cursor.Position = PointToScreen(button1.Location);
        //</MoveCursor>

        //<ShowHideCursor>
        private void button1_MouseEnter(object sender, EventArgs e) =>
            Cursor.Hide();

        private void button1_MouseLeave(object sender, EventArgs e) =>
            Cursor.Show();
        //</ShowHideCursor>
    }
}
