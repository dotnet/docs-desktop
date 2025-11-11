using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class TestConfigurationExample
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        // <TestConfiguration>
        public static void TestBinaryFormatterConfiguration()
        {
            // Test data to verify configuration
            var testPerson = new Person { Name = "Test User", Age = 30 };

            try
            {
                // Test storing data (this should work with proper configuration)
                Clipboard.SetData("TestPerson", testPerson);
                Console.WriteLine("Successfully stored test data on clipboard");

                // Test retrieving with type resolver
                if (Clipboard.TryGetData("TestPerson", SecureTypeResolver, out Person retrievedPerson))
                {
                    Console.WriteLine($"Successfully retrieved: {retrievedPerson.Name}, Age: {retrievedPerson.Age}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve test data");
                }

                // Test that unauthorized types are rejected
                try
                {
                    Clipboard.TryGetData("TestPerson", UnauthorizedTypeResolver, out Person _);
                    Console.WriteLine("ERROR: Unauthorized type was not rejected!");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"SUCCESS: Unauthorized type properly rejected - {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Configuration test failed: {ex.Message}");
            }
        }

        private static Type SecureTypeResolver(TypeName typeName)
        {
            var allowedTypes = new Dictionary<string, Type>
            {
                ["ClipboardExamples.Person"] = typeof(Person),
            };

            if (allowedTypes.TryGetValue(typeName.FullName, out Type allowedType))
            {
                return allowedType;
            }

            throw new InvalidOperationException($"Type '{typeName.FullName}' is not permitted");
        }

        private static Type UnauthorizedTypeResolver(TypeName typeName)
        {
            // Intentionally restrictive resolver to test rejection
            throw new InvalidOperationException($"No types are permitted by this test resolver");
        }
        // </TestConfiguration>
    }
}