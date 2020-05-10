// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TopoPad.Core.Layers
{
    public abstract class Layer : GroupNodeBase, ILayer
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

        public Layer(IGroup parentNode, string name = null) : base()
        {
            m_ReadOnlyChildNodes = new ReadOnlyObservableCollection<IGroupNode>(m_ChildNodes);
            ParentNode = parentNode;
            if (name == null)
            {
                List<string> allNames = GetAllNodeNames();
                for (int i = 1; true; i++)
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
