using System;
using System.Collections.Generic;
using Figgle;
using static System.Console;

namespace InheritanceGameDemo
{
    class Game
    {
        private Player CurrentPlayer;
        private Character CurrentEnemy;
        private List<Character> Enemies;
        public Game()
        {
            Ant fireAuntie = new Ant("Fire Auntie", 7, ConsoleColor.Red, 3);


            Ant hades = new Ant("hades", 12, ConsoleColor.Magenta, 6);
            Item leafNinjaStar = new Item("Leaf Ninja Star", 10);
            hades.PickUpItem(leafNinjaStar);

            Bee buzzBee = new Bee("buzzBee", 5, ConsoleColor.DarkYellow, true);

            //Polymorphism in action!
            Enemies = new List<Character>() { fireAuntie, hades, buzzBee };
            
        }
        public void Run()
        {

            RunIntro();

            for(int i = 0; i < Enemies.Count; i++)
            {
                CurrentEnemy = Enemies[i];
                IntroCurrentEnemy();
                BattleCurrentEnemy();
                if (CurrentPlayer.IsDead)
                {
                    WriteLine("You were defeated...");
                    WaitForKey();
                    break;
                }
                else
                {
                    WriteLine($"You defeated {CurrentEnemy.Name}!");
                    WaitForKey();
                }
            }

            RunGameOver();
            WaitForKey();
        }

        private void RunGameOver()
        {
            Clear(); 
            if (CurrentPlayer.IsDead)
            {
                WriteLine($@"{FiggleFonts.Epic.Render("You lose!")}
Defeating in microscopic combat, your journey has come to an end. 
You couldn`t make it back to your lab this time.
Try again!
");
            }
            else
            {
                WriteLine($@"{FiggleFonts.Epic.Render("You win!")}
Your journey is over. Exhausted, you make it back inside to your lab,
get your equipment running again, and return yourself to normal size.");
            }

            WriteLine(@"Thanks for playing

Credits:
~ MJP, https://asciiart.website/index.php?art=animals/insects/ants
~ Unknown artist, https://asciiart.website/index.php?art=animals/insects/bees
");
            WaitForKey();
        }

        private void RunIntro()
        {

            WriteLine(FiggleFonts.Ogre.Render("Micro RPG"));
            Write("What is your name? ");
            string name = ReadLine();
            CurrentPlayer = new Player(name, 20, ConsoleColor.Green);
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"You wake up outside and look around at a field of blades of grass towering over you
 /  /              \
/   /   \          /   \
\   \   /          \   /  /
/   /  /     o   \  \  \  \
\  /  /  /  /|\  /  /  /  /
 \ \  \ /   / \  \ /   \ / ");
            ResetColor();
            WaitForKey();
            Clear();
            WriteLine($@"Your memory is hazy, but  you remember flaches  of a science experiment.
You accidentally shrunk yourself down to the size of a quarter. You look around and see a colony
of ants taken an interest in you. Looks like you are going to have to fight your way to the safety.

Are you ready? You have got {Enemies.Count}x insects approaching...");

            CurrentPlayer.DisplayInfo();    
            WriteLine($"");

            WaitForKey();
        }
        private void IntroCurrentEnemy()
        {
            Clear();
            ForegroundColor = CurrentEnemy.Color;
            WriteLine($"A new enemy approaches.");
            ResetColor();
            CurrentEnemy.DisplayInfo();
            WriteLine();
            WaitForKey();
        }
        private void BattleCurrentEnemy()
        {
            while (CurrentPlayer.IsAlive && CurrentEnemy.IsAlive)
            {
                //Show health bars, so player  an informed decision on what to do.
                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();

                //Let the player attack the current enemy and display the results.
                CurrentPlayer.Fight(CurrentEnemy);

                WriteLine();

                WaitForKey();

                //Check if player or enemy is dead.
                if (CurrentPlayer.IsDead || CurrentEnemy.IsDead)
                {
                    break;
                }

                //Re-show the health bars, so player can see the results.
                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                //Let the enemy attack the player and print out the result.
                CurrentEnemy.Fight(CurrentPlayer);

                WaitForKey();
            }
        }
        private void WaitForKey()
        {
            WriteLine("Press any key to continue...\n");
            ReadKey(true);
        }
    }
}
