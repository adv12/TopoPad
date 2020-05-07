using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using ReactiveUI;
using System;
using System.Reactive;
using TopoPad.AvaloniaSceneInteraction;
using TopoPad.Core;
using TopoPad.Core.Layers;

namespace TopoPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public SceneControlViewModel SceneControlViewModel { get; }

        public IItemsLayer Layer { get; }

        private string m_GeometryText;
        public string GeometryText
        {
            get => m_GeometryText;
            set => this.RaiseAndSetIfChanged(ref m_GeometryText, value);
        }

        private string m_ErrorText;
        public string ErrorText
        {
            get => m_ErrorText;
            set => this.RaiseAndSetIfChanged(ref m_ErrorText, value);
        }

        public ReactiveCommand<Unit, Unit> AddGeometry { get; }

        public MainWindowViewModel()
        {
            SceneControlViewModel = new SceneControlViewModel();
            SceneControlViewModel.Document = new SpatialDocument();
            Layer = SceneControlViewModel.Document.AddItemsLayer();
            Layer.Name = "WKT Geometries";
            AddGeometry = ReactiveCommand.Create(() =>
            {
                Geometry geometry = null;
                try
                {
                    WKTReader reader = new WKTReader();
                    geometry = reader.Read(GeometryText);
                    ErrorText = null;
                }
                catch (Exception ex)
                {
                    ErrorText = "Error parsing WKT: " + ex.Message;
                }
                if (geometry != null)
                {
                    Layer.AddItem(new Feature()
                    {
                        Geometry = geometry
                    });
                    ((IViewport)SceneControlViewModel).Fit(SceneControlViewModel.Document, .05);
                    SceneControlViewModel.Drawn = false;
                }
            });
        }

    }
}
