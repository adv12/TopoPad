// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IVector
    {
        public double X { get; }

        public double Y { get; }

        public double Length { get; }

        public double SquaredLength { get; }
    }
}
