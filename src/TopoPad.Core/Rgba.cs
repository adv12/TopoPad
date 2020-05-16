// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TopoPad.Core
{
    [JsonConverter(typeof(RgbaConverter))]
    public struct Rgba
    {
        public static Rgba AliceBlue { get; private set; } = FromHexString("#F0F8FFFF");
        public static Rgba AntiqueWhite { get; private set; } = FromHexString("#FAEBD7FF");
        public static Rgba Aqua { get; private set; } = FromHexString("#00FFFFFF");
        public static Rgba Aquamarine { get; private set; } = FromHexString("#7FFFD4FF");
        public static Rgba Azure { get; private set; } = FromHexString("#F0FFFFFF");
        public static Rgba Beige { get; private set; } = FromHexString("#F5F5DCFF");
        public static Rgba Bisque { get; private set; } = FromHexString("#FFE4C4FF");
        public static Rgba Black { get; private set; } = FromHexString("#000000FF");
        public static Rgba BlanchedAlmond { get; private set; } = FromHexString("#FFEBCDFF");
        public static Rgba Blue { get; private set; } = FromHexString("#0000FFFF");
        public static Rgba BlueViolet { get; private set; } = FromHexString("#8A2BE2FF");
        public static Rgba Brown { get; private set; } = FromHexString("#A52A2AFF");
        public static Rgba BurlyWood { get; private set; } = FromHexString("#DEB887FF");
        public static Rgba CadetBlue { get; private set; } = FromHexString("#5F9EA0FF");
        public static Rgba Chartreuse { get; private set; } = FromHexString("#7FFF00FF");
        public static Rgba Chocolate { get; private set; } = FromHexString("#D2691EFF");
        public static Rgba Coral { get; private set; } = FromHexString("#FF7F50FF");
        public static Rgba CornflowerBlue { get; private set; } = FromHexString("#6495EDFF");
        public static Rgba Cornsilk { get; private set; } = FromHexString("#FFF8DCFF");
        public static Rgba Crimson { get; private set; } = FromHexString("#DC143CFF");
        public static Rgba Cyan { get; private set; } = FromHexString("#00FFFFFF");
        public static Rgba DarkBlue { get; private set; } = FromHexString("#00008BFF");
        public static Rgba DarkCyan { get; private set; } = FromHexString("#008B8BFF");
        public static Rgba DarkGoldenrod { get; private set; } = FromHexString("#B8860BFF");
        public static Rgba DarkGray { get; private set; } = FromHexString("#A9A9A9FF");
        public static Rgba DarkGreen { get; private set; } = FromHexString("#006400FF");
        public static Rgba DarkKhaki { get; private set; } = FromHexString("#BDB76BFF");
        public static Rgba DarkMagenta { get; private set; } = FromHexString("#8B008BFF");
        public static Rgba DarkOliveGreen { get; private set; } = FromHexString("#556B2FFF");
        public static Rgba DarkOrange { get; private set; } = FromHexString("#FF8C00FF");
        public static Rgba DarkOrchid { get; private set; } = FromHexString("#9932CCFF");
        public static Rgba DarkRed { get; private set; } = FromHexString("#8B0000FF");
        public static Rgba DarkSalmon { get; private set; } = FromHexString("#E9967AFF");
        public static Rgba DarkSeaGreen { get; private set; } = FromHexString("#8FBC8BFF");
        public static Rgba DarkSlateBlue { get; private set; } = FromHexString("#483D8BFF");
        public static Rgba DarkSlateGray { get; private set; } = FromHexString("#2F4F4FFF");
        public static Rgba DarkTurquoise { get; private set; } = FromHexString("#00CED1FF");
        public static Rgba DarkViolet { get; private set; } = FromHexString("#9400D3FF");
        public static Rgba DeepPink { get; private set; } = FromHexString("#FF1493FF");
        public static Rgba DeepSkyBlue { get; private set; } = FromHexString("#00BFFFFF");
        public static Rgba DimGray { get; private set; } = FromHexString("#696969FF");
        public static Rgba DodgerBlue { get; private set; } = FromHexString("#1E90FFFF");
        public static Rgba Firebrick { get; private set; } = FromHexString("#B22222FF");
        public static Rgba FloralWhite { get; private set; } = FromHexString("#FFFAF0FF");
        public static Rgba ForestGreen { get; private set; } = FromHexString("#228B22FF");
        public static Rgba Fuchsia { get; private set; } = FromHexString("#FF00FFFF");
        public static Rgba Gainsboro { get; private set; } = FromHexString("#DCDCDCFF");
        public static Rgba GhostWhite { get; private set; } = FromHexString("#F8F8FFFF");
        public static Rgba Gold { get; private set; } = FromHexString("#FFD700FF");
        public static Rgba Goldenrod { get; private set; } = FromHexString("#DAA520FF");
        public static Rgba Gray { get; private set; } = FromHexString("#808080FF");
        public static Rgba Green { get; private set; } = FromHexString("#008000FF");
        public static Rgba GreenYellow { get; private set; } = FromHexString("#ADFF2FFF");
        public static Rgba Honeydew { get; private set; } = FromHexString("#F0FFF0FF");
        public static Rgba HotPink { get; private set; } = FromHexString("#FF69B4FF");
        public static Rgba IndianRed { get; private set; } = FromHexString("#CD5C5CFF");
        public static Rgba Indigo { get; private set; } = FromHexString("#4B0082FF");
        public static Rgba Ivory { get; private set; } = FromHexString("#FFFFF0FF");
        public static Rgba Khaki { get; private set; } = FromHexString("#F0E68CFF");
        public static Rgba Lavender { get; private set; } = FromHexString("#E6E6FAFF");
        public static Rgba LavenderBlush { get; private set; } = FromHexString("#FFF0F5FF");
        public static Rgba LawnGreen { get; private set; } = FromHexString("#7CFC00FF");
        public static Rgba LemonChiffon { get; private set; } = FromHexString("#FFFACDFF");
        public static Rgba LightBlue { get; private set; } = FromHexString("#ADD8E6FF");
        public static Rgba LightCoral { get; private set; } = FromHexString("#F08080FF");
        public static Rgba LightCyan { get; private set; } = FromHexString("#E0FFFFFF");
        public static Rgba LightGoldenrodYellow { get; private set; } = FromHexString("#FAFAD2FF");
        public static Rgba LightGray { get; private set; } = FromHexString("#D3D3D3FF");
        public static Rgba LightGreen { get; private set; } = FromHexString("#90EE90FF");
        public static Rgba LightPink { get; private set; } = FromHexString("#FFB6C1FF");
        public static Rgba LightSalmon { get; private set; } = FromHexString("#FFA07AFF");
        public static Rgba LightSeaGreen { get; private set; } = FromHexString("#20B2AAFF");
        public static Rgba LightSkyBlue { get; private set; } = FromHexString("#87CEFAFF");
        public static Rgba LightSlateGray { get; private set; } = FromHexString("#778899FF");
        public static Rgba LightSteelBlue { get; private set; } = FromHexString("#B0C4DEFF");
        public static Rgba LightYellow { get; private set; } = FromHexString("#FFFFE0FF");
        public static Rgba Lime { get; private set; } = FromHexString("#00FF00FF");
        public static Rgba LimeGreen { get; private set; } = FromHexString("#32CD32FF");
        public static Rgba Linen { get; private set; } = FromHexString("#FAF0E6FF");
        public static Rgba Magenta { get; private set; } = FromHexString("#FF00FFFF");
        public static Rgba Maroon { get; private set; } = FromHexString("#800000FF");
        public static Rgba MediumAquamarine { get; private set; } = FromHexString("#66CDAAFF");
        public static Rgba MediumBlue { get; private set; } = FromHexString("#0000CDFF");
        public static Rgba MediumOrchid { get; private set; } = FromHexString("#BA55D3FF");
        public static Rgba MediumPurple { get; private set; } = FromHexString("#9370DBFF");
        public static Rgba MediumSeaGreen { get; private set; } = FromHexString("#3CB371FF");
        public static Rgba MediumSlateBlue { get; private set; } = FromHexString("#7B68EEFF");
        public static Rgba MediumSpringGreen { get; private set; } = FromHexString("#00FA9AFF");
        public static Rgba MediumTurquoise { get; private set; } = FromHexString("#48D1CCFF");
        public static Rgba MediumVioletRed { get; private set; } = FromHexString("#C71585FF");
        public static Rgba MidnightBlue { get; private set; } = FromHexString("#191970FF");
        public static Rgba MintCream { get; private set; } = FromHexString("#F5FFFAFF");
        public static Rgba MistyRose { get; private set; } = FromHexString("#FFE4E1FF");
        public static Rgba Moccasin { get; private set; } = FromHexString("#FFE4B5FF");
        public static Rgba NavajoWhite { get; private set; } = FromHexString("#FFDEADFF");
        public static Rgba Navy { get; private set; } = FromHexString("#000080FF");
        public static Rgba OldLace { get; private set; } = FromHexString("#FDF5E6FF");
        public static Rgba Olive { get; private set; } = FromHexString("#808000FF");
        public static Rgba OliveDrab { get; private set; } = FromHexString("#6B8E23FF");
        public static Rgba Orange { get; private set; } = FromHexString("#FFA500FF");
        public static Rgba OrangeRed { get; private set; } = FromHexString("#FF4500FF");
        public static Rgba Orchid { get; private set; } = FromHexString("#DA70D6FF");
        public static Rgba PaleGoldenrod { get; private set; } = FromHexString("#EEE8AAFF");
        public static Rgba PaleGreen { get; private set; } = FromHexString("#98FB98FF");
        public static Rgba PaleTurquoise { get; private set; } = FromHexString("#AFEEEEFF");
        public static Rgba PaleVioletRed { get; private set; } = FromHexString("#DB7093FF");
        public static Rgba PapayaWhip { get; private set; } = FromHexString("#FFEFD5FF");
        public static Rgba PeachPuff { get; private set; } = FromHexString("#FFDAB9FF");
        public static Rgba Peru { get; private set; } = FromHexString("#CD853FFF");
        public static Rgba Pink { get; private set; } = FromHexString("#FFC0CBFF");
        public static Rgba Plum { get; private set; } = FromHexString("#DDA0DDFF");
        public static Rgba PowderBlue { get; private set; } = FromHexString("#B0E0E6FF");
        public static Rgba Purple { get; private set; } = FromHexString("#800080FF");
        public static Rgba Red { get; private set; } = FromHexString("#FF0000FF");
        public static Rgba RosyBrown { get; private set; } = FromHexString("#BC8F8FFF");
        public static Rgba RoyalBlue { get; private set; } = FromHexString("#4169E1FF");
        public static Rgba SaddleBrown { get; private set; } = FromHexString("#8B4513FF");
        public static Rgba Salmon { get; private set; } = FromHexString("#FA8072FF");
        public static Rgba SandyBrown { get; private set; } = FromHexString("#F4A460FF");
        public static Rgba SeaGreen { get; private set; } = FromHexString("#2E8B57FF");
        public static Rgba SeaShell { get; private set; } = FromHexString("#FFF5EEFF");
        public static Rgba Sienna { get; private set; } = FromHexString("#A0522DFF");
        public static Rgba Silver { get; private set; } = FromHexString("#C0C0C0FF");
        public static Rgba SkyBlue { get; private set; } = FromHexString("#87CEEBFF");
        public static Rgba SlateBlue { get; private set; } = FromHexString("#6A5ACDFF");
        public static Rgba SlateGray { get; private set; } = FromHexString("#708090FF");
        public static Rgba Snow { get; private set; } = FromHexString("#FFFAFAFF");
        public static Rgba SpringGreen { get; private set; } = FromHexString("#00FF7FFF");
        public static Rgba SteelBlue { get; private set; } = FromHexString("#4682B4FF");
        public static Rgba Tan { get; private set; } = FromHexString("#D2B48CFF");
        public static Rgba Teal { get; private set; } = FromHexString("#008080FF");
        public static Rgba Thistle { get; private set; } = FromHexString("#D8BFD8FF");
        public static Rgba Tomato { get; private set; } = FromHexString("#FF6347FF");
        public static Rgba Turquoise { get; private set; } = FromHexString("#40E0D0FF");
        public static Rgba Violet { get; private set; } = FromHexString("#EE82EEFF");
        public static Rgba Wheat { get; private set; } = FromHexString("#F5DEB3FF");
        public static Rgba White { get; private set; } = FromHexString("#FFFFFFFF");
        public static Rgba WhiteSmoke { get; private set; } = FromHexString("#F5F5F5FF");
        public static Rgba Yellow { get; private set; } = FromHexString("#FFFF00FF");
        public static Rgba YellowGreen { get; private set; } = FromHexString("#9ACD32FF");
        public static Rgba TransparentBlack { get; private set; } = new Rgba(0, 0, 0, 0);
        public static Rgba TransparentWhite { get; private set; } = new Rgba(255, 255, 255, 0);

        public static Rgba FromHexString(string hex)
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

        public string ToHexString()
        {
            return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2") + A.ToString("X2");
        }

        public class RgbaConverter : JsonConverter<Rgba>
        {
            public override Rgba Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options) =>
                    Rgba.FromHexString(reader.GetString());

            public override void Write(
                Utf8JsonWriter writer,
                Rgba rgba,
                JsonSerializerOptions options) =>
                    writer.WriteStringValue(rgba.ToHexString());
        }
    }
}
