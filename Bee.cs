using System;
using static System.Console;

namespace InheritanceGameDemo
{
    class Bee : Character
    {
        private bool HasPoisonSting;
        
        public Bee(string name, int health, ConsoleColor color, bool hasPoison)
            : base(name, health, color, ArtAssets.Bee)
        {
            HasPoisonSting = hasPoison;
        }

        public void Fly()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine(" takes to the air!");
        }
        public void Sting()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            Write(" lunges forward with their ");
            if (HasPoisonSting)
            {
                WriteLine("poison stinger.");
            }
            else
            {
                WriteLine("sharp stinger.");
            }
        }
        public override void Fight(Character otherCharacter)
        {
            
            ForegroundColor = Color;
            WriteLine($"Bee {Name} is fighting {otherCharacter.Name}.");
            ResetColor();
            //int randNom = RandomGenerator.Next(1, 101);
            //if (randNom <= 50)
            //{
            //    Fly();
            //}
            //else
            //{
            //    Sting();
            //}
        }
    }
}
