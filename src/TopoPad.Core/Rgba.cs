namespace TopoPad.Core
{
    public struct Rgba
    {
        public static readonly Rgba Black = new Rgba(0, 0, 0, 255);
        public static readonly Rgba White = new Rgba(255, 255, 255, 255);
        public static readonly Rgba TransparentBlack = new Rgba(0, 0, 0, 0);
        public static readonly Rgba TransparentWhite = new Rgba(255, 255, 255, 0);

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

        public Rgba (byte grayscaleValue, byte a) : this(grayscaleValue, grayscaleValue, grayscaleValue, a)
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
