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
            switch (value)
            {
                case KeyModifiers.Alt:
                    return TP.KeyModifiers.Alt;
                case KeyModifiers.Control:
                    return TP.KeyModifiers.Control;
                case KeyModifiers.Meta:
                    return TP.KeyModifiers.Meta;
                case KeyModifiers.Shift:
                    return TP.KeyModifiers.Shift;
                default:
                    return TP.KeyModifiers.None;
            }
        }

        public static TP.MouseButton Convert(MouseButton value)
        {
            switch (value)
            {
                case MouseButton.Left:
                    return TP.MouseButton.Left;
                case MouseButton.Middle:
                    return TP.MouseButton.Middle;
                case MouseButton.Right:
                    return TP.MouseButton.Right;
                default:
                    return TP.MouseButton.None;
            }
        }

        public static TP.PointerType Convert(PointerType value)
        {
            switch (value)
            {
                case PointerType.Touch:
                    return TP.PointerType.Touch;
                default:
                    return TP.PointerType.Mouse;
            }
        }

        public static TP.PointerUpdateKind Convert(PointerUpdateKind value)
        {
            switch (value)
            {
                case PointerUpdateKind.LeftButtonPressed:
                    return TP.PointerUpdateKind.LeftButtonPressed;
                case PointerUpdateKind.LeftButtonReleased:
                    return TP.PointerUpdateKind.LeftButtonReleased;
                case PointerUpdateKind.MiddleButtonPressed:
                    return TP.PointerUpdateKind.MiddleButtonPressed;
                case PointerUpdateKind.MiddleButtonReleased:
                    return TP.PointerUpdateKind.MiddleButtonReleased;
                case PointerUpdateKind.RightButtonPressed:
                    return TP.PointerUpdateKind.RightButtonPressed;
                case PointerUpdateKind.RightButtonReleased:
                    return TP.PointerUpdateKind.RightButtonReleased;
                default:
                    return TP.PointerUpdateKind.Other;
            }
        }
    }
}
