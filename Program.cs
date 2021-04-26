using System;
using static System.Console;

namespace InheritanceGameDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Micro RPG";

            Game myGame = new Game();
            myGame.Run();
        }
    }
}
