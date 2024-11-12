namespace MyExampleProject;

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
        label1 = new Label();
        checkBox1 = new CheckBox();
        button2 = new Button();
        button3 = new Button();
        groupBox1 = new GroupBox();
        checkedListBox1 = new CheckedListBox();
        listBox1 = new ListBox();
        comboBox1 = new ComboBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(21, 52);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(21, 25);
        label1.Name = "label1";
        label1.Size = new Size(48, 15);
        label1.TabIndex = 1;
        label1.Text = "Buttons";
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(21, 139);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(82, 19);
        checkBox1.TabIndex = 2;
        checkBox1.Text = "checkBox1";
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.FlatStyle = FlatStyle.Flat;
        button2.Location = new Point(21, 81);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 3;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.FlatStyle = FlatStyle.Popup;
        button3.Location = new Point(21, 110);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 4;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Location = new Point(189, 25);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(200, 100);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "groupBox1";
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Items.AddRange(new object[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10" });
        checkedListBox1.Location = new Point(412, 39);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new Size(120, 94);
        checkedListBox1.TabIndex = 6;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Items.AddRange(new object[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10" });
        listBox1.Location = new Point(586, 31);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(120, 94);
        listBox1.TabIndex = 7;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10" });
        comboBox1.Location = new Point(21, 164);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 23);
        comboBox1.TabIndex = 8;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(comboBox1);
        Controls.Add(listBox1);
        Controls.Add(checkedListBox1);
        Controls.Add(groupBox1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(checkBox1);
        Controls.Add(label1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Label label1;
    private CheckBox checkBox1;
    private Button button2;
    private Button button3;
    private GroupBox groupBox1;
    private CheckedListBox checkedListBox1;
    private ListBox listBox1;
    private ComboBox comboBox1;
}
