// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointerPoint
    {
        IPointer Pointer { get; }

        Coordinate Position { get; }

        IPointerPointProperties Properties { get; }
    }
}
