using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TopoPad.Views
{
    public class LayersView : UserControl
    {
        public LayersView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
