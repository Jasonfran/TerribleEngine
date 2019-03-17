using System.Collections.Generic;
using TerribleEngine.ECS;

namespace TerribleEngine.Scene
{
    public class WorldRoot : IEntityParent
    {
        public List<IEntity> Children { get; }
    }
}