using System.Collections.Generic;

namespace TerribleEngine.ECS
{
    public interface IEntityParent
    {
        List<IEntity> Children { get; }

    }
}