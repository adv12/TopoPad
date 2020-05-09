// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia;
using TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class VectorWrapper : IVector
    {
        private Vector V;

        public double X => V.X;

        public double Y => V.Y;

        public double Length => V.Length;

        public double SquaredLength => V.SquaredLength;

        public VectorWrapper(Vector vector)
        {
            V = vector;
        }
    }
}
