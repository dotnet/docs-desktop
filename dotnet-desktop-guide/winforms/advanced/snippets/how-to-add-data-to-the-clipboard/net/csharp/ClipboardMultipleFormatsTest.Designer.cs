namespace ClipboardExample
{
    partial class ClipboardMultipleFormatsTest
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
            btnTestMultipleFormats = new Button();
            btnClearClipboard = new Button();
            btnCheckClipboard = new Button();
            lblStatus = new Label();
            txtClipboardInfo = new TextBox();
            lblTitle = new Label();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // btnTestMultipleFormats
            // 
            btnTestMultipleFormats.Location = new Point(30, 80);
            btnTestMultipleFormats.Name = "btnTestMultipleFormats";
            btnTestMultipleFormats.Size = new Size(150, 30);
            btnTestMultipleFormats.TabIndex = 0;
            btnTestMultipleFormats.Text = "Test Multiple Formats";
            btnTestMultipleFormats.UseVisualStyleBackColor = true;
            btnTestMultipleFormats.Click += btnTestMultipleFormats_Click;
            // 
            // btnClearClipboard
            // 
            btnClearClipboard.Location = new Point(200, 80);
            btnClearClipboard.Name = "btnClearClipboard";
            btnClearClipboard.Size = new Size(120, 30);
            btnClearClipboard.TabIndex = 1;
            btnClearClipboard.Text = "Clear Clipboard";
            btnClearClipboard.UseVisualStyleBackColor = true;
            btnClearClipboard.Click += btnClearClipboard_Click;
            // 
            // btnCheckClipboard
            // 
            btnCheckClipboard.Location = new Point(340, 80);
            btnCheckClipboard.Name = "btnCheckClipboard";
            btnCheckClipboard.Size = new Size(120, 30);
            btnCheckClipboard.TabIndex = 2;
            btnCheckClipboard.Text = "Check Clipboard";
            btnCheckClipboard.UseVisualStyleBackColor = true;
            btnCheckClipboard.Click += btnCheckClipboard_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(30, 130);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(47, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Ready.";
            // 
            // txtClipboardInfo
            // 
            txtClipboardInfo.Location = new Point(30, 160);
            txtClipboardInfo.Multiline = true;
            txtClipboardInfo.Name = "txtClipboardInfo";
            txtClipboardInfo.ReadOnly = true;
            txtClipboardInfo.ScrollBars = ScrollBars.Vertical;
            txtClipboardInfo.Size = new Size(430, 150);
            txtClipboardInfo.TabIndex = 4;
            txtClipboardInfo.Text = "Click 'Check Clipboard' to see available formats.";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 21);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Clipboard Multiple Formats Test";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(30, 50);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(398, 15);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Test adding multiple data formats to clipboard and retrieving them.";
            // 
            // ClipboardMultipleFormatsTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 341);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(txtClipboardInfo);
            Controls.Add(lblStatus);
            Controls.Add(btnCheckClipboard);
            Controls.Add(btnClearClipboard);
            Controls.Add(btnTestMultipleFormats);
            MaximizeBox = false;
            MinimumSize = new Size(510, 380);
            Name = "ClipboardMultipleFormatsTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clipboard Multiple Formats Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestMultipleFormats;
        private Button btnClearClipboard;
        private Button btnCheckClipboard;
        private Label lblStatus;
        private TextBox txtClipboardInfo;
        private Label lblTitle;
        private Label lblDescription;
    }
}
