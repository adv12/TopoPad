// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.Core
{
    public interface ISpatialDocumentContainer : IReadOnlySpatialDocumentContainer
    {
        new ISpatialDocument Document { get; set; }
    }
}
