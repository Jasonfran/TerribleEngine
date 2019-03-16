using TerribleEngine.Gameplay;

namespace TerribleEngine.ECS
{
    public class CoreSystemLoader : ISystemLoader
    {
        public void LoadSystems(ISystemLoaderCallback callback)
        {
            callback.AddSystem(new TestSystem());
        }
    }
}