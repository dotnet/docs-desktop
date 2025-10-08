using System;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace ClipboardExamples
{
    public class DragDropExamples
    {
        public class MyItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        // <DragDropUsage>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is ITypedDataObject typedData)
            {
                // Retrieve files from drag data using a standard format
                if (typedData.TryGetData(DataFormats.FileDrop, out string[] files))
                    Console.WriteLine($"Dropped files: {string.Join(", ", files)}");

                // Retrieve text using a standard format
                if (typedData.TryGetData(DataFormats.Text, out string text))
                    Console.WriteLine($"Dropped text: {text}");

                // Retrieve custom items using an application-specific format
                if (typedData.TryGetData("CustomItem", out MyItem item))
                    Console.WriteLine($"Dropped custom item: {item.Name} = {item.Value}");
            }
        }
        // </DragDropUsage>
    }
}
