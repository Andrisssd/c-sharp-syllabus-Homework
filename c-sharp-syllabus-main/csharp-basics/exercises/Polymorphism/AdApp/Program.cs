using System;

namespace AdApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            var c = new Campaign();
            c.AddAdvert(new Advert(1000));
            c.AddAdvert(new Hoarding(500, 7, 200));
            c.AddAdvert(new NewspaperAd(0, 30, 20));
            c.AddAdvert(new TVAd(50000, 1000, 30, true));
            c.AddAdvert(new Poster(5, 100, 5));
            Console.WriteLine(c.ToString());
        }
    }
}