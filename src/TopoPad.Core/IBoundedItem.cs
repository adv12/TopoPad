using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopoPad.Core
{
    public interface IBoundedItem
    {
        public Envelope Bounds { get; }
    }
}
