using OpenTK;
using OpenTK.Graphics;

namespace TerribleEngine
{
    public class WindowManager
    {
        private static WindowManager _instance;
        public static WindowManager Instance => _instance ?? (_instance = new WindowManager());

        private WindowManager()
        {
            
        }

        public GameWindow NewWindow(int width, int height, string title)
        {
            return new GameWindow(width, height, GraphicsMode.Default, title);
        }
    }
}