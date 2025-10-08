using System;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class TypeResolver
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

        public class MyType
        {
            public string Data { get; set; }
        }

        // <TypeResolverExample>
        public static void TypeResolverExample()
        {
            // Create a type resolver that maps old type names to current types
            Func<TypeName, Type> resolver = typeName =>
            {
                // Only allow specific, known, safe types
                return typeName.FullName switch
                {
                    "MyApp.Person" => typeof(Person),
                    "MyApp.Settings" => typeof(AppSettings),
                    "System.String" => typeof(string),
                    "System.Int32" => typeof(int),
                    _ => throw new InvalidOperationException($"Type not allowed: {typeName.FullName}")
                };
            };

            // Use the resolver with legacy binary data
            if (Clipboard.TryGetData("LegacyFormat", resolver, out Person person))
            {
                Console.WriteLine($"Processing person: {person.Name}, Age: {person.Age}");
            }

            // Use a resolver with conversion control
            if (Clipboard.TryGetData("OldCustomData", resolver, out MyType data))
            {
                Console.WriteLine($"Processing custom data: {data.Data}");
            }
        }
        // </TypeResolverExample>
    }
}
