using System;
using System.Collections.Generic;

namespace VideoStore
{
    class VideoStore
    {
        public static int _LastIndex = 0;
        List<Video> Inventory = new List<Video>();

        public void AddVideo(string title)
        {
            Inventory.Add(new Video(title));
        }
        
        public void Checkout(string title)
        {
            for(int i =0; i < Inventory.Count; i++)
            {
                if(Inventory[i].Title == title && Inventory[i].isAvailable == true)
                {
                    Inventory[i].BeingCheckedOut();
                }
            }
        }

        public void ReturnVideo(string title)
        {
            for (int i = 0; i < Inventory.Count; i++)
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
        public void TakeSingleUsersRating(string name, double newRate)
        {
            for(int i = 0; i < Inventory.Count; i++)
            {
                if(Inventory[i].Title == name)
                {
                    Inventory[i].ReceivingRating(newRate);
                }
            }
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
