using System.Collections.Generic;
using TerribleEngine.ECS;

namespace TerribleEngine.World
{
    public interface IWorld
    {
        List<Entity> Entities { get; }
    }
}