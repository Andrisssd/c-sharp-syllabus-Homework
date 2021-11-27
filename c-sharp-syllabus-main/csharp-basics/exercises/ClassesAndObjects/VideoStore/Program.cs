using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    class Program
    {
        public static int _countOfMovies = 3;
        private static VideoStore _videoStore = new VideoStore();
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine("Choose the operation you want to perform ");
                Console.WriteLine("Choose 0 for EXIT");
                Console.WriteLine("Choose 1 to fill video store");
                Console.WriteLine("Choose 2 to rent video (as user)");
                Console.WriteLine("Choose 3 to return video (as user)");
                Console.WriteLine("Choose 4 to list inventory");
                Console.WriteLine("Choose 5 to add video");
                Console.WriteLine("Choose 6 to rate stored videos");
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                int n = Convert.ToByte(Console.ReadLine());
                switch (n)
                {
                    case 0:
                        return;
                    case 1:
                        FillVideoStore();
                        break;
                    case 2:
                        RentVideo();
                        break;
                    case 3:
                        ReturnVideo();
                        break;
                    case 4:
                        ListInventory();
                        break;
                    case 5:
                        AddNewVideo();
                        break;
                    case 6:
                        RateAVideo();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void ListInventory()
        {
            _videoStore.ListInventory();
        }

        private static void FillVideoStore()
        {
            for (var i = 0; i < _countOfMovies; i++)
            {
                Console.WriteLine("Enter movie name");
                string movieName = Console.ReadLine();
                Console.WriteLine("Enter rating");
                int rating = Convert.ToInt16(Console.ReadLine());
                _videoStore.AddVideo(movieName);
                _videoStore.TakeUsersRating(rating);
            }
        }
        private static void AddNewVideo()
        {
            _countOfMovies++;
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter rating");
            int rating = Convert.ToInt16(Console.ReadLine());
            _videoStore.AddVideo(movieName);
            _videoStore.TakeUsersRating(rating);
        }
        private static void RateAVideo()
        {
            Console.WriteLine("Enter video title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter rate: ");
            double rate = Convert.ToDouble(Console.ReadLine());
            _videoStore.TakeSingleUsersRating(title, rate);
        }

        private static void RentVideo()
        {
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();
            _videoStore.Checkout(movieName);
        }

        private static void ReturnVideo()
        {
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();
            _videoStore.ReturnVideo(movieName);
        }
    }
}
