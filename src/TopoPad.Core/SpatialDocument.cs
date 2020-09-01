// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.ObjectModel;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public class SpatialDocument : Group, ISpatialDocument
    {
        private long m_SpatialReference = 0;
        public long SpatialReference
        {
            get => m_SpatialReference;
            set => SetField(ref m_SpatialReference, value);
        }

        public ObservableCollection<IGroupNode> SelectedNodes { get; } = new ObservableCollection<IGroupNode>();

        private IGroupNode m_SelectedNode;
        public IGroupNode SelectedNode
        {
            get => m_SelectedNode;
            set => SetField(ref m_SelectedNode, value);
        }

        public ILayer SelectedLayer => SelectedNode as ILayer;

        private Rgba m_BackColor = Rgba.FromHexString("#CCC");
        public Rgba BackColor
        {
            get => m_BackColor;
            set => SetField(ref m_BackColor, value);
        }

        public SpatialDocument() : base()
        {
            Name = "Document";
            OverrideItemsStyleSpec = new Style.ItemsStyleSpec();
        }

    }
}
