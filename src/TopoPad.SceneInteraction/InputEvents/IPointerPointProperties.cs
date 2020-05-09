using System;
using System.Collections.Generic;
using System.Text;

namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointerPointProperties
    {
        bool IsLeftButtonPressed { get; }

        bool IsMiddleButtonPressed { get; }

        bool IsRightButtonPressed { get; }

        PointerUpdateKind PointerUpdateKind { get; }
    }
}
