using System;
using System.Collections.Generic;
using TopoPad.Core.Layers;
using TopoPad.Core.SpatialItems;

namespace TopoPad.Core.HitTest
{
    public class ItemsHitTestSpec
    {
        private Lazy<HashSet<IItemsLayer>> m_Layers;
        public HashSet<IItemsLayer> Layers => m_Layers.Value;

        public bool LimitLayers { get; set; }

        private Lazy<HashSet<ISpatialItem>> m_SpatialItems;
        public HashSet<ISpatialItem> SpatialItems => m_SpatialItems.Value;

        public bool LimitItems { get; set; }

        public bool BoundaryOnly { get; set; }

        public bool TopmostOnly { get; set; }

        public bool SelectedItemsOnly { get; set; }

        public bool ActiveItemsOnly { get; set; }

        public ItemsHitTestSpec(bool boundaryOnly = false,
            bool topmostOnly = false, bool selectedItemsOnly = false,
            bool activeItemsOnly = false):
            this(null, null, boundaryOnly, topmostOnly, selectedItemsOnly,
                activeItemsOnly)
        {
        }

        public ItemsHitTestSpec(IEnumerable<IItemsLayer> layers,
            bool boundaryOnly = false,bool topmostOnly = false,
            bool selectedItemsOnly = false, bool activeItemsOnly = false) :
            this(layers, null, boundaryOnly, topmostOnly,
                selectedItemsOnly, activeItemsOnly)
        {
        }

        public ItemsHitTestSpec(IEnumerable<ISpatialItem> spatialItems,
            bool boundaryOnly = false, bool topmostOnly = false,
            bool selectedItemsOnly = false, bool activeItemsOnly = false) :
            this(null, spatialItems, boundaryOnly, topmostOnly,
                selectedItemsOnly, activeItemsOnly)
        {
        }

        public ItemsHitTestSpec(IEnumerable<IItemsLayer> layers,
            IEnumerable<ISpatialItem> spatialItems, bool boundaryOnly = false,
            bool topmostOnly = false, bool selectedItemsOnly = false,
            bool activeItemsOnly = false)
        {
            if (layers != null)
            {
                LimitLayers = true;
                foreach (IItemsLayer layer in layers)
                {
                    Layers.Add(layer);
                }
            }
            if (spatialItems != null)
            {
                LimitItems = true;
                foreach (ISpatialItem item in spatialItems)
                {
                    SpatialItems.Add(item);
                }
            }
            BoundaryOnly = boundaryOnly;
            TopmostOnly = topmostOnly;
            SelectedItemsOnly = selectedItemsOnly;
            ActiveItemsOnly = activeItemsOnly;
        }

    }
}
