// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using NetTopologySuite.Geometries;

namespace TopoPad.Core.SpatialItems
{
    public class ImageItem : PropertyNotifier, IImageItem
    {
        public IImage Image => throw new System.NotImplementedException();

        public Envelope Bounds => throw new System.NotImplementedException();
    }
}
