namespace TopoPad.Core.Style
{
    public class LineStyle : ColorStyle
    {
        private LineType m_Type = LineType.Solid;
        public LineType Type
        {
            get => m_Type;
            set => SetField(ref m_Type, value);
        }

        private double m_Width = 1;
        public double Width {
            get => m_Width;
            set => SetField(ref m_Width, value);
        }
    }
}
