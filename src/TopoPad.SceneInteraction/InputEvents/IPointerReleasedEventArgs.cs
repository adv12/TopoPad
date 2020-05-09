// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointerReleasedEventArgs : IPointerEventArgs
    {
        MouseButton InitialPressMouseButton { get; }
    }
}
