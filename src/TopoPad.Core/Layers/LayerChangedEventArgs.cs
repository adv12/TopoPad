// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Collections.Generic;
using System.Text;

namespace TopoPad.Core.Layers
{
    public class LayerChangedEventArgs
    {
        public ILayer Layer { get; }

        public LayerChangedEventArgs(ILayer layer)
        {
            Layer = layer;
        }
    }
}
