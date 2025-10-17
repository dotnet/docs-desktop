using System;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class TypeSafeRetrieval
    {
        // <BasicTypeSafeRetrieval>
        public static void BasicTypeSafeRetrievalExamples()
        {
            // Retrieve text data using a standard format
            if (Clipboard.TryGetData(DataFormats.Text, out string textData))
                Console.WriteLine($"Text: {textData}");

            // Retrieve an integer using a custom format
            if (Clipboard.TryGetData("NumberData", out int numberData))
                Console.WriteLine($"Number: {numberData}");

            // Retrieve Unicode text using a standard format
            if (Clipboard.TryGetData(DataFormats.UnicodeText, out string unicodeText))
                Console.WriteLine($"Unicode: {unicodeText}");

            // Retrieve raw text data with OLE conversion control
            if (Clipboard.TryGetData(DataFormats.Text, out string rawText))
                Console.WriteLine($"Raw: {rawText}");

            // Retrieve file drops using a standard format
            if (Clipboard.TryGetData(DataFormats.FileDrop, out string[] files))
                Console.WriteLine($"Files: {string.Join(", ", files)}");
        }
        // </BasicTypeSafeRetrieval>

        // <CustomJsonTypes>
        public static void CustomJsonTypesExamples()
        {
            // Retrieve a custom type stored with SetDataAsJson<T>()
            if (Clipboard.TryGetData("Person", out Person person))
                Console.WriteLine($"Person: {person.Name}");

            // Retrieve application-specific data formats
            if (Clipboard.TryGetData("MyApp.Settings", out AppSettings settings))
                Console.WriteLine($"Settings: {settings.Theme}");

            // Retrieve complex custom objects
            if (Clipboard.TryGetData("DocumentData", out DocumentInfo doc))
                Console.WriteLine($"Document: {doc.Title}");
        }
        // </CustomJsonTypes>

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

        public class DocumentInfo
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime Created { get; set; }
        }
    }
}
