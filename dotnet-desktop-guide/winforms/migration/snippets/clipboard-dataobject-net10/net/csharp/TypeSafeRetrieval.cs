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
            {
                ProcessTextData(textData);
            }

            // Retrieve an integer using a custom format
            if (Clipboard.TryGetData("NumberData", out int numberData))
            {
                ProcessNumber(numberData);
            }

            // Retrieve Unicode text using a standard format
            if (Clipboard.TryGetData(DataFormats.UnicodeText, out string unicodeText))
            {
                ProcessUnicodeText(unicodeText);
            }

            // Retrieve raw text data with OLE conversion control
            if (Clipboard.TryGetData(DataFormats.Text, out string rawText))
            {
                ProcessRawText(rawText);
            }

            // Retrieve file drops using a standard format
            if (Clipboard.TryGetData(DataFormats.FileDrop, out string[] files))
            {
                ProcessFiles(files);
            }
        }
        // </BasicTypeSafeRetrieval>

        // <CustomJsonTypes>
        public static void CustomJsonTypesExamples()
        {
            // Retrieve a custom type stored with SetDataAsJson<T>()
            if (Clipboard.TryGetData("Person", out Person person))
            {
                ProcessPerson(person);
            }

            // Retrieve application-specific data formats
            if (Clipboard.TryGetData("MyApp.Settings", out AppSettings settings))
            {
                ApplySettings(settings);
            }

            // Retrieve complex custom objects
            if (Clipboard.TryGetData("DocumentData", out DocumentInfo doc))
            {
                LoadDocument(doc);
            }
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

        private static void ProcessTextData(string text) => Console.WriteLine($"Text: {text}");
        private static void ProcessNumber(int number) => Console.WriteLine($"Number: {number}");
        private static void ProcessUnicodeText(string text) => Console.WriteLine($"Unicode: {text}");
        private static void ProcessRawText(string text) => Console.WriteLine($"Raw: {text}");
        private static void ProcessFiles(string[] files) => Console.WriteLine($"Files: {string.Join(", ", files)}");
        private static void ProcessPerson(Person person) => Console.WriteLine($"Person: {person.Name}");
        private static void ApplySettings(AppSettings settings) => Console.WriteLine($"Settings: {settings.Theme}");
        private static void LoadDocument(DocumentInfo doc) => Console.WriteLine($"Document: {doc.Title}");
    }
}