using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var colors = new List<string>();
            string[] colorArray = { "Green", "White", "Black", "Yellow", "Blue" };

            colors.Add("Red");
            foreach(var color in colorArray)
            {
                colors.Add(color);
            }

            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }

            Console.WriteLine();
        }
    }
}
