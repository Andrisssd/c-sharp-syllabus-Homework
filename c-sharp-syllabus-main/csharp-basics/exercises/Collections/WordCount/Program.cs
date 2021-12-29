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
            TextFileInfo worker = new TextFileInfo();

            worker.SetTextPath(TEXT_PATH);

            Console.WriteLine(worker.GetNumOfChars());
            Console.WriteLine(worker.GetNumOfLines());
            Console.WriteLine(worker.GetNumOfWords());
        }
    }
}
