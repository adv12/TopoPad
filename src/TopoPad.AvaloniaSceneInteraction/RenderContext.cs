using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using System.Linq;
using TopoPad.Core;
using TopoPad.Core.Style;
using AM = Avalonia.Media;
using A = Avalonia;
using Avalonia.Media;
using TopoPad.Core.Layers;
using TopoPad.SceneInteraction;

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

        public void RenderScene(IScene scene, bool fast)
        {
            m_Context.FillRectangle(new SolidColorBrush(scene.Document.BackColor.Argb),
                    new A.Rect(new A.Point(0, 0), new A.Size(scene.Width, scene.Height)));
            RenderGroup(scene.Document, fast);
            scene.Drawn = true;
        }

        public void RenderGroup(IGroup group, bool fast)
        {
            foreach (IGroupNode childNode in group.ChildNodes)
            {
                if (childNode is ILayer layer)
                {
                    RenderLayer(layer, fast);
                }
                else if (childNode is IGroup g)
                {
                    RenderGroup(g, fast);
                }
            }
        }

        public void RenderLayer(ILayer layer, bool fast)
        {
            using (DrawingContext.PushedState state = m_Context.PushOpacity(layer.Opacity))
            {
                layer.Render(this, fast);
            }
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
            m_Context.DrawGeometry(null, GetPen(lineStyle), geometry);
            DrawCoordinates(viewLineString.Coordinates, vertexStyle, fast);
        }

        public void DrawPoint(Point point, PointStyle style, bool fast)
        {
            Point viewPoint = (Point)Viewport.GetViewGeometry(point);
            A.Rect rect = GetPointRect(viewPoint.Coordinate, style.Size);
            Brush brush = GetBrush(style.FillStyle);
            Pen pen = GetPen(style.LineStyle);
            AM.Geometry geometry;
            if (style.Shape == PointShape.Circle)
            {
                geometry = new EllipseGeometry(rect);
            }
            else
            {
                geometry = new RectangleGeometry(rect);
            }
            m_Context.DrawGeometry(brush, pen, geometry);
        }

        private void DrawCoordinates(Coordinate[] coords, PointStyle style, bool fast, bool skipLast = false)
        {
            Brush brush = GetBrush(style.FillStyle);
            Pen pen = GetPen(style.LineStyle);
            int max = (skipLast ? coords.Length - 1 : coords.Length);
            for (int i = 0; i < max; i++)
            {
                A.Rect rect = GetPointRect(coords[i], style.Size);
                AM.Geometry geometry;
                if (style.Shape == PointShape.Circle)
                {
                    geometry = new EllipseGeometry(rect);
                }
                else
                {
                    geometry = new RectangleGeometry(rect);
                }
                m_Context.DrawGeometry(brush, pen, geometry);
            }
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
            DrawCoordinates(viewPolygon.Shell.Coordinates, vertexStyle, fast, true);
            foreach (LinearRing hole in viewPolygon.Holes)
            {
                DrawCoordinates(hole.Coordinates, vertexStyle, fast, true);
            }
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

        private Brush GetBrush(FillStyle fillStyle)
        {
            if (fillStyle == null)
            {
                return null;
            }
            return new SolidColorBrush(fillStyle.ForeColor.Argb);
        }

        private Pen GetPen(LineStyle lineStyle)
        {
            if (lineStyle == null || lineStyle.Type == LineType.None || lineStyle.Width == 0)
            {
                return null;
            }
            if (lineStyle.Type == LineType.Solid)
            {
                return new Pen(new SolidColorBrush(lineStyle.ForeColor.Argb), lineStyle.Width);
            }
            IDashStyle dashStyle = null;
            switch (lineStyle.Type)
            {
                case LineType.DashDot:
                    dashStyle = DashStyle.DashDot;
                    break;
                case LineType.DashDotDot:
                    dashStyle = DashStyle.DashDotDot;
                    break;
                case LineType.Dot:
                    dashStyle = DashStyle.Dot;
                    break;
                default:
                    dashStyle = DashStyle.Dash;
                    break;
            }
            return new Pen(new SolidColorBrush(lineStyle.ForeColor.Argb), lineStyle.Width, dashStyle);
        }

        private A.Rect GetPointRect(Coordinate c, double size)
        {
            double halfSize = size / 2;
            return new A.Rect(c.X - halfSize, c.Y - halfSize, size, size);
        }
    }
}
