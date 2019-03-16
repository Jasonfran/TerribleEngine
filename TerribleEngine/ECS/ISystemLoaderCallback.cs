namespace TerribleEngine.ECS
{
    public interface ISystemLoaderCallback
    {
        void AddSystem(ITerribleSystem system);
    }
}