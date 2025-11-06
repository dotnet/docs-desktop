using System;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class CustomTypesExamples
    {
        // <SimpleCustomTypes>
        // Records work without any attributes.
        public record PersonInfo(string Name, int Age, string Email);

        // Simple classes serialize all public properties automatically.
        public class DocumentMetadata
        {
            public string Title { get; set; }
            public DateTime Created { get; set; }
            public string Author { get; set; }
        }

        // Structs with public properties work seamlessly.
        public struct Point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
        // </SimpleCustomTypes>

        // <JsonAttributesExample>
        public class ClipboardFriendlyType
        {
            // Include a field that normally isn't serialized
            [JsonInclude]
            private int _privateData;

            // Public properties are always serialized
            public string Name { get; set; }
            
            // Exclude sensitive or non-essential data
            [JsonIgnore]
            public string InternalId { get; set; }
            
            // Handle property name differences for compatibility
            [JsonPropertyName("display_text")]
            public string DisplayText { get; set; }
            
            // Control null value handling
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string OptionalField { get; set; }
        }
        // </JsonAttributesExample>

        // <CustomTypesClipboardOperations>
        public static void CustomTypesClipboardOperationsExample()
        {
            var data = new ClipboardFriendlyType 
            { 
                Name = "Sample", 
                DisplayText = "Sample Display Text",
                InternalId = "internal-123" // This property isn't serialized due to [JsonIgnore]
            };

            Clipboard.SetDataAsJson("MyAppData", data);

            if (Clipboard.TryGetData("MyAppData", out ClipboardFriendlyType retrieved))
            {
                Console.WriteLine($"Retrieved: {retrieved.Name}");
                // retrieved.InternalId is null because of [JsonIgnore]
            }
        }
        // </CustomTypesClipboardOperations>
    }
}