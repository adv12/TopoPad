// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using TopoPad.SceneInteraction;

namespace TopoPad.AvaloniaSceneInteraction
{
    public class SceneControl : Control
    {
        public static readonly DirectProperty<SceneControl, IScene> SceneProperty =
            AvaloniaProperty.RegisterDirect<SceneControl, IScene>(
                nameof(Scene),
                o => o.Scene,
                (o, v) => o.Scene = v);

        public static readonly DirectProperty<SceneControl, bool> DrawnProperty =
            AvaloniaProperty.RegisterDirect<SceneControl, bool>(
                nameof(Drawn),
                o => o.Drawn,
                (o, v) => o.Drawn = v);

        private IScene m_Scene;
        public IScene Scene
        {
            get => m_Scene;
            set => SetAndRaise(SceneProperty, ref m_Scene, value);
        }

        private bool m_Drawn;
        public bool Drawn
        {
            get => m_Drawn;
            set
            {
                SetAndRaise(DrawnProperty, ref m_Drawn, value);
                if (!Drawn)
                {
                    InvalidateVisual();
                }
            }
        }

        public SceneControl()
        {
            ClipToBounds = true;
        }

        public override void Render(DrawingContext context)
        {
            if (Scene?.Document != null)
            {
                bool fast = false;
                RenderContext renderContext = new RenderContext(Scene, context);
                renderContext.RenderScene(Scene, fast);
            }
        }


    }
}
