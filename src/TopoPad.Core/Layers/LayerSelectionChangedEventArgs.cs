using System.Collections.Generic;
using TopoPad.Core.SpatialItems;

namespace TopoPad.Core.Layers
{
    public class LayerSelectionChangedEventArgs
    {
        public IItemsLayer Layer { get; }

        public IList<ISpatialItem> NewlySelectedItems { get; } = new List<ISpatialItem>(1);

        public IList<ISpatialItem> NewlyDeselectedItems { get; } = new List<ISpatialItem>(1);

        public IList<ISpatialItem> NewlyActivatedItems { get; } = new List<ISpatialItem>(1);

        public IList<ISpatialItem> NewlyDeactivatedItems { get; } = new List<ISpatialItem>(1);

        public LayerSelectionChangedEventArgs(IItemsLayer layer)
        {
            Layer = layer;
        }
    }
}
