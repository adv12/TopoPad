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
