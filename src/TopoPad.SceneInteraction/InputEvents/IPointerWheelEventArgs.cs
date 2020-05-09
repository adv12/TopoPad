namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointerWheelEventArgs : IPointerEventArgs
    {
        IVector Delta { get; }
    }
}
