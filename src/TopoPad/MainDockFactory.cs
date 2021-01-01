// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Collections.Generic;
using Avalonia.Data;
using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Controls;
using TopoPad.ViewModels;

namespace TopoPad
{
    public class MainDockFactory : Factory
    {
        private MainWindowViewModel m_ViewModel;

        public MainDockFactory(MainWindowViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        public override IDock CreateLayout()
        {
            var documentViewModel = new SceneControlDocumentViewModel()
            {
                Id = "Viewport",
                Title = "Viewport"
            };
            documentViewModel.SceneControlViewModel.Document = m_ViewModel.Document;

            var layersToolViewModel = new LayersViewModel()
            {
                Id = "Layers",
                Title = "Layers"
            };
            layersToolViewModel.SceneViewModel.Scene = documentViewModel.SceneControlViewModel;

            var editLayerToolViewModel = new EditLayerViewModel()
            {
                Id = "GroupAndLayerSettings",
                Title = "Group and Layer Settings"
            };
            editLayerToolViewModel.SceneViewModel.Scene = documentViewModel.SceneControlViewModel;

            var addGeometryViewModel = new AddGeometryViewModel()
            {
                Id = "AddGeometry",
                Title = "Add Geometry"
            };
            addGeometryViewModel.SceneViewModel.Scene = documentViewModel.SceneControlViewModel;

            var mainLayout = new ProportionalDock
            {
                Id = "MainLayout",
                Title = "MainLayout",
                Proportion = double.NaN,
                Orientation = Orientation.Horizontal,
                ActiveDockable = null,
                VisibleDockables = CreateList<IDockable>
                (
                    new ProportionalDock
                    {
                        Id = "LeftPane",
                        Title = "LeftPane",
                        Proportion = .2,
                        Orientation = Orientation.Vertical,
                        ActiveDockable = null,
                        VisibleDockables = CreateList<IDockable>
                        (
                            new ToolDock
                            {
                                Id = "LeftPaneTop",
                                Title = "LeftPaneTop",
                                Proportion = double.NaN,
                                ActiveDockable = layersToolViewModel,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    layersToolViewModel
                                )
                            },
                            new SplitterDock()
                            {
                                Id = "LeftPaneTopSplitter",
                                Title = "LeftPaneTopSplitter"
                            },
                            new ToolDock
                            {
                                Id = "LeftPaneBottom",
                                Title = "LeftPaneBottom",
                                Proportion = double.NaN,
                                ActiveDockable = editLayerToolViewModel,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    editLayerToolViewModel
                                )
                            }
                        )
                    },
                    new SplitterDock()
                    {
                        Id = "LeftSplitter",
                        Title = "LeftSplitter"
                    },
                    new ProportionalDock
                    {
                        Id = "CenterPane",
                        Title = "CenterPane",
                        Proportion = double.NaN,
                        Orientation = Orientation.Vertical,
                        ActiveDockable = null,
                        VisibleDockables = CreateList<IDockable>
                        (
                            new DocumentDock
                            {
                                Id = "DocumentsPane",
                                Title = "DocumentsPane",
                                Proportion = .8,
                                ActiveDockable = documentViewModel,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    documentViewModel
                                )
                            },
                            new SplitterDock()
                            {
                                Id = "CenterPaneSplitter",
                                Title = "CenterPaneSplitter"
                            },
                            new ToolDock
                            {
                                Id = "CenterPaneBottom",
                                Title = "CenterPaneBottom",
                                Proportion = double.NaN,
                                ActiveDockable = addGeometryViewModel,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    addGeometryViewModel
                                )
                            }
                        )
                    }
                )
            };

            var mainView = new MainViewModel
            {
                Id = "Main",
                Title = "Main",
                ActiveDockable = mainLayout,
                VisibleDockables = CreateList<IDockable>(mainLayout)
            };

            var root = CreateRootDock();

            root.Id = "Root";
            root.Title = "Root";
            root.ActiveDockable = mainView;
            root.DefaultDockable = mainView;
            root.VisibleDockables = CreateList<IDockable>(mainView);
            
            return root;
        }

        public override void InitLayout(IDockable layout)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                [nameof(IRootDock)] = () => m_ViewModel,
                [nameof(IProportionalDock)] = () => m_ViewModel,
                [nameof(IDocumentDock)] = () => m_ViewModel,
                [nameof(IToolDock)] = () => m_ViewModel,
                [nameof(ISplitterDock)] = () => m_ViewModel,
                [nameof(IDockWindow)] = () => m_ViewModel,
                [nameof(IDocument)] = () => m_ViewModel,
                [nameof(ITool)] = () => m_ViewModel,
                ["Viewport"] = () => m_ViewModel,
                ["Layers"] = () => m_ViewModel,
                ["EditLayer"] = () => m_ViewModel,
                ["AddGeometry"] = () => m_ViewModel,
                ["LeftPane"] = () => m_ViewModel,
                ["LeftPaneTop"] = () => m_ViewModel,
                ["LeftPaneTopSplitter"] = () => m_ViewModel,
                ["LeftPaneBottom"] = () => m_ViewModel,
                ["CenterPane"] = () => m_ViewModel,
                ["CenterPaneSplitter"] = () => m_ViewModel,
                ["CenterPaneBottom"] = () => m_ViewModel,
                ["RightPane"] = () => m_ViewModel,
                ["RightPaneTop"] = () => m_ViewModel,
                ["RightPaneTopSplitter"] = () => m_ViewModel,
                ["RightPaneBottom"] = () => m_ViewModel,
                ["DocumentsPane"] = () => m_ViewModel,
                ["MainLayout"] = () => m_ViewModel,
                ["LeftSplitter"] = () => m_ViewModel,
                ["RightSplitter"] = () => m_ViewModel,
                ["MainLayout"] = () => m_ViewModel,
                ["Main"] = () => m_ViewModel,
            };

            this.HostWindowLocator = new Dictionary<string, Func<IHostWindow>>
            {
                [nameof(IDockWindow)] = () =>
                {
                    var hostWindow = new HostWindow()
                    {
                        [!HostWindow.TitleProperty] = new Binding("ActiveDockable.Title")
                    };
                    return hostWindow;
                }
            };

            this.DockableLocator = new Dictionary<string, Func<IDockable>>
            {
            };

            base.InitLayout(layout);
        }
    }
}
