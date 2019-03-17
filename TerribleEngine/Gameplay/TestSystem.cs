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
        private float step = 0.0f;

        public override void OnInit()
        {
            base.OnInit();
            Console.WriteLine("Test System init");

            testEntity = EntityManager.NewEntity();
            testEntity.AddComponent(new Renderable()
            {
                Material = null,
                Model = ResourceManager.LoadModel("Models/cube.obj")
            });
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            step += dt;

            testEntity.Transform.Position = new Vector3((float)Math.Sin(step) * 6.0f, 0.0f, 0.0f);
            Console.WriteLine(dt);

        }

        public override void OnExit()
        {
            base.OnExit();
            Console.WriteLine("Test system exit");
        }
    }
}