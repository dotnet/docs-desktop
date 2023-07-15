namespace UserControlProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ctlFirstName = new ClearableTextBox();
            ctlLastName = new ClearableTextBox();
            lblFullName = new Label();
            SuspendLayout();
            // 
            // ctlFirstName
            // 
            ctlFirstName.Location = new Point(12, 12);
            ctlFirstName.MinimumSize = new Size(84, 53);
            ctlFirstName.Name = "ctlFirstName";
            ctlFirstName.Size = new Size(191, 53);
            ctlFirstName.TabIndex = 0;
            ctlFirstName.Title = "First Name";
            ctlFirstName.TextChanged += ctlFirstName_TextChanged;
            // 
            // ctlLastName
            // 
            ctlLastName.Location = new Point(12, 71);
            ctlLastName.MinimumSize = new Size(84, 53);
            ctlLastName.Name = "ctlLastName";
            ctlLastName.Size = new Size(191, 53);
            ctlLastName.TabIndex = 1;
            ctlLastName.Title = "Last Name";
            ctlLastName.TextChanged += ctlLastName_TextChanged;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(12, 252);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(38, 15);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 276);
            Controls.Add(lblFullName);
            Controls.Add(ctlLastName);
            Controls.Add(ctlFirstName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ClearableTextBox ctlFirstName;
        private ClearableTextBox ctlLastName;
        private Label lblFullName;
    }
}
