namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IPointer
    {
        int Id { get; }

        PointerType Type { get; }

        bool IsPrimary { get; }
    }
}
