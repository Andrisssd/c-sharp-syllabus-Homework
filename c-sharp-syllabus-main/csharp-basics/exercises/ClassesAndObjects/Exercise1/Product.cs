using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Exercise1
{
    public class Product
    {
        private string _name;
        private double _price;
        private int _amount;

        public Product(string name, double price, int amount)
        {
            _name = name;
            _price = price;
            _amount = amount;
        }

        public void SetNewPrice(double price)
        {
            if (price >= 0)
            {
                _price = price;
                return;
            }

            throw new PriceIsLowerThanZeroException(price);
        }

        public void SetNewAmount(int amount)
        {
            if (amount >= 0)
            {
                _amount = amount;
                return;
            }

            throw new AmountIsLowerThanZeroException(amount);
        }

        public Dictionary<string, object> GetNamePriceAndAmount()
        {
            var parameterValue = new Dictionary<string, object>();

            parameterValue.Add("Price", _price);
            parameterValue.Add("Name", _name);
            parameterValue.Add("Amount", _amount);

            return parameterValue;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{_name}, price {_price}, amount {_amount}");
        }
    }
}
