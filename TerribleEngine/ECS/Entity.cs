using System.Collections.Generic;
using TerribleEngine.ComponentModels;
using TerribleEngine.Scene;

namespace TerribleEngine.ECS
{
    public class Entity : IEntity
    {
        public int Id { get; }
        public ComponentSet ComponentSet { get; internal set; }
        public List<IEntity> Children { get; }
        public IEntity Parent { get; set; }
        public Transform Transform { get; set; }
        public IWorld World { get; private set; }

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
            Children = new List<IEntity>();
        }

        public T AddChild<T>(T entity) where T : IEntity
        {
            EntityManager.ChangeParent(this, entity);
            return entity;
        }

        public void SetParent(IEntity parent)
        {
            EntityManager.ChangeParent(parent, this);
        }

        public void SetWorld(IWorld world)
        {
            World = world;
        }

        public T AddComponent<T>(T component) where T : IComponent
        {
            return EntityManager.AddComponent(this, component);
        }

        public T GetComponent<T>() where T : IComponent
        {
            return EntityManager.GetComponent<T>(this);
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