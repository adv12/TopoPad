// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.Core.Style
{
    public class ColorStyle : StyleNotifier
    {
        private Rgba m_Color = Rgba.Black;
        public Rgba Color
        {
            get => m_Color;
            set => SetField(ref m_Color, value);
        }
    }
}
