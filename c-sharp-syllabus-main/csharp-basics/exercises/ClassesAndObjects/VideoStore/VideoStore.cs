using System;
using System.Collections.Generic;

namespace VideoStore
{
    class VideoStore
    {
        public static int _LastIndex = 0;
        Video[] Inventory = new Video[Program._countOfMovies];

        public void AddVideo(string title)
        {
            Inventory[_LastIndex] = new Video(title); 
        }
        
        public void Checkout(string title)
        {
            for(int i =0; i < Inventory.Length; i++)
            {
                if(Inventory[i].Title == title && Inventory[i].isAvailable == true)
                {
                    Inventory[i].BeingCheckedOut();
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        public void ReturnVideo(string title)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i].Title == title && Inventory[i].isAvailable == false)
                {
                    Inventory[i].BeingReturned();
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        public void TakeUsersRating(double rating)
        {
            Inventory[_LastIndex].ReceivingRating(rating);
            _LastIndex++;
        }

        public void ListInventory()
        {
            if (Inventory[0]!=null)
            {
                foreach (var video in Inventory)
                {
                    Console.WriteLine(video.ToString());
                }
            }
            else
            {
                Console.WriteLine("None videos available");
            }
        }
    }
}
