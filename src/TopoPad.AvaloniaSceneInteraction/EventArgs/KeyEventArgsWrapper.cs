// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia.Input;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class KeyEventArgsWrapper : TP.IKeyEventArgs
    {
        private KeyEventArgs E;

        public bool Handled
        {
            get => E.Handled;
            set => E.Handled = value;
        }

        public TP.Key Key => InputConverter.Convert(E.Key);

        public TP.KeyModifiers KeyModifiers => InputConverter.Convert(E.KeyModifiers);

        public KeyEventArgsWrapper(KeyEventArgs e)
        {
            E = e;
        }
    }
}
