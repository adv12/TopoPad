using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TopoPad.Views
{
    public class AddGeometryView : UserControl
    {
        public AddGeometryView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
