using System;
using System.Collections.Generic;
using System.Text;

namespace TopoPad.Core.Style
{
    public class FeatureStyleSet: PropertyNotifier
    {
        private PointStyle m_PointStyle;
        public PointStyle PointStyle
        {
            get => m_PointStyle;
            set => SetField(ref m_PointStyle, value);
        }

        private LineStyle m_LineStyle;
        public LineStyle LineStyle
        {
            get => m_LineStyle;
            set => SetField(ref m_LineStyle, value);
        }

        private PointStyle m_VertexStyle;
        public PointStyle VertexStyle
        {
            get => m_VertexStyle;
            set => SetField(ref m_VertexStyle, value);
        }

        private FillStyle m_FillStyle;
        public FillStyle FillStyle
        {
            get => m_FillStyle;
            set => SetField(ref m_FillStyle, value);
        }
    }
}
