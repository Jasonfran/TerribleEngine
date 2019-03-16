namespace TerribleEngine.Models
{
    public class Settings
    {
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Settings(string title, int width, int height)
        {
            Title = title;
            Width = width;
            Height = height;
        }
    }
}