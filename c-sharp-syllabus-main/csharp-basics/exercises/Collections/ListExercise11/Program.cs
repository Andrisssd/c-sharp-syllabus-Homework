using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            for(int i = 0; i < 10; i++)
            {
                list.Add(i.ToString());
            }
 
            list.Insert(4, "newValue");
            list[list.Count-1] = "last element";
            list.Sort();
            if (list.Contains("Foobar"))
            {
                Console.WriteLine("Contains Foobar");
            }

            foreach(var str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}
