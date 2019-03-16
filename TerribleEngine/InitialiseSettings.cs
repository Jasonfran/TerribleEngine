using OpenTK.Graphics;
using OpenTK.Platform;

namespace TerribleEngine
{
    public class InitialiseSettings
    {
        public IGraphicsContext Context { get; set; }
        public IWindowInfo WindowInfo { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}