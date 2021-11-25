using System;

namespace CozaLozaWoza_Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseString = "";
            for(int i=1; i<=110; i++)
            {
                if (i%11==1)
                {
                    baseString+="\n";
                }
                if (i%15==0)
                {
                    baseString+="CozaLoza ";
                }
                else if (i%7==0)
                {
                    baseString+="Woza ";
                }
                else if (i%5==0)
                {
                    baseString+="Loza ";
                }
                else if (i%3==0)
                {
                    baseString+="Coza ";
                }
                else
                {
                    baseString+=i+" ";
                }
            }
            Console.WriteLine(baseString);
        }
    }
}
