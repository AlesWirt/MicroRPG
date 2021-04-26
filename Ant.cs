using System;
using static System.Console;

namespace InheritanceGameDemo
{
    class Ant : Character
    {
        private int ChargeDistance;
        private Item CurrentItem;

        public Ant(string name, int health, ConsoleColor color, int distance)
            : base(name, health, color, ArtAssets.Ant)
        {
            ChargeDistance = distance;
        }

        public void PickUpItem(Item item)
        {
            CurrentItem = item;
        }
        public void Charge()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine($" charges swiftly forward {ChargeDistance} inches.");

            if(CurrentItem != null)
            {
                WriteLine($"They are carrying {CurrentItem.Name}.");
            }
        }
        public void Bite()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();
            WriteLine($" viciously chomps down!");
        }

        public override void Fight(Character otherCharacter)
        {
            //WriteLine($"Ant {Name} is fighting {otherCharacter.Name}.");
            //Options:
            //  -   50% hit with a bite for 4 damage
            //  -   50% miss with a bite


            ForegroundColor = Color;
            int randPercent = RandomGenerator.Next(1, 101);
            Write($"Ant {Name} bites at {otherCharacter.Name} and ");
            if (randPercent <= 50)
            {
                WriteLine("hits for 4 damage.");
                otherCharacter.TakeDamage(4);
            }
            else
            {
                WriteLine("misses...");
            }
            ResetColor();
        }
    }
}
