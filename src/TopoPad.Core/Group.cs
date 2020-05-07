// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public class Group : GroupNodeBase, IGroup
    {
        private readonly ObservableCollection<IGroupNode> m_ChildNodes = new ObservableCollection<IGroupNode>();

        private readonly ReadOnlyObservableCollection<IGroupNode> m_ReadOnlyChildNodes;

        public override ReadOnlyObservableCollection<IGroupNode> ChildNodes => m_ReadOnlyChildNodes;

        public Group()
        {
            m_ReadOnlyChildNodes = new ReadOnlyObservableCollection<IGroupNode>(m_ChildNodes);
            m_ChildNodes.CollectionChanged += ChildNodes_CollectionChanged;
            Name = "New Group";
        }

        private void ChildNodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                if (e.NewItems != null)
                {
                    foreach (IGroupNode node in e.NewItems)
                    {
                        node.PropertyChanged += Node_PropertyChanged;
                        node.LayerSelectionChanged += Node_LayerSelectionChanged;
                        node.LayerStyleChanged += Node_LayerStyleChanged;
                        node.LayerDataChanged += Node_LayerDataChanged;
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (IGroupNode node in e.OldItems)
                    {
                        node.PropertyChanged -= Node_PropertyChanged;
                        node.LayerSelectionChanged -= Node_LayerSelectionChanged;
                        node.LayerStyleChanged -= Node_LayerStyleChanged;
                        node.LayerDataChanged -= Node_LayerDataChanged;
                    }
                }
            }
        }

        private void Node_LayerStyleChanged(object sender, LayerChangedEventArgs e)
        {
            OnLayerStyleChanged(e);
        }

        private void Node_LayerDataChanged(object sender, LayerChangedEventArgs e)
        {
            OnLayerDataChanged(e);
        }

        private void Node_LayerSelectionChanged(object sender, LayerSelectionChangedEventArgs e)
        {
            OnLayerSelectionChanged(e);
        }

        private void Node_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Bounds))
            {
                OnPropertyChanged(nameof(Bounds));
            }
        }

        public Group(IGroup parentNode): this()
        {
            ParentNode = parentNode;
            List<string> allNames = GetAllNodeNames();
            for (int i = 0; ; i++)
            {
                string name = "Group " + i;
                if (!allNames.Contains(name))
                {
                    Name = name;
                    break;
                }
            }
        }

        public IGroup AddGroup()
        {
            return new Group(this);
        }

        public IItemsLayer AddItemsLayer()
        {
            return new ItemsLayer(this);
        }

        public IItemsLayer AddItemsLayer(string name)
        {
            return new ItemsLayer(this, name);
        }

        public void AddChild(IGroupNode child)
        {
            m_ChildNodes.Add(child);
            child.ParentNode = this;
        }

        public void RemoveChild(IGroupNode child)
        {
            m_ChildNodes.Remove(child);
            child.ParentNode = null;
        }

        public void Ungroup()
        {
            for (int i = m_ChildNodes.Count - 1; i > 0; i--)
            {
                m_ChildNodes[i].ParentNode = this.ParentNode;
            }
        }
    }
}
