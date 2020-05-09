namespace TopoPad.SceneInteraction.InputEvents
{
    public interface IVector
    {
        public double X { get; }

        public double Y { get; }

        public double Length { get; }

        public double SquaredLength { get; }
    }
}
