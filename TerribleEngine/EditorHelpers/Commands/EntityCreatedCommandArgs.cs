using TerribleEngine.ECS;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityCreatedCommandArgs
    {
        public IEntity Entity { get; }

        public EntityCreatedCommandArgs(IEntity entity)
        {
            Entity = entity;
        }
    }
}