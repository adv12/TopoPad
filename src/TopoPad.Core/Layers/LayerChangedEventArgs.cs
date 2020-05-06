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
