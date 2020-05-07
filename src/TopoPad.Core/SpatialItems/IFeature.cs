﻿// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

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
