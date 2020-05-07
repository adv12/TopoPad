// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using NetTopologySuite.Geometries;

namespace TopoPad.Core.Layers
{
    public interface ILayer : IGroupNode
    {
        double Opacity { get; set; }
        bool Selected { get; set; }
        void Render(IRenderContext renderContext, bool fast);
    }
}
