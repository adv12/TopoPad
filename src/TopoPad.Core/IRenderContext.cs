using NetTopologySuite.Geometries;
using TopoPad.Core.Style;

namespace TopoPad.Core
{
    public interface IRenderContext
    {
        IViewport Viewport { get; }

        void DrawPoint(Point point, PointStyle style, bool fast);

        void DrawLineString(LineString lineString, LineStyle lineStyle, PointStyle vertexStyle, bool fast);

        void DrawPolygon(Polygon polygon, FillStyle fillStyle, LineStyle lineStyle, PointStyle vertexStyle, bool fast);

        void DrawImage(IImage image, int sourceX, int sourceY, int sourceWidth, int sourceHeight, int level,
            Envelope bounds, bool fast);
    }
}
