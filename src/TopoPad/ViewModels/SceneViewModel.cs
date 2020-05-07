using ReactiveUI;
using TopoPad.AvaloniaSceneInteraction;
using TopoPad.Core;
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
