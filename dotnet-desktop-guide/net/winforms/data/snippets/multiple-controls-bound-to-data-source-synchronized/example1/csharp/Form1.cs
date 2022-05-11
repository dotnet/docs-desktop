namespace binding_control_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //<bind_controls_using_BindingSource>
            // Add the table to DataSet
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            // Set the data source to the DataSet.
            bindingSource1.DataSource = set1;

            //Set the DataMember to the Menu table.
            bindingSource1.DataMember = "Menu";

            // Add the control data bindings.
            dataGridView1.DataSource = bindingSource1;
            textBox1.DataBindings.Add("Text", bindingSource1,
                "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", bindingSource1,
                "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            bindingSource1.BindingComplete +=
                new BindingCompleteEventHandler(bindingSource1_BindingComplete);

            //</bind_controls_using_BindingSource>                  
        }
        

    }
}