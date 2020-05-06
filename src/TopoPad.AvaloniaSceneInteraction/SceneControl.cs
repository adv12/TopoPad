using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using NetTopologySuite.Geometries.Utilities;
using System.Collections.Generic;
using TopoPad.Core;
using TopoPad.Core.Layers;
using TopoPad.SceneInteraction;
using Geometry = NetTopologySuite.Geometries.Geometry;

namespace TopoPad.AvaloniaSceneInteraction
{
    public class SceneControl : Control, IScene
    {
        public static readonly DirectProperty<SceneControl, ISpatialDocument> DocumentProperty =
            AvaloniaProperty.RegisterDirect<SceneControl, ISpatialDocument>(
                nameof(Document),
                o => o.Document,
                (o, v) => o.Document = v);

        public static readonly DirectProperty<SceneControl, double> ScaleProperty =
            AvaloniaProperty.RegisterDirect<SceneControl, double>(
                nameof(Scale),
                o => o.Scale,
                (o, v) => o.Scale = v);

        public static readonly DirectProperty<SceneControl, double> CenterXProperty =
            AvaloniaProperty.RegisterDirect<SceneControl, double>(
                nameof(CenterX),
                o => o.CenterX,
                (o, v) => o.CenterX = v);

        public static readonly DirectProperty<SceneControl, double> CenterYProperty =
            AvaloniaProperty.RegisterDirect<SceneControl, double>(
                nameof(CenterY),
                o => o.CenterY,
                (o, v) => o.CenterY = v);

        private Dictionary<Geometry, Geometry> m_WorldToViewGeometries = new Dictionary<Geometry, Geometry>();

        private ISpatialDocument m_Document;
        public ISpatialDocument Document {
            get => m_Document;
            set
            {
                if (SetAndRaise(DocumentProperty, ref m_Document, value))
                {
                    InvalidateVisual();
                }
            }
        }

        private double m_Scale = 1;
        public double Scale {
            get => m_Scale;
            set
            {
                if (SetAndRaise(ScaleProperty, ref m_Scale, value))
                {
                    ViewChanged();
                }
            }
        }

        private double m_CenterX;
        public double CenterX {
            get => m_CenterX;
            set
            {
                if (SetAndRaise(CenterXProperty, ref m_CenterX, value))
                {
                    ViewChanged();
                }
            }
        }

        private double m_CenterY;
        public double CenterY {
            get => m_CenterY;
            set
            {
                if (SetAndRaise(CenterYProperty, ref m_CenterY, value))
                {
                    ViewChanged();
                }
            }
        }

        private AffineTransformation m_ViewToWorldTransform;
        public AffineTransformation ViewToWorldTransform
        {
            get
            {
                if (m_ViewToWorldTransform == null)
                {
                    m_ViewToWorldTransform = AffineTransformation.TranslationInstance(-Width / 2, -Height / 2);
                    m_ViewToWorldTransform.Scale(1 / Scale, 1 / Scale);
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
                    m_WorldToViewTransform.Scale(Scale, Scale);
                    m_WorldToViewTransform.Translate(Width / 2, Height / 2);
                }
                return m_WorldToViewTransform;
            }
        }

        public override void Render(DrawingContext context)
        {
            if (Document != null)
            {
                bool fast = false;
                context.FillRectangle(new SolidColorBrush(Document.BackColor.Argb),
                    new Rect(Bounds.Size));
                RenderContext renderContext = new RenderContext(this, context);
                RenderGroup(Document, renderContext, fast);
            }
        }

        public void RenderGroup(IGroup group, RenderContext renderContext, bool fast)
        {
            foreach (IGroupNode childNode in group.ChildNodes)
            {
                if (childNode is ILayer layer)
                {
                    RenderLayer(layer, renderContext, fast);
                }
                else if (childNode is IGroup g)
                {
                    RenderGroup(g, renderContext, fast);
                }
            }
        }

        public void RenderLayer(ILayer layer, RenderContext renderContext, bool fast)
        {
            layer.Render(renderContext, fast);
        }

        public void CacheViewGeometry(NetTopologySuite.Geometries.Geometry worldGeometry, Geometry viewGeometry)
        {
            m_WorldToViewGeometries[worldGeometry] = viewGeometry;
        }

        public NetTopologySuite.Geometries.Geometry GetCachedViewGeometry(Geometry worldGeometry)
        {
            if (!m_WorldToViewGeometries.TryGetValue(worldGeometry, out Geometry viewGeometry))
            {
                return viewGeometry;
            }
            return null;
        }

        private void ViewChanged()
        {
            m_ViewToWorldTransform = null;
            m_WorldToViewTransform = null;
            InvalidateVisual();
        }
    }
}
