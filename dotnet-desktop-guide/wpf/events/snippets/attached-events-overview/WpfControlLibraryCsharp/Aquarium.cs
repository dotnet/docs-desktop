using System.Windows.Controls;
using System.Windows.Media;

namespace WpfControlCsharp
{
    public class Aquarium : Canvas
    {
        public Aquarium()
          : base()
        {
            // Initialize aquarium.
            Background = new SolidColorBrush(Colors.Aqua);
        }
    }
}
