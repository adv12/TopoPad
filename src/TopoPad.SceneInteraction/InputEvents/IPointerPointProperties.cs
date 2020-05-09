// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

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
