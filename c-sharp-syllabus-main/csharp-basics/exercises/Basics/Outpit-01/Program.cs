using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetNumber());
            Console.ReadKey();
        }

        static int GetNumber()
        {
            return new Random().Next() * 10;
        }
    }
}
