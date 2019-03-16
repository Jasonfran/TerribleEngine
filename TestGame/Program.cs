using System;
using System.Collections.Generic;
using System.Reflection;
using TerribleEngine.Attributes;

namespace TestGame
{

    class Program
    {
        private static EngineThread thread;

        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
        }
    }
}
