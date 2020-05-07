using System;
using System.Collections.Generic;
using System.Text;

namespace TopoPad.Core
{
    public interface IReadOnlySpatialDocumentContainer
    {
        public ISpatialDocument Document { get; }
    }
}
