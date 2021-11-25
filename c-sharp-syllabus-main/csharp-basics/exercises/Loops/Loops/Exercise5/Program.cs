using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseString = "";
            int lengthSum;
            Console.Write("Enter first word:");
            string firstWord = Console.ReadLine();
            Console.Write("Enter second word:");
            string secondWord = Console.ReadLine();
            lengthSum = firstWord.Length + secondWord.Length;
            baseString += firstWord;
            SumBaseStringWithDots(lengthSum, ref baseString);
            baseString += secondWord;
            Console.WriteLine(baseString);
        }

        public static void SumBaseStringWithDots(int lengthSum, ref string baseString)
        {
            int dotNum = 30 - lengthSum;
            if (dotNum>=0)
            {
                for(int i = 0; i < dotNum; i++)
                {
                    baseString += ".";
                }
            }
            else
            {
                Console.WriteLine("Reached symbol limit");
            }
        }
    }
}
