﻿// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Dock.Model.Controls;

namespace TopoPad.ViewModels
{
    public class SceneToolViewModel : Tool
    {
        public SceneViewModel SceneViewModel { get; } = new SceneViewModel();
    }
}
