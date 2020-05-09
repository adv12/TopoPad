// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia.Input;
using NetTopologySuite.Geometries;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class PointerPointWrapper : TP.IPointerPoint
    {
        private PointerPoint P;

        private TP.IPointer m_Pointer;
        public TP.IPointer Pointer => m_Pointer ?? (m_Pointer = new PointerWrapper(P.Pointer));

        private Coordinate m_Position;
        public Coordinate Position
        {
            get
            {
                if (m_Position == null)
                {
                    Avalonia.Point pos = P.Position;
                    m_Position = new Coordinate(pos.X, pos.Y);
                }
                return m_Position;
            }
        }

        private TP.IPointerPointProperties m_Properties;
        public TP.IPointerPointProperties Properties => m_Properties ??
            (m_Properties = new PointerPointPropertiesWrapper(P.Properties));

        public PointerPointWrapper(PointerPoint p)
        {
            P = p;
        }


    }
}
