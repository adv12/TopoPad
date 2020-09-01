// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using TopoPad.Core.Layers;
using TopoPad.Core.Style;

namespace TopoPad.Core
{
    public interface IGroup : IGroupNode
    {
        IGroup AddGroup();

        IItemsLayer AddItemsLayer(string name = null);

        void AddChild(IGroupNode child);

        void RemoveChild(IGroupNode child);

        void Ungroup();
    }
}
