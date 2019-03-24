using System;
using System.Collections.Generic;
using TerribleEngine.ECS;

namespace TerribleEngine.Scene
{
    public class World : IWorld
    {
        public WorldRoot WorldRoot { get; }

        public World()
        {
            WorldRoot = new WorldRoot();
        }

        public void AddChild(IEntity entity)
        {
            WorldRoot.Children.Add(entity);
            entity.SetWorld(this);
        }
    }
}