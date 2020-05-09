using Avalonia.Input;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class PointerPointPropertiesWrapper : TP.IPointerPointProperties
    {
        private PointerPointProperties P;

        public bool IsLeftButtonPressed => P.IsLeftButtonPressed;

        public bool IsMiddleButtonPressed => P.IsMiddleButtonPressed;

        public bool IsRightButtonPressed => P.IsRightButtonPressed;

        public TP.PointerUpdateKind PointerUpdateKind => InputConverter.Convert(P.PointerUpdateKind);

        public PointerPointPropertiesWrapper(PointerPointProperties properties)
        {
            P = properties;
        }
    }
}
