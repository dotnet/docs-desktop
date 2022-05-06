namespace Sample_print_win_form1
{
    public partial class Form1 : Form
    {
        Bitmap memoryImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
            
            printDocument1.Print();
            
        }
        private void PrintDocument1_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e) =>
               e.Graphics.DrawImage(memoryImage, 0, 0);
        
    }
}