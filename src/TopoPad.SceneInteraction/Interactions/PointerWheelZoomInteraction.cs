// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public class PointerWheelZoomInteraction : InteractionBase
    {
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
            e.Handled = true;
        }
    }
}
