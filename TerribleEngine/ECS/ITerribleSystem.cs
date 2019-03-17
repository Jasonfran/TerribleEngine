using System.Collections.Generic;
using TerribleEngine.Attributes;
using TerribleEngine.Resources;
using TerribleEngine.Scene;

namespace TerribleEngine.ECS
{
    public interface ITerribleSystem
    {
        List<Entity> Entities { get; }
        EntityManager EntityManager { get; set; }
        EventManager EventManager { get; set; }
        IResourceManager ResourceManager { get; set; }

        IWorld World { get; set; }

        DependsOnComponents GetDependencies();
        void OnExit();
        void OnInit();
        void Update(float dt);
    }
}