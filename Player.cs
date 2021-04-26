using System;
using static System.Console;

namespace InheritanceGameDemo
{
    class Player : Character
    {
        public Player(string name, int health, ConsoleColor color)
            : base(name, health, color, ArtAssets.Player)
        {

        }
        private void ThrowAtDirt(Character otherCharacter)
        {
            Write("You throw a clump of dirt ");
            int randPercent = RandomGenerator.Next(1, 101);
            if (randPercent <= 90)
            {
                WriteLine("and it hits.");
                otherCharacter.TakeDamage(2);
            }
            else
            {
                WriteLine("and it`s misses...");
            }
        }
        private void SwingAt(Character otherCharacter)
        {
            Write("You taking mighty swing ");
            int randPercent = RandomGenerator.Next(1, 101);
            if (randPercent <= 50)
            {
                WriteLine("and it connects solidly.");
                otherCharacter.TakeDamage(4);
            }
            else
            {
                WriteLine("and it`s misses...");
            }
        }
        public override void Fight(Character otherCharacter)
        {
            //WriteLine($"Player {Name} attacks {otherCharacter.Name}.");
            ForegroundColor = Color;
            WriteLine($@"You are facing {otherCharacter.Name}. What would you like to do?

1. Pick up a clump of dirt and throw it (90% chance to do 2 damage).
2. Take a mighty swing with a twig (50% chance to do 4 damage).
");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            if(keyInfo.Key == ConsoleKey.D1)
            {
                ThrowAtDirt(otherCharacter);
            }
            else if(keyInfo.Key == ConsoleKey.D2)
            {
                SwingAt(otherCharacter);
            }
            else
            {
                WriteLine("That`s not a valid move! Try again!");
                Fight(otherCharacter);
                return;
            }
                ResetColor();
        }
    }
}
