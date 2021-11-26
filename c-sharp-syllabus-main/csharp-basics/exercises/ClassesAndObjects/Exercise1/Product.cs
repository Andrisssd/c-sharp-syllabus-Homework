using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Product
    {
        private string name;
        private double price;
        private int amount;

        public Product(string name, double price, int amount)
        {
            this.name = name;
            this.price = price;
            this.amount = amount;
        }

        public void SetNewPrice()
        {
            Console.Write($"Enter new price for {name}: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            price = newPrice;
        }

        public void SetNewAmount()
        {
            Console.Write($"Enter new amount for {name}: ");
            int newAmount = Convert.ToInt32(Console.ReadLine());
            amount = newAmount;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{name}, price {price}, amount {amount}");
        }
    }
}
