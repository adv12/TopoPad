// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System.Collections.ObjectModel;
using System.Reactive;
using Dock.Model;
using ReactiveUI;
using TopoPad.Core;
using TopoPad.Core.Layers;

namespace TopoPad.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IFactory m_Factory;
        private IDock m_Layout;
        private string m_CurrentView;

        public IFactory Factory
        {
            get => m_Factory;
            set => this.RaiseAndSetIfChanged(ref m_Factory, value);
        }

        public IDock Layout
        {
            get => m_Layout;
            set => this.RaiseAndSetIfChanged(ref m_Layout, value);
        }

        public string CurrentView
        {
            get => m_CurrentView;
            set => this.RaiseAndSetIfChanged(ref m_CurrentView, value);
        }

        private ISpatialDocument m_Document;
        public ISpatialDocument Document
        {
            get => m_Document;
            set => this.RaiseAndSetIfChanged(ref m_Document, value);
        }

        public ReactiveCommand<Unit, Unit> NewDocumentCommand { get; }

        public MainWindowViewModel()
        {
            NewDocumentCommand = ReactiveCommand.Create(() => NewDocument());
        }

        public void NewDocument()
        {
            SpatialDocument document = new SpatialDocument();
            ILayer layer = document.AddItemsLayer();
            document.SelectedNode = layer;
            layer.Name = "WKT Geometries";
            Document = document;
        }

    }
}
