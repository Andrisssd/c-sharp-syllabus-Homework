using System;

namespace AsciiFigure_Exercise8
{
    class AsciiFigure
    {
        private int _size;

        public AsciiFigure(int size)
        {
            this._size = size;
        }

        public void PrintFigure()
        {
            string baseStr = "";
            for(int i = 1; i <= _size; i++)
            {
                baseStr += RepeatForLoop("////", _size-i);
                baseStr += RepeatForLoop("****", (i-1)*2);
                baseStr += RepeatForLoop(@"\\\\", _size-i);
                baseStr += "\n"; 
            }
            Console.WriteLine(baseStr);
        } 

        public static string RepeatForLoop(string s, int n)
        {
            var result = "";
            if (n==0)
            {
                return result;
            }
            for (var i = 0; i < n; i++)
            {
                result += s;
            }
            return result;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            AsciiFigure figure5 = new AsciiFigure(7);
            figure5.PrintFigure();
        }
    }
}
