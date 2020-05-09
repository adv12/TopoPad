using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public abstract class InteractionBase : IInteraction
    {
        public IScene Scene { get; set; }

        public abstract void OnPointerMoved(IPointerEventArgs e);

        public abstract void OnPointerPressed(IPointerEventArgs e);

        public abstract void OnPointerReleased(IPointerReleasedEventArgs e);

        public abstract void OnPointerWheelChanged(IPointerWheelEventArgs e);
    }
}
