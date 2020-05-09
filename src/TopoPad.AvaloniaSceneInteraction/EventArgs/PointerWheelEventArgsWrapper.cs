// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia.Input;
using Avalonia.VisualTree;
using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class PointerWheelEventArgsWrapper : PointerEventArgsWrapper, IPointerWheelEventArgs
    {
        private VectorWrapper m_Delta;
        public IVector Delta => m_Delta ?? (m_Delta = new VectorWrapper(((PointerWheelEventArgs)E).Delta));

        public PointerWheelEventArgsWrapper(PointerWheelEventArgs e, IVisual visual) : base(e, visual)
        {
            
        }
    }
}
