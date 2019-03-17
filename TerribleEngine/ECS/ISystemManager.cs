using System.Collections.Generic;
using TerribleEngine.Resources;
using TerribleEngine.Scene;

namespace TerribleEngine.ECS
{
    public interface ISystemManager
    {
        void ExitSystems();
        void LoadSystems(ISystemLoader systemLoader);
        List<ITerribleSystem> SystemsWhichSatisfy(ComponentSet componentSet);
        void UpdateSystems(float dt);
        void InitialiseSystems(EntityManager entityManager, EventManager eventManager, IResourceManager resourceManager, IWorld world);
    }
}