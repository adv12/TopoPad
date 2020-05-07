using Dock.Model.Controls;
using ReactiveUI;
using TopoPad.AvaloniaSceneInteraction;
using TopoPad.Core;

namespace TopoPad.ViewModels
{
    public class SceneControlDocumentViewModel: Document, ISpatialDocumentContainer
    {
        private ISpatialDocument m_Document;
        public ISpatialDocument Document
        {
            get => m_Document;
            set
            {
                this.RaiseAndSetIfChanged(ref m_Document, value);
                m_SceneControlViewModel.Document = value;
            }
        }

        private SceneControlViewModel m_SceneControlViewModel = new SceneControlViewModel();
        public SceneControlViewModel SceneControlViewModel
        {
            get => m_SceneControlViewModel;
        }
    }
}
