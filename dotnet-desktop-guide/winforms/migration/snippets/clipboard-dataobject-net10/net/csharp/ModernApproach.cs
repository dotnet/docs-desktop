using System;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class ModernApproach
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        // <ModernTryGetData>
        public static void ModernTryGetDataExample()
        {
            // Use this - type-safe approach with TryGetData<T>()
            if (Clipboard.TryGetData("MyApp.Person", out Person person))
            {
                ProcessPerson(person);  // person is guaranteed to be the correct type
            }
            else
            {
                // Handle the case where data isn't available or is the wrong type
                ShowError("Unable to retrieve person data from clipboard");
            }
        }
        // </ModernTryGetData>

        private static void ProcessPerson(Person person)
        {
            Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}");
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}