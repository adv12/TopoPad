using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TopoPad.Core.Style
{
    public class StyleNotifier : PropertyNotifier
    {
        public event EventHandler StyleChanged;

        protected bool SetNotifyUnregisterRegister<T>(ref T field, T value,
            [CallerMemberName] string propertyName = null)
            where T: INotifyPropertyChanged
        {
            T old = field;
            bool set = SetField(ref field, value, propertyName);
            if (set)
            {
                if (old != null)
                {
                    old.PropertyChanged -= Field_PropertyChanged;
                    if (old is StyleNotifier notifier)
                    {
                        notifier.StyleChanged -= Notifier_StyleChanged;
                    }
                }
                if (field != null)
                {
                    field.PropertyChanged += Field_PropertyChanged;
                    if (field is StyleNotifier notifier)
                    {
                        notifier.StyleChanged += Notifier_StyleChanged;
                    }
                }
            }
            return set;
        }

        private void Notifier_StyleChanged(object sender, EventArgs e)
        {
            StyleChanged?.Invoke(this, e);
        }

        private void Field_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StyleChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
