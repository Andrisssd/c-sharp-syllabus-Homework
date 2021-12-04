using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneDirectory one = new PhoneDirectory();
            one.PutNumber("Andris", "29345676");
            Console.WriteLine(one.GetNumber("Andris"));
            Console.WriteLine(one.GetNumber("Andrew"));
        }
    }
}
