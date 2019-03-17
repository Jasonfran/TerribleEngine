using System.Collections.Generic;
using TerribleEngine.ECS;

namespace TerribleEngine.Scene
{
    public interface IWorld
    {
        WorldRoot WorldRoot { get; }
    }
}