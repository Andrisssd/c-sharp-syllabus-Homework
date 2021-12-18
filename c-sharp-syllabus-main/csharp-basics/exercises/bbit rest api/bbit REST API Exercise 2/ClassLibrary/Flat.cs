﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Flat : IValidatable
    {
        public string UniqueId { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }

        public int RoomCount { get; set; }

        public int ResidentCount { get; set; }

        public double LivingSpace { get; set; }

        public House? HouseWhereLocated { get; set; }

        public bool IsValid()
        {
            double minimalLivingSpace = 5;
            return (Number>0 && Floor>0 && RoomCount>0 && ResidentCount>=0 && LivingSpace>minimalLivingSpace);
        }
    }
}