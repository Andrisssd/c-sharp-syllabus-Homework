using System;

namespace ConvertCurrency_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = "learning C sharp";
            var price = 12.5;
            var priceInUSD = ConvertToUSD(price);
            var priceInBRL = ConvertToBRL(price);

            Console.WriteLine("Product: " + product);
            Console.WriteLine("Price in USD: " + priceInUSD);
            Console.WriteLine("Price in BRL: " + priceInBRL);
            Console.ReadKey();
        }

        static double ConvertToUSD(double price)
        {
            return Math.Round(price*1.4*1.01,2);
        }

        static double ConvertToBRL(double price)
        {
            return Math.Round(ConvertToUSD(price)*5.61,2);
        }
    }
}
