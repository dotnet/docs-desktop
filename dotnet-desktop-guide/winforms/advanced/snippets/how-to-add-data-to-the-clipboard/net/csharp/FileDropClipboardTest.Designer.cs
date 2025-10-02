namespace ClipboardExample
{
    partial class FileDropClipboardTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The main text box control for displaying clipboard file information.
        /// </summary>
        private TextBox textBox;

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
            this.textBox = new TextBox();
            this.SuspendLayout();
            
            // 
            // textBox
            // 
            this.textBox.Location = new Point(12, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = ScrollBars.Vertical;
            this.textBox.Size = new Size(560, 437);
            this.textBox.TabIndex = 0;
            this.textBox.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
            
            // 
            // FileDropClipboardTest
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 461);
            this.Controls.Add(this.textBox);
            this.Name = "FileDropClipboardTest";
            this.Text = "File Drop Clipboard Test";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
