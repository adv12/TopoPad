// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Dock.Model.Controls;
using TopoPad.Core;
using TopoPad.SceneInteraction;

namespace TopoPad.ViewModels
{
    public class SceneToolViewModel : Tool
    {
        public SceneViewModel SceneViewModel { get; } = new SceneViewModel();

        public IScene Scene => SceneViewModel?.Scene;

        public ISpatialDocument Document => Scene?.Document;
    }
}
