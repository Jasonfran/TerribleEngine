using System.Collections.Generic;
using System.Linq;
using TerribleEngine.Attributes;
using TerribleEngine.Resources;

namespace TerribleEngine.ECS
{
    public abstract class TerribleSystem : ITerribleSystem
    {
        public List<Entity> Entities { get; }

        public EntityManager EntityManager { get; set; }
        public EventManager EventManager { get; set; }
        public IResourceManager ResourceManager { get; set; }

        protected TerribleSystem()
        {
            Entities = new List<Entity>();
        }

        public virtual void OnInit()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnExit()
        {

        }

        ~TerribleSystem()
        {
            OnExit();
        }

        public DependsOnComponents GetDependencies()
        {
            var type = GetType();
            var attribute = (DependsOnComponents) type.GetCustomAttributes(typeof(DependsOnComponents), true).FirstOrDefault();

            return attribute;
        }
    }
}