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
