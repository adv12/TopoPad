// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Ardalis.GuardClauses;

namespace TopoPad.Core.Style
{
    public class FeatureStyleSet : StyleNotifier
    {
        private PointStyle m_PointStyle = new PointStyle();
        public PointStyle PointStyle
        {
            get => m_PointStyle;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_PointStyle, value);
            }
        }

        private LineStyle m_LineStyle = new LineStyle();
        public LineStyle LineStyle
        {
            get => m_LineStyle;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_LineStyle, value);
            }
        }

        private PointStyle m_VertexStyle = new PointStyle()
        {
            FillStyle = new FillStyle
            {
                Color = Rgba.White
            }
        };
        public PointStyle VertexStyle
        {
            get => m_VertexStyle;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_VertexStyle, value);
            }
        }

        private FillStyle m_FillStyle = new FillStyle();
        public FillStyle FillStyle
        {
            get => m_FillStyle;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_FillStyle, value);
            }
        }
    }
}
