using TerribleEngine.ECS;
using TerribleEngine.Scene;

namespace TerribleEngine.Events
{
    public class EntityCreatedEvent : IEvent
    {
        public IEntity Entity { get; }
        public IWorld World { get; }

        public EntityCreatedEvent(IEntity entity, IWorld world)
        {
            Entity = entity;
            World = world;
        }
    }
}