using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TerribleEngine.Attributes;
using TerribleEngine.ComponentModels;
using TerribleEngine.Enums;

namespace TerribleEngine.ECS
{
    public class EntityManager
    {
        private readonly ISystemManager _systemManager;

        // Used to store a reference to all entities
        private readonly List<Entity> _allEntities;

        // Used to group entities together by common sets
        private readonly ConcurrentDictionary<ComponentSet, List<Entity>> _entitiesWithComponentSet;

        // All entities with one component
        private readonly ConcurrentDictionary<Type, List<Entity>> _entitiesWithComponent;

        // Entity to component mapping
        private readonly ConcurrentDictionary<Entity, Dictionary<Type, IComponent>> _entityComponents;

        private readonly Dictionary<DependsOnComponents, List<ITerribleSystem>> _systemsToNotify;

        private int _entityIdCounter;
        
        public EntityManager(ISystemManager systemManager)
        {
            _systemManager = systemManager;
            _allEntities = new List<Entity>();
            _entitiesWithComponentSet = new ConcurrentDictionary<ComponentSet, List<Entity>>();
            _entitiesWithComponent = new ConcurrentDictionary<Type, List<Entity>>();
            _entityComponents = new ConcurrentDictionary<Entity, Dictionary<Type, IComponent>>();

            _systemsToNotify = new Dictionary<DependsOnComponents, List<ITerribleSystem>>();
        }

        public Entity NewEntity()
        {
            var id = GetEntityId();
            var transform = new Transform();
            var entity = new Entity(id, this, transform);

            _allEntities.Add(entity);

            if (!_entitiesWithComponentSet.ContainsKey(entity.ComponentSet))
            {
                _entitiesWithComponentSet.TryAdd(entity.ComponentSet, new List<Entity>());
            }

            _entitiesWithComponentSet[entity.ComponentSet].Add(entity);

            if (!_entityComponents.ContainsKey(entity))
            {
                _entityComponents.TryAdd(entity, new Dictionary<Type, IComponent>());
            }

            return entity;
        }

        public T AddComponent<T>(Entity entity, T component) where T : IComponent
        {   
            TryAddComponent(entity, component);   
            return component;
        }

        public void RemoveComponent<T>(Entity entity) where T : IComponent 
        {
            var type = typeof(T);
            var newComponentSet = new ComponentSet(entity.ComponentSet.ComponentTypes.Where(x => x != type).ToArray());

            _entitiesWithComponent[type].Remove(entity);
            _entityComponents[entity].Remove(type);
            RemoveFromSystems(entity);
            ChangeEntityComponentSet(entity, newComponentSet);
        }

        public T GetComponent<T>(Entity entity) where T : IComponent
        {
            if (entity.HasComponent<T>())
            {
                return (T) _entityComponents[entity][typeof(T)];
            }

            return default(T);
        }

        public bool HasComponent<T>(Entity entity) where T : IComponent
        {
            var type = typeof(T);
            return entity.ComponentSet.ComponentTypes.Contains(type);
        }

        internal void RegisterSystem(ITerribleSystem system)
        {
            var dependsOn = system.GetDependencies();
            if (!_systemsToNotify.ContainsKey(dependsOn))
            {
                _systemsToNotify.Add(dependsOn, new List<ITerribleSystem>());
            }

            _systemsToNotify[dependsOn].Add(system);
        }

        internal void UnregisterSystem(ITerribleSystem system)
        {
            _systemsToNotify[system.GetDependencies()].Remove(system);
        }

        private int GetEntityId()
        {
            return _entityIdCounter++;
        }

        private void ChangeEntityComponentSet(Entity entity, ComponentSet newComponentSet)
        {
            _entitiesWithComponentSet[entity.ComponentSet].Remove(entity);

            if (!_entitiesWithComponentSet.ContainsKey(newComponentSet))
            {
                _entitiesWithComponentSet.TryAdd(newComponentSet, new List<Entity>());
            }

            _entitiesWithComponentSet[newComponentSet].Add(entity);
            entity.ComponentSet = newComponentSet;
        }

        private void TryAddComponent<T>(Entity entity, T component) where T : IComponent
        {
            var type = typeof(T);
            if (HasComponent<T>(entity))
            {
                throw new InvalidOperationException($"Entity ({entity.Id}) already has component {type.Name}");
            }

            if (!_entitiesWithComponent.ContainsKey(type))
            {
                _entitiesWithComponent.TryAdd(type, new List<Entity>());
            }

            _entitiesWithComponent[type].Add(entity);
            _entityComponents[entity][type] = component;
            ChangeEntityComponentSet(entity, new ComponentSet(entity.ComponentSet, type));
            AddToSystems(entity);
        }

        private List<ITerribleSystem> SystemsWhichSatisfy(ComponentSet componentSet)
        {
            var systems = new List<ITerribleSystem>();
            foreach (var kv in _systemsToNotify)
            {
                var systemComponentSet = kv.Key.RequiredTypes.ComponentTypes;
                if (!systemComponentSet.Except(componentSet.ComponentTypes).Any())
                {
                    systems.AddRange(kv.Value);
                }
            }

            return systems;
        }

        private void AddToSystems(Entity entity)
        {
            var systems = SystemsWhichSatisfy(entity.ComponentSet);
            foreach (var system in systems)
            {
                var terribleSystem = system as TerribleSystem;
                terribleSystem?.CollectionUpdate(entity, EntityCollectionChange.Added);
            }
        }

        private void RemoveFromSystems(Entity entity)
        {
            var systems = SystemsWhichSatisfy(entity.ComponentSet);
            foreach (var system in systems)
            {
                var terribleSystem = system as TerribleSystem;
                terribleSystem?.CollectionUpdate(entity, EntityCollectionChange.Removed);
            }
        }
    }
}