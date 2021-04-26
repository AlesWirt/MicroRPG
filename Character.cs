using System;
using static System.Console;

namespace InheritanceGameDemo
{
    class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public string TextArt { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public int MaxHealth { get; protected set; }
        public Random RandomGenerator { get; protected set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }
        public Character(string name, int health, ConsoleColor color, string textArt)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            TextArt = textArt;
            Color = color;
            RandomGenerator = new Random();
        }

        public void DisplayInfo()
        {
            BackgroundColor = Color;
            Write($"{Name}");
            ResetColor();

            ForegroundColor = Color;
            WriteLine($"{TextArt}\n\n");
            WriteLine("****************");
            WriteLine($"Health: {Health}");
            WriteLine("****************");
            ResetColor();
        }

        public virtual void Fight(Character otherCharacter)
        {
            WriteLine("Enemy is fighting.");
        }

        public void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            if(Health < 0)
            {
                Health = 0;
            }
        }
        public void DisplayHealthBar()
        {
            ForegroundColor = Color;
            WriteLine($"{Name} health:");
            ResetColor();
            Write("[");
            //Draw "Health" hit points that are filled in:
            BackgroundColor = ConsoleColor.Green;
            for(int i = 0; i < Health; i++)
            {
                Write(" ");
            }
            //Draw the rest as not filled int:
            BackgroundColor = ConsoleColor.Black;
            for(int i = Health; i < MaxHealth; i++)
            {
                Write(" ");
            }
            WriteLine($"] ({Health}/{MaxHealth})");
        }
    }
}
