using Fare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebSupergoo.ABCpdf;

namespace WordCount
{
    class Program
    {
        private const string TEXT_PATH = @"C:\Users\User\Desktop\homework\c-sharp-syllabus-Homework\c-sharp-syllabus-main\csharp-basics\exercises\Collections\WordCount\lear.txt";
        static void Main(string[] args)
        {
            if (File.Exists(TEXT_PATH))
            {
                string text = File.ReadAllText(TEXT_PATH);
                string[] textLines = File.ReadAllLines(TEXT_PATH);

                int numOfChars = textLines.Sum(s => s.Length);
                int numOfLines = textLines.Length;
                int numOfWords = Regex.Matches(text, @"\b\w+\b").Count;

                Console.WriteLine("Lines = {0}",numOfLines);
                Console.WriteLine("Words = {0}",numOfWords);
                Console.WriteLine("Chars = {0}",numOfChars);
            }
        }
    }
}
