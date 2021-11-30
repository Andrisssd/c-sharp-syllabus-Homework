using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter alphabetic-only text");
            string input = Console.ReadLine();
            ConvertCharsToNums(input);
        }

        public static void ConvertCharsToNums(string input)
        {
            char[] inChar = input.ToLower().ToCharArray();

            for(int i = 0; i < inChar.Length; i++)
            {
                switch (inChar[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                        Console.Write(2+" ");
                        break;
                    case 'd':
                    case 'e':
                    case 'f':
                        Console.Write(3+" ");
                        break;
                    case 'g':
                    case 'h':
                    case 'i':
                        Console.Write(4+" ");
                        break;
                    case 'j':
                    case 'k':
                    case 'l':
                        Console.Write(5+" ");
                        break;
                    case 'm':
                    case 'n':
                    case 'o':
                        Console.Write(6+" ");
                        break;
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                        Console.Write(7+" ");
                        break;
                    case 't':
                    case 'u':
                    case 'v':
                        Console.Write(8+" ");
                        break;
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        Console.Write(9+" ");
                        break;
                    case ' ':
                        Console.Write("  ");
                        break;
                    default:
                        throw new Exception("Wrong input.");
                        break;
                }
            }
                
        }
    }
}
