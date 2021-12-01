using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        private const string _path = @"C:\Users\User\Desktop\homework\c-sharp-syllabus-Homework\c-sharp-syllabus-main\csharp-basics\exercises\Collections\Histogram\midtermscores.txt";

        private static void Main(string[] args)
        {
            int[] scores = File.ReadAllText(_path).Split(' ').Select(x => int.Parse(x)).ToArray();
            Array.Sort(scores);
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"00-09:","" },
                {"10-19:","" },
                {"20-29:","" },
                {"30-39:","" },
                {"40-49:","" },
                {"50-59:","" },
                {"60-69:","" },
                {"70-79:","" },
                {"80-89:","" },
                {"90-99:","" },
                {"100:","" },

            };
            foreach(var score in scores)
            {
                if(score == 100)
                {
                    dictionary["100:"] = GetNumberOfScores(ref scores, 100, 100);
                }
                else if(score >= 90)
                {
                    dictionary["90-99:"] = GetNumberOfScores(ref scores, 90, 99);
                }
                else if(score >= 80)
                {
                    dictionary["80-89:"] = GetNumberOfScores(ref scores, 80, 89);
                }
                else if(score >= 70)
                {
                    dictionary["70-79:"] = GetNumberOfScores(ref scores, 70, 79);
                }
                else if(score >= 60)
                {
                    dictionary["60-69:"] = GetNumberOfScores(ref scores, 60, 69);
                }
                else if(score >= 50)
                {
                    dictionary["50-59:"] = GetNumberOfScores(ref scores, 50, 59);
                }
                else if(score >= 40)
                {
                    dictionary["40-49:"] = GetNumberOfScores(ref scores, 40, 49);
                }
                else if(score >= 30)
                {
                    dictionary["30-39:"] = GetNumberOfScores(ref scores, 30, 39);
                }
                else if(score >= 20)
                {
                    dictionary["20-29:"] = GetNumberOfScores(ref scores, 20, 29);
                }
                else if(score >= 10)
                {
                    dictionary["10-19:"] = GetNumberOfScores(ref scores, 10, 19);
                }
                else
                {
                    dictionary["0-9:"] = GetNumberOfScores(ref scores, 0, 9);
                }
            }

            foreach(var score in dictionary)
            {
                Console.WriteLine(score.Key+score.Value);
            }
        }

        static string GetNumberOfScores(ref int[] scores, int firstRange, int lastRange)
        {
            string str = "";
            foreach(var score in scores)
            {
                if(score >= firstRange && score <=lastRange)
                {
                    str += "*";
                }
            }

            return str;
        }
    }
}
