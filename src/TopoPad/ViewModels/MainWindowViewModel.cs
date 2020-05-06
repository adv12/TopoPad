using ReactiveUI;
using TopoPad.Core;
using TopoPad.Core.Layers;

namespace TopoPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ISpatialDocument Document { get; }

        public IItemsLayer Layer { get; }

        private string m_GeometryText;
        public string GeometryText
        {
            get => m_GeometryText;
            set
            {
                this.RaiseAndSetIfChanged(ref m_GeometryText, value);
            }
        }

        public MainWindowViewModel()
        {
            Document = new SpatialDocument();
            Layer = Document.AddItemsLayer();
        }

    }
}
