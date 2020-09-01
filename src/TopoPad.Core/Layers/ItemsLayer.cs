// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
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
    }
}
