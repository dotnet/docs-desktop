using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class PrimitiveTypesExamples
    {
        // <PrimitiveTypesExample>
        public static void PrimitiveTypesExample()
        {
            // Numeric types
            Clipboard.SetData("MyInt", 42);
            Clipboard.SetData("MyDouble", 3.14159);
            Clipboard.SetData("MyDecimal", 123.45m);

            // Text and character types
            Clipboard.SetData("MyString", "Hello World");
            Clipboard.SetData("MyChar", 'A');

            // Boolean and date/time types
            Clipboard.SetData("MyBool", true);
            Clipboard.SetData("MyDateTime", DateTime.Now);
            Clipboard.SetData("MyTimeSpan", TimeSpan.FromMinutes(30));

            // Later retrieval with type safety
            if (Clipboard.TryGetData("MyTimeSpan", out TimeSpan value))
            {
                Console.WriteLine($"Clipboard value is: {value}");
            }
        }
        // </PrimitiveTypesExample>

        // <CollectionsExample>
        public static void CollectionsExample()
        {
            // Arrays of primitive types
            int[] numbers = { 1, 2, 3, 4, 5 };
            Clipboard.SetData("NumberArray", numbers);

            double[] coordinates = { 1.0, 2.5, 3.7 };
            Clipboard.SetData("Coordinates", coordinates);

            // Generic lists
            List<int> intList = new List<int> { 10, 20, 30 };
            Clipboard.SetData("IntList", intList);

            // Retrieval maintains type safety
            if (Clipboard.TryGetData("NumberArray", out int[] retrievedNumbers))
            {
                Console.WriteLine($"Numbers: {string.Join(", ", retrievedNumbers)}");
            }
        }
        // </CollectionsExample>
    }
}
