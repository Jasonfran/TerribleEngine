using TerribleEngine.ECS;

namespace TerribleEngine.EditorHelpers.Commands
{
    public class EntityParentedCommandArgs
    {
        public IEntity Parent { get; }

        public IEntity Child { get; }

        public EntityParentedCommandArgs(IEntity parent, IEntity child)
        {
            Parent = parent;
            Child = child;
        }
    }
}