using System;
using System.Windows;

namespace CodeSampleCsharp
{
    //<WeakEventManagerTemplate>
    class SomeEventWeakEventManager : WeakEventManager
    {
        private SomeEventWeakEventManager()
        {
        }

        /// <summary>
        /// Add a handler for the given source's event.
        /// </summary>
        public static void AddHandler(SomeEventSource source,
                                      EventHandler<SomeEventArgs> handler)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            CurrentManager.ProtectedAddHandler(source, handler);
        }

        /// <summary>
        /// Remove a handler for the given source's event.
        /// </summary>
        public static void RemoveHandler(SomeEventSource source,
                                         EventHandler<SomeEventArgs> handler)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            CurrentManager.ProtectedRemoveHandler(source, handler);
        }

        /// <summary>
        /// Get the event manager for the current thread.
        /// </summary>
        private static SomeEventWeakEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(SomeEventWeakEventManager);
                SomeEventWeakEventManager manager =
                    (SomeEventWeakEventManager)GetCurrentManager(managerType);

                // at first use, create and register a new manager
                if (manager == null)
                {
                    manager = new SomeEventWeakEventManager();
                    SetCurrentManager(managerType, manager);
                }

                return manager;
            }
        }

        /// <summary>
        /// Return a new list to hold listeners to the event.
        /// </summary>
        protected override ListenerList NewListenerList()
        {
            return new ListenerList<SomeEventArgs>();
        }

        /// <summary>
        /// Listen to the given source for the event.
        /// </summary>
        protected override void StartListening(object source)
        {
            SomeEventSource typedSource = (SomeEventSource)source;
            typedSource.SomeEvent += new EventHandler<SomeEventArgs>(OnSomeEvent);
        }

        /// <summary>
        /// Stop listening to the given source for the event.
        /// </summary>
        protected override void StopListening(object source)
        {
            SomeEventSource typedSource = (SomeEventSource)source;
            typedSource.SomeEvent -= new EventHandler<SomeEventArgs>(OnSomeEvent);
        }

        /// <summary>
        /// Event handler for the SomeEvent event.
        /// </summary>
        void OnSomeEvent(object sender, SomeEventArgs e)
        {
            DeliverEvent(sender, e);
        }
    }
    //</WeakEventManagerTemplate>
}
