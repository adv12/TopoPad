// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using NetTopologySuite.Geometries;

namespace TopoPad.Core
{
    public interface IBoundedItem
    {
        public Envelope Bounds { get; }
    }
}
