// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.Core
{
    public class GroupNodeChangedEventArgs
    {
        public IGroupNode Node { get; }

        public GroupNodeChangedEventArgs(IGroupNode node)
        {
            Node = node;
        }
    }
}
