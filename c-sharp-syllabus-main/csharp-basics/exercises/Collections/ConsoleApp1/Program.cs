using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        string str = "";
        for (int i = 0; i<=n; i++)
        {
            for (int j = 0; j<i; j++)
            {
                str+=n.ToString();
            }

            str+="\n";
        }
        Console.WriteLine(str);




    }
}