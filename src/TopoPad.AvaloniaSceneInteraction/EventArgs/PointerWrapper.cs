﻿using Avalonia.Input;
using TP = TopoPad.SceneInteraction.InputEvents;

namespace TopoPad.AvaloniaSceneInteraction.EventArgs
{
    public class PointerWrapper : TP.IPointer
    {
        private IPointer m_Pointer;

        public int Id => m_Pointer.Id;

        public TP.PointerType Type => InputConverter.Convert(m_Pointer.Type);

        public bool IsPrimary => m_Pointer.IsPrimary;
        
        public PointerWrapper(IPointer pointer)
        {
            m_Pointer = pointer;
        }
    }
}