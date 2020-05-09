using System;

namespace TopoPad.SceneInteraction.InputEvents
{
    public enum PointerType
    {
        Mouse,
        Touch
    }

    public enum MouseButton
    {
        None,
        Left,
        Right,
        Middle
    }

    [Flags]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Meta = 8
    }

    public enum PointerUpdateKind
    {
        LeftButtonPressed,
        MiddleButtonPressed,
        RightButtonPressed,
        LeftButtonReleased,
        MiddleButtonReleased,
        RightButtonReleased,
        Other
    }
}
