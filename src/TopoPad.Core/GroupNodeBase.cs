using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public abstract class GroupNodeBase : PropertyNotifier, IGroupNode
    {
        public event EventHandler<LayerSelectionChangedEventArgs> LayerSelectionChanged;

        public event EventHandler<LayerChangedEventArgs> LayerStyleChanged;

        public event EventHandler<LayerChangedEventArgs> LayerDataChanged;

        private string m_Name;
        public string Name
        {
            get => m_Name;
            set => SetField(ref m_Name, value);
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
            GetNodeNames(names, this);
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
    }
}
