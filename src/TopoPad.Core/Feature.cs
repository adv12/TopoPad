﻿using NetTopologySuite.Geometries;
using TopoPad.Core.SpatialItems;

namespace TopoPad.Core
{
    public class Feature : PropertyNotifier, IFeature
    {
        public Envelope Bounds => Geometry?.EnvelopeInternal;

        private long m_Id = 0;
        public long Id
        {
            get => m_Id;
            set => SetField(ref m_Id, value);
        }

        private Geometry m_Geometry;
        public Geometry Geometry {
            get => m_Geometry;
            set
            {
                if (SetField(ref m_Geometry, value))
                {
                    OnPropertyChanged(nameof(Bounds));
                }
            }
        }
        
    }
}
