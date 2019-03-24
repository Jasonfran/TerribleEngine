using System;
using TerribleEditorV2.Controller;
using TerribleEngine.ECS;
using TerribleEngine.EditorHelpers.Interfaces;

namespace TerribleEditorV2.EngineHelpers
{
    public class EditorEntityManager : IEditorEntityManager
    {
        public ISceneTreeController SceneTreeController { get; }

        public EditorEntityManager(ISceneTreeController sceneTreeController)
        {
            SceneTreeController = sceneTreeController;
        }

        public void AddEntity(IEntity entity)
        {
            SceneTreeController.AddEntity(entity); 
            Console.WriteLine("new entity added to scene tree view");
        }

        public void AddChild(IEntity parent, IEntity child)
        {
            SceneTreeController.AddChild(parent, child);
            Console.WriteLine("new entity added as child");
        }
    }
}