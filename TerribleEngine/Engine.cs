namespace TerribleEngine
{
    public class Engine
    {
        private World.World _world;

        public Engine()
        {
            _world = new World.World();
        }

        public World.World GetScene()
        {
            return _world;
        }
    }
}