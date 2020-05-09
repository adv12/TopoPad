// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using NetTopologySuite.Geometries;

namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointerEventArgs : IEventArgs
    {
        KeyModifiers KeyModifiers { get; }

        IPointer Pointer => CurrentPoint.Pointer;

        IPointerPoint CurrentPoint { get; }

        ulong Timestamp { get; }

        Coordinate Position => CurrentPoint.Position;
    }
}
