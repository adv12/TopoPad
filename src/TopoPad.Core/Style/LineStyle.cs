namespace TopoPad.Core.Style
{
    public class LineStyle : ColorStyle
    {
        private double m_Width = 1;
        public double Width {
            get => m_Width;
            set => SetField(ref m_Width, value);
        }
    }
}
