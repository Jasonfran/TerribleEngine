using TerribleEngine.ECS;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityCreatedCommandParams
    {
        public IEntity Entity { get; }

        public EntityCreatedCommandParams(IEntity entity)
        {
            Entity = entity;
        }
    }
}