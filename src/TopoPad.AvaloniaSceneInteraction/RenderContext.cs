using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using System.Linq;
using TopoPad.Core;
using TopoPad.Core.Style;
using AM = Avalonia.Media;
using A = Avalonia;
using Avalonia.Media;

namespace TopoPad.AvaloniaSceneInteraction
{
    public class RenderContext : IRenderContext
    {
        public IViewport Viewport { get; }

        private AM.DrawingContext m_Context;

        public RenderContext(IViewport viewport, AM.DrawingContext drawingContext)
        {
            Guard.Against.Null(viewport, nameof(viewport));
            Guard.Against.Null(drawingContext, nameof(drawingContext));
            Viewport = viewport;
            m_Context = drawingContext;
        }

        public void DrawImage(IImage image, int sourceX, int sourceY, int sourceWidth, int sourceHeight, int level,
            Envelope bounds, bool fast)
        {
            
        }

        public void DrawLineString(LineString lineString, LineStyle lineStyle, PointStyle vertexStyle, bool fast)
        {
            LineString viewLineString = (LineString)Viewport.GetViewGeometry(lineString);
            AM.PolylineGeometry geometry = new AM.PolylineGeometry(
                viewLineString.Coordinates.Select(c => new A.Point(c.X, c.Y)), false);
            m_Context.DrawGeometry(null, new AM.Pen(lineStyle.ForeColor.Argb, lineStyle.Width), geometry);
        }

        public void DrawPoint(Point point, PointStyle style, bool fast)
        {
            
        }

        public void DrawPolygon(Polygon polygon, FillStyle fillStyle, LineStyle lineStyle,
            PointStyle vertexStyle, bool fast)
        {
            Polygon viewPolygon = (Polygon)Viewport.GetViewGeometry(polygon);
            AM.PathGeometry geometry = new AM.PathGeometry();
            AM.StreamGeometryContext geometryContext = geometry.Open();
            DrawPolygonRing(viewPolygon.Shell, false, geometryContext);
            foreach (LinearRing hole in viewPolygon.Holes)
            {
                DrawPolygonRing(hole, true, geometryContext);
            }
            m_Context.DrawGeometry(new SolidColorBrush(fillStyle.ForeColor.Argb),
                new Pen(new SolidColorBrush(lineStyle.ForeColor.Argb)),
                geometry);
        }

        private void DrawPolygonRing(LinearRing ring, bool isHole, AM.StreamGeometryContext geometryContext)
        {
            Coordinate[] coords = ring.Coordinates;
            geometryContext.BeginFigure(new A.Point(coords[0].X, coords[0].Y), !isHole);
            for (int i = 1; i < coords.Length; i++)
            {
                geometryContext.LineTo(new A.Point(coords[i].X, coords[i].Y));
            }
            geometryContext.EndFigure(true);
        }
    }
}
