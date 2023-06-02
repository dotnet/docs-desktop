namespace CustomControlProject
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
            customControl11 = new CustomControl1();
            SuspendLayout();
            // 
            // customControl11
            // 
            customControl11.Location = new Point(12, 12);
            customControl11.Name = "customControl11";
            customControl11.Size = new Size(228, 117);
            customControl11.TabIndex = 4;
            customControl11.Text = "customControl11";
            customControl11.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 141);
            Controls.Add(customControl11);
            Name = "Form1";
            Text = "Custom Control";
            ResumeLayout(false);
        }

        #endregion
        private CustomControl1 customControl11;
    }
}
