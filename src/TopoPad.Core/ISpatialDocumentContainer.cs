namespace TopoPad.Core
{
    public interface ISpatialDocumentContainer : IReadOnlySpatialDocumentContainer
    {
        new ISpatialDocument Document { get; set; }
    }
}
