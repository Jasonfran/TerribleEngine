using System;
using System.Collections.Generic;
using TerribleEditorV2.Controller;
using TerribleEngine.ECS;
using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEditorV2.EngineHelpers
{
    public class EditorEntityManager : IEditorEntityManager
    {
        private Dictionary<IEntity, List<IEntity>> _entities;

        public ISceneTreeController SceneTreeController { get; }

        public EditorEntityManager(ISceneTreeController sceneTreeController)
        {
            SceneTreeController = sceneTreeController;

            _entities = new Dictionary<IEntity, List<IEntity>>();
        }

        public void AddEntity(IEntity entity)
        {
            _entities.Add(entity, new List<IEntity>());
            SceneTreeController.AddEntity(entity); 
            Console.WriteLine("new entity added to scene tree view");
        }

        public void AddChild(IEntity parent, IEntity child)
        {
            if (_entities.TryGetValue(parent, out var entities))
            {
                entities.Add(child);
            }

            if (_entities.TryGetValue(child.Parent, out var exParentEntities))
            {
                exParentEntities.Remove(child);
            }

            SceneTreeController.AddChild(parent, child);
            Console.WriteLine("new entity added as child");
        }
    }
}