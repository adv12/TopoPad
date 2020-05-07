using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TopoPad.Core
{
    public interface ISpatialDocument : IGroup
    {
        ObservableCollection<IGroupNode> SelectedNodes { get; }

        long SpatialReference { get; set; }

        Rgba BackColor { get; set; }
    }
}
