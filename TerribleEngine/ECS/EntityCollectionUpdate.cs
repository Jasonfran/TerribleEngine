using TerribleEngine.Enums;

namespace TerribleEngine.ECS
{
    public class EntityCollectionUpdate
    {
        public IEntity Entity { get; }
        public EntityCollectionChange Change { get; }

        public EntityCollectionUpdate(IEntity entity, EntityCollectionChange change)
        {
            Entity = entity;
            Change = change;
        }
    }
}