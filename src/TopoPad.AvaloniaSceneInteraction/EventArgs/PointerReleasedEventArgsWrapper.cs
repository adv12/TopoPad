// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia.Input;
using Avalonia.VisualTree;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class PointerReleasedEventArgsWrapper : PointerEventArgsWrapper, TP.IPointerReleasedEventArgs
    {
        public TP.MouseButton InitialPressMouseButton { get; }

        public PointerReleasedEventArgsWrapper(PointerReleasedEventArgs e, IVisual visual) : base(e, visual)
        {

        }
    }
}
