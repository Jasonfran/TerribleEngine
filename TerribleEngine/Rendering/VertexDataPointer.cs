namespace TerribleEngine.Rendering
{
    public class VertexDataPointer
    {
        public int Start { get; }
        public int Count { get; }

        public VertexDataPointer(int start, int count)
        {
            Start = start;
            Count = count;
        }
    }
}