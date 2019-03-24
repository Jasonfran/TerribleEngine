using TerribleEngine.ECS;

namespace TerribleEngine.Events
{
    public class EntityParentedEvent : IEvent
    {
        public IEntity Parent { get; }
        public IEntity Child { get; }

        public EntityParentedEvent(IEntity parent, IEntity child)
        {
            Parent = parent;
            Child = child;
        }
    }
}