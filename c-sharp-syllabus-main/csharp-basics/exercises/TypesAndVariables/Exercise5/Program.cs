using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            string class1 = "English";
            string class2 = "Biology";
            string class3 = "Sport";
            string teacher1 = "Mr. Bob";
            string teacher2 = "Mrs. Bob";
            string teacher3 = "Mr. Fjodor";
            string table = "";
            string[] classes = { class1, class2, class3 };
            string[] teachers = { teacher1, teacher2, teacher3 };

            for(int i = -1; i <= classes.Length; i++)
            {
                if(i == -1 || i == classes.Length)
                {
                    table += "+---------------------------------+\n";
                }
                else
                {
                    table += $"|1|{Repeat(" ", 15-classes[i].Length)}{classes[i]}|{Repeat(" ", 15-teachers[i].Length)}{teachers[i]}|\n";
                }
            }
            Console.WriteLine(table); 
        }

        static string Repeat(string el, int num)
        {
            string str = "";
            for(int i = 0; i < num; i++)
            {
                str += el;
            }
            return str;
        }
    }
}
