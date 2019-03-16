namespace TerribleEngine.ECS
{
    public interface ISystemLoader
    {
        void LoadSystems(ISystemLoaderCallback callback);
    }
}