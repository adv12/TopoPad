// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Collections.Generic;
using TopoPad.Core;
using TopoPad.SceneInteraction.InputEvents;
using TopoPad.SceneInteraction.Interactions;

namespace TopoPad.SceneInteraction
{
    public interface IReadOnlyScene : IViewport, IReadOnlySpatialDocumentContainer
    {
        bool Drawn { get; set; }

        IEnumerable<IInteraction> Interactions { get; }

        void PushInteraction(IInteraction interaction);

        IInteraction PopInteraction();

        void ApplyToInteractions(Action<IInteraction> action, IEventArgs e)
        {
            foreach (IInteraction interaction in Interactions)
            {
                if (e.Handled)
                {
                    break;
                }
                action(interaction);
            }
        }

        void OnPointerMoved(IPointerEventArgs e)
        {
            ApplyToInteractions(i => i.OnPointerMoved(e), e);
        }

        void OnPointerPressed(IPointerEventArgs e)
        {
            ApplyToInteractions(i => i.OnPointerPressed(e), e);
        }

        void OnPointerReleased(IPointerReleasedEventArgs e)
        {
            ApplyToInteractions(i => i.OnPointerReleased(e), e);
        }

        void OnPointerWheelChanged(IPointerWheelEventArgs e)
        {
            ApplyToInteractions(i => i.OnPointerWheelChanged(e), e);
        }

        void OnKeyDown(IKeyEventArgs e)
        {
            ApplyToInteractions(i => i.OnKeyDown(e), e);
        }

        void OnKeyUp(IKeyEventArgs e)
        {
            ApplyToInteractions(i => i.OnKeyUp(e), e);
        }
    }
}
