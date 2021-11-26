using System;
using System.Threading.Tasks;

namespace Exercise_9
{
    class RollTwoDice
    {
        private static int neededSum { get; set; }
        public static void StartGame()
        {
            Console.Write("Desired sum: ");
            try
            {
                neededSum = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new Exception("Wrong input format");
            }
            
            if(neededSum>=2 && neededSum<=12)
            {
                Roll();
            }
        }
        public static void Roll()
        {
            int firstRandomNum = new Random().Next(1, 7);
            int secondRandomNum = new Random().Next(1, 7);
            int rolledSum = firstRandomNum + secondRandomNum;
            Console.WriteLine($"{firstRandomNum} and {secondRandomNum} = {rolledSum}");
            if(rolledSum != neededSum)
            {
                Roll();
            }
            else
            {
                neededSum = default;
                StartGame();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RollTwoDice.StartGame();
        }
    }
}
