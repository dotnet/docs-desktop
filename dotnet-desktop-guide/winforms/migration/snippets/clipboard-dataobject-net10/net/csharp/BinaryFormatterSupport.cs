using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class BinaryFormatterSupport
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

        public class MyCustomType
        {
            public string Data { get; set; }
        }

        // <SecureTypeResolver>
        // Create a security-focused type resolver
        private static Type SecureTypeResolver(TypeName typeName)
        {
            // Explicit allow-list of permitted types—add only what you need
            var allowedTypes = new Dictionary<string, Type>
            {
                ["MyApp.Person"] = typeof(Person),
                ["MyApp.Settings"] = typeof(AppSettings),
                ["System.String"] = typeof(string),
                ["System.Int32"] = typeof(int),
                // Add only the specific types your application requires
            };

            // Only allow explicitly listed types - exact string match required
            if (allowedTypes.TryGetValue(typeName.FullName, out Type allowedType))
            {
                return allowedType;
            }

            // Reject any type not in the allow-list with clear error message
            throw new InvalidOperationException(
                $"Type '{typeName.FullName}' is not permitted for clipboard deserialization");
        }

        // Use the resolver with clipboard operations
        public static void UseSecureTypeResolver()
        {
            if (Clipboard.TryGetData("LegacyData", SecureTypeResolver, out MyCustomType data))
            {
                ProcessLegacyData(data);
            }
        }
        // </SecureTypeResolver>

        private static void ProcessLegacyData(MyCustomType data)
        {
            Console.WriteLine($"Processing legacy data: {data.Data}");
        }
    }
}