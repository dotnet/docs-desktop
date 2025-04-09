using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        //<MoveCursor>
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        private void button1_Click(object sender, EventArgs e)
        {
            Point position = PointToScreen(checkBox1.Location) + new Size(checkBox1.Width / 2, checkBox1.Height / 2);
            SetCursorPos(position.X, position.Y);
        }
        //</MoveCursor>

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
