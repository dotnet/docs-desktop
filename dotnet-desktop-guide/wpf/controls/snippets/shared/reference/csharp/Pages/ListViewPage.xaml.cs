using System.Collections.Generic;
using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class ListViewPage : Page
    {
        public ListViewPage()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            var sampleData = new List<FileData>
            {
                new FileData { Name = "Document.pdf", Type = "PDF", Size = "1.2 MB", Modified = "Today" },
                new FileData { Name = "Image.jpg", Type = "JPEG", Size = "856 KB", Modified = "Yesterday" },
                new FileData { Name = "Spreadsheet.xlsx", Type = "Excel", Size = "234 KB", Modified = "2 days ago" },
                new FileData { Name = "Presentation.pptx", Type = "PowerPoint", Size = "3.4 MB", Modified = "1 week ago" },
                new FileData { Name = "Archive.zip", Type = "ZIP", Size = "15.7 MB", Modified = "2 weeks ago" }
            };
            
            SampleListView.ItemsSource = sampleData;
        }
    }

    public class FileData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Modified { get; set; }
    }
}
