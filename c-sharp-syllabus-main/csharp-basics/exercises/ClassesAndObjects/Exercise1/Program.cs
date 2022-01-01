using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product bananas = new Product("Bananas", 9.99, 10);
            bananas.PrintProduct();
            bananas.SetNewAmount(10);
            bananas.SetNewPrice(4.4);
            bananas.PrintProduct();
        }
    }
}
