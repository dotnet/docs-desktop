using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs
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

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Mouse entered!";
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            label1.Text = "Doubleclicked!";
        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            label1.Text = "preview key";
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "button key";

        }

        private void a(object sender, KeyPressEventArgs e)
        {
            label1.Text = "button key";

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        //<HandlerViaCode>
        private void button1_Click(object sender, EventArgs e)
        {
            // Create and add the button
            Button myNewButton = new()
            {
                Location = new Point(10, 10),
                Size = new Size(120, 25),
                Text = "Do work"
            };

            // Handle the Click event for the new button
            myNewButton.Click += MyNewButton_Click;
            this.Controls.Add(myNewButton);

            // Remove this button handler so the user cannot do this twice
            //<RemoveHandler>
            button1.Click -= button1_Click;
            //</RemoveHandler>
        }

        private void MyNewButton_Click(object sender, EventArgs e)
        {
            
        }
        //</HandlerViaCode>
    }
}
