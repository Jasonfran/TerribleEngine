using TerribleEditorV2.Models;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Controller
{
    public interface ISceneTreeController
    {
        SceneTreeViewModel Model { get; }
        void AddEntity(IEntity entity);
        void AddChild(IEntity parent, IEntity child);
    }
}