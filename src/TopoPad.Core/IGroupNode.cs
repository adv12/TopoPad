using NetTopologySuite.Geometries;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public interface IGroupNode : INotifyPropertyChanged, IBoundedItem
    {
        event EventHandler<LayerSelectionChangedEventArgs> LayerSelectionChanged;

        event EventHandler<LayerChangedEventArgs> LayerStyleChanged;

        event EventHandler<LayerChangedEventArgs> LayerDataChanged;

        string Name { get; set; }

        bool Snappable { get; set; }

        bool ItemsSelectable { get; set; }

        bool ItemsMovable { get; set; }

        bool FeaturesEditable { get; set; }

        Coordinate GetSnapPoint(Coordinate input);

        IGroup ParentNode { get; set; }

        ReadOnlyObservableCollection<IGroupNode> ChildNodes { get; }
    }
}
