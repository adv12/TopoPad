using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using TopoPad.Core;
using TopoPad.Core.Layers;
using TopoPad.SceneInteraction;

namespace TopoPad.ViewModels
{
    public class AddGeometryViewModel : SceneToolViewModel
    {
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

        public AddGeometryViewModel() : base()
        {
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
                    IScene scene = SceneViewModel.Scene;
                    ISpatialDocument document = scene.Document;
                    IItemsLayer layer = document.SelectedLayer as IItemsLayer;
                    if (layer == null)
                    {
                        layer = (IItemsLayer)document.FindTopMatchingChild(n => n is IItemsLayer);
                    }
                    if (layer == null)
                    {
                        layer = document.AddItemsLayer("WKT Geometries");
                        document.SelectedNode = layer;
                    }
                    layer.AddItem(new Feature()
                    {
                        Geometry = geometry
                    });
                    scene.Fit(document, .05);
                    scene.Drawn = false;
                }
            });
        }
    }
}
