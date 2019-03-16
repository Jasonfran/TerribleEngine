using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TerribleEngine.Attributes;
using TerribleEngine.Resources;

namespace TerribleEngine.ECS
{
    public class SystemManager : ISystemManager, ISystemLoaderCallback
    {
        private List<ITerribleSystem> _systems;

        private Dictionary<DependsOnComponents, List<ITerribleSystem>> _systemDependencies;

        public SystemManager()
        {
            _systems = new List<ITerribleSystem>();
            _systemDependencies = new Dictionary<DependsOnComponents, List<ITerribleSystem>>();
        }

        public void LoadSystems(ISystemLoader systemLoader)
        {
            systemLoader.LoadSystems(this);
        }

        public void InitialiseSystems(EntityManager entityManager, EventManager eventManager, IResourceManager resourceManager)
        {
            foreach (var system in _systems)
            {
                system.EntityManager = entityManager;
                system.EventManager = eventManager;
                system.ResourceManager = resourceManager;
                system.OnInit();
            }
        }

        public void UpdateSystems()
        {
            foreach (var system in _systems)
            {
                system.Update();
            }
        }

        public void ExitSystems()
        {
            _systems.Clear();
        }

        public void AddSystem(ITerribleSystem system)
        {
            var dependencies = system.GetDependencies();
            if (dependencies == null) return;

            if (!_systemDependencies.ContainsKey(dependencies))
            {
                _systemDependencies.Add(dependencies, new List<ITerribleSystem>());
            }

            _systems.Add(system);
            _systemDependencies[dependencies].Add(system);
        }

        public List<ITerribleSystem> SystemsWhichSatisfy(ComponentSet componentSet)
        {
            var systems = new List<ITerribleSystem>();
            foreach (var kv in _systemDependencies)
            {
                var systemComponentSet = kv.Key.RequiredTypes.ComponentTypes;
                if (!systemComponentSet.Except(componentSet.ComponentTypes).Any())
                {
                    systems.AddRange(kv.Value);
                }
            }

            return systems;
        }
    }
}