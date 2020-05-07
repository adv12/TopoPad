﻿using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public class SpatialDocument : Group, ISpatialDocument
    {
        private long m_SpatialReference = 0;
        public long SpatialReference {
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

        private Rgba m_BackColor = new Rgba(200, 255);
        public Rgba BackColor
        {
            get => m_BackColor;
            set => SetField(ref m_BackColor, value);
        }

        public SpatialDocument(): base()
        {
            Name = "Document";
        }

    }
}
