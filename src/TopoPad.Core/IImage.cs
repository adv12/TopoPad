// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

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
