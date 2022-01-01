using System;
using Exceptions;

namespace Exercise5
{
    public class Date
    {
        private int _year;
        private int _month;
        private int _day;
        private DateTime _date;

        public void SetDate(int year, int month, int day)
        {
            try
            {
                _date = new DateTime(year, month, day);
                _day = _date.Day;
                _month = _date.Month;
                _year = _date.Year;
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
