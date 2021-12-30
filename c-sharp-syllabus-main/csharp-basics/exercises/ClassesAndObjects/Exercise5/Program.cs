using System;
using Exceptions;

namespace Exercise5
{
    public class Date
    {
        private int _year
        {
            get => _date.Year;
        }

        private int _month
        {
            get => _date.Month;
        }

        private int _day
        {
            get => _date.Day;
        }

        private DateTime _date;

        public void SetDate(int year, int month, int day)
        {
            try
            {
                _date = new DateTime(year, month, day);
            }
            catch
            {
                throw new InvalidParameterException();
            }
        }

        public string GetDate()
        {
            return $"{_year}/{_month}/{_day}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var date = new Date();
            date.SetDate(2021, 10, 10);
            Console.WriteLine(date.GetDate());
            var date2 = new Date();
            date2.SetDate(2021, 45, 10);
            Console.WriteLine(date2.GetDate());
        }
    }
}
