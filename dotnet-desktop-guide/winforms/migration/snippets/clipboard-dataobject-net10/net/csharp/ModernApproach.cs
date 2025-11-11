using System;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var data = new Person { Name = "Alice", Age = 28 };
            Clipboard.SetDataAsJson("MyAppData", data);

            // Use this - type-safe approach with TryGetData<T>()
            if (Clipboard.TryGetData("MyApp.Person", out Person person))
            {
                // person is guaranteed to be the correct type
                Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}");
            }
            else
            {
                // Handle the case where data isn't available or is the wrong type
                MessageBox.Show("Unable to retrieve person data from clipboard");
            }
        }
        // </ModernTryGetData>
    }
}
