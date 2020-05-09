namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointerReleasedEventArgs : IPointerEventArgs
    {
        MouseButton InitialPressMouseButton { get; }
    }
}
