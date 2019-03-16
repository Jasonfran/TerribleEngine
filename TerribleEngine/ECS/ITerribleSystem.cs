using System.Collections.Generic;
using TerribleEngine.Attributes;
using TerribleEngine.Resources;

namespace TerribleEngine.ECS
{
    public interface ITerribleSystem
    {
        List<Entity> Entities { get; }
        EntityManager EntityManager { get; set; }
        EventManager EventManager { get; set; }
        IResourceManager ResourceManager { get; set; }

        DependsOnComponents GetDependencies();
        void OnExit();
        void OnInit();
        void Update();
    }
}