using System.Collections.ObjectModel;

namespace TopoPad.Core
{
    public class SpatialDocument : Group, ISpatialDocument
    {
        private long m_SpatialReference = 0;
        public long SpatialReference {
            get => m_SpatialReference;
            set => SetField(ref m_SpatialReference, value);
        }

        private Rgba m_BackColor = new Rgba(200, 255);
        public Rgba BackColor
        {
            get => m_BackColor;
            set => SetField(ref m_BackColor, value);
        }

        public ObservableCollection<IGroupNode> SelectedNodes { get; } = new ObservableCollection<IGroupNode>();

        public SpatialDocument(): base()
        {
            Name = "Document";
        }

    }
}
