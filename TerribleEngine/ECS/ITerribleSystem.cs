using System.Collections.Generic;
using TerribleEngine.Attributes;
using TerribleEngine.Resources;
using TerribleEngine.Scene;

namespace TerribleEngine.ECS
{
    public interface ITerribleSystem
    {
        List<IEntity> Entities { get; }
        EntityManager EntityManager { get; set; }
        EventManager EventManager { get; set; }
        IResourceManager ResourceManager { get; set; }

        IWorld World { get; set; }

        DependsOnComponents GetDependencies();
        void Exit();
        void Init();
        void Update(float dt);
    }
}