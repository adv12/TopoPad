﻿// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using NetTopologySuite.Geometries;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public interface IGroupNode : INotifyPropertyChanged, IBoundedItem
    {
        event EventHandler<LayerSelectionChangedEventArgs> LayerSelectionChanged;

        event EventHandler<LayerChangedEventArgs> LayerStyleChanged;

        event EventHandler<LayerChangedEventArgs> LayerDataChanged;

        event EventHandler<GroupNodeChangedEventArgs> VisibilityChanged;

        event EventHandler<GroupNodeChangedEventArgs> OpacityChanged;

        string Name { get; set; }

        bool Visible { get; set; }

        double Opacity { get; set; }

        bool Snappable { get; set; }

        bool ItemsSelectable { get; set; }

        bool ItemsMovable { get; set; }

        bool FeaturesEditable { get; set; }

        Coordinate GetSnapPoint(Coordinate input);

        IGroup ParentNode { get; set; }

        int NumAncestors
        {
            get
            {
                int i = 0;
                IGroupNode parent = ParentNode;
                while (parent != null)
                {
                    parent = parent.ParentNode;
                    i++;
                }
                return i;
            }
        }

        ReadOnlyObservableCollection<IGroupNode> ChildNodes { get; }

        IGroupNode FindTopMatchingChild(Func<IGroupNode, bool> nodeTester)
        {
            for (int i = ChildNodes.Count - 1; i >= 0; i--)
            {
                IGroupNode child = ChildNodes[i];
                if (nodeTester(child))
                {
                    return child;
                }
                IGroupNode match = child.FindTopMatchingChild(nodeTester);
                if (match != null)
                {
                    return match;
                }
            }
            return null;
        }
    }
}
