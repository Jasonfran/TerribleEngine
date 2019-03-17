using TerribleEngine.Enums;

namespace TerribleEngine.ECS
{
    public class EntityCollectionUpdate
    {
        public Entity Entity { get; }
        public EntityCollectionChange Change { get; }

        public EntityCollectionUpdate(Entity entity, EntityCollectionChange change)
        {
            Entity = entity;
            Change = change;
        }
    }
}