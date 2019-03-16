using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TerribleEngine.ComponentModels;

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

        private int _entityIdCounter;
        
        public EntityManager(ISystemManager systemManager)
        {
            _systemManager = systemManager;
            _allEntities = new List<Entity>();
            _entitiesWithComponentSet = new ConcurrentDictionary<ComponentSet, List<Entity>>();
            _entitiesWithComponent = new ConcurrentDictionary<Type, List<Entity>>();
            _entityComponents = new ConcurrentDictionary<Entity, Dictionary<Type, IComponent>>();
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

        public bool HasComponent<T>(Entity entity) where T : IComponent
        {
            var type = typeof(T);
            return entity.ComponentSet.ComponentTypes.Contains(type);
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

        private void AddToSystems(Entity entity)
        {
            var systems = _systemManager.SystemsWhichSatisfy(entity.ComponentSet);
            foreach (var system in systems)
            {
                system.Entities.Add(entity);
            }
        }

        private void RemoveFromSystems(Entity entity)
        {
            var systems = _systemManager.SystemsWhichSatisfy(entity.ComponentSet);
            foreach (var system in systems)
            {
                system.Entities.Remove(entity);
            }
        }
    }
}