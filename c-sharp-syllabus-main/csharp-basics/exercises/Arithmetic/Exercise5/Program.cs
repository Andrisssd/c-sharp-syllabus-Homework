using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("I'm thinking of a number between 1-100.  Try to guess it.");
            int loggedNum = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            int trueNumber = random.Next(1, 101);

            if (loggedNum == trueNumber)
            {
                Console.WriteLine("You guessed it!  What are the odds?!?");
               
            } else if (loggedNum > trueNumber)
            {
                Console.WriteLine($"Sorry, you are too high.  I was thinking of {trueNumber}.");
               
            }else if(loggedNum < trueNumber)
            {
                Console.WriteLine($"Sorry, you are too low.  I was thinking of {trueNumber}.");
            }
        }
    }
}
