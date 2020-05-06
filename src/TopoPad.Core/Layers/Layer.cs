using NetTopologySuite.Geometries;
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

        public Layer(IGroup parentNode): base()
        {
            m_ReadOnlyChildNodes = new ReadOnlyObservableCollection<IGroupNode>(m_ChildNodes);
            ParentNode = parentNode;
            List<string> allNames = GetAllNodeNames();
            for (int i = 0; true; i++)
            {
                string name = "Layer " + i;
                if (!allNames.Contains(name))
                {
                    Name = name;
                    break;
                }
            }
        }

        public abstract void Render(IRenderContext renderContext, bool fast);
    }
}
