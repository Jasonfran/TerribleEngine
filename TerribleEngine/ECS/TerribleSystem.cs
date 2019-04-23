using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TerribleEngine.Attributes;
using TerribleEngine.Enums;
using TerribleEngine.Resources;
using TerribleEngine.Scene;

namespace TerribleEngine.ECS
{
    public abstract class TerribleSystem : ITerribleSystem
    {
        public List<IEntity> Entities { get; }
        private ConcurrentQueue<EntityCollectionUpdate> _collectionUpdates;

        public EntityManager EntityManager { get; set; }
        public EventManager EventManager { get; set; }
        public IResourceManager ResourceManager { get; set; }
        public IWorld World { get; set; }

        protected TerribleSystem()
        {
            Entities = new List<IEntity>();
            _collectionUpdates = new ConcurrentQueue<EntityCollectionUpdate>();
        }

        ~TerribleSystem()
        {
            Exit();
        }

        public void Init()
        {
            OnInit();
        }


        public void Update(float dt)
        {
            ProcessCollectionUpdates();

            OnUpdate(dt);
        }

        public void Exit()
        {
            OnExit();
        }

        protected abstract void OnInit();
        protected abstract void OnUpdate(float dt);
        protected abstract void OnExit();

        public DependsOnComponents GetDependencies()
        {
            var type = GetType();
            var attribute = (DependsOnComponents) type.GetCustomAttributes(typeof(DependsOnComponents), true).FirstOrDefault();

            return attribute ?? new DependsOnComponents();
        }

        internal void CollectionUpdate(IEntity entity, EntityCollectionChange change)
        {
            _collectionUpdates.Enqueue(new EntityCollectionUpdate(entity, change));
        }

        private void ProcessCollectionUpdates()
        {
            while (!_collectionUpdates.IsEmpty)
            {
                if (_collectionUpdates.TryDequeue(out var update))
                {
                    if (update.Change == EntityCollectionChange.Added)
                    {
                        Entities.Add(update.Entity);
                    }
                    else
                    {
                        Entities.Remove(update.Entity);
                    }
                }
            }
        }
    }
}