using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TopoPad.Core.Layers
{
    public abstract class Layer: GroupNodeBase, ILayer
    {
        private readonly ObservableCollection<IGroupNode> m_ChildNodes = new ObservableCollection<IGroupNode>();

        private readonly ReadOnlyObservableCollection<IGroupNode> m_ReadOnlyChildNodes;

        public override ReadOnlyObservableCollection<IGroupNode> ChildNodes => m_ReadOnlyChildNodes;

        private bool m_Selected;
        public bool Selected
        {
            get => m_Selected;
            set => SetField(ref m_Selected, value);
        }

        private double m_Opacity = 1;
        public double Opacity
        {
            get => m_Opacity;
            set {
                Guard.Against.OutOfRange(value, nameof(value), 0, 1);
                if (SetField(ref m_Opacity, value))
                {
                    OnLayerStyleChanged(new LayerChangedEventArgs(this));
                }
            }
        }

        public Layer(IGroup parentNode, string name = null): base()
        {
            m_ReadOnlyChildNodes = new ReadOnlyObservableCollection<IGroupNode>(m_ChildNodes);
            ParentNode = parentNode;
            if (name == null)
            {
                List<string> allNames = GetAllNodeNames();
                for (int i = 0; true; i++)
                {
                    name = "Layer " + i;
                    if (!allNames.Contains(name))
                    {
                        break;
                    }
                }
            }
            Name = name;
        }

        public abstract void Render(IRenderContext renderContext, bool fast);
    }
}
