// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using ReactiveUI;
using System.Reactive;

namespace TopoPad.ViewModels
{
    public class LayersViewModel : SceneToolViewModel
    {
        public ReactiveCommand<Unit, Unit> AddLayerCommand { get; }

        public ReactiveCommand<Unit, Unit> AddGroupCommand { get; }

        public LayersViewModel()
        {
            AddLayerCommand = ReactiveCommand.Create(() =>
            {
                if (Document != null)
                {
                    Document.SelectedNode = Document.AddItemsLayerAtSelectedNode();
                }
            });

            AddGroupCommand = ReactiveCommand.Create(() =>
            {
                if (Document != null)
                {
                    Document.SelectedNode = Document.AddGroupAtSelectedNode(1);
                }
            });
        }
    }
}
