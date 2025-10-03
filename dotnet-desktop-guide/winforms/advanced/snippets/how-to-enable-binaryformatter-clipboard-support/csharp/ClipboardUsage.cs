using System;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class ClipboardUsageExample
    {
        public class MyCustomType
        {
            public string Data { get; set; }
        }

        // <ClipboardUsage>
        // Use the resolver with clipboard operations
        private static Type SecureTypeResolver(TypeName typeName)
        {
            // Implementation from SecureTypeResolver example
            // ... (allow-list implementation here)
            throw new InvalidOperationException($"Type '{typeName.FullName}' is not permitted");
        }

        public static void UseSecureTypeResolver()
        {
            // Retrieve legacy data using the secure type resolver
            if (Clipboard.TryGetData("LegacyData", SecureTypeResolver, out MyCustomType data))
            {
                ProcessLegacyData(data);
            }
            else
            {
                Console.WriteLine("No compatible data found on clipboard");
            }
        }
        // </ClipboardUsage>

        private static void ProcessLegacyData(MyCustomType data)
        {
            Console.WriteLine($"Processing legacy data: {data.Data}");
        }
    }
}