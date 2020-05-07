using TopoPad.Core;

namespace TopoPad.SceneInteraction
{
    public interface IReadOnlyScene : IViewport, IReadOnlySpatialDocumentContainer
    {
        public bool Drawn { get; set; }
    }
}
