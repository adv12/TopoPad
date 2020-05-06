using System;
using System.ComponentModel;

namespace TopoPad.Core
{
    public interface IImage : INotifyPropertyChanged
    {
        int Width { get; }
        int Height { get; }
        public Span<Rgba> GetPixels(int sourceX, int sourceY, int sourceWidth, int sourceHeight, int level);
    }
}
