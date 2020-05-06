namespace TopoPad.Core.Style
{
    public class PointStyle : ColorStyle
    {
        private double m_Size = 3;
        double Size {
            get => m_Size;
            set => SetField(ref m_Size, value);
        }
    }
}
