using System.Collections.Generic;
using TerribleEngine.Resources;

namespace TerribleEngine.ECS
{
    public interface ISystemManager
    {
        void ExitSystems();
        void LoadSystems(ISystemLoader systemLoader);
        List<ITerribleSystem> SystemsWhichSatisfy(ComponentSet componentSet);
        void UpdateSystems();
        void InitialiseSystems(EntityManager entityManager, EventManager eventManager, IResourceManager resourceManager);
    }
}