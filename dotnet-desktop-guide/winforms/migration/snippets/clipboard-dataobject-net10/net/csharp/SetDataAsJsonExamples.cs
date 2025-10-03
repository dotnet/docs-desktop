using System;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class SetDataAsJsonExamples
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class AppSettings
        {
            public string Theme { get; set; }
            public bool AutoSave { get; set; }
        }

        // <AutomaticFormatInference>
        public static void AutomaticFormatInferenceExample()
        {
            var person = new Person { Name = "Alice", Age = 25 };

            // The format is automatically inferred from the type name
            Clipboard.SetDataAsJson("Person", person);  // Uses "Person" as the format

            // Retrieve the data later
            if (Clipboard.TryGetData("Person", out Person retrievedPerson))
            {
                Console.WriteLine($"Retrieved: {retrievedPerson.Name}");
            }
        }
        // </AutomaticFormatInference>

        // <CustomFormat>
        public static void CustomFormatExample()
        {
            var settings = new AppSettings { Theme = "Dark", AutoSave = true };

            // Use a custom format for better organization
            Clipboard.SetDataAsJson("MyApp.Settings", settings);

            // Store the same data in multiple formats
            Clipboard.SetDataAsJson("Config.V1", settings);
            Clipboard.SetDataAsJson("AppConfig", settings);
        }
        // </CustomFormat>
    }
}