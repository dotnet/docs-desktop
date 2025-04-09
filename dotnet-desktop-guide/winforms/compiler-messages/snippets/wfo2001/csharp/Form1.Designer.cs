namespace ExampleApp
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
            btnStopWatch = new Button();
            lblStopWatch = new Label();
            SuspendLayout();
            // 
            // btnStopWatch
            // 
            btnStopWatch.Location = new Point(313, 177);
            btnStopWatch.Name = "btnStopWatch";
            btnStopWatch.Size = new Size(75, 23);
            btnStopWatch.TabIndex = 0;
            btnStopWatch.Text = "Start";
            btnStopWatch.UseVisualStyleBackColor = true;
            btnStopWatch.Click += btnStopWatch_Click;
            // 
            // lblStopWatch
            // 
            lblStopWatch.AutoSize = true;
            lblStopWatch.Location = new Point(317, 210);
            lblStopWatch.Name = "lblStopWatch";
            lblStopWatch.Size = new Size(38, 15);
            lblStopWatch.TabIndex = 1;
            lblStopWatch.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStopWatch);
            Controls.Add(btnStopWatch);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStopWatch;
        private Label lblStopWatch;
    }
}
