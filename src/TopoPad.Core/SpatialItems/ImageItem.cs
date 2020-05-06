using NetTopologySuite.Geometries;

namespace TopoPad.Core.SpatialItems
{
    public class ImageItem : PropertyNotifier, IImageItem
    {
        public IImage Image => throw new System.NotImplementedException();

        public Envelope Bounds => throw new System.NotImplementedException();
    }
}
