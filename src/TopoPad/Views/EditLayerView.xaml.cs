using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TopoPad.Views
{
    public class EditLayerView : UserControl
    {
        public EditLayerView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
