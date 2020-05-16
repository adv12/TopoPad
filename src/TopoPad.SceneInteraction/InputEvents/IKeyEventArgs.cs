// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IKeyEventArgs : IEventArgs
    {
        public Key Key { get; }
        public KeyModifiers KeyModifiers { get; }
    }
}
