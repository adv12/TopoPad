// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.ComponentModel;
using System.Linq;
using Ardalis.GuardClauses;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Utilities;

namespace TopoPad.Core
{
    public interface IViewport : INotifyPropertyChanged
    {
        double Width { get; }

        double Height { get; }

        double WorldWidth => Width / Scale;

        double WorldHeight => Height / Scale;

        double Scale { get; set; }

        bool FlipX { get; }

        bool FlipY { get; }

        int XMultiplier => FlipX ? -1 : 1;

        int YMultiplier => FlipY ? -1 : 1;

        double CenterX { get; set; }

        double CenterY { get; set; }

        Coordinate Center => new Coordinate(CenterX, CenterY);

        AffineTransformation ViewToWorldTransform { get; }

        AffineTransformation WorldToViewTransform { get; }

        Envelope ViewExtent => new Envelope(0, Width, 0, Height);

        Envelope WorldViewExtent => ViewToWorld(ViewExtent);

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

        void Fit(IBoundedItem item, double paddingFraction = 0)
        {
            Fit(item?.Bounds, paddingFraction);
        }

        void Fit(Envelope envelope, double paddingFraction = 0)
        {
            Guard.Against.OutOfRange(paddingFraction, nameof(paddingFraction), 0, double.MaxValue);
            if (envelope == null || envelope.IsNull)
            {
                return;
            }
            CenterOn(envelope);
            double viewAspectRatio = Width / Height;
            double envelopeAspectRatio = envelope.Width / envelope.Height;
            if (envelopeAspectRatio > viewAspectRatio)
            {
                double targetWidth = envelope.Width * (1 + paddingFraction);
                Scale *= WorldViewExtent.Width / targetWidth;
            }
            else
            {
                double targetHeight = envelope.Height * (1 + paddingFraction);
                Scale *= WorldViewExtent.Height / targetHeight;
            }
        }

        void CenterOn(IBoundedItem item)
        {
            CenterOn(item.Bounds);
        }

        void CenterOn(Envelope envelope)
        {
            if (envelope == null || envelope.IsNull)
            {
                return;
            }
            CenterOn(envelope.Centre.X, envelope.Centre.Y);
        }

        void CenterOn(Coordinate c)
        {
            CenterOn(c.X, c.Y);
        }

        void CenterOn(double x, double y)
        {
            CenterX = x;
            CenterY = y;
        }

        void PanView(double viewRight, double viewUp)
        {
            Pan(viewRight / Scale, viewUp / Scale);
        }

        void Pan(double worldX, double worldY)
        {
            CenterOn(CenterX + worldX, CenterY + worldY);
        }

        void PanFraction(double worldFractionX, double worldFractionY)
        {
            Pan(WorldWidth * worldFractionX, WorldHeight * worldFractionY);
        }
    }
}
