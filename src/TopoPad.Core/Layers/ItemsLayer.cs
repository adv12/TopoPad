// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using TopoPad.Core.HitTest;
using TopoPad.Core.SpatialItems;
using TopoPad.Core.Style;

namespace TopoPad.Core.Layers
{
    public class ItemsLayer : Layer, IItemsLayer
    {
        private readonly ObservableCollection<ISpatialItem> m_Items = new ObservableCollection<ISpatialItem>();

        private HashSet<ISpatialItem> m_SelectedItems = new HashSet<ISpatialItem>();

        private HashSet<ISpatialItem> m_ActiveItems = new HashSet<ISpatialItem>();

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

        private ItemsStyleSpec m_StyleSpec = new ItemsStyleSpec();
        public ItemsStyleSpec StyleSpec
        {
            get => m_StyleSpec;
            set
            {
                Guard.Against.Null(value, nameof(value));
                if (SetField(ref m_StyleSpec, value))
                {
                    FireStyleChanged();
                }
            }
        }

        public ItemsLayer(IGroup parentNode, string name = null) : base(parentNode, name)
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
                    FeatureStyleSet featureStyleSet = StyleSpec?.FeatureStyleSet;

                    if (IsItemActive(feature))
                    {
                        featureStyleSet = StyleSpec?.ActiveFeatureStyleSet;
                    }
                    else if (IsItemSelected(feature))
                    {
                        featureStyleSet = StyleSpec?.SelectedFeatureStyleSet;
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
            m_SelectedItems.Add(item);
            FireSelectionChanged();
        }

        public void SelectItems(IEnumerable<ISpatialItem> items)
        {
            foreach (ISpatialItem item in items)
            {
                SelectItem(item);
            }
        }

        public void SelectAll()
        {
            SelectItems(Items);
            FireSelectionChanged();
        }

        public void DeselectItem(ISpatialItem item)
        {
            DeactivateItem(item);
            m_SelectedItems.Remove(item);
            FireSelectionChanged();
        }

        public void DeselectItems(IEnumerable<ISpatialItem> items)
        {
            foreach (ISpatialItem item in items)
            {
                DeselectItem(item);
            }
            FireSelectionChanged();
        }

        public void DeselectAll()
        {
            m_ActiveItems.Clear();
            m_SelectedItems.Clear();
            FireSelectionChanged();
        }

        public bool IsItemSelected(ISpatialItem item)
        {
            return m_SelectedItems.Contains(item);
        }

        public void ActivateItem(ISpatialItem item)
        {
            SelectItem(item);
            m_ActiveItems.Add(item);
            FireSelectionChanged();
        }

        public void ActivateItems(IEnumerable<ISpatialItem> items)
        {
            foreach (ISpatialItem item in items)
            {
                ActivateItem(item);
            }
            FireSelectionChanged();
        }

        public void ActivateAll()
        {
            ActivateItems(Items);
            FireSelectionChanged();
        }

        public void DeactivateItem(ISpatialItem item)
        {
            m_ActiveItems.Remove(item);
            FireSelectionChanged();
        }

        public void DeactivateItems(IEnumerable<ISpatialItem> items)
        {
            foreach (ISpatialItem item in items)
            {
                DeactivateItem(item);
            }
            FireSelectionChanged();
        }

        public void DeactivateAll()
        {
            m_ActiveItems.Clear();
            FireSelectionChanged();
        }

        public bool IsItemActive(ISpatialItem item)
        {
            return m_ActiveItems.Contains(item);
        }

        public void HitTest(double x, double y, double viewBoundaryBuffer,
            double viewToWorld, ItemsHitTestSpec spec,
            Dictionary<ISpatialItem, IItemsLayer> hits)
        {
            if (spec.LimitLayers && !spec.Layers.Contains(this))
            {
                return;
            }
            IEnumerable<ISpatialItem> items = this.Items;
            if (spec.TopmostOnly)
            {
                if (hits.Any())
                {
                    return;
                }
                items = items.Reverse();
            }
            foreach (ISpatialItem item in items)
            {
                if (item is Feature)
                {
                    if (HitTestFeature((Feature)item, x, y, viewBoundaryBuffer,
                        viewToWorld, spec))
                    {
                        hits[item] = this;
                    }
                }
                else if (item is ImageItem)
                {
                    if (item.Bounds.Contains(x, y))
                    {
                        hits[item] = this;
                    }
                }
                if (spec.TopmostOnly && hits.Any())
                {
                    return;
                }
            }
        }

        private bool HitTestFeature(Feature f, double x, double y, double viewBoundaryBuffer,
            double viewToWorld, ItemsHitTestSpec spec)
        {
            FeatureStyleSet styleSet =
                IsItemActive(f) ? StyleSpec.ActiveFeatureStyleSet :
                IsItemSelected(f) ? StyleSpec.SelectedFeatureStyleSet :
                this.StyleSpec.FeatureStyleSet;
            Geometry geom = f.Geometry;
            if (geom == null)
            {
                return false;
            }
            return geom.Dimension switch
            {
                Dimension.Point => HitTestPoint(styleSet, geom, x, y, viewBoundaryBuffer, viewToWorld, spec),
                Dimension.Curve => HitTestCurve(styleSet, geom, x, y, viewBoundaryBuffer, viewToWorld, spec),
                Dimension.Surface => HitTestArea(styleSet, geom, x, y, viewBoundaryBuffer, viewToWorld, spec),
                _ => false
            };
        }

        private bool HitTestPoint(FeatureStyleSet styleSet, Geometry geom,
            double x, double y, double viewBoundaryBuffer, double viewToWorld,
            ItemsHitTestSpec spec)
        {
            double buffer = ((styleSet.PointStyle.Size + styleSet.PointStyle.LineStyle.Width) / 2 + 
                viewBoundaryBuffer) * viewToWorld;
            switch (styleSet.PointStyle.Shape)
            {
                case PointShape.Circle:
                    return geom.Distance(new Point(x, y)) < buffer;
                default:
                    Envelope env = new Envelope(geom.Coordinate);
                    env.ExpandBy(buffer);
                    return env.Contains(x, y);
            }
        }

        private bool HitTestCurve(FeatureStyleSet styleSet, Geometry geom,
            double x, double y, double viewBoundaryBuffer, double viewToWorld,
            ItemsHitTestSpec spec)
        {
            if (geom is GeometryCollection gc)
            {
                if (gc.Geometries.Any(g => (g is Point || g is MultiPoint) &&
                    HitTestPoint(styleSet, g, x, y, viewBoundaryBuffer,
                    viewToWorld, spec)))
                {
                    return true;
                }
            }
            double buffer = (styleSet.LineStyle.Width / 2 +
                viewBoundaryBuffer) * viewToWorld;
            return geom.Distance(new Point(x, y)) < buffer;
        }

        private bool HitTestArea(FeatureStyleSet styleSet, Geometry geom,
            double x, double y, double viewBoundaryBuffer, double viewToWorld,
            ItemsHitTestSpec spec)
        {
            Point p = new Point(x, y);
            if (geom is GeometryCollection gc)
            {
                if (gc.Geometries.Any(g => g is IPolygonal && g.Contains(p)))
                {
                    return true;
                }
                if (gc.Geometries.Any(g => (g is Point || g is MultiPoint) &&
                    HitTestPoint(styleSet, g, x, y, viewBoundaryBuffer,
                    viewToWorld, spec)))
                {
                    return true;
                }
            }
            else if (geom.Contains(p))
            {
                return true;
            }
            double buffer = (styleSet.LineStyle.Width / 2 + viewBoundaryBuffer) * viewToWorld;
            return geom.Distance(p) < buffer;
        }

        private bool SetNotifyUnregisterRegister(ref FeatureStyleSet field, FeatureStyleSet value,
            [CallerMemberName] string propertyName = null)
        {
            FeatureStyleSet old = field;
            bool set = SetField(ref field, value, propertyName);
            if (set)
            {
                if (old != null)
                {
                    old.PropertyChanged -= Field_PropertyChanged;
                    old.StyleChanged -= Field_StyleChanged;
                }
                if (field != null)
                {
                    field.PropertyChanged += Field_PropertyChanged; ;
                    field.StyleChanged += Field_StyleChanged;
                }
            }
            return set;
        }

        private void Field_StyleChanged(object sender, System.EventArgs e)
        {
            FireStyleChanged();
        }

        private void Field_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FireStyleChanged();
        }

        private void FireStyleChanged()
        {
            OnLayerStyleChanged(new LayerChangedEventArgs(this));
        }

        private void FireSelectionChanged()
        {
            OnLayerSelectionChanged(new LayerSelectionChangedEventArgs(this));
        }
    }
}
