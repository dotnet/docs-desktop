namespace ClipboardExample
{
    partial class ClipboardTextTest
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
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnSetText = new System.Windows.Forms.Button();
            this.lblUnicodeText = new System.Windows.Forms.Label();
            this.txtUnicodeText = new System.Windows.Forms.TextBox();
            this.btnSetUnicodeText = new System.Windows.Forms.Button();
            this.lblRtf = new System.Windows.Forms.Label();
            this.txtRtf = new System.Windows.Forms.TextBox();
            this.btnSetRtf = new System.Windows.Forms.Button();
            this.lblHtml = new System.Windows.Forms.Label();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btnSetHtml = new System.Windows.Forms.Button();
            this.lblCommaSeparatedValue = new System.Windows.Forms.Label();
            this.txtCommaSeparatedValue = new System.Windows.Forms.TextBox();
            this.btnSetCommaSeparatedValue = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnGetClipboard = new System.Windows.Forms.Button();
            this.btnClearClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 15);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(31, 15);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(12, 33);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(300, 23);
            this.txtText.TabIndex = 1;
            this.txtText.Text = "Plain text example";
            // 
            // btnSetText
            // 
            this.btnSetText.Location = new System.Drawing.Point(318, 33);
            this.btnSetText.Name = "btnSetText";
            this.btnSetText.Size = new System.Drawing.Size(75, 23);
            this.btnSetText.TabIndex = 2;
            this.btnSetText.Text = "Set Text";
            this.btnSetText.UseVisualStyleBackColor = true;
            this.btnSetText.Click += new System.EventHandler(this.btnSetText_Click);
            // 
            // lblUnicodeText
            // 
            this.lblUnicodeText.AutoSize = true;
            this.lblUnicodeText.Location = new System.Drawing.Point(12, 65);
            this.lblUnicodeText.Name = "lblUnicodeText";
            this.lblUnicodeText.Size = new System.Drawing.Size(79, 15);
            this.lblUnicodeText.TabIndex = 3;
            this.lblUnicodeText.Text = "Unicode Text:";
            // 
            // txtUnicodeText
            // 
            this.txtUnicodeText.Location = new System.Drawing.Point(12, 83);
            this.txtUnicodeText.Name = "txtUnicodeText";
            this.txtUnicodeText.Size = new System.Drawing.Size(300, 23);
            this.txtUnicodeText.TabIndex = 4;
            this.txtUnicodeText.Text = "Unicode text example: ñ, é, ü, 中文";
            // 
            // btnSetUnicodeText
            // 
            this.btnSetUnicodeText.Location = new System.Drawing.Point(318, 83);
            this.btnSetUnicodeText.Name = "btnSetUnicodeText";
            this.btnSetUnicodeText.Size = new System.Drawing.Size(75, 23);
            this.btnSetUnicodeText.TabIndex = 5;
            this.btnSetUnicodeText.Text = "Set Unicode";
            this.btnSetUnicodeText.UseVisualStyleBackColor = true;
            this.btnSetUnicodeText.Click += new System.EventHandler(this.btnSetUnicodeText_Click);
            // 
            // lblRtf
            // 
            this.lblRtf.AutoSize = true;
            this.lblRtf.Location = new System.Drawing.Point(12, 115);
            this.lblRtf.Name = "lblRtf";
            this.lblRtf.Size = new System.Drawing.Size(29, 15);
            this.lblRtf.TabIndex = 6;
            this.lblRtf.Text = "RTF:";
            // 
            // txtRtf
            // 
            this.txtRtf.Location = new System.Drawing.Point(12, 133);
            this.txtRtf.Name = "txtRtf";
            this.txtRtf.Size = new System.Drawing.Size(300, 23);
            this.txtRtf.TabIndex = 7;
            this.txtRtf.Text = "{\\rtf1\\ansi\\deff0 {\\fonttbl {\\f0 Times New Roman;}} \\f0\\fs24 Hello \\b World\\b0 !}";
            // 
            // btnSetRtf
            // 
            this.btnSetRtf.Location = new System.Drawing.Point(318, 133);
            this.btnSetRtf.Name = "btnSetRtf";
            this.btnSetRtf.Size = new System.Drawing.Size(75, 23);
            this.btnSetRtf.TabIndex = 8;
            this.btnSetRtf.Text = "Set RTF";
            this.btnSetRtf.UseVisualStyleBackColor = true;
            this.btnSetRtf.Click += new System.EventHandler(this.btnSetRtf_Click);
            // 
            // lblHtml
            // 
            this.lblHtml.AutoSize = true;
            this.lblHtml.Location = new System.Drawing.Point(12, 165);
            this.lblHtml.Name = "lblHtml";
            this.lblHtml.Size = new System.Drawing.Size(39, 15);
            this.lblHtml.TabIndex = 9;
            this.lblHtml.Text = "HTML:";
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(12, 183);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(300, 23);
            this.txtHtml.TabIndex = 10;
            this.txtHtml.Text = "<html><body><b>Hello</b> <i>World</i>!</body></html>";
            // 
            // btnSetHtml
            // 
            this.btnSetHtml.Location = new System.Drawing.Point(318, 183);
            this.btnSetHtml.Name = "btnSetHtml";
            this.btnSetHtml.Size = new System.Drawing.Size(75, 23);
            this.btnSetHtml.TabIndex = 11;
            this.btnSetHtml.Text = "Set HTML";
            this.btnSetHtml.UseVisualStyleBackColor = true;
            this.btnSetHtml.Click += new System.EventHandler(this.btnSetHtml_Click);
            // 
            // lblCommaSeparatedValue
            // 
            this.lblCommaSeparatedValue.AutoSize = true;
            this.lblCommaSeparatedValue.Location = new System.Drawing.Point(12, 215);
            this.lblCommaSeparatedValue.Name = "lblCommaSeparatedValue";
            this.lblCommaSeparatedValue.Size = new System.Drawing.Size(32, 15);
            this.lblCommaSeparatedValue.TabIndex = 12;
            this.lblCommaSeparatedValue.Text = "CSV:";
            // 
            // txtCommaSeparatedValue
            // 
            this.txtCommaSeparatedValue.Location = new System.Drawing.Point(12, 233);
            this.txtCommaSeparatedValue.Name = "txtCommaSeparatedValue";
            this.txtCommaSeparatedValue.Size = new System.Drawing.Size(300, 23);
            this.txtCommaSeparatedValue.TabIndex = 13;
            this.txtCommaSeparatedValue.Text = "Name,Age,City\\r\\nJohn,25,\"New York\"\\r\\nJane,30,London";
            // 
            // btnSetCommaSeparatedValue
            // 
            this.btnSetCommaSeparatedValue.Location = new System.Drawing.Point(318, 233);
            this.btnSetCommaSeparatedValue.Name = "btnSetCommaSeparatedValue";
            this.btnSetCommaSeparatedValue.Size = new System.Drawing.Size(75, 23);
            this.btnSetCommaSeparatedValue.TabIndex = 14;
            this.btnSetCommaSeparatedValue.Text = "Set CSV";
            this.btnSetCommaSeparatedValue.UseVisualStyleBackColor = true;
            this.btnSetCommaSeparatedValue.Click += new System.EventHandler(this.btnSetCommaSeparatedValue_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 275);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(101, 15);
            this.lblOutput.TabIndex = 15;
            this.lblOutput.Text = "Clipboard Output:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 293);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(381, 120);
            this.txtOutput.TabIndex = 16;
            this.txtOutput.Text = "";
            // 
            // btnGetClipboard
            // 
            this.btnGetClipboard.Location = new System.Drawing.Point(12, 419);
            this.btnGetClipboard.Name = "btnGetClipboard";
            this.btnGetClipboard.Size = new System.Drawing.Size(100, 30);
            this.btnGetClipboard.TabIndex = 17;
            this.btnGetClipboard.Text = "Get Clipboard";
            this.btnGetClipboard.UseVisualStyleBackColor = true;
            this.btnGetClipboard.Click += new System.EventHandler(this.btnGetClipboard_Click);
            // 
            // btnClearClipboard
            // 
            this.btnClearClipboard.Location = new System.Drawing.Point(118, 419);
            this.btnClearClipboard.Name = "btnClearClipboard";
            this.btnClearClipboard.Size = new System.Drawing.Size(100, 30);
            this.btnClearClipboard.TabIndex = 18;
            this.btnClearClipboard.Text = "Clear Clipboard";
            this.btnClearClipboard.UseVisualStyleBackColor = true;
            this.btnClearClipboard.Click += new System.EventHandler(this.btnClearClipboard_Click);
            // 
            // ClipboardTextTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 461);
            this.Controls.Add(this.btnClearClipboard);
            this.Controls.Add(this.btnGetClipboard);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnSetCommaSeparatedValue);
            this.Controls.Add(this.txtCommaSeparatedValue);
            this.Controls.Add(this.lblCommaSeparatedValue);
            this.Controls.Add(this.btnSetHtml);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.lblHtml);
            this.Controls.Add(this.btnSetRtf);
            this.Controls.Add(this.txtRtf);
            this.Controls.Add(this.lblRtf);
            this.Controls.Add(this.btnSetUnicodeText);
            this.Controls.Add(this.txtUnicodeText);
            this.Controls.Add(this.lblUnicodeText);
            this.Controls.Add(this.btnSetText);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClipboardTextTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clipboard Text Format Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnSetText;
        private System.Windows.Forms.Label lblUnicodeText;
        private System.Windows.Forms.TextBox txtUnicodeText;
        private System.Windows.Forms.Button btnSetUnicodeText;
        private System.Windows.Forms.Label lblRtf;
        private System.Windows.Forms.TextBox txtRtf;
        private System.Windows.Forms.Button btnSetRtf;
        private System.Windows.Forms.Label lblHtml;
        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.Button btnSetHtml;
        private System.Windows.Forms.Label lblCommaSeparatedValue;
        private System.Windows.Forms.TextBox txtCommaSeparatedValue;
        private System.Windows.Forms.Button btnSetCommaSeparatedValue;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnGetClipboard;
        private System.Windows.Forms.Button btnClearClipboard;
    }
}
