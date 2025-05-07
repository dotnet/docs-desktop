using System;

namespace CodeSampleCsharp
{
    public class SomeEventArgs : EventArgs
    {
        public string TimeStamp { get; set; }

        public SomeEventArgs()
        {
            TimeStamp = DateTime.Now.ToLongTimeString();
        }
    }
}
