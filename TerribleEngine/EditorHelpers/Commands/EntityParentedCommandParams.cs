using TerribleEngine.ECS;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityParentedCommandParams
    {
        public IEntity Parent { get; }

        public IEntity Child { get; }

        public EntityParentedCommandParams(IEntity parent, IEntity child)
        {
            Parent = parent;
            Child = child;
        }
    }
}