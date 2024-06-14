using System.IO.IsolatedStorage;
using System.IO;
using System.Windows;

namespace SDKSamples
{
    public partial class App : Application
    {
        string _filename = "App.data";

        public App()
        {
            // Initialize application-scope property
            Properties["NumberOfAppSessions"] = "0";
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            // Restore application-scope property from isolated storage
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
            try
            {
                if (storage.FileExists(_filename))
                {
                    using (IsolatedStorageFileStream stream = storage.OpenFile(_filename, FileMode.Open, FileAccess.Read))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Restore each application-scope property individually
                        while (!reader.EndOfStream)
                        {
                            string[] keyValue = reader.ReadLine().Split(new char[] { ',' });
                            Properties[keyValue[0]] = keyValue[1];
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                // Path the file didn't exist
            }
            catch (IsolatedStorageException ex)
            {
                // Storage was removed or doesn't exist
                // -or-
                // If using .NET 6+ the inner exception contains the real cause
            }
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            // Increase the amount of times the app was opened
            Properties["NumberOfAppSessions"] = int.Parse((string)Properties["NumberOfAppSessions"]) + 1;

            // Persist application-scope property to isolated storage
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
            using (IsolatedStorageFileStream stream = storage.OpenFile(_filename, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Persist each application-scope property individually
                foreach (string key in Properties.Keys)
                    writer.WriteLine("{0},{1}", key, Properties[key]);
            }
        }
    }

}
