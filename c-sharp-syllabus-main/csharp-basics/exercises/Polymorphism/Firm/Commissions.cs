using System;
using System.Collections.Generic;
using System.Text;

namespace Firm
{
    class Commissions : Hourly
    {
        private float _comissionRate;
        private double _totalSales;
        public Commissions(string eName, string eAddress, string ePhone, string socSecNumber, double rate, float comissionRate) :base(eName, eAddress, ePhone,socSecNumber, rate)
        {
            _comissionRate = comissionRate;
            _totalSales = 0;
        }

        public void AddSales(double sales)
        {
            _totalSales = sales;
        }

        public override void AddHours(int moreHours)
        {
            base.AddHours(moreHours);
        }

        public override double Pay()
        {
            var payment = Math.Round(payRate * _hoursWorked + _totalSales * _comissionRate,2);
            _hoursWorked = 0;
            _totalSales = 0;
            return payment;
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"\nCommisions per {_totalSales}$ sales: {Math.Round(_totalSales * _comissionRate)} $";
            return result;
        }
    }
}
