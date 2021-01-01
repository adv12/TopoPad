// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Utilities;
using ReactiveUI;
using TopoPad.Core;
using TopoPad.SceneInteraction;
using TopoPad.SceneInteraction.Interactions;

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
                        old.VisibilityChanged -= Document_VisibilityChanged;
                        old.OpacityChanged -= Document_OpacityChanged;
                    }
                    if (Document != null)
                    {
                        Document.LayerSelectionChanged += Document_LayerSelectionChanged;
                        Document.LayerStyleChanged += Document_LayerStyleChanged;
                        Document.LayerDataChanged += Document_LayerDataChanged;
                        Document.VisibilityChanged += Document_VisibilityChanged;
                        Document.OpacityChanged += Document_OpacityChanged;
                    }
                    ViewChanged();
                }
            }
        }

        private void Document_OpacityChanged(object sender, GroupNodeChangedEventArgs e)
        {
            Drawn = false;
        }

        private void Document_VisibilityChanged(object sender, GroupNodeChangedEventArgs e)
        {
            Drawn = false;
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

        public Avalonia.Rect Bounds
        {
            set
            {
                if (value != null)
                {
                    Width = value.Width;
                    Height = value.Height;
                }
            }
        }

        private double m_Width;
        public double Width
        {
            get => m_Width;
            private set
            {
                if (m_Width != this.RaiseAndSetIfChanged(ref m_Width, value))
                {
                    ViewChanged();
                }
            }
        }

        private double m_Height;
        public double Height
        {
            get => m_Height;
            private set
            {
                if (m_Height != this.RaiseAndSetIfChanged(ref m_Height, value))
                {
                    ViewChanged();
                }
            }
        }

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

        public bool FlipX => false;

        public bool FlipY => true;

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

        private List<IInteraction> m_Interactions = new List<IInteraction>();

        public IEnumerable<IInteraction> Interactions
        {
            get
            {
                for (int i = m_Interactions.Count - 1; i >= 0; i--)
                {
                    yield return m_Interactions[i];
                }
            }
        }

        public SceneControlViewModel()
        {
            PushInteraction(new PointerWheelZoomInteraction());
            PushInteraction(new ArrowKeyPanInteraction());
            PushInteraction(new DragPanInteraction());
            PushInteraction(new ClickSelectInteraction());
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

        public void PushInteraction(IInteraction interaction)
        {
            m_Interactions.Add(interaction);
            interaction.Scene = this;
        }

        public IInteraction PopInteraction()
        {
            IInteraction interaction = null;
            if (m_Interactions.Count > 0)
            {
                int index = m_Interactions.Count - 1;
                interaction = m_Interactions[index];
                m_Interactions.RemoveAt(index);
                interaction.Scene = null;
            }
            return interaction;
        }
    }
}
