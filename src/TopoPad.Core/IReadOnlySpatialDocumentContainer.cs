// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

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
