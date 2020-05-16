// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public class DragPanInteraction : InteractionBase
    {
        private bool m_Dragging;

        private Coordinate m_LastViewPosition;

        public override void OnPointerPressed(IPointerEventArgs e)
        {
            if (e.CurrentPoint.Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
            {
                m_Dragging = true;
                m_LastViewPosition = e.Position;
                e.Handled = true;
            }
        }

        public override void OnPointerMoved(IPointerEventArgs e)
        {
            Guard.Against.Null(Scene, nameof(Scene));
            Coordinate pos = e.Position;
            if (m_Dragging && e.CurrentPoint.Properties.IsLeftButtonPressed)
            {
                Scene.PanView((m_LastViewPosition.X - pos.X) * Scene.XMultiplier,
                    (m_LastViewPosition.Y - pos.Y) * Scene.YMultiplier);
                e.Handled = true;
            }
            else
            {
                m_Dragging = false;
            }
            m_LastViewPosition = pos;
        }

        public override void OnPointerReleased(IPointerReleasedEventArgs e)
        {
            if (e.CurrentPoint.Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
            {
                m_Dragging = false;
                e.Handled = true;
            }
        }
    }
}
