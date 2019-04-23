using TerribleEditorV2.Models;
using TerribleEditorV2.Models.SceneTree;
using TerribleEngine.ECS;

namespace TerribleEditorV2.Controller
{
    public interface ISceneTreeController
    {
        SceneTreeViewModel Model { get; }
        void AddEntity(IEntity entity);
        void AddChild(IEntity parent, IEntity child);

        void SelectedItemChanged(object item);
    }
}