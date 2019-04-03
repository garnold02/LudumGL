using System;
using System.Collections.Generic;
using LudumGL;

namespace TestGame
{
    class Program
    {
        public static Loop gameLoop;
        static void Main(string[] args)
        {
            gameLoop = new Loop();
            Game.gameLoop = gameLoop;
            Game.Start();
        }
    }
}
