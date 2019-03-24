using TerribleEngine.ECS;

namespace TerribleEngine.EditorHelpers.Interfaces
{
    public interface IEditorEntityManager
    {
        void AddEntity(IEntity entity);
        void AddChild(IEntity parent, IEntity child);
    }
}