// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public abstract class InteractionBase : IInteraction
    {
        public IScene Scene { get; set; }

        public virtual void OnPointerMoved(IPointerEventArgs e)
        {

        }

        public virtual void OnPointerPressed(IPointerEventArgs e)
        {

        }

        public virtual void OnPointerReleased(IPointerReleasedEventArgs e)
        {

        }

        public virtual void OnPointerWheelChanged(IPointerWheelEventArgs e)
        {

        }
    }
}
