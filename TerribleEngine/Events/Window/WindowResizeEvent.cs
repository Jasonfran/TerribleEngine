namespace TerribleEngine.Events.Window
{
    public class WindowResizeEvent : IEvent
    {
        public int Width { get; }
        public int Height { get; }

        public WindowResizeEvent(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}