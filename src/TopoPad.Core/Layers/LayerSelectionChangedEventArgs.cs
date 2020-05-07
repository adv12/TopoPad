// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using TopoPad.Core.SpatialItems;

namespace TopoPad.Core.Layers
{
    public class LayerSelectionChangedEventArgs : LayerChangedEventArgs
    {
        public IList<ISpatialItem> NewlySelectedItems { get; } = new List<ISpatialItem>(1);

        public IList<ISpatialItem> NewlyDeselectedItems { get; } = new List<ISpatialItem>(1);

        public IList<ISpatialItem> NewlyActivatedItems { get; } = new List<ISpatialItem>(1);

        public IList<ISpatialItem> NewlyDeactivatedItems { get; } = new List<ISpatialItem>(1);

        public LayerSelectionChangedEventArgs(IItemsLayer layer) : base(layer)
        {

        }
    }
}
