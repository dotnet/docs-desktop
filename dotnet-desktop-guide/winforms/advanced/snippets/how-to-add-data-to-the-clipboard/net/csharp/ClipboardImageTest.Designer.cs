namespace ClipboardOperations
{
    partial class ClipboardImageTest
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnSetImage1 = new Button();
            btnSetImage2 = new Button();
            btnGetFromClipboard = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(20, 150);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(150, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(300, 85);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(150, 100);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // btnSetImage1
            // 
            btnSetImage1.Location = new Point(190, 50);
            btnSetImage1.Name = "btnSetImage1";
            btnSetImage1.Size = new Size(90, 30);
            btnSetImage1.TabIndex = 3;
            btnSetImage1.Text = "Set Image 1";
            btnSetImage1.UseVisualStyleBackColor = true;
            btnSetImage1.Click += btnSetImage1_Click;
            // 
            // btnSetImage2
            // 
            btnSetImage2.Location = new Point(190, 180);
            btnSetImage2.Name = "btnSetImage2";
            btnSetImage2.Size = new Size(90, 30);
            btnSetImage2.TabIndex = 4;
            btnSetImage2.Text = "Set Image 2";
            btnSetImage2.UseVisualStyleBackColor = true;
            btnSetImage2.Click += btnSetImage2_Click;
            // 
            // btnGetFromClipboard
            // 
            btnGetFromClipboard.Location = new Point(470, 115);
            btnGetFromClipboard.Name = "btnGetFromClipboard";
            btnGetFromClipboard.Size = new Size(120, 30);
            btnGetFromClipboard.TabIndex = 5;
            btnGetFromClipboard.Text = "Get from Clipboard";
            btnGetFromClipboard.UseVisualStyleBackColor = true;
            btnGetFromClipboard.Click += btnGetFromClipboard_Click;
            // 
            // ClipboardImageTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 280);
            Controls.Add(btnGetFromClipboard);
            Controls.Add(btnSetImage2);
            Controls.Add(btnSetImage1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "ClipboardImageTest";
            Text = "Clipboard Image Test";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button btnSetImage1;
        private Button btnSetImage2;
        private Button btnGetFromClipboard;
    }
}
