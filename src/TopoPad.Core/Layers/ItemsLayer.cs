using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TopoPad.Core.SpatialItems;
using TopoPad.Core.Style;

namespace TopoPad.Core.Layers
{
    public class ItemsLayer : Layer, IItemsLayer
    {
        private readonly ObservableCollection<ISpatialItem> m_Items = new ObservableCollection<ISpatialItem>();

        public override Envelope Bounds
        {
            get
            {
                Envelope bounds = new Envelope();
                foreach (ISpatialItem item in Items)
                {
                    if (item.Bounds != null)
                    {
                        bounds.ExpandToInclude(item.Bounds);
                    }
                }
                return bounds;
            }
        }

        public ReadOnlyObservableCollection<ISpatialItem> Items { get; }

        private FeatureStyleSet m_FeatureStyleSet = new FeatureStyleSet();
        public FeatureStyleSet FeatureStyleSet {
            get => m_FeatureStyleSet;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetField(ref m_FeatureStyleSet, value);
            }
        }

        private FeatureStyleSet m_SelectedFeatureStyleSet = new FeatureStyleSet();
        public FeatureStyleSet SelectedFeatureStyleSet
        {
            get => m_SelectedFeatureStyleSet;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetField(ref m_SelectedFeatureStyleSet, value);
            }
        }

        private FeatureStyleSet m_ActiveFeatureStyleSet = new FeatureStyleSet();
        public FeatureStyleSet ActiveFeatureStyleSet
        {
            get => m_ActiveFeatureStyleSet;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetField(ref m_ActiveFeatureStyleSet, value);
            }
        }

        public ItemsLayer(IGroup parentNode) : base(parentNode)
        {
            Items = new ReadOnlyObservableCollection<ISpatialItem>(m_Items);
        }

        public void AddItem(ISpatialItem item)
        {
            m_Items.Add(item);
        }

        public override void Render(IRenderContext renderContext, bool fast)
        {
            foreach (ISpatialItem item in Items)
            {
                if (item is Feature feature)
                {
                    FeatureStyleSet featureStyleSet = FeatureStyleSet;

                    if (IsItemActive(feature))
                    {
                        featureStyleSet = ActiveFeatureStyleSet;
                    }
                    else if (IsItemSelected(feature))
                    {
                        featureStyleSet = SelectedFeatureStyleSet;
                    }
                    RenderGeometry(renderContext, featureStyleSet, feature.Geometry, fast);
                }
            }
        }

        public void RenderGeometry(IRenderContext renderContext,
            FeatureStyleSet featureStyleSet, Geometry geom, bool fast)
        {
            if (geom != null)
            {
                if (geom is GeometryCollection gc)
                {
                    for (int i = 0; i < gc.NumGeometries; i++)
                    {
                        RenderGeometry(renderContext, featureStyleSet, gc.GetGeometryN(i), fast);
                    }
                }
                else if (geom is Point point)
                {
                    renderContext.DrawPoint(point, featureStyleSet.PointStyle, fast);
                }
                else if (geom is LineString lineString)
                {
                    renderContext.DrawLineString(lineString, featureStyleSet.LineStyle,
                        featureStyleSet.VertexStyle, fast);
                }
                else if (geom is Polygon polygon)
                {
                    renderContext.DrawPolygon(polygon, featureStyleSet.FillStyle, featureStyleSet.LineStyle,
                        featureStyleSet.VertexStyle, fast);
                }
            }
        }

        public void SelectItem(ISpatialItem item)
        {
            throw new System.NotImplementedException();
        }

        public void SelectItems(IEnumerable<ISpatialItem> items)
        {
            throw new System.NotImplementedException();
        }

        public void SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeselectItem(ISpatialItem item)
        {
            throw new System.NotImplementedException();
        }

        public void DeselectItems(IEnumerable<ISpatialItem> items)
        {
            throw new System.NotImplementedException();
        }

        public void DeselectAll()
        {
            throw new System.NotImplementedException();
        }

        public bool IsItemSelected(ISpatialItem item)
        {
            return false;
        }

        public void ActivateItem(ISpatialItem item)
        {
            throw new System.NotImplementedException();
        }

        public void ActivateItems(IEnumerable<ISpatialItem> items)
        {
            throw new System.NotImplementedException();
        }

        public void ActivateAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeactivateItem(ISpatialItem item)
        {
            throw new System.NotImplementedException();
        }

        public void DeactivateItems(IEnumerable<ISpatialItem> items)
        {
            throw new System.NotImplementedException();
        }

        public void DeactivateAll()
        {
            throw new System.NotImplementedException();
        }

        public bool IsItemActive(ISpatialItem item)
        {
            return false;
        }
    }
}
