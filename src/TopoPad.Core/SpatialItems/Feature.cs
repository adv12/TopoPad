// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using NetTopologySuite.Geometries;

namespace TopoPad.Core.SpatialItems
{
    public class Feature : PropertyNotifier, IFeature
    {
        private long m_Id;
        public long Id
        {
            get => m_Id;
            set => SetField(ref m_Id, value);
        }

        private Geometry m_Geometry;
        public Geometry Geometry
        {
            get => m_Geometry;
            set => SetField(ref m_Geometry, value);
        }

        public Envelope Bounds => throw new NotImplementedException();

    }
}
