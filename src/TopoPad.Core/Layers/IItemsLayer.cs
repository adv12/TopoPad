// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using TopoPad.Core.SpatialItems;
using TopoPad.Core.Style;

namespace TopoPad.Core.Layers
{
    public interface IItemsLayer : ILayer
    {
        ReadOnlyObservableCollection<ISpatialItem> Items { get; }

        ItemsLayerStyleSpec StyleSpec { get; set; }

        void AddItem(ISpatialItem item);

        void SelectItem(ISpatialItem item);

        void SelectItems(IEnumerable<ISpatialItem> items);

        void SelectAll();

        void DeselectItem(ISpatialItem item);

        void DeselectItems(IEnumerable<ISpatialItem> items);

        void DeselectAll();

        bool IsItemSelected(ISpatialItem item);

        void ActivateItem(ISpatialItem item);

        void ActivateItems(IEnumerable<ISpatialItem> items);

        void ActivateAll();

        void DeactivateItem(ISpatialItem item);

        void DeactivateItems(IEnumerable<ISpatialItem> items);

        void DeactivateAll();

        bool IsItemActive(ISpatialItem item);
    }
}
