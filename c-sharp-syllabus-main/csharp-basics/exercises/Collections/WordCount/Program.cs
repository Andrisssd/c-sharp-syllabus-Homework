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
        private const string TEXT_PATH = "../../lear.txt";
        static void Main(string[] args)
        {
            TextFileInfo worker = new TextFileInfo();

            worker.SetTextPath(Path.GetFullPath(TEXT_PATH));

            Console.WriteLine(worker.GetNumOfChars());
            Console.WriteLine(worker.GetNumOfLines());
            Console.WriteLine(worker.GetNumOfWords());
        }
    }
}
