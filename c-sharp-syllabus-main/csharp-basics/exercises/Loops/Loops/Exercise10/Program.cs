﻿using System;

namespace Exercise10
{
    class Program
    {
        private static int min { get; set; }
        private static int max { get; set; }

        static void Main(string[] args)
        {
            StartProgram();
        }

        public static int GetMax()
        {
            return max;
        }

        public static int GetMin()
        {
            return min;
        }

        public static void SetMax(int num)
        {
            max = num;
        }

        public static void SetMin(int num)
        {
            min = num;
        }

        public static void StartProgram()
        {
            AskForNums();
            PrintSquare();
        }

        public static void AskForNums()
        {
            int minn, maxx;
            Console.Write("Min? ");
            int.TryParse(Console.ReadLine(), out minn);
            Console.Write("Max? ");
            int.TryParse(Console.ReadLine(), out maxx);
            if(maxx <= minn)
            {
                Console.WriteLine("Max equals or smaller than Min!");
                StartProgram();
            }
            else
            {
                SetMax(maxx);
                SetMin(minn);
            }
        }

        public static void PrintSquare() 
        {
            string baseString = "";
            string str = "";
            int iterationNum = GetMax() - GetMin();
            for (int i = GetMin(); i <= GetMax(); i++)
            {
                baseString += i;
            }

            for (int i = 0; i < iterationNum; i++)
            {
                str += ToReplaceLetter(baseString, i) + "\n";
            }
            Console.WriteLine(str); 
        }

        public static string ToReplaceLetter(string text,int num)
        {
            string newString = "";
            newString += text.Substring(num, text.Length-num) + text.Substring(0, num);
            return newString;
        }
    }
}
