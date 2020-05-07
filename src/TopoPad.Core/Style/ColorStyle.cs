// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.Core.Style
{
    public class ColorStyle : StyleNotifier
    {
        private Rgba m_ForeColor = Rgba.Black;
        public Rgba ForeColor
        {
            get => m_ForeColor;
            set => SetField(ref m_ForeColor, value);
        }

        private Rgba m_BackColor = Rgba.TransparentWhite;
        public Rgba BackColor
        {
            get => m_BackColor;
            set => SetField(ref m_BackColor, value);
        }
    }
}
