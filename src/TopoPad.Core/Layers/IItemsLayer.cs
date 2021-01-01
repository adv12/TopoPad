// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using TopoPad.Core.SpatialItems;

namespace TopoPad.Core.Layers
{
    public interface IItemsLayer : ILayer
    {
        ReadOnlyObservableCollection<ISpatialItem> Items { get; }

        void AddItem(ISpatialItem item);

        void SelectItem(ISpatialItem item);

        void SelectItems(IEnumerable<ISpatialItem> items);

        void DeselectItem(ISpatialItem item);

        void DeselectItems(IEnumerable<ISpatialItem> items);

        bool IsItemSelected(ISpatialItem item);

        void ActivateItem(ISpatialItem item);

        void ActivateItems(IEnumerable<ISpatialItem> items);

        void DeactivateItem(ISpatialItem item);

        void DeactivateItems(IEnumerable<ISpatialItem> items);

        bool IsItemActive(ISpatialItem item);
    }
}
