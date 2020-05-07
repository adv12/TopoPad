using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Utilities;
using ReactiveUI;
using System.Collections.Generic;
using TopoPad.Core;
using TopoPad.SceneInteraction;

namespace TopoPad.AvaloniaSceneInteraction
{
    public class SceneControlViewModel : ReactiveObject, IScene, ISpatialDocumentContainer
    {
        private Dictionary<Geometry, Geometry> m_WorldToViewGeometries = new Dictionary<Geometry, Geometry>();

        private ISpatialDocument m_Document;
        public ISpatialDocument Document
        {
            get => m_Document;
            set
            {
                ISpatialDocument old = m_Document;
                if (m_Document != this.RaiseAndSetIfChanged(ref m_Document, value))
                {
                    if (old != null)
                    {
                        old.LayerSelectionChanged -= Document_LayerSelectionChanged;
                        old.LayerStyleChanged -= Document_LayerStyleChanged;
                        old.LayerDataChanged -= Document_LayerDataChanged;
                    }
                    if (Document != null)
                    {
                        Document.LayerSelectionChanged += Document_LayerSelectionChanged;
                        Document.LayerStyleChanged += Document_LayerStyleChanged;
                        Document.LayerDataChanged += Document_LayerDataChanged;
                    }
                    ViewChanged();
                }
            }
        }

        private void Document_LayerDataChanged(object sender, Core.Layers.LayerChangedEventArgs e)
        {
            Drawn = false;
        }

        private void Document_LayerSelectionChanged(object sender, Core.Layers.LayerSelectionChangedEventArgs e)
        {
            Drawn = false;
        }

        private void Document_LayerStyleChanged(object sender, Core.Layers.LayerChangedEventArgs e)
        {
            Drawn = false;
        }

        private Avalonia.Rect m_Bounds;
        public Avalonia.Rect Bounds {
            get => m_Bounds;
            set
            {
                this.RaiseAndSetIfChanged(ref m_Bounds, value);
                if (m_Bounds != null)
                {
                    Width = m_Bounds.Width;
                    this.RaisePropertyChanged(nameof(Width));
                    Height = m_Bounds.Height;
                    this.RaisePropertyChanged(nameof(Height));
                    ViewChanged();
                }
            }
        }

        public double Width { get; private set; }
        public double Height { get; private set; }

        private double m_Scale = 1;
        public double Scale
        {
            get => m_Scale;
            set
            {
                if (m_Scale != this.RaiseAndSetIfChanged(ref m_Scale, value))
                {
                    ViewChanged();
                }
            }
        }

        private double m_CenterX;
        public double CenterX
        {
            get => m_CenterX;
            set
            {
                if (m_CenterX != this.RaiseAndSetIfChanged(ref m_CenterX, value))
                {
                    ViewChanged();
                }
            }
        }

        private double m_CenterY;
        public double CenterY
        {
            get => m_CenterY;
            set
            {
                if (m_CenterY != this.RaiseAndSetIfChanged(ref m_CenterY, value))
                {
                    ViewChanged();
                }
            }
        }

        private bool m_Drawn;
        public bool Drawn
        {
            get => m_Drawn;
            set => this.RaiseAndSetIfChanged(ref m_Drawn, value);
        }

        private AffineTransformation m_ViewToWorldTransform;
        public AffineTransformation ViewToWorldTransform
        {
            get
            {
                if (m_ViewToWorldTransform == null)
                {
                    m_ViewToWorldTransform = AffineTransformation.TranslationInstance(-Width / 2, -Height / 2);
                    m_ViewToWorldTransform.Scale(1 / Scale, -1 / Scale);
                    m_ViewToWorldTransform.Translate(CenterX, CenterY);
                }
                return m_ViewToWorldTransform;
            }
        }

        private AffineTransformation m_WorldToViewTransform;
        public AffineTransformation WorldToViewTransform
        {
            get
            {
                if (m_WorldToViewTransform == null)
                {
                    m_WorldToViewTransform = AffineTransformation.TranslationInstance(-CenterX, -CenterY);
                    m_WorldToViewTransform.Scale(Scale, -Scale);
                    m_WorldToViewTransform.Translate(Width / 2, Height / 2);
                }
                return m_WorldToViewTransform;
            }
        }

        private void ViewChanged()
        {
            m_ViewToWorldTransform = null;
            m_WorldToViewTransform = null;
            m_WorldToViewGeometries.Clear();
            Drawn = false;
        }

        public void CacheViewGeometry(Geometry worldGeometry, Geometry viewGeometry)
        {
            m_WorldToViewGeometries[worldGeometry] = viewGeometry;
        }

        public Geometry GetCachedViewGeometry(Geometry worldGeometry)
        {
            if (m_WorldToViewGeometries.TryGetValue(worldGeometry, out Geometry viewGeometry))
            {
                return viewGeometry;
            }
            return null;
        }
    }
}
