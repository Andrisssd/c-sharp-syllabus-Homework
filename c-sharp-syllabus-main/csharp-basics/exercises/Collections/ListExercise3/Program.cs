using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var colors = new List<string>();
            colors.Add("Red");
            colors.Add("Green");
            colors.Add("Orange");
            colors.Add("White");
            colors.Add("Black");
            colors.Insert(0, "Yellow");
            Console.WriteLine(string.Join(",", colors));

            
            colors.Insert(1, "Blue");
            colors.Insert(3, "Gray");
            Console.WriteLine(string.Join(",", colors));
        }
    }
}
