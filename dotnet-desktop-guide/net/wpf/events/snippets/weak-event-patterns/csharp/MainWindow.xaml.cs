using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CodeSampleCsharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TestExistingWeakEventManager();
            TestGenericWeakEventManager();
            TestCustomWeakEventManager();
        }

        private void TestExistingWeakEventManager()
        {
            TextBox source = new();

            //<AddExistingStrongEventHandler>
            source.LostFocus += new RoutedEventHandler(Source_LostFocus);
            //</AddExistingStrongEventHandler>

            //<RemoveExistingStrongEventHandler>
            source.LostFocus -= new RoutedEventHandler(Source_LostFocus);
            //</RemoveExistingStrongEventHandler>

            //<AddExistingWeakEventHandler>
            LostFocusEventManager.AddHandler(source, Source_LostFocus);
            //</AddExistingWeakEventHandler>

            //<RemoveExistingWeakEventHandler>
            LostFocusEventManager.RemoveHandler(source, Source_LostFocus);
            //</RemoveExistingWeakEventHandler>
        }

        private void TestGenericWeakEventManager()
        {
            SomeEventSource source = new();

            //<AddGenericStrongEventHandler>
            source.SomeEvent += new EventHandler<SomeEventArgs>(Source_SomeEvent);
            //</AddGenericStrongEventHandler>

            //<RemoveGenericStrongEventHandler>
            source.SomeEvent -= new EventHandler<SomeEventArgs>(Source_SomeEvent);
            //</RemoveGenericStrongEventHandler>

            //<AddGenericWeakEventHandler>
            WeakEventManager<SomeEventSource, SomeEventArgs>.AddHandler(source, "SomeEvent", Source_SomeEvent);
            //</AddGenericWeakEventHandler>

            //<RemoveGenericWeakEventHandler>
            WeakEventManager<SomeEventSource, SomeEventArgs>.RemoveHandler(source, "SomeEvent", Source_SomeEvent);
            //</RemoveGenericWeakEventHandler>
        }

        private void TestCustomWeakEventManager()
        {
            SomeEventSource source = new();

            //<AddCustomStrongEventHandler>
            source.SomeEvent += new EventHandler<SomeEventArgs>(Source_SomeEvent);
            //</AddCustomStrongEventHandler>

            //<RemoveCustomStrongEventHandler>
            source.SomeEvent -= new EventHandler<SomeEventArgs>(Source_SomeEvent);
            //</RemoveCustomStrongEventHandler>

            //<AddCustomWeakEventHandler>
            SomeEventWeakEventManager.AddHandler(source, Source_SomeEvent);
            //</AddCustomWeakEventHandler>

            //<RemoveCustomWeakEventHandler>
            SomeEventWeakEventManager.RemoveHandler(source, Source_SomeEvent);
            //</RemoveCustomWeakEventHandler>
        }

        private void Source_LostFocus(object sender, RoutedEventArgs e) => Debug.WriteLine("Source_LostFocus");

        private void Source_SomeEvent(object sender, SomeEventArgs e) => Debug.WriteLine("Source_SomeEvent");
    }
}
