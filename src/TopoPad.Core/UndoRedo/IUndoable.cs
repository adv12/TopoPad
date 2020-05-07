// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.ComponentModel;

namespace TopoPad.Core.UndoRedo
{
    public interface IUndoable : INotifyPropertyChanged
    {
        bool CanUndo { get; }
        bool CanRedo { get; }
        void Undo();
        void Redo();
    }
}
