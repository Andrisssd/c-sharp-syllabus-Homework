using System;

namespace ConvertCurrency_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = "learning C sharp";
            var price = 19.99;
            var priceInUSD = ConvertToUSD(price);

            Console.WriteLine("Product: " + product);
            Console.WriteLine("Price in USD: " + priceInUSD);
            Console.ReadKey();
        }

        static double ConvertToUSD(double price)
        {
            return Math.Round(price*1.4,2);
        }
    }
}
