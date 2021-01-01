using System.Collections.Generic;
using System.Linq;
using NetTopologySuite.Geometries;
using TopoPad.Core;
using TopoPad.Core.HitTest;
using TopoPad.Core.Layers;
using TopoPad.Core.SpatialItems;
using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.SceneInteraction.Interactions
{
    public class ClickSelectInteraction : InteractionBase
    {
        private IPointer m_Pointer;
        private Coordinate m_Position;
        private ItemsHitTestSpec m_HitTestSpec = new ItemsHitTestSpec(false, true);
        private Dictionary<ISpatialItem, IItemsLayer> m_Hits =
            new Dictionary<ISpatialItem, IItemsLayer>();

        public override void OnPointerPressed(IPointerEventArgs e)
        {
            IPointerPoint point = e.CurrentPoint;
            IPointerPointProperties props = point.Properties;
            if (props.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed &&
                !props.IsMiddleButtonPressed && !props.IsRightButtonPressed)
            {
                m_Pointer = e.Pointer;
                m_Position = point.Position;
            }
        }

        public override void OnPointerReleased(IPointerReleasedEventArgs e)
        {
            IPointerPointProperties props = e.CurrentPoint.Properties;
            if (props.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
            {
                HandleLeftButtonUp(e);
                m_Pointer = null;
                m_Position = null;
            }
        }

        public override void OnPointerMoved(IPointerEventArgs e)
        {
            if (e.Pointer.Equals(m_Pointer))
            {
                if (e.CurrentPoint.Position.Distance(m_Position) > 5)
                {
                    m_Pointer = null;
                    m_Position = null;
                }
                else
                {
                    if (!e.CurrentPoint.Properties.IsLeftButtonPressed)
                    {
                        HandleLeftButtonUp(e);
                    }
                    e.Handled = true;
                }
            }
        }

        private void HandleLeftButtonUp(IPointerEventArgs e)
        {
            if (m_Pointer != null)
            {
                ISpatialDocument doc = Scene?.Document;
                if (doc != null)
                {
                    m_Hits.Clear();
                    Coordinate pos = Scene.ViewToWorld(m_Position);
                    doc.HitTest(pos.X, pos.Y, 3, 1 / Scene.Scale,
                        m_HitTestSpec, m_Hits);
                    bool multi = e.KeyModifiers.HasFlag(KeyModifiers.Shift);
                    if (m_Hits.Count == 1)
                    {
                        if (!multi)
                        {
                            doc.DeselectAll();
                        }
                        var pair = m_Hits.First();
                        IItemsLayer layer = pair.Value;
                        ISpatialItem item = pair.Key;
                        if (layer.IsItemSelected(item))
                        {
                            if (multi)
                            {
                                layer.DeselectItem(item);
                            }
                        }
                        else
                        {
                            layer.SelectItem(item);
                        }
                    }
                    else
                    {
                        doc.DeselectAll();
                    }
                }
            }
        }
    }
}
