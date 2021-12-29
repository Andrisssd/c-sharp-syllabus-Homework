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
    public class TextFileInfo
    {
        private string _textPath;

        public string SetTextPath(string path)
        {
            if (FileValid(path))
            {
                _textPath = path;
                return _textPath;
            }

            throw new PathNotFoundException(path);
        }

        public int GetNumOfChars()
        {
            if (FileValid(_textPath))
            {
                string[] textLines = File.ReadAllLines(_textPath);
                return textLines.Sum(s => s.Length);
            }

            throw new FileNotFoundException(_textPath);
        }

        public int GetNumOfLines()
        {
            if (FileValid(_textPath))
            {
                string[] textLines = File.ReadAllLines(_textPath);
                return textLines.Length;
            }

            throw new FileNotFoundException(_textPath);
        }

        public int GetNumOfWords()
        {
            if (FileValid(_textPath))
            {
                string text = File.ReadAllText(_textPath);
                return Regex.Matches(text, @"\b\w+\b").Count;
            }

            throw new FileNotFoundException(_textPath);
        }

        public bool FileValid(string _path)
        {
            return File.Exists(_path);
        }

        public string GetFullPath()
        {
            return _textPath;
        }
    }
}
