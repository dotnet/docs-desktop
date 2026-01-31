using System.Collections.Generic;
using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class DataGridPage : Page
    {
        public DataGridPage()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            var sampleData = new List<PersonData>
            {
                new PersonData { Id = 1, Name = "John Doe", Email = "john@example.com", IsActive = true },
                new PersonData { Id = 2, Name = "Jane Smith", Email = "jane@example.com", IsActive = false },
                new PersonData { Id = 3, Name = "Bob Johnson", Email = "bob@example.com", IsActive = true },
                new PersonData { Id = 4, Name = "Alice Brown", Email = "alice@example.com", IsActive = true }
            };
            
            SampleDataGrid.ItemsSource = sampleData;
        }
    }

    public class PersonData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
