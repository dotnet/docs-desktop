using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snippets
{
    public partial class DataBindingExample : Form
    {
        public DataBindingExample()
        {
            InitializeComponent();
            button1.CommandParameter = 5;
        }

        private void DataBindingExample_DataContextChanged(object sender, EventArgs e) =>
            companyBindingSource.DataSource = DataContext;

        private void btnCompany1_Click(object sender, EventArgs e)
        {
            DataContext = new Company() { EmployeeCount = 10 };
            
        }

        private void btnCompany2_Click(object sender, EventArgs e)
        {
            DataContext = new Company() { EmployeeCount = 3 };
        }
    }
}
