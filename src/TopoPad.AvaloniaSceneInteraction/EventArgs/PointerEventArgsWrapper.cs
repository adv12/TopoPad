// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Ardalis.GuardClauses;
using Avalonia.Input;
using Avalonia.VisualTree;
using NetTopologySuite.Geometries;
using System.Diagnostics.CodeAnalysis;
using TopoPad.SceneInteraction.InputEvents;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class PointerEventArgsWrapper : TP.IPointerEventArgs
    {
        [NotNull]
        protected PointerEventArgs E;

        [NotNull]
        protected IVisual Visual;

        public bool Handled
        {
            get => E.Handled;
            set => E.Handled = value;
        }

        public TP.KeyModifiers KeyModifiers => InputConverter.Convert(E.KeyModifiers);

        private IPointerPoint m_CurrentPoint;
        public IPointerPoint CurrentPoint => m_CurrentPoint ??
            (m_CurrentPoint = new PointerPointWrapper(E.GetCurrentPoint(Visual)));

        public ulong Timestamp => E.Timestamp;

        private Coordinate m_Position;
        public Coordinate Position
        {
            get
            {
                if (m_Position == null)
                {
                    Avalonia.Point p = E.GetPosition(Visual);
                    m_Position = new Coordinate(p.X, p.Y);
                }
                return m_Position;
            }
        }

        public PointerEventArgsWrapper(PointerEventArgs e, IVisual visual)
        {
            Guard.Against.Null(e, nameof(e));
            Guard.Against.Null(visual, nameof(visual));
            E = e;
            Visual = visual;
        }
    }
}
