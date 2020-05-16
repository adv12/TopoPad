// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public interface IInteraction
    {
        IScene Scene { get; set; }

        void OnPointerMoved(IPointerEventArgs e);

        void OnPointerPressed(IPointerEventArgs e);

        void OnPointerReleased(IPointerReleasedEventArgs e);

        void OnPointerWheelChanged(IPointerWheelEventArgs e);

        void OnKeyDown(IKeyEventArgs e);

        void OnKeyUp(IKeyEventArgs e);
    }
}
