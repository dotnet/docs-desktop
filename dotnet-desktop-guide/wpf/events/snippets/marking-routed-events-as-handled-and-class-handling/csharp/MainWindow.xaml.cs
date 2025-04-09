using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeSampleCsharp
{
    //<InstanceEventHandling>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Attach an instance handler on componentWrapper that will be invoked by handled KeyDown events.
            componentWrapper.AddHandler(KeyDownEvent, new RoutedEventHandler(Handler.InstanceEventInfo),
                handledEventsToo: true);
        }

        // The handler attached to componentWrapper in XAML.
        public void HandlerInstanceEventInfo(object sender, KeyEventArgs e) => 
            Handler.InstanceEventInfo(sender, e);
    }
    //</InstanceEventHandling>

    //<ClassEventHandling>
    public class ComponentWrapper : ComponentWrapperBase
    {
        static ComponentWrapper()
        {
            // Class event handler implemented in the static constructor.
            EventManager.RegisterClassHandler(typeof(ComponentWrapper), KeyDownEvent, 
                new RoutedEventHandler(Handler.ClassEventInfo_Static));
        }

        // Class event handler that overrides a base class virtual method.
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Handler.ClassEventInfo_Override(this, e);

            // Call the base OnKeyDown implementation on ComponentWrapperBase.
            base.OnKeyDown(e);
        }
    }

    public class ComponentWrapperBase : StackPanel
    {
        // Class event handler implemented in the static constructor.
        static ComponentWrapperBase()
        {
            EventManager.RegisterClassHandler(typeof(ComponentWrapperBase), KeyDownEvent, 
                new RoutedEventHandler(Handler.ClassEventInfoBase_Static));
        }

        // Class event handler that overrides a base class virtual method.
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Handler.ClassEventInfoBase_Override(this, e);

            e.Handled = true;
            Debug.WriteLine("The KeyDown routed event is marked as handled.");

            // Call the base OnKeyDown implementation on StackPanel.
            base.OnKeyDown(e);
        }
    }
    //</ClassEventHandling>

    /* Debug output:
The instance handler attached to componentWrapper was triggered by the PreviewKeyDown routed event raised on componentTextBox.
The static class handler attached to componentWrapper was triggered by the KeyDown routed event raised on componentTextBox.
The static class handler attached to componentWrapperBase was triggered by the KeyDown routed event raised on componentTextBox.
The override class handler attached to componentWrapper was triggered by the KeyDown routed event raised on componentTextBox.
The override class handler attached to componentWrapperBase was triggered by the KeyDown routed event raised on componentTextBox.
The KeyDown routed event is marked as handled.
The instance handler attached to componentWrapper was triggered by the KeyDown routed event raised on componentTextBox. Parameter handledEventsToo set to true.
    */
}
