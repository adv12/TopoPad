// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using TopoPad.AvaloniaSceneInteraction.EventArgs;
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
                renderContext.RenderScene(fast);
            }
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            Scene?.OnPointerMoved(new PointerEventArgsWrapper(e, this));
            if (!e.Handled)
            {
                base.OnPointerMoved(e);
            }
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            Scene?.OnPointerPressed(new PointerEventArgsWrapper(e, this));
            if (!e.Handled)
            {
                base.OnPointerPressed(e);
            }
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            Scene?.OnPointerReleased(new PointerReleasedEventArgsWrapper(e, this));
            if (!e.Handled)
            {
                base.OnPointerReleased(e);
            }
        }

        protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
        {
            Scene?.OnPointerWheelChanged(new PointerWheelEventArgsWrapper(e, this));
            if (!e.Handled)
            {
                base.OnPointerWheelChanged(e);
            }
        }
    }
}
