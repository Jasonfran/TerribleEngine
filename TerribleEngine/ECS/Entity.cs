using System.Collections.Generic;
using TerribleEngine.ComponentModels;

namespace TerribleEngine.ECS
{
    public class Entity
    {
        public int Id { get; }
        public ComponentSet ComponentSet { get; set; }
        public List<Entity> Children { get; }
        public Entity Parent { get; private set; }
        public Transform Transform { get; set; }
        public World.World World { get; private set; }

        private EntityManager EntityManager { get; set; }

        /// <summary>
        /// Don't instantiate this manually. Call <see cref="EntityManager"/>'s NewEntity() function
        /// </summary>
        /// <param name="id">Id given to the entity by the entity manager</param>
        /// <param name="entityManager"></param>
        internal Entity(int id, EntityManager entityManager, Transform transform)
        {
            Id = id;
            EntityManager = entityManager;
            Transform = transform;

            ComponentSet = new ComponentSet();
            Children = new List<Entity>();
        }

        public Entity AddChild(Entity entity)
        {
            Children.Add(entity);
            entity.Parent = this;
            entity.World = World;
            return entity;
        }

        public T AddComponent<T>(T component) where T : IComponent
        {
            return EntityManager.AddComponent(this, component);
        }

        public void RemoveComponent<T>() where T : IComponent
        {
            EntityManager.RemoveComponent<T>(this);
        }

        public bool HasComponent<T>() where T : IComponent
        {
            return EntityManager.HasComponent<T>(this);
        }
    }
}