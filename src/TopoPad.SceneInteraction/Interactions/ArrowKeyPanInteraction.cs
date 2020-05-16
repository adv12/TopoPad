// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public class ArrowKeyPanInteraction : InteractionBase
    {
        public override void OnKeyDown(IKeyEventArgs e)
        {
            double distance = 5;
            if ((e.KeyModifiers & KeyModifiers.Shift) == KeyModifiers.Shift)
            {
                distance = 50;
            }
            if (e.Key == Key.Left)
            {
                Scene.PanView(-distance, 0);
                e.Handled = true;
            }
            else if (e.Key == Key.Right)
            {
                Scene.PanView(distance, 0);
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                Scene.PanView(0, distance);
                e.Handled = true;
            }
            else if (e.Key == Key.Down)
            {
                Scene.PanView(0, -distance);
                e.Handled = true;
            }
        }
    }
}
