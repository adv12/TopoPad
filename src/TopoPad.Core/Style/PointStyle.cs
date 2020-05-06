using Ardalis.GuardClauses;

namespace TopoPad.Core.Style
{
    public class PointStyle : ColorStyle
    {
        private double m_Size = 3;
        public double Size {
            get => m_Size;
            set => SetField(ref m_Size, value);
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

        private PointShape m_Shape = PointShape.Square;
        public PointShape Shape
        {
            get => m_Shape;
            set => SetField(ref m_Shape, value);
        }
    }
}
