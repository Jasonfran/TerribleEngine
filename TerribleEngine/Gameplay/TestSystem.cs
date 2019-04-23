using System;
using System.Collections.Generic;
using OpenTK;
using TerribleEngine.Attributes;
using TerribleEngine.ComponentModels;
using TerribleEngine.ECS;
using TerribleEngine.Events;

namespace TerribleEngine.Gameplay
{

    //[DependsOnComponents(typeof(Transform), typeof(Renderable))]
    public class TestSystem : TerribleSystem
    {
        private Entity testEntity;
        private Entity testEntity2;
        private float step = 0.0f;

        protected override void OnInit()
        {
            Console.WriteLine("Test System init");

            testEntity = EntityManager.NewEntity();
            testEntity.AddComponent(new Renderable()
            {
                Material = null,
                Model = ResourceManager.LoadModel("Models/cube.obj")
            });

            World.AddChild(testEntity);


            testEntity2 = EntityManager.NewEntity();
            testEntity2.AddComponent(new Renderable()
            {
                Material = null,
                Model = ResourceManager.LoadModel("Models/cube.obj")
            });

            testEntity.AddChild(testEntity2);
        }

        protected override void OnUpdate(float dt)
        {
            step += dt;

            testEntity.Transform.Position = new Vector3((float)Math.Sin(step) * 6.0f, 0.0f, 0.0f);
        }

        protected override void OnExit()
        {
            Console.WriteLine("Test system exit");
        }
    }
}