using System;

namespace CozaLozaWoza_Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            CozaLozaWoza core = new CozaLozaWoza();

            string baseString = "";

            for(int i=1; i<=110; i++)
            {
                if(i%11 == 0)
                {
                    baseString += "\n";
                }
                baseString += core.GetCozaLozaWozaOrNumber(i);
            }
            Console.WriteLine(baseString);
        }

        
    }
}
