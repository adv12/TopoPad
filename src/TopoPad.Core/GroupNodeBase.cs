// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using TopoPad.Core.Layers;
using TopoPad.Core.Style;

namespace TopoPad.Core
{
    public abstract class GroupNodeBase : PropertyNotifier, IGroupNode
    {
        public event EventHandler<LayerSelectionChangedEventArgs> LayerSelectionChanged;

        public event EventHandler<LayerChangedEventArgs> LayerStyleChanged;

        public event EventHandler<LayerChangedEventArgs> LayerDataChanged;

        public event EventHandler<GroupNodeChangedEventArgs> VisibilityChanged;

        public event EventHandler<GroupNodeChangedEventArgs> OpacityChanged;

        private string m_Name;
        public string Name
        {
            get => m_Name;
            set => SetField(ref m_Name, value);
        }

        private bool m_Visible = true;
        public bool Visible
        {
            get => m_Visible;
            set
            {
                if (SetField(ref m_Visible, value))
                {
                    OnVisibilityChanged(new GroupNodeChangedEventArgs(this));
                }
            }
        }

        private double m_Opacity = 1;
        public double Opacity
        {
            get => m_Opacity;
            set
            {
                Guard.Against.OutOfRange(value, nameof(value), 0, 1);
                if (SetField(ref m_Opacity, value))
                {
                    OnOpacityChanged(new GroupNodeChangedEventArgs(this));
                }
            }
        }

        public virtual Envelope Bounds
        {
            get
            {
                Envelope bounds = new Envelope();
                foreach (IGroupNode child in ChildNodes)
                {
                    if (child.Bounds != null)

                    {
                        bounds.ExpandToInclude(child.Bounds);
                    }
                }
                return bounds;
            }
        }

        public virtual bool Snappable { get; set; } = true;
        public virtual bool ItemsSelectable { get; set; } = true;
        public virtual bool ItemsMovable { get; set; } = true;
        public virtual bool FeaturesEditable { get; set; } = true;

        private ItemsStyleSpec m_LocalItemsStyleSpec;
        public ItemsStyleSpec OverrideItemsStyleSpec
        {
            get => m_LocalItemsStyleSpec;
            set
            {
                Guard.Against.Null(value, nameof(value));
                if (SetField(ref m_LocalItemsStyleSpec, value))
                {
                    List<IItemsLayer> itemsLayers = new List<IItemsLayer>();
                    GetItemsLayers(this, itemsLayers);
                    foreach (IItemsLayer layer in itemsLayers)
                    {
                        if (layer == this || layer.OverrideItemsStyleSpec == null)
                        {
                            OnLayerStyleChanged(new LayerChangedEventArgs(layer));
                        }
                    }
                }
            }
        }

        private IGroup m_ParentNode;
        public IGroup ParentNode
        {
            get
            {
                return m_ParentNode;
            }
            set
            {
                var oldParent = m_ParentNode;
                {
                    m_ParentNode = value;
                    if (oldParent != value)
                    {
                        oldParent?.RemoveChild(this);
                        value?.AddChild(this);
                    }
                    OnPropertyChanged();
                }
            }
        }

        public abstract ReadOnlyObservableCollection<IGroupNode> ChildNodes { get; }

        public abstract IReadOnlyList<IGroupNode> ChildNodesReversed { get; }

        public Coordinate GetSnapPoint(Coordinate input)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllNodeNames()
        {
            IGroupNode top = this;
            while (top.ParentNode != null)
            {
                top = top.ParentNode;
            }
            List<string> names = new List<string>();
            GetNodeNames(names, top);
            return names;
        }

        private void GetNodeNames(List<string> names, IGroupNode node)
        {
            names.Add(node.Name);
            foreach (IGroupNode child in node.ChildNodes)
            {
                GetNodeNames(names, child);
            }
        }

        private void GetItemsLayers(IGroupNode groupNode, List<IItemsLayer> layers)
        {
            if (groupNode is IItemsLayer layer)
            {
                layers.Add(layer);
            }
            else
            {
                foreach (IGroupNode child in  groupNode.ChildNodes)
                {
                    GetItemsLayers(child, layers);
                }
            }
        }

        protected void OnLayerSelectionChanged(LayerSelectionChangedEventArgs e)
        {
            LayerSelectionChanged?.Invoke(this, e);
        }

        protected void OnLayerStyleChanged(LayerChangedEventArgs e)
        {
            LayerStyleChanged?.Invoke(this, e);
        }

        protected void OnLayerDataChanged(LayerChangedEventArgs e)
        {
            LayerDataChanged?.Invoke(this, e);
        }

        protected void OnVisibilityChanged(GroupNodeChangedEventArgs e)
        {
            VisibilityChanged?.Invoke(this, e);
        }

        protected void OnOpacityChanged(GroupNodeChangedEventArgs e)
        {
            OpacityChanged?.Invoke(this, e);
        }
    }
}
