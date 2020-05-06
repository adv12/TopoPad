using NetTopologySuite.Geometries;
using System.ComponentModel;

namespace TopoPad.Core.SpatialItems
{
    public interface IFeature : ISpatialItem, INotifyPropertyChanged
    {
        long Id { get; set; }
        Geometry Geometry { get; set; }
    }
}
