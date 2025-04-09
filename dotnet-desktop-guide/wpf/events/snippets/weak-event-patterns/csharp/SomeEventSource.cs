using System;

namespace CodeSampleCsharp
{
    public class SomeEventSource
    {
        public event EventHandler<SomeEventArgs> SomeEvent;

        public void RaiseDoEvent()
        {
            OnSomeEvent(new SomeEventArgs());
        }

        protected void OnSomeEvent(SomeEventArgs e)
        {
            SomeEvent?.Invoke(this, e);
        }
    }
}
