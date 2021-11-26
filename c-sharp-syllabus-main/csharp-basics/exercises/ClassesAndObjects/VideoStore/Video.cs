using System;
using System.Collections.Generic;

namespace VideoStore
{
    class Video
    {
        public bool isAvailable;
        public double rate = 0;
        
        public Video(string title)
        {
            Title = title;
            isAvailable = true;
        }

        public void BeingCheckedOut()
        {
            isAvailable = false;
        }

        public void BeingReturned()
        {
            isAvailable = true;
        }

        public void ReceivingRating(double rating)
        {
            rate += rating;
        }

        public double AverageRating()
        {
            return rate;
        }

        public bool Available()
        {
            return isAvailable;
        }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Title} {AverageRating()} {Available()}";
        }
    }
}
