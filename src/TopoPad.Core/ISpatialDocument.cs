// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.ObjectModel;
using System.ComponentModel;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public interface ISpatialDocument : IGroup
    {
        long SpatialReference { get; set; }

        ObservableCollection<IGroupNode> SelectedNodes { get; }

        IGroupNode SelectedNode { get; set; }

        ILayer SelectedLayer { get; }

        Rgba BackColor { get; set; }

        IItemsLayer AddItemsLayerAtSelectedNode()
        {
            IGroupNode node = SelectedNode;
            if (node is IGroup group)
            {
                return group.AddItemsLayer();
            }
            else if (node is ILayer)
            {
                return node.ParentNode?.AddItemsLayer();
            }
            else
            {
                return AddItemsLayer();
            }
        }

        IGroup AddGroupAtSelectedNode(int maxGroupLevels)
        {
            IGroupNode node = SelectedNode;
            if (node is ILayer)
            {
                node = node.ParentNode;
            }
            while (node != null && node.NumAncestors >= maxGroupLevels)
            {
                node = node.ParentNode;
            }
            if (node is IGroup group)
            {
                return group?.AddGroup();
            }
            else
            {
                return AddGroup();
            }
        }
    }
}
