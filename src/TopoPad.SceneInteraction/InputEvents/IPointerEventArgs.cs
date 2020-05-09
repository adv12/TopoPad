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
