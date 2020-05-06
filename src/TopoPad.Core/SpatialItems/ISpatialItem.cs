using NetTopologySuite.Geometries;

namespace TopoPad.Core.SpatialItems
{
    public interface ISpatialItem
    {
        Envelope Bounds { get; }
    }
}
