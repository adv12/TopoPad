using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Utilities;
using System.ComponentModel;
using System.Linq;

namespace TopoPad.Core
{
    public interface IViewport : INotifyPropertyChanged
    {
        double Width { get; }

        double Height { get; }

        double Scale { get; set; }

        double CenterX { get; set; }

        double CenterY { get; set; }

        AffineTransformation ViewToWorldTransform { get; }

        AffineTransformation WorldToViewTransform { get; }

        void CacheViewGeometry(Geometry worldGeometry, Geometry viewGeometry);

        Geometry GetCachedViewGeometry(Geometry worldGeometry);

        Geometry GetViewGeometry(Geometry worldGeometry)
        {
            Geometry viewGeometry = GetCachedViewGeometry(worldGeometry);
            if (viewGeometry == null)
            {
                viewGeometry = WorldToViewTransform.Transform(worldGeometry);
                if (viewGeometry is Polygon polygon)
                {
                    if (!polygon.Shell.IsCCW || polygon.Holes.Any(h => h.IsCCW))
                    {
                        // Clone with default precision model
                        polygon = (Polygon)GeometryFactory.Default.CreateGeometry(polygon);
                        LinearRing shell = polygon.Shell.IsCCW ? polygon.Shell : (LinearRing)polygon.Shell.Reverse();
                        LinearRing[] holes = polygon.Holes;
                        for (int i = 0; i < holes.Length; i++)
                        {
                            if (holes[i].IsCCW)
                            {
                                holes[i] = (LinearRing)holes[i].Reverse();
                            }
                        }
                        viewGeometry = new Polygon(shell, holes);
                    }
                }
                CacheViewGeometry(worldGeometry, viewGeometry);
            }
            return viewGeometry;
        }

        Envelope ViewToWorld(Envelope viewEnvelope)
        {
            Guard.Against.Null(viewEnvelope, nameof(viewEnvelope));
            if (viewEnvelope.IsNull)
            {
                return viewEnvelope;
            }
            Envelope worldEnvelope = new Envelope();
            Coordinate src = new Coordinate(0, 0);
            AffineTransformation transform = ViewToWorldTransform;
            worldEnvelope.ExpandToInclude(transform.Transform(src, src));
            src.X = Width;
            src.Y = Height;
            worldEnvelope.ExpandToInclude(transform.Transform(src, src));
            return worldEnvelope;
        }

        Envelope WorldToView(Envelope worldEnvelope)
        {
            Guard.Against.Null(worldEnvelope, nameof(worldEnvelope));
            if (worldEnvelope.IsNull)
            {
                return worldEnvelope;
            }
            Envelope viewEnvelope = new Envelope();
            Coordinate src = new Coordinate(0, 0);
            AffineTransformation transform = ViewToWorldTransform;
            worldEnvelope.ExpandToInclude(transform.Transform(src, src));
            src.X = Width;
            src.Y = Height;
            worldEnvelope.ExpandToInclude(transform.Transform(src, src));
            return worldEnvelope;
        }
    }
}
