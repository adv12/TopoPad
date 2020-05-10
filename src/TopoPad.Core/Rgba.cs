// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;

namespace TopoPad.Core
{
    public struct Rgba
    {
        public static Rgba AliceBlue { get; private set; } = FromHex("#F0F8FFFF");
        public static Rgba AntiqueWhite { get; private set; } = FromHex("#FAEBD7FF");
        public static Rgba Aqua { get; private set; } = FromHex("#00FFFFFF");
        public static Rgba Aquamarine { get; private set; } = FromHex("#7FFFD4FF");
        public static Rgba Azure { get; private set; } = FromHex("#F0FFFFFF");
        public static Rgba Beige { get; private set; } = FromHex("#F5F5DCFF");
        public static Rgba Bisque { get; private set; } = FromHex("#FFE4C4FF");
        public static Rgba Black { get; private set; } = FromHex("#000000FF");
        public static Rgba BlanchedAlmond { get; private set; } = FromHex("#FFEBCDFF");
        public static Rgba Blue { get; private set; } = FromHex("#0000FFFF");
        public static Rgba BlueViolet { get; private set; } = FromHex("#8A2BE2FF");
        public static Rgba Brown { get; private set; } = FromHex("#A52A2AFF");
        public static Rgba BurlyWood { get; private set; } = FromHex("#DEB887FF");
        public static Rgba CadetBlue { get; private set; } = FromHex("#5F9EA0FF");
        public static Rgba Chartreuse { get; private set; } = FromHex("#7FFF00FF");
        public static Rgba Chocolate { get; private set; } = FromHex("#D2691EFF");
        public static Rgba Coral { get; private set; } = FromHex("#FF7F50FF");
        public static Rgba CornflowerBlue { get; private set; } = FromHex("#6495EDFF");
        public static Rgba Cornsilk { get; private set; } = FromHex("#FFF8DCFF");
        public static Rgba Crimson { get; private set; } = FromHex("#DC143CFF");
        public static Rgba Cyan { get; private set; } = FromHex("#00FFFFFF");
        public static Rgba DarkBlue { get; private set; } = FromHex("#00008BFF");
        public static Rgba DarkCyan { get; private set; } = FromHex("#008B8BFF");
        public static Rgba DarkGoldenrod { get; private set; } = FromHex("#B8860BFF");
        public static Rgba DarkGray { get; private set; } = FromHex("#A9A9A9FF");
        public static Rgba DarkGreen { get; private set; } = FromHex("#006400FF");
        public static Rgba DarkKhaki { get; private set; } = FromHex("#BDB76BFF");
        public static Rgba DarkMagenta { get; private set; } = FromHex("#8B008BFF");
        public static Rgba DarkOliveGreen { get; private set; } = FromHex("#556B2FFF");
        public static Rgba DarkOrange { get; private set; } = FromHex("#FF8C00FF");
        public static Rgba DarkOrchid { get; private set; } = FromHex("#9932CCFF");
        public static Rgba DarkRed { get; private set; } = FromHex("#8B0000FF");
        public static Rgba DarkSalmon { get; private set; } = FromHex("#E9967AFF");
        public static Rgba DarkSeaGreen { get; private set; } = FromHex("#8FBC8BFF");
        public static Rgba DarkSlateBlue { get; private set; } = FromHex("#483D8BFF");
        public static Rgba DarkSlateGray { get; private set; } = FromHex("#2F4F4FFF");
        public static Rgba DarkTurquoise { get; private set; } = FromHex("#00CED1FF");
        public static Rgba DarkViolet { get; private set; } = FromHex("#9400D3FF");
        public static Rgba DeepPink { get; private set; } = FromHex("#FF1493FF");
        public static Rgba DeepSkyBlue { get; private set; } = FromHex("#00BFFFFF");
        public static Rgba DimGray { get; private set; } = FromHex("#696969FF");
        public static Rgba DodgerBlue { get; private set; } = FromHex("#1E90FFFF");
        public static Rgba Firebrick { get; private set; } = FromHex("#B22222FF");
        public static Rgba FloralWhite { get; private set; } = FromHex("#FFFAF0FF");
        public static Rgba ForestGreen { get; private set; } = FromHex("#228B22FF");
        public static Rgba Fuchsia { get; private set; } = FromHex("#FF00FFFF");
        public static Rgba Gainsboro { get; private set; } = FromHex("#DCDCDCFF");
        public static Rgba GhostWhite { get; private set; } = FromHex("#F8F8FFFF");
        public static Rgba Gold { get; private set; } = FromHex("#FFD700FF");
        public static Rgba Goldenrod { get; private set; } = FromHex("#DAA520FF");
        public static Rgba Gray { get; private set; } = FromHex("#808080FF");
        public static Rgba Green { get; private set; } = FromHex("#008000FF");
        public static Rgba GreenYellow { get; private set; } = FromHex("#ADFF2FFF");
        public static Rgba Honeydew { get; private set; } = FromHex("#F0FFF0FF");
        public static Rgba HotPink { get; private set; } = FromHex("#FF69B4FF");
        public static Rgba IndianRed { get; private set; } = FromHex("#CD5C5CFF");
        public static Rgba Indigo { get; private set; } = FromHex("#4B0082FF");
        public static Rgba Ivory { get; private set; } = FromHex("#FFFFF0FF");
        public static Rgba Khaki { get; private set; } = FromHex("#F0E68CFF");
        public static Rgba Lavender { get; private set; } = FromHex("#E6E6FAFF");
        public static Rgba LavenderBlush { get; private set; } = FromHex("#FFF0F5FF");
        public static Rgba LawnGreen { get; private set; } = FromHex("#7CFC00FF");
        public static Rgba LemonChiffon { get; private set; } = FromHex("#FFFACDFF");
        public static Rgba LightBlue { get; private set; } = FromHex("#ADD8E6FF");
        public static Rgba LightCoral { get; private set; } = FromHex("#F08080FF");
        public static Rgba LightCyan { get; private set; } = FromHex("#E0FFFFFF");
        public static Rgba LightGoldenrodYellow { get; private set; } = FromHex("#FAFAD2FF");
        public static Rgba LightGray { get; private set; } = FromHex("#D3D3D3FF");
        public static Rgba LightGreen { get; private set; } = FromHex("#90EE90FF");
        public static Rgba LightPink { get; private set; } = FromHex("#FFB6C1FF");
        public static Rgba LightSalmon { get; private set; } = FromHex("#FFA07AFF");
        public static Rgba LightSeaGreen { get; private set; } = FromHex("#20B2AAFF");
        public static Rgba LightSkyBlue { get; private set; } = FromHex("#87CEFAFF");
        public static Rgba LightSlateGray { get; private set; } = FromHex("#778899FF");
        public static Rgba LightSteelBlue { get; private set; } = FromHex("#B0C4DEFF");
        public static Rgba LightYellow { get; private set; } = FromHex("#FFFFE0FF");
        public static Rgba Lime { get; private set; } = FromHex("#00FF00FF");
        public static Rgba LimeGreen { get; private set; } = FromHex("#32CD32FF");
        public static Rgba Linen { get; private set; } = FromHex("#FAF0E6FF");
        public static Rgba Magenta { get; private set; } = FromHex("#FF00FFFF");
        public static Rgba Maroon { get; private set; } = FromHex("#800000FF");
        public static Rgba MediumAquamarine { get; private set; } = FromHex("#66CDAAFF");
        public static Rgba MediumBlue { get; private set; } = FromHex("#0000CDFF");
        public static Rgba MediumOrchid { get; private set; } = FromHex("#BA55D3FF");
        public static Rgba MediumPurple { get; private set; } = FromHex("#9370DBFF");
        public static Rgba MediumSeaGreen { get; private set; } = FromHex("#3CB371FF");
        public static Rgba MediumSlateBlue { get; private set; } = FromHex("#7B68EEFF");
        public static Rgba MediumSpringGreen { get; private set; } = FromHex("#00FA9AFF");
        public static Rgba MediumTurquoise { get; private set; } = FromHex("#48D1CCFF");
        public static Rgba MediumVioletRed { get; private set; } = FromHex("#C71585FF");
        public static Rgba MidnightBlue { get; private set; } = FromHex("#191970FF");
        public static Rgba MintCream { get; private set; } = FromHex("#F5FFFAFF");
        public static Rgba MistyRose { get; private set; } = FromHex("#FFE4E1FF");
        public static Rgba Moccasin { get; private set; } = FromHex("#FFE4B5FF");
        public static Rgba NavajoWhite { get; private set; } = FromHex("#FFDEADFF");
        public static Rgba Navy { get; private set; } = FromHex("#000080FF");
        public static Rgba OldLace { get; private set; } = FromHex("#FDF5E6FF");
        public static Rgba Olive { get; private set; } = FromHex("#808000FF");
        public static Rgba OliveDrab { get; private set; } = FromHex("#6B8E23FF");
        public static Rgba Orange { get; private set; } = FromHex("#FFA500FF");
        public static Rgba OrangeRed { get; private set; } = FromHex("#FF4500FF");
        public static Rgba Orchid { get; private set; } = FromHex("#DA70D6FF");
        public static Rgba PaleGoldenrod { get; private set; } = FromHex("#EEE8AAFF");
        public static Rgba PaleGreen { get; private set; } = FromHex("#98FB98FF");
        public static Rgba PaleTurquoise { get; private set; } = FromHex("#AFEEEEFF");
        public static Rgba PaleVioletRed { get; private set; } = FromHex("#DB7093FF");
        public static Rgba PapayaWhip { get; private set; } = FromHex("#FFEFD5FF");
        public static Rgba PeachPuff { get; private set; } = FromHex("#FFDAB9FF");
        public static Rgba Peru { get; private set; } = FromHex("#CD853FFF");
        public static Rgba Pink { get; private set; } = FromHex("#FFC0CBFF");
        public static Rgba Plum { get; private set; } = FromHex("#DDA0DDFF");
        public static Rgba PowderBlue { get; private set; } = FromHex("#B0E0E6FF");
        public static Rgba Purple { get; private set; } = FromHex("#800080FF");
        public static Rgba Red { get; private set; } = FromHex("#FF0000FF");
        public static Rgba RosyBrown { get; private set; } = FromHex("#BC8F8FFF");
        public static Rgba RoyalBlue { get; private set; } = FromHex("#4169E1FF");
        public static Rgba SaddleBrown { get; private set; } = FromHex("#8B4513FF");
        public static Rgba Salmon { get; private set; } = FromHex("#FA8072FF");
        public static Rgba SandyBrown { get; private set; } = FromHex("#F4A460FF");
        public static Rgba SeaGreen { get; private set; } = FromHex("#2E8B57FF");
        public static Rgba SeaShell { get; private set; } = FromHex("#FFF5EEFF");
        public static Rgba Sienna { get; private set; } = FromHex("#A0522DFF");
        public static Rgba Silver { get; private set; } = FromHex("#C0C0C0FF");
        public static Rgba SkyBlue { get; private set; } = FromHex("#87CEEBFF");
        public static Rgba SlateBlue { get; private set; } = FromHex("#6A5ACDFF");
        public static Rgba SlateGray { get; private set; } = FromHex("#708090FF");
        public static Rgba Snow { get; private set; } = FromHex("#FFFAFAFF");
        public static Rgba SpringGreen { get; private set; } = FromHex("#00FF7FFF");
        public static Rgba SteelBlue { get; private set; } = FromHex("#4682B4FF");
        public static Rgba Tan { get; private set; } = FromHex("#D2B48CFF");
        public static Rgba Teal { get; private set; } = FromHex("#008080FF");
        public static Rgba Thistle { get; private set; } = FromHex("#D8BFD8FF");
        public static Rgba Tomato { get; private set; } = FromHex("#FF6347FF");
        public static Rgba Turquoise { get; private set; } = FromHex("#40E0D0FF");
        public static Rgba Violet { get; private set; } = FromHex("#EE82EEFF");
        public static Rgba Wheat { get; private set; } = FromHex("#F5DEB3FF");
        public static Rgba White { get; private set; } = FromHex("#FFFFFFFF");
        public static Rgba WhiteSmoke { get; private set; } = FromHex("#F5F5F5FF");
        public static Rgba Yellow { get; private set; } = FromHex("#FFFF00FF");
        public static Rgba YellowGreen { get; private set; } = FromHex("#9ACD32FF");
        public static Rgba TransparentBlack { get; private set; } = new Rgba(0, 0, 0, 0);
        public static Rgba TransparentWhite { get; private set; } = new Rgba(255, 255, 255, 0);

        public static Rgba FromHex(string hex)
        {
            hex = hex.Trim().ToLowerInvariant().Replace("#", "");
            int length = hex.Length;
            if (length == 1 || length == 2)
            {
                return new Rgba(GetHexByte(hex), 255);
            }
            else if (length == 3 || length == 4)
            {
                byte r = GetHexByte(hex.Substring(0, 1));
                byte g = GetHexByte(hex.Substring(1, 1));
                byte b = GetHexByte(hex.Substring(2, 1));
                byte a = length == 4 ? GetHexByte(hex.Substring(3, 1)) : (byte)255;
                return new Rgba(r, g, b, a);
            }
            else if (length == 6 || length == 8)
            {
                byte r = GetHexByte(hex.Substring(0, 2));
                byte g = GetHexByte(hex.Substring(2, 2));
                byte b = GetHexByte(hex.Substring(4, 2));
                byte a = length == 8 ? GetHexByte(hex.Substring(6, 2)) : (byte)255;
                return new Rgba(r, g, b, a);
            }
            return White;
        }

        private static byte GetHexByte(string hex)
        {
            if (hex.Length == 1)
            {
                hex += hex;
            }
            return Convert.ToByte(hex, 16);
        }

        public uint Value;

        public uint R => (Value >> 24) & 255;

        public uint G => (Value >> 16) & 255;

        public uint B => (Value >> 8) & 255;

        public uint A => Value & 255;

        public uint Argb => A << 24 | R << 16 | G << 8 | B;

        public Rgba(uint value)
        {
            Value = value;
        }

        public Rgba(byte grayscaleValue, byte a) : this(grayscaleValue, grayscaleValue, grayscaleValue, a)
        {

        }

        public Rgba(byte red, byte green, byte blue) : this(red, green, blue, 255)
        {

        }

        public Rgba(byte red, byte green, byte blue, byte alpha)
        {
            Value = ((uint)red << 24) | ((uint)green << 16) | ((uint)blue << 8) | alpha;
        }
    }
}
