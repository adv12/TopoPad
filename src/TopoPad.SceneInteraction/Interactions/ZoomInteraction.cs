using System;
using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public class ZoomInteraction : InteractionBase
    {
        public override void OnPointerMoved(IPointerEventArgs e)
        {

        }

        public override void OnPointerPressed(IPointerEventArgs e)
        {

        }

        public override void OnPointerReleased(IPointerReleasedEventArgs e)
        {

        }

        public override void OnPointerWheelChanged(IPointerWheelEventArgs e)
        {
            if (e.Delta.Y > 0)
            {
                Scene.Scale *= (1 + Math.Abs(e.Delta.Y) / 10);
            }
            else
            {
                Scene.Scale /= (1 + Math.Abs(e.Delta.Y) / 10);
            }
        }
    }
}
