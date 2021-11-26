using System;

namespace Exercise5
{
    class Date
    {
        public int year
        {
            get => date.Year;
        }

        public int month
        {
            get => date.Month;
        }

        public int day
        {
            get => date.Day;
        }

        public DateTime date;

        public Date(int year, int month, int day)
        {
            date = new DateTime(year, month, day);
        }

        public void DisplayDate()
        {
            Console.WriteLine($"{year}/{month}/{day}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var date = new Date(2000, 08, 01);
            date.DisplayDate();
            var date2 = new Date(2000, 45, 01);
            date.DisplayDate();
        }
    }
}
