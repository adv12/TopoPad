// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using ReactiveUI;
using TopoPad.SceneInteraction;

namespace TopoPad.ViewModels
{
    public class SceneViewModel : ViewModelBase
    {
        private IScene m_Scene;
        public IScene Scene
        {
            get => m_Scene;
            set => this.RaiseAndSetIfChanged(ref m_Scene, value);
        }
    }
}
