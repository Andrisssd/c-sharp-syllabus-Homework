using System;

namespace Piglet_Exercise7
{
    class Program
    {
        public static int score;
        static void Main(string[] args)
        {
            StartGame();
        }
        public static void Roll()
        {

            int roll = new Random().Next(1, 7);
            if (roll!=1)
            {
                score += roll;
                Console.WriteLine($"You rolled a {roll}!");
                AskForRoll();
            }
            else
            {
                score =0;
                GameOver();
            }
        }
        public static void StartGame()
        {
            score = 0;
            Console.WriteLine("Welcome to Piglet!");
            Roll();
        }
        public static void AskForRoll()
        {
            Console.Write("Roll again? Y/n ");
            string answer = Console.ReadLine().ToLower();
            Console.WriteLine("===================");
            if(answer == "y")
            {
                Roll();
            }
            else if(answer == "n")
            {
                GameOver();
            }
            else
            {
                Console.WriteLine("Wrong input");
                AskForRoll();
            }
        }

        public static void AskForRematch()
        {
            Console.Write("Play again? Y/n ");
            string answer = Console.ReadLine().ToLower();
            Console.WriteLine("===================");
            if (answer == "y")
            {
                  StartGame();
            }
            else if (answer == "n")
            {
                  Environment.Exit(0);
            }
            else
            {
                  Console.WriteLine("Wrong input");
                   AskForRematch();
            }
        }
        public static void GameOver()
        {
            Console.WriteLine($"You got {score} points!");
            AskForRematch();
        }
    }
}
