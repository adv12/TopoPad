// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia.Input;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public static class InputConverter
    {
        public static TP.KeyModifiers Convert(KeyModifiers value)
        {
            return (TP.KeyModifiers)value;
        }

        public static TP.MouseButton Convert(MouseButton value)
        {
            return (TP.MouseButton)value;
        }

        public static TP.PointerType Convert(PointerType value)
        {
            return (TP.PointerType)value;
        }

        public static TP.PointerUpdateKind Convert(PointerUpdateKind value)
        {
            return (TP.PointerUpdateKind)value;
        }

        public static TP.Key Convert(Key value)
        {
            return (TP.Key)value;
        }
    }
}
