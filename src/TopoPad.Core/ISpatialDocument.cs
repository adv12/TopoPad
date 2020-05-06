namespace TopoPad.Core
{
    public interface ISpatialDocument : IGroup
    {
        long SpatialReference { get; set; }

        Rgba BackColor { get; set; }
    }
}
