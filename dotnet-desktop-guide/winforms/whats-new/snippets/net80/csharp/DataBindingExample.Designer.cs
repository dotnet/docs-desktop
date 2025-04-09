namespace snippets
{
    partial class DataBindingExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            companyBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            btnCompany1 = new Button();
            btnCompany2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)companyBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.DataBindings.Add(new Binding("Command", companyBindingSource, "IncreaseEmployeeCommand", true));
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(170, 23);
            button1.TabIndex = 0;
            button1.Text = "Increase Employee Count";
            button1.UseVisualStyleBackColor = true;
            // 
            // companyBindingSource
            // 
            companyBindingSource.DataSource = typeof(Company);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 1;
            label1.Text = "Employee Count:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.DataBindings.Add(new Binding("Text", companyBindingSource, "EmployeeCount", true));
            label2.Location = new Point(116, 45);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 2;
            label2.Text = "0";
            // 
            // btnCompany1
            // 
            btnCompany1.Location = new Point(12, 123);
            btnCompany1.Name = "btnCompany1";
            btnCompany1.Size = new Size(207, 23);
            btnCompany1.TabIndex = 3;
            btnCompany1.Text = "Load Company 1 (10 employess)";
            btnCompany1.UseVisualStyleBackColor = true;
            btnCompany1.Click += btnCompany1_Click;
            // 
            // btnCompany2
            // 
            btnCompany2.Location = new Point(12, 152);
            btnCompany2.Name = "btnCompany2";
            btnCompany2.Size = new Size(207, 23);
            btnCompany2.TabIndex = 4;
            btnCompany2.Text = "Load Company 2 (3 employess)";
            btnCompany2.UseVisualStyleBackColor = true;
            btnCompany2.Click += btnCompany2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.DataBindings.Add(new Binding("Image", companyBindingSource, "CompanyImage", true));
            pictureBox1.Location = new Point(12, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // DataBindingExample
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 192);
            Controls.Add(pictureBox1);
            Controls.Add(btnCompany2);
            Controls.Add(btnCompany1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "DataBindingExample";
            Text = "DataBindingExample";
            DataContextChanged += DataBindingExample_DataContextChanged;
            ((System.ComponentModel.ISupportInitialize)companyBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private BindingSource companyBindingSource;
        private Button btnCompany1;
        private Button btnCompany2;
        private PictureBox pictureBox1;
    }
}
