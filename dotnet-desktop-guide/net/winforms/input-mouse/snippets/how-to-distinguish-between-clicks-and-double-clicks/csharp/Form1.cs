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
    //<RollbackForm>
    public partial class Form1 : Form
    {
        private FormBorderStyle _initialStyle;
        private bool _isDoubleClicking;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _initialStyle = this.FormBorderStyle;

            var button1 = new DoubleClickButton();
            button1.Location = new Point(50, 50);
            button1.Size = new Size(200, 23);
            button1.Text = "Click or Double Click";
            button1.Click += Button1_Click;
            button1.DoubleClick += Button1_DoubleClick;

            Controls.Add(button1);
        }

        private void Button1_DoubleClick(object sender, EventArgs e)
        {
            // This flag prevents the click handler logic from running
            // A double click raises the click event twice.
            _isDoubleClicking = true;
            FormBorderStyle = _initialStyle;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (_isDoubleClicking)
                _isDoubleClicking = false;
            else
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
    //</RollbackForm>
}
