// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using System;
using System.Collections.Generic;
using Avalonia.Data;
using TopoPad.ViewModels;
using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Controls;
using TopoPad.Core;
using TopoPad.Core.Layers;

namespace TopoPad
{
    public class MainDockFactory : Factory
    {
        private object m_Context;

        public MainDockFactory(object context)
        {
            m_Context = context;
        }

        public override IDock CreateLayout()
        {
            SpatialDocument document = new SpatialDocument();
            ILayer layer = document.AddItemsLayer();
            document.SelectedNode = layer;
            layer.Name = "WKT Geometries";

            var documentViewModel = new SceneControlDocumentViewModel()
            {
                Id = "Document1",
                Title = "Document 1"
            };
            documentViewModel.SceneControlViewModel.Document = document;

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
            root.Top = CreatePinDock();
            root.Top.Alignment = Alignment.Top;
            root.Bottom = CreatePinDock();
            root.Bottom.Alignment = Alignment.Bottom;
            root.Left = CreatePinDock();
            root.Left.Alignment = Alignment.Left;
            root.Right = CreatePinDock();
            root.Right.Alignment = Alignment.Right;

            return root;
        }

        public override void InitLayout(IDockable layout)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                [nameof(IRootDock)] = () => m_Context,
                [nameof(IPinDock)] = () => m_Context,
                [nameof(IProportionalDock)] = () => m_Context,
                [nameof(IDocumentDock)] = () => m_Context,
                [nameof(IToolDock)] = () => m_Context,
                [nameof(ISplitterDock)] = () => m_Context,
                [nameof(IDockWindow)] = () => m_Context,
                [nameof(IDocument)] = () => m_Context,
                [nameof(ITool)] = () => m_Context,
                ["Document1"] = () => m_Context,
                ["Layers"] = () => m_Context,
                ["EditLayer"] = () => m_Context,
                ["AddGeometry"] = () => m_Context,
                ["LeftPane"] = () => m_Context,
                ["LeftPaneTop"] = () => m_Context,
                ["LeftPaneTopSplitter"] = () => m_Context,
                ["LeftPaneBottom"] = () => m_Context,
                ["CenterPane"] = () => m_Context,
                ["CenterPaneSplitter"] = () => m_Context,
                ["CenterPaneBottom"] = () => m_Context,
                ["RightPane"] = () => m_Context,
                ["RightPaneTop"] = () => m_Context,
                ["RightPaneTopSplitter"] = () => m_Context,
                ["RightPaneBottom"] = () => m_Context,
                ["DocumentsPane"] = () => m_Context,
                ["MainLayout"] = () => m_Context,
                ["LeftSplitter"] = () => m_Context,
                ["RightSplitter"] = () => m_Context,
                ["MainLayout"] = () => m_Context,
                ["Main"] = () => m_Context,
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
