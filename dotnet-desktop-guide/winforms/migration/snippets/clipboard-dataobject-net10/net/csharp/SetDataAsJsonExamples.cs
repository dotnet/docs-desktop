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

            // Use the type name as the format
            Clipboard.SetDataAsJson(typeof(Person).FullName, person);

            // Retrieve the data and infer the format automatically
            if (Clipboard.TryGetData(out Person retrievedPerson))
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
        }
        // </CustomFormat>
    }
}
