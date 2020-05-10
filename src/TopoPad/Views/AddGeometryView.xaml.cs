// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TopoPad.Views
{
    public class AddGeometryView : UserControl
    {
        public AddGeometryView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
