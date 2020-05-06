using NetTopologySuite.Geometries;

namespace TopoPad.Core.Layers
{
    public interface ILayer : IGroupNode
    {
        bool Selected { get; set; }
        void Render(IRenderContext renderContext, bool fast);
    }
}
