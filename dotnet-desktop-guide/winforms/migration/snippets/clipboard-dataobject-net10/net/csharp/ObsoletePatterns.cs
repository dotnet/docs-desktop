using System;
using System.Windows.Forms;

namespace ClipboardExamples
{
    // Examples of obsolete patterns that no longer work in .NET 10
    public class ObsoletePatterns
    {
        // <ObsoleteCustomType>
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void BrokenCustomTypeExample()
        {
            // This worked in .NET 8 and earlier but silently fails starting with .NET 9
            Person person = new Person { Name = "John", Age = 30 };
            Clipboard.SetData("MyApp.Person", person);  // No data is stored

            // Later attempts to retrieve the data return null
            object data = Clipboard.GetData("MyApp.Person");
        }
        // </ObsoleteCustomType>

        // <ObsoleteGetData>
        public static void ObsoleteGetDataExample()
        {
            // Don't use - GetData() is obsolete in .NET 10
            object data = Clipboard.GetData("MyApp.Person");  // Obsolete method

            // Always returns null on a custom object type
            if (data != null)
            {
                Person person = (Person)data;  // Unsafe casting
                ProcessPerson(person);
            }
        }
        // </ObsoleteGetData>

        private static void ProcessPerson(Person person)
        {
            Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}");
        }
    }
}
