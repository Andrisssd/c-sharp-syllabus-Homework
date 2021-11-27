using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    class Video
    {
        public bool isAvailable;
        public List<double> rate;
        
        public Video(string title)
        {
            Title = title;
            isAvailable = true;
            rate = new List<double>();
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
            rate.Add(rating);
        }

        public double AverageRating()
        {
            double rateSum = 0;
            foreach(var num in rate)
            {
                rateSum += num;
            }
            return rateSum/rate.Count();
        }

        public bool Available()
        {
            return isAvailable;
        }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"Title:{Title} || Average rating: {AverageRating()} || IsAvailable: {Available()}";
        }
    }
}
