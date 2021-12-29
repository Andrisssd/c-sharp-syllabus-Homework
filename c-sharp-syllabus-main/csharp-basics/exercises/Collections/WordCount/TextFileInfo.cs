using Fare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class TextFileInfo
    {
        private string _textPath;

        public string SetTextPath(string path)
        {
            _textPath = path;
            return _textPath;
        }

        public int GetNumOfChars()
        {
            string[] textLines = File.ReadAllLines(_textPath);
            return textLines.Select(line => line=string.Join("", line.Where(letter => letter != ' '))).Sum(line => line.Length);
        }

        public int GetNumOfLines()
        {
            string[] textLines = File.ReadAllLines(_textPath);
            return textLines.Length;
        }

        public int GetNumOfWords()
        {
            string[] textLines = File.ReadAllLines(_textPath);
            string[][] linesAndWords = textLines.Select(line => line.Split(' ').ToArray()).ToArray();
            return linesAndWords.Select(x => x.Count()).Sum();
        }

        public bool FileValid(string _path)
        {
            return File.Exists(_path);
        }
    }
}
