using TopoPad.Core;

namespace TopoPad.SceneInteraction
{
    public interface IScene : IViewport
    {
        ISpatialDocument Document { get; }

        public bool Drawn { get; set; }
    }
}
