using TopoPad.Core.Layers;

namespace TopoPad.Core
{
    public interface IGroup : IGroupNode
    {
        IGroup AddGroup();

        IItemsLayer AddItemsLayer(string name = null);

        void AddChild(IGroupNode child);

        void RemoveChild(IGroupNode child);

        void Ungroup();
    }
}
