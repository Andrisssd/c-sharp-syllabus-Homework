using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    
    class FuelGauge
    {
        private int liters;
        
        public void SetFuelLevel(int liters)
        {
            this.liters = liters;
        }
        public void IncrementFuelLevel()
        {
            if(liters < 70)
            {
                liters++;
            }
            else
            {
                Console.WriteLine("Max fuel");
            }
        }
        public void DecrementFuelLevel()
        {
            if(liters >0)
            {
                liters--;
            }
            else
            {
                Console.WriteLine("None fuel left");
            }
        }

        public void PrintGuelLevel()
        {
            Console.WriteLine($"{liters} L");
        }

    }
    class Odometer
    {
        private int mileage;

        public Odometer()
        {
            mileage = 0;
        }
        public void IncrementMileage()
        {
            mileage++;
            if(mileage == 1)
        }
    }
}
