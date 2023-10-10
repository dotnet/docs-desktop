//<full>
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SDKSamples
{
    public partial class MultiWindow : Window
    {
        public MultiWindow() =>
            InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e) =>
            ThreadStatusItem.Content = $"Thread ID: {Thread.CurrentThread.ManagedThreadId}";

        //<delay>
        private void PauseButton_Click(object sender, RoutedEventArgs e) =>
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        //</delay>

        //<buttons>
        private void SameThreadWindow_Click(object sender, RoutedEventArgs e) =>
            new MultiWindow().Show();

        private void NewThreadWindow_Click(object sender, RoutedEventArgs e)
        {
            Thread newWindowThread = new Thread(ThreadStartingPoint);
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }
        //</buttons>

        //<thread>
        private void ThreadStartingPoint()
        {
            new MultiWindow().Show();

            System.Windows.Threading.Dispatcher.Run();
        }
        //</thread>
    }
}
//</full>
