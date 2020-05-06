using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using TopoPad.Core;
using TopoPad.Core.Layers;
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

        public override void Render(DrawingContext context)
        {
            if (Scene?.Document != null)
            {
                bool fast = false;
                context.FillRectangle(new SolidColorBrush(Scene.Document.BackColor.Argb),
                    new Rect(Bounds.Size));
                RenderContext renderContext = new RenderContext(Scene, context);
                RenderGroup(Scene.Document, renderContext, fast);
                Scene.Drawn = true;
            }
        }

        public void RenderGroup(IGroup group, RenderContext renderContext, bool fast)
        {
            foreach (IGroupNode childNode in group.ChildNodes)
            {
                if (childNode is ILayer layer)
                {
                    RenderLayer(layer, renderContext, fast);
                }
                else if (childNode is IGroup g)
                {
                    RenderGroup(g, renderContext, fast);
                }
            }
        }

        public void RenderLayer(ILayer layer, RenderContext renderContext, bool fast)
        {
            layer.Render(renderContext, fast);
        }
    }
}
