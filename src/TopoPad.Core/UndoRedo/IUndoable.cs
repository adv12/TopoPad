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
