using System;
using System.Collections.Generic;
using TerribleEngine.Attributes;
using TerribleEngine.ComponentModels;
using TerribleEngine.ECS;
using TerribleEngine.Events;

namespace TerribleEngine.Gameplay
{

    [DependsOnComponents(typeof(Transform), typeof(Renderable))]
    public class TestSystem : TerribleSystem
    {
        public override void OnInit()
        {
            base.OnInit();
            Console.WriteLine("Test System init");
            EventManager.RegisterEventListener<TestEvent>(TestEventHandler);
        }

        private void TestEventHandler(object obj)
        {
            if (obj is TestEvent e)
            {
                //Console.WriteLine(e.Message);
            }
        }

        public override void Update()
        {
            base.Update();
            EventManager.RaiseEvent(new TestEvent("test1", "test2"));
            //Console.WriteLine("Raised event!");

        }

        public override void OnExit()
        {
            base.OnExit();
            Console.WriteLine("Test system exit");
        }
    }
}