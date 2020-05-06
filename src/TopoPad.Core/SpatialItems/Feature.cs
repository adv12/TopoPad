using NetTopologySuite.Geometries;
using System;

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
