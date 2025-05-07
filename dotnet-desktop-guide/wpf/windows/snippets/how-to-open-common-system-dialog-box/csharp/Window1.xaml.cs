using System.Windows;

namespace WindowsOverview
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //<YesNoCancel>
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            //<MessageBoxShow>
            result = MessageBox.Show(messageBoxText, caption, button, icon);
            //</YesNoCancel>

            switch (result)
            {
                case MessageBoxResult.Cancel:
                    // User pressed Cancel
                    break;
                case MessageBoxResult.Yes:
                    // User pressed Yes
                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    break;
            }
            //</MessageBoxShow>
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //<SaveFile>
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;
            }
            //</SaveFile>
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            //<OpenFile>
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }
            //</OpenFile>
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            //<OpenFolder>
            // Configure open folder dialog box
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            // Show open folder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if (result == true)
            {
                // Get the selected folder
                string fullPathToFolder = dialog.FolderName;
                string folderNameOnly = dialog.SafeFolderName;
            }
            //</OpenFolder>
        }

        private void OpenFolderMultiple_Click(object sender, RoutedEventArgs e)
        {
            //<OpenFolderMultiselect>
            // Configure open folder dialog box
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = true;
            dialog.Title = "Select one or more folders";

            // Show open folder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if (result == true)
            {
                // Get multiple folder names
                for (int index = 0; index < dialog.FolderNames.Length; index++)
                {
                    // Get the selected folder
                    string fullPathToFolder = dialog.FolderNames[index];
                    string folderNameOnly = dialog.SafeFolderNames[index];
                }
            }
            //</OpenFolderMultiselect>
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            //<Print>
            // Configure printer dialog box
            var dialog = new System.Windows.Controls.PrintDialog();
            dialog.PageRangeSelection = System.Windows.Controls.PageRangeSelection.AllPages;
            dialog.UserPageRangeEnabled = true;

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Document was printed
            }
            //</Print>
        }
    }
}
