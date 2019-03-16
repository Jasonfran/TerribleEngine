using System.Collections.Generic;
using TerribleEngine.ECS;

namespace TerribleEngine.World
{
    public class World : IWorld
    {
        public List<Entity> Entities { get; }
    }
}