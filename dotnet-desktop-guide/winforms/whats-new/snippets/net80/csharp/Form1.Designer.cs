namespace snippets;

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
        button1 = new Button();
        checkBox1 = new CheckBox();
        dateTimePicker1 = new DateTimePicker();
        richTextBox1 = new RichTextBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(12, 12);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(12, 41);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(83, 19);
        checkBox1.TabIndex = 1;
        checkBox1.Text = "checkBox1";
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new Point(12, 66);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.ShowCheckBox = true;
        dateTimePicker1.Size = new Size(208, 23);
        dateTimePicker1.TabIndex = 2;
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new Point(226, 34);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(167, 55);
        richTextBox1.TabIndex = 3;
        richTextBox1.Text = "";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(226, 16);
        label1.Name = "label1";
        label1.Size = new Size(106, 15);
        label1.TabIndex = 4;
        label1.Text = "RichTextBox below";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label2.Location = new Point(12, 92);
        label2.Name = "label2";
        label2.Size = new Size(75, 16);
        label2.TabIndex = 5;
        label2.Text = "Font preview";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        label3.Location = new Point(12, 107);
        label3.Name = "label3";
        label3.Size = new Size(75, 15);
        label3.TabIndex = 6;
        label3.Text = "Font preview";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 122);
        label4.Name = "label4";
        label4.Size = new Size(75, 15);
        label4.TabIndex = 7;
        label4.Text = "Font preview";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(403, 161);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(richTextBox1);
        Controls.Add(dateTimePicker1);
        Controls.Add(checkBox1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private CheckBox checkBox1;
    private DateTimePicker dateTimePicker1;
    private RichTextBox richTextBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
}
